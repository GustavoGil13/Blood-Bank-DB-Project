Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form3
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim old_CC As Int64
    Dim count As Integer
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection(Form1.connection)
        CMD = New SqlCommand
        CMD.Connection = CN
        print_pessoas_button_Click(sender, e)
    End Sub
    Sub Reset()
        CC_box.Clear()
        nome_box.Clear()
        apelido_box.Clear()
        morada_box.Clear()
        idade_box.Clear()
        telemovel_box.Clear()
        person_type_ComboBox.Text = "Entidade"
        Salary_Box.Clear()
        ComboBox_BT.Text = "Escolha o tipo de sangue"
        For i As Integer = 0 To Patologias_ListBox.Items.Count - 1
            Patologias_ListBox.SetItemChecked(i, False)
        Next
        For i As Integer = 0 To Medicamentos_ListBox.Items.Count - 1
            Medicamentos_ListBox.SetItemChecked(i, False)
        Next
    End Sub
    Sub Clear_checked()
        For i As Integer = 0 To Patologias_ListBox.Items.Count - 1
            Patologias_ListBox.SetItemChecked(i, False)
        Next
        For i As Integer = 0 To Medicamentos_ListBox.Items.Count - 1
            Medicamentos_ListBox.SetItemChecked(i, False)
        Next
    End Sub
    Private Function checkPerson(ByVal CC As String) As Boolean
        Dim check As Boolean

        Try
            CN.Open()
            CMD.CommandText = "select * from Pessoa where CC=" + CC
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                check = False
            Else
                check = True
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro checkPerson: Tabela Pessoa vazia")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return check
    End Function

    Private Function getNextId(ByVal ID_str As String, ByVal table_name As String) As String
        Dim ID As String

        Try
            CN.Open()
            CMD.CommandText = "select top 1 " + ID_str + " from " + table_name + " order by " + ID_str + " desc"
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                ID = RDR.Item(ID_str) + 1
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Tabela " + table_name + " vazia")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return ID
    End Function
    Private Function getCurrentIdByCC(ByVal CC As String, ByVal column_name As String, ByVal table_name As String, ByVal key_name As String) As String
        Dim n As String
        Try
            CN.Open()
            CMD.CommandText = "select " + column_name + " from " + table_name + " where " + key_name + "=" + CC
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                n = RDR.Item(column_name)
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Tabela " + table_name + " vazia")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return n
    End Function

    Private Sub InsertDoador(ByVal CC As String)
        Dim ID_doador, ID_ficha As String
        Dim morada

        If String.IsNullOrEmpty(morada_box.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_box.Text
        End If

        ID_doador = getNextId("ID_Doador", "Doador")
        ID_ficha = getNextId("ID_Ficha", "Ficha_Clinica")

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não foi possível connectar")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        Try
            Dim cmd As SqlCommand = New SqlCommand("InsertDoador", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CC", CC)
            cmd.Parameters.AddWithValue("@nome", nome_box.Text)
            cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
            cmd.Parameters.AddWithValue("@morada", morada)
            cmd.Parameters.AddWithValue("@idade", idade_box.Text)
            cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
            cmd.Parameters.AddWithValue("@ID_doador", ID_doador)
            cmd.Parameters.AddWithValue("@ID_ficha", ID_ficha)
            cmd.Parameters.AddWithValue("@tipo_sangue", ComboBox_BT.Text)
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Doador inserido com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Doador não inserido")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub
    Private Sub EditDoador(ByVal CC As String)
        Dim morada

        If String.IsNullOrEmpty(morada_box.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_box.Text
        End If

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não foi possível connectar")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        Try
            Dim cmd As SqlCommand = New SqlCommand("EditDoador", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CC_antigo", old_CC)
            cmd.Parameters.AddWithValue("@CC", CC)
            cmd.Parameters.AddWithValue("@nome", nome_box.Text)
            cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
            cmd.Parameters.AddWithValue("@morada", morada)
            cmd.Parameters.AddWithValue("@idade", idade_box.Text)
            cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
            cmd.Parameters.AddWithValue("@tipo_sangue", ComboBox_BT.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Doador atualizado com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Doador não atualizado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub
    Private Sub InsertPaciente(ByVal CC As String)
        Dim ID_Paciente, ID_ficha, medicamentos, patologias As String
        Dim morada
        medicamentos = ""
        patologias = ""

        If String.IsNullOrEmpty(morada_box.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_box.Text
        End If

        ID_Paciente = getNextId("ID_Paciente", "Paciente")

        ID_ficha = getNextId("ID_Ficha", "Ficha_Clinica")

        For i = 0 To Patologias_ListBox.Items.Count - 1
            Dim patologia As String = CType(Patologias_ListBox.Items(i), String)

            If Patologias_ListBox.GetItemChecked(i) Then
                patologias += patologia + ","
            End If
        Next
        If patologias <> "" Then
            patologias = patologias.Substring(0, patologias.Length - 1)
        End If

        For i = 0 To Medicamentos_ListBox.Items.Count - 1
            Dim medicamento As String = CType(Medicamentos_ListBox.Items(i), String)

            If Medicamentos_ListBox.GetItemChecked(i) Then
                medicamentos += medicamento + ","
            End If
        Next
        If medicamentos <> "" Then
            medicamentos = medicamentos.Substring(0, medicamentos.Length - 1)
        End If


        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não foi possível connectar")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        Try
            Dim cmd As SqlCommand = New SqlCommand("InsertPaciente", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CC", CC)
            cmd.Parameters.AddWithValue("@nome", nome_box.Text)
            cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
            cmd.Parameters.AddWithValue("@morada", morada)
            cmd.Parameters.AddWithValue("@idade", idade_box.Text)
            cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
            cmd.Parameters.AddWithValue("@ID_paciente", ID_Paciente)
            cmd.Parameters.AddWithValue("@ID_ficha", ID_ficha)
            cmd.Parameters.AddWithValue("@tipo_sangue", ComboBox_BT.Text)
            cmd.Parameters.AddWithValue("@doencas", patologias)
            cmd.Parameters.AddWithValue("@medicamentos", medicamentos)
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Paciente inserido com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Paciente não inserido")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    Private Sub EditPaciente(ByVal CC As String)
        Dim morada
        Dim medicamentos, patologias, ID As String
        medicamentos = ""
        patologias = ""

        If String.IsNullOrEmpty(morada_box.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_box.Text
        End If

        For i = 0 To Patologias_ListBox.Items.Count - 1
            Dim patologia As String = CType(Patologias_ListBox.Items(i), String)

            If Patologias_ListBox.GetItemChecked(i) Then
                patologias += patologia + ","
            End If
        Next
        If patologias <> "" Then
            patologias = patologias.Substring(0, patologias.Length - 1)
        End If

        For i = 0 To Medicamentos_ListBox.Items.Count - 1
            Dim medicamento As String = CType(Medicamentos_ListBox.Items(i), String)

            If Medicamentos_ListBox.GetItemChecked(i) Then
                medicamentos += medicamento + ","
            End If
        Next
        If medicamentos <> "" Then
            medicamentos = medicamentos.Substring(0, medicamentos.Length - 1)
        End If

        ID = getCurrentIdByCC(CC, "ID_Ficha", "Ficha_Clinica", "CC_Pessoa")

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não foi possível connectar")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        Try
            Dim cmd As SqlCommand = New SqlCommand("EditPaciente", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CC_antigo", old_CC)
            cmd.Parameters.AddWithValue("@CC", CC)
            cmd.Parameters.AddWithValue("@nome", nome_box.Text)
            cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
            cmd.Parameters.AddWithValue("@morada", morada)
            cmd.Parameters.AddWithValue("@idade", idade_box.Text)
            cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
            cmd.Parameters.AddWithValue("@ID_ficha", ID)
            cmd.Parameters.AddWithValue("@tipo_sangue", ComboBox_BT.Text)
            cmd.Parameters.AddWithValue("@doencas", patologias)
            cmd.Parameters.AddWithValue("@medicamentos", medicamentos)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Paciente atualizado com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Paciente não atualizado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub
    Private Sub InsertFuncionario(ByVal CC As String, Optional ByVal gestor As Integer = 0)
        Dim ID_Funcionario As String
        Dim morada

        If String.IsNullOrEmpty(morada_box.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_box.Text
        End If

        Dim salario As Integer
        If String.IsNullOrEmpty(Salary_Box.Text) Then
            salario = 0
        Else
            salario = CInt(Salary_Box.Text)
        End If

        ID_Funcionario = getNextId("ID_Funcionario", "Funcionario")

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não foi possível connectar")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        If gestor = 0 Then
            Try
                Dim cmd As SqlCommand = New SqlCommand("InsertFuncionario", CN)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CC", CC)
                cmd.Parameters.AddWithValue("@nome", nome_box.Text)
                cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
                cmd.Parameters.AddWithValue("@morada", morada)
                cmd.Parameters.AddWithValue("@idade", idade_box.Text)
                cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
                cmd.Parameters.AddWithValue("@ID_Func", ID_Funcionario)
                cmd.Parameters.AddWithValue("@salario", salario)
                cmd.Parameters.AddWithValue("@banco", Form1.BS)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Funcionário inserido com sucesso")
            Catch ex As SqlException
                MessageBox.Show("Erro: Funcionário não inserido")
            End Try
        Else
            Try
                Dim cmd As SqlCommand = New SqlCommand("InsertGestor", CN)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CC", CC)
                cmd.Parameters.AddWithValue("@nome", nome_box.Text)
                cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
                cmd.Parameters.AddWithValue("@morada", morada)
                cmd.Parameters.AddWithValue("@idade", idade_box.Text)
                cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
                cmd.Parameters.AddWithValue("@ID_Func", ID_Funcionario)
                cmd.Parameters.AddWithValue("@salario", salario)
                cmd.Parameters.AddWithValue("@banco", Form1.BS)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Gestor inserido e atualizado com sucesso")
            Catch ex As SqlException
                MessageBox.Show("Erro: Gestor não inserido")
            End Try
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    Private Sub EditFuncionario(ByVal CC As String, Optional ByVal gestor As Integer = 0)
        Dim morada

        If String.IsNullOrEmpty(morada_box.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_box.Text
        End If

        Dim salario As Integer
        If String.IsNullOrEmpty(Salary_Box.Text) Then
            salario = 0
        Else
            salario = CInt(Salary_Box.Text)
        End If

        Dim id = getCurrentIdByCC(CC, "ID_Funcionario", "Funcionario", "CC_Funcionario")

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não foi possível connectar")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        If gestor = 0 Then
            Try
                Dim cmd As SqlCommand = New SqlCommand("EditFuncionario", CN)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CC_antigo", old_CC)
                cmd.Parameters.AddWithValue("@CC", CC)
                cmd.Parameters.AddWithValue("@nome", nome_box.Text)
                cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
                cmd.Parameters.AddWithValue("@morada", morada)
                cmd.Parameters.AddWithValue("@idade", idade_box.Text)
                cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
                cmd.Parameters.AddWithValue("@salario", salario)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Funcionário atualizado com sucesso")
            Catch ex As SqlException
                MessageBox.Show("Erro: Funcionário não atualizado")
            End Try
        Else
            Try
                Dim cmd As SqlCommand = New SqlCommand("EditGestor", CN)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CC_antigo", old_CC)
                cmd.Parameters.AddWithValue("@CC", CC)
                cmd.Parameters.AddWithValue("@nome", nome_box.Text)
                cmd.Parameters.AddWithValue("@apelido", apelido_box.Text)
                cmd.Parameters.AddWithValue("@morada", morada)
                cmd.Parameters.AddWithValue("@idade", idade_box.Text)
                cmd.Parameters.AddWithValue("@telemovel", telemovel_box.Text)
                cmd.Parameters.AddWithValue("@ID_Func", id)
                cmd.Parameters.AddWithValue("@salario", salario)
                cmd.Parameters.AddWithValue("@banco", Form1.BS)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Gestor atualizado com sucesso")
            Catch ex As SqlException
                MessageBox.Show("Erro: Gestor não atualizado")
            End Try
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub CC_box_TextChanged(sender As Object, e As EventArgs) Handles CC_box.TextChanged

    End Sub
    Private Sub CC_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CC_box.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub nome_box_TextChanged(sender As Object, e As EventArgs) Handles nome_box.TextChanged

    End Sub
    Private Sub nome_box_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nome_box.KeyPress

        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub apelido_box_TextChanged(sender As Object, e As EventArgs) Handles apelido_box.TextChanged

    End Sub
    Private Sub apelido_box_KeyPress(sender As Object, e As KeyPressEventArgs) Handles apelido_box.KeyPress

        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub morada_box_TextChanged(sender As Object, e As EventArgs) Handles morada_box.TextChanged

    End Sub
    Private Sub morada_TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles morada_box.KeyPress
        Select Case Asc(e.KeyChar)
            Case 8, 32, 65 To 90, 97 To 122
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub idade_box_TextChanged(sender As Object, e As EventArgs) Handles idade_box.TextChanged

    End Sub
    Private Sub idade_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles idade_box.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub telemovel_box_TextChanged(sender As Object, e As EventArgs) Handles telemovel_box.TextChanged

    End Sub
    Private Sub telemovel_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles telemovel_box.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Inserir_button_Click(sender As Object, e As EventArgs) Handles Inserir_button.Click
        If String.IsNullOrEmpty(CC_box.Text) Or String.IsNullOrEmpty(nome_box.Text) Or String.IsNullOrEmpty(apelido_box.Text) Or String.IsNullOrEmpty(idade_box.Text) Or String.IsNullOrEmpty(telemovel_box.Text) Then
            MessageBox.Show("É necessário passar o CC, nome, apelido, idade e número de telemovel")
            Return
        End If

        Select Case person_type_ComboBox.Text
            Case "Entidade"
                MessageBox.Show("É necessário identificar a entidade")
                Return
            Case "Doador"
                If ComboBox_BT.Text = "Escolha o tipo de sangue" Then
                    MessageBox.Show("É necessário passar o tipo de sangue")
                    Return
                ElseIf Patologias_ListBox.CheckedItems.Count = 0 And Medicamentos_ListBox.CheckedItems.Count = 0 Then
                    If checkPerson(CC_box.Text) Then
                        InsertDoador(CC_box.Text)
                    Else
                        MessageBox.Show("Pessoa com CC=" + CC_box.Text + " já existe")
                    End If
                Else
                    MessageBox.Show("não puderá doar sangue pois possui uma doença ou toma um medicamento que o impossibilita")
                    Clear_checked()
                    Return
                End If
            Case "Paciente"
                If ComboBox_BT.Text = "Escolha o tipo de sangue" Then
                    MessageBox.Show("É necessário passar o tipo de sangue")
                    Return
                Else
                    If checkPerson(CC_box.Text) Then
                        InsertPaciente(CC_box.Text)
                    Else
                        MessageBox.Show("Pessoa com CC=" + CC_box.Text + " já existe")
                    End If
                End If
            Case "Funcionário"
                If checkPerson(CC_box.Text) Then
                    InsertFuncionario(CC_box.Text)
                Else
                    MessageBox.Show("Pessoa com CC=" + CC_box.Text + " já existe")
                End If
            Case "Gestor"
                If checkPerson(CC_box.Text) Then
                    InsertFuncionario(CC_box.Text, 1)
                Else
                    MessageBox.Show("Pessoa com CC=" + CC_box.Text + " já existe")
                End If
        End Select
        print_pessoas_button_Click(sender, e)

        Reset()
    End Sub

    Private Sub Remove_button_Click(sender As Object, e As EventArgs) Handles Remove_button.Click

        If String.IsNullOrEmpty(CC_box.Text) Then
            MessageBox.Show("É necessário passar o Cartão de Cidadão")
        Else
            Try
                If Not checkPerson(CC_box.Text) Then
                    CN.Open()
                    Dim cmd As SqlCommand = New SqlCommand("del_pessoa", CN)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CC_pessoa", CC_box.Text)
                    Dim rows = cmd.ExecuteNonQuery()
                    MessageBox.Show("Pessoa com CC=" + CC_box.Text + " eliminada com sucesso")
                Else
                    MessageBox.Show("Pessoa com CC=" + CC_box.Text + " não existe")
                End If
            Catch ex As SqlException
                MessageBox.Show("Erro: Não removido")
            End Try
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        print_pessoas_button_Click(sender, e)
        Reset()
    End Sub

    Private Sub Edit_button_Click(sender As Object, e As EventArgs) Handles Edit_button.Click
        If count = 0 Then
            MessageBox.Show("É necessário clicar no botão preencher campos antes de editar")
            Return
        End If

        Select Case person_type_ComboBox.Text
            Case "Funcionário"
                EditFuncionario(CC_box.Text)
            Case "Doador"
                EditDoador(CC_box.Text)
            Case "Paciente"
                EditPaciente(CC_box.Text)
            Case "Gestor"
                EditFuncionario(CC_box.Text, 1)
        End Select

        Reset()

        count = 0
    End Sub

    Private Sub print_box_persons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles print_box_persons.SelectedIndexChanged

    End Sub

    Private Sub Search_button_Click(sender As Object, e As EventArgs) Handles Fiil_button.Click
        count = 1
        Clear_checked()

        Dim query_base = "select * 
                            from (select CC, nome, apelido, morada, idade, telemovel
	                            from Paciente join Pessoa on CC=CC_Paciente
	                            where nome_bs_p='" + Form1.BS + "'
                                union
                                select CC, nome, apelido, morada, idade, telemovel
                                from Doador join Pessoa on CC=CC_Doador
	                            where nome_bs_d='" + Form1.BS + "'
	                            union
	                            select CC, nome, apelido, morada, idade, telemovel
	                            from Funcionario join Pessoa on CC=CC_Funcionario
	                            where Funcionario_BS_nome='" + Form1.BS + "') as temp"

        Dim query1 = query_base + " where temp.CC=" + CC_box.Text
        Dim query_Func = query_base + " join Funcionario on CC_Funcionario=temp.CC where temp.CC=" + CC_box.Text
        Dim query_gestor = query_base + " join Funcionario on CC_Funcionario=temp.CC join Banco_Sangue on ID_Funcionario=ID_gestor where temp.CC=" + CC_box.Text
        Dim query_Doador_BT = query_base + " join Doador on CC_Doador=temp.CC join Tipo_Sangue_Pessoa on temp.CC= CC_Pessoa_TP where temp.CC=" + CC_box.Text
        Dim query_Paciente_BT = query_base + " join Paciente on CC_Paciente=temp.CC join Tipo_Sangue_Pessoa on temp.CC= CC_Pessoa_TP where temp.CC=" + CC_box.Text
        Dim query_Paciente_patologias = query_base + " join Paciente on CC_Paciente=temp.CC join Tipo_Sangue_Pessoa on temp.CC= CC_Pessoa_TP join Descreve_Patologias on CC_Pessoa_DP=temp.CC where temp.CC=" + CC_box.Text
        Dim query_Paciente_medicamentos = query_base + " join Paciente on CC_Paciente=temp.CC join Tipo_Sangue_Pessoa on temp.CC= CC_Pessoa_TP join Especifica_Medicamentos on CC_Pessoa_EM=temp.CC where temp.CC=" + CC_box.Text

        If String.IsNullOrEmpty(CC_box.Text) Then
            MessageBox.Show("É necessário inserir o Cartão de Cidadão")
        Else
            old_CC = CC_box.Text
            CMD.CommandText = query1
            Try
                CN.Open()
            Catch ex As SqlException
                MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
                If CN.State = ConnectionState.Open Then
                    CN.Close()
                End If
                Return
            End Try

            Try
                Dim RDR As SqlDataReader
                RDR = CMD.ExecuteReader
                If RDR.HasRows() Then
                    RDR.Read()
                    nome_box.Text = RDR.Item("nome")
                    apelido_box.Text = RDR.Item("apelido")
                    morada_box.Text = IIf(RDR.IsDBNull(RDR.GetOrdinal("morada")), " ------ ", RDR.Item("morada"))
                    idade_box.Text = RDR.Item("idade")
                    telemovel_box.Text = RDR.Item("telemovel")
                    RDR.Close()

                    CMD.CommandText = query_Func
                    RDR = CMD.ExecuteReader
                    If RDR.HasRows() Then
                        RDR.Read()
                        Salary_Box.Text = RDR.Item("salario").ToString
                        RDR.Close()
                        CMD.CommandText = query_gestor
                        RDR = CMD.ExecuteReader
                        If RDR.HasRows() Then
                            person_type_ComboBox.Text = "Gestor"
                        Else
                            person_type_ComboBox.Text = "Funcionário"
                        End If
                    End If
                    RDR.Close()

                    CMD.CommandText = query_Doador_BT
                    RDR = CMD.ExecuteReader
                    If RDR.HasRows() Then
                        RDR.Read()
                        person_type_ComboBox.Text = "Doador"
                        ComboBox_BT.Text = RDR.Item("Tipo_Sangue_Pessoa").ToString
                    End If
                    RDR.Close()

                    CMD.CommandText = query_Paciente_BT
                    RDR = CMD.ExecuteReader
                    If RDR.HasRows() Then
                        RDR.Read()
                        person_type_ComboBox.Text = "Paciente"
                        ComboBox_BT.Text = RDR.Item("Tipo_Sangue_Pessoa").ToString
                    End If
                    RDR.Close()

                    CMD.CommandText = query_Paciente_patologias
                    RDR = CMD.ExecuteReader
                    If RDR.HasRows() Then
                        While RDR.Read
                            Dim patologia = RDR.Item("nome_DP").ToString
                            For i = 0 To Patologias_ListBox.Items.Count - 1
                                If Patologias_ListBox.Items(i).ToString = patologia Then
                                    Patologias_ListBox.SetItemChecked(i, True)
                                End If
                            Next
                        End While
                    End If
                    RDR.Close()

                    CMD.CommandText = query_Paciente_medicamentos
                    RDR = CMD.ExecuteReader
                    If RDR.HasRows() Then
                        While RDR.Read
                            Dim medicamento = RDR.Item("nome_EM").ToString
                            For i = 0 To Medicamentos_ListBox.Items.Count - 1
                                If medicamento = Medicamentos_ListBox.Items(i).ToString Then
                                    Medicamentos_ListBox.SetItemChecked(i, True)
                                End If
                            Next
                        End While
                    End If
                    RDR.Close()
                Else
                    MessageBox.Show("Pessoa não encontrada")
                End If
            Catch ex As Exception
                MessageBox.Show("Erro")
            End Try
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If



    End Sub

    Private Sub print_pessoas_button_Click(sender As Object, e As EventArgs) Handles print_pessoas_button.Click
        Dim query_paciente, query_doador, query_funcionario As String

        query_paciente = "select CC, nome, apelido, idade From Paciente Join Pessoa On CC=CC_Paciente Where nome_bs_p='" + Form1.BS + "' Order By CC"
        query_doador = "select CC, nome, apelido, idade From Doador Join Pessoa On CC=CC_Doador Where nome_bs_d='" + Form1.BS + "' Order By CC"
        query_funcionario = "select CC, nome, apelido, idade From Funcionario Join Pessoa On CC=CC_Funcionario Where Funcionario_BS_nome='" + Form1.BS + "' Order By CC"

        Dim querys As New List(Of String) From {query_paciente, query_doador, query_funcionario}
        Dim table_names As New List(Of String) From {"Pacientes", "Doadores", "Funcionários"}

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        print_box_persons.Items.Clear()
        For j = 0 To querys.Count - 1
            CMD.CommandText = querys(j)
            print_box_persons.Items.Add(table_names(j))
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                Dim n_column = RDR.FieldCount - 1
                Dim head = ""
                For i = 0 To n_column
                    head += RDR.GetName(i) + "     "
                Next
                print_box_persons.Items.Add(head)
                While RDR.Read
                    Dim line = ""
                    For i = 0 To n_column
                        line += IIf(RDR.IsDBNull(i), " ------ ", RDR.Item(i).ToString() + "  ")
                    Next
                    print_box_persons.Items.Add(line)
                End While
            End If
            RDR.Close()
        Next

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Patologias_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Patologias_ListBox.SelectedIndexChanged

    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Medicamentos_ListBox.SelectedIndexChanged

    End Sub

    Private Sub person_type_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles person_type_ComboBox.SelectedIndexChanged

    End Sub
    Private Sub person_type_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles person_type_ComboBox.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox_BT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_BT.SelectedIndexChanged

    End Sub
    Private Sub ComboBox_BT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox_BT.KeyPress
        e.Handled = True
    End Sub

    Private Sub Salary_Box_TextChanged(sender As Object, e As EventArgs) Handles Salary_Box.TextChanged

    End Sub
    Private Sub Salary_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Salary_Box.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class