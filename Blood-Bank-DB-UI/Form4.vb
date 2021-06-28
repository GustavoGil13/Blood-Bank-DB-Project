Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form4
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection(Form1.connection)
        CMD = New SqlCommand
        CMD.Connection = CN
        recipientes_todos_Button_Click(sender, e)
        list_doadores_Button_Click(sender, e)
    End Sub
    Sub ClearAll()
        id_doador_TextBox.Clear()
        codigo_TextBox.Clear()
        id_paciente_TextBox.Clear()
        doacao_DateTimePicker.Value = DateTime.Now
        armazenamento_DateTimePicker.Value = DateTime.Now
        recebe_DateTimePicker.Value = DateTime.Now
    End Sub

    Private Function getDate(ByVal column_name As String)
        Dim d

        Try
            CN.Open()
            CMD.CommandText = "select " + column_name + " from Recipiente_Sangue where codigo_associado=" + codigo_TextBox.Text
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                If RDR.IsDBNull(RDR.GetOrdinal(column_name)) Then
                    d = DBNull.Value
                Else
                    d = CType(RDR.Item(column_name), DateTime).ToShortDateString
                End If
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Recipiente de Sangue está vazia")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return d
    End Function

    Private Function getBT(ByVal column_name As String) As String
        Dim BT As String

        Try
            CN.Open()
            If column_name = "Doador" Then
                CMD.CommandText = "select Tipo_Sangue_Pessoa from Doador join Tipo_Sangue_Pessoa on CC_Doador=CC_Pessoa_TP where nome_bs_d='" + Form1.BS + "' and ID_Doador=" + id_doador_TextBox.Text
            ElseIf column_name = "Paciente" Then
                CMD.CommandText = "select Tipo_Sangue_Pessoa from Paciente join Tipo_Sangue_Pessoa on CC_Paciente=CC_Pessoa_TP where nome_bs_p='" + Form1.BS + "' and ID_Paciente=" + id_paciente_TextBox.Text
            Else
                CMD.CommandText = "select tipo_sangue_RS from Recipiente_Sangue join Tipo_Sangue_Recipiente on codigo_associado=codigo_associado_RS where RS_BS_nome='" + Form1.BS + "' and codigo_associado=" + codigo_TextBox.Text
            End If
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                If column_name = "Doador" Or column_name = "Paciente" Then
                    BT = RDR.Item("Tipo_Sangue_Pessoa")
                Else
                    BT = RDR.Item("tipo_sangue_RS")
                End If
            Else
                If CN.State = ConnectionState.Open Then
                    CN.Close()
                End If
                If column_name = "Doador" Or column_name = "Paciente" Then
                    MessageBox.Show("Erro: ID de " + column_name + " não é valido")
                Else
                    MessageBox.Show("Erro: Código de Recipiente não é valido")
                End If
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Tabela Tipo de Sangue Pessoa está vazia")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return BT
    End Function
    Private Function getCodigo() As String
        Dim codigo As String

        Try
            CN.Open()
            CMD.CommandText = "select top 1 codigo_associado from Recipiente_Sangue order by codigo_associado desc"
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                codigo = RDR.Item("codigo_associado") + 1
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Tabela Recipiente de Sangue vazia")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return codigo
    End Function
    Private Sub Recipientes_box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Recipientes_box.SelectedIndexChanged

    End Sub
    Private Sub showAllRecipientes()
        recipientes_Label.Text = "Recipientes de Sangue"
        Dim codigo, ID_Doador, ID_Paciente, doacao, armazenamento, recebe, tipo_sangue, line As String
        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try
        CMD.CommandText = "select codigo_associado, ID_Doador_RS, data_doa_sangue, data_armazenamento_RS, ID_Paciente_RS, data_utilizacao, tipo_sangue_RS
                            from Recipiente_Sangue join Tipo_Sangue_Recipiente on codigo_associado=codigo_associado_RS
                            where RS_BS_nome='" + Form1.BS + "'"

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        If RDR.HasRows() Then
            Recipientes_box.Items.Clear()
            Dim n_column = RDR.FieldCount - 1
            Recipientes_box.Items.Add("Código    ID_Doador         Doação         Armazenamento    ID_Paciente    Utilizacao          TS Recipiente")
            While RDR.Read
                codigo = IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_associado")), " ------ ", RDR.Item("codigo_associado"))
                ID_Doador = IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Doador_RS")), " ------ ", RDR.Item("ID_Doador_RS"))
                If RDR.IsDBNull(RDR.GetOrdinal("data_doa_sangue")) Then
                    doacao = " ------ "
                Else
                    doacao = CType(RDR.Item("data_doa_sangue"), DateTime).ToShortDateString
                End If
                If RDR.IsDBNull(RDR.GetOrdinal("data_armazenamento_RS")) Then
                    armazenamento = " ------ "
                Else
                    armazenamento = CType(RDR.Item("data_armazenamento_RS"), DateTime).ToShortDateString
                End If
                ID_Paciente = IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Paciente_RS")), " ------ ", RDR.Item("ID_Paciente_RS"))
                If RDR.IsDBNull(RDR.GetOrdinal("data_utilizacao")) Then
                    recebe = " ------ "
                Else
                    recebe = CType(RDR.Item("data_utilizacao"), DateTime).ToShortDateString
                End If
                tipo_sangue = IIf(RDR.IsDBNull(RDR.GetOrdinal("tipo_sangue_RS")), " ------ ", RDR.Item("tipo_sangue_RS"))
                If CInt(codigo) >= 10 Then
                    line = codigo + "                " + ID_Doador + "                    " + doacao + "         " + armazenamento + "              " + ID_Paciente + "                  " + recebe + "                  " + tipo_sangue
                Else
                    line = " " + codigo + "                " + ID_Doador + "                    " + doacao + "         " + armazenamento + "              " + ID_Paciente + "                  " + recebe + "                  " + tipo_sangue
                End If
                Recipientes_box.Items.Add(line)
            End While
        Else
            Recipientes_box.Items.Add("Este banco não possui Recipientes de Sangue")
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    Private Sub showDisponiveisRecipientes()
        recipientes_Label.Text = "Recipientes disponiveis para doação"
        Dim codigo, ID_Doador, ID_Paciente, doacao, armazenamento, line, tipo_sangue As String
        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try
        CMD.CommandText = "select codigo_associado,ID_Doador_RS,tipo_sangue_RS,data_doa_sangue, data_armazenamento_RS
                            from Recipiente_Sangue join Tipo_Sangue_Recipiente on codigo_associado=codigo_associado_RS
                            where RS_BS_nome='" + Form1.BS + "' and ID_Paciente_RS is null and data_armazenamento_RS is not null and data_utilizacao is null"

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        If RDR.HasRows() Then
            Recipientes_box.Items.Clear()
            Dim n_column = RDR.FieldCount - 1
            Recipientes_box.Items.Add("Código    ID_Doador      Tipo de Sangue         Doação         Armazenamento")
            While RDR.Read
                codigo = IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_associado")), " ------ ", RDR.Item("codigo_associado"))
                ID_Doador = IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Doador_RS")), " ------ ", RDR.Item("ID_Doador_RS"))
                tipo_sangue = IIf(RDR.IsDBNull(RDR.GetOrdinal("tipo_sangue_RS")), " --- ", RDR.Item("tipo_sangue_RS"))
                If RDR.IsDBNull(RDR.GetOrdinal("data_doa_sangue")) Then
                    doacao = " ------ "
                Else
                    doacao = CType(RDR.Item("data_doa_sangue"), DateTime).ToShortDateString
                End If
                If RDR.IsDBNull(RDR.GetOrdinal("data_armazenamento_RS")) Then
                    armazenamento = " ------ "
                Else
                    armazenamento = CType(RDR.Item("data_armazenamento_RS"), DateTime).ToShortDateString
                End If
                If CInt(codigo) >= 10 Then
                    line = codigo + "                " + ID_Doador + "                      " + tipo_sangue + "                       " + doacao + "         " + armazenamento + "              " + ID_Paciente
                Else
                    line = " " + codigo + "                " + ID_Doador + "                      " + tipo_sangue + "                       " + doacao + "         " + armazenamento + "              " + ID_Paciente
                End If
                Recipientes_box.Items.Add(line)
            End While
        Else
            Recipientes_box.Items.Add("Este banco não possui Recipientes de Sangue disponiveis")
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub
    Private Sub showDisponiveisPacientes()
        doadores_Label.Text = "Pacientes que são compativeis com os Recipientes disponiveis para doação"
        Dim ID_Paciente, codigo, CC_Paciente, nome, apelido, idade, tipo_sangue_pessoa, tipo_sangue_rs As String
        Dim head As String = "{0, 10} {1, 10} {2, 15} {3, 10} {4, 15} {5, 15} {6, 20} {7, 20}"
        Dim line As String = "{0, 10} {1, 20} {2, 20} {3, 15} {4, 15} {5, 15} {6, 25} {7, 25}"
        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try
        CMD.CommandText = "select codigo_associado, ID_Paciente, CC_Paciente, nome, apelido, idade, Tipo_Sangue_Pessoa, tipo_sangue_RS
                            from Paciente join Tipo_Sangue_Pessoa on CC_Paciente=CC_Pessoa_TP join Tipo_Sangue_Recipiente on tipo_sangue_RS=Tipo_Sangue_Pessoa join Recipiente_Sangue on codigo_associado=codigo_associado_RS join Pessoa on CC_Paciente=CC
                            where nome_bs_p='" + Form1.BS + "' and RS_BS_nome='" + Form1.BS + "' and ID_Paciente_RS is null and data_utilizacao is null order by ID_Paciente"

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        If RDR.HasRows() Then
            listar_pacientes_ListBox.Items.Clear()
            Dim n_column = RDR.FieldCount - 1
            listar_pacientes_ListBox.Items.Add(String.Format(head, "Código", "ID_Paciente", "CC_Paciente", "nome", "apelido", "idade", "TS Paciente", "TS Recipiente"))
            While RDR.Read
                ID_Paciente = IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Paciente")), " ------ ", RDR.Item("ID_Paciente"))
                codigo = IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_associado")), " ------ ", RDR.Item("codigo_associado"))
                CC_Paciente = IIf(RDR.IsDBNull(RDR.GetOrdinal("CC_Paciente")), " ------ ", RDR.Item("CC_Paciente"))
                nome = IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), " ------ ", RDR.Item("nome"))
                apelido = IIf(RDR.IsDBNull(RDR.GetOrdinal("apelido")), " ------ ", RDR.Item("apelido"))
                idade = IIf(RDR.IsDBNull(RDR.GetOrdinal("idade")), " ------ ", RDR.Item("idade"))
                tipo_sangue_pessoa = IIf(RDR.IsDBNull(RDR.GetOrdinal("Tipo_Sangue_Pessoa")), " --- ", RDR.Item("Tipo_Sangue_Pessoa"))
                tipo_sangue_rs = IIf(RDR.IsDBNull(RDR.GetOrdinal("tipo_sangue_RS")), " --- ", RDR.Item("tipo_sangue_RS"))
                listar_pacientes_ListBox.Items.Add(String.Format(line, codigo, ID_Paciente, CC_Paciente, nome, apelido, idade, tipo_sangue_pessoa, tipo_sangue_rs))
            End While
        Else
            listar_pacientes_ListBox.Items.Add("Este banco não possui Pessoas compativeis com o tipo de sangue dos recipientes")
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    Private Sub showDoadores()
        doadores_Label.Text = "Doadores"
        Dim ID_Doador, CC_Doador, nome, apelido, idade, Tipo_Sangue_Pessoa As String
        Dim head As String = "{0, 10} {1, 10} {2, 17} {3, 20} {4, 20} {5, 20}"
        Dim line As String = "{0, 10} {1, 20} {2, 20} {3, 20} {4, 22} {5, 22}"
        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try
        CMD.CommandText = "select ID_Doador, CC_Doador, nome, apelido, idade, Tipo_Sangue_Pessoa
                            from Doador join Pessoa on CC=CC_Doador join Tipo_Sangue_Pessoa on CC_Pessoa_TP=CC_Doador
                            where nome_bs_d='" + Form1.BS + "'"

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        If RDR.HasRows() Then
            listar_pacientes_ListBox.Items.Clear()
            Dim n_column = RDR.FieldCount - 1
            listar_pacientes_ListBox.Items.Add(String.Format(head, "ID_Doador", "CC_Doador", "nome", "apelido", "idade", "TS Doador"))
            While RDR.Read
                ID_Doador = IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Doador")), " ------ ", RDR.Item("ID_Doador"))
                CC_Doador = IIf(RDR.IsDBNull(RDR.GetOrdinal("CC_Doador")), " ------ ", RDR.Item("CC_Doador"))
                nome = IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), " ------ ", RDR.Item("nome"))
                apelido = IIf(RDR.IsDBNull(RDR.GetOrdinal("apelido")), " ------ ", RDR.Item("apelido"))
                idade = IIf(RDR.IsDBNull(RDR.GetOrdinal("idade")), " ------ ", RDR.Item("idade"))
                Tipo_Sangue_Pessoa = IIf(RDR.IsDBNull(RDR.GetOrdinal("Tipo_Sangue_Pessoa")), " --- ", RDR.Item("Tipo_Sangue_Pessoa"))
                listar_pacientes_ListBox.Items.Add(String.Format(line, ID_Doador, CC_Doador, nome, apelido, idade, Tipo_Sangue_Pessoa))
            End While
        Else
            listar_pacientes_ListBox.Items.Add("Este banco não possui Doadores")
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    Private Sub recipientes_todos_Button_Click(sender As Object, e As EventArgs) Handles recipientes_todos_Button.Click
        showAllRecipientes()
    End Sub

    Private Sub reci_disponiveis_button_Click(sender As Object, e As EventArgs) Handles reci_disponiveis_button.Click
        showDisponiveisRecipientes()
    End Sub

    Private Sub list_pacientes_Button_Click(sender As Object, e As EventArgs) Handles list_pacientes_Button.Click
        showDisponiveisPacientes()
    End Sub

    Private Sub listar_pacientes_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listar_pacientes_ListBox.SelectedIndexChanged

    End Sub

    Private Sub list_doadores_Button_Click(sender As Object, e As EventArgs) Handles list_doadores_Button.Click
        showDoadores()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub codigo_TextBox_TextChanged(sender As Object, e As EventArgs) Handles codigo_TextBox.TextChanged

    End Sub
    Private Sub codigo_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codigo_TextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub armazenamento_DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles armazenamento_DateTimePicker.ValueChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles id_paciente_TextBox.TextChanged

    End Sub
    Private Sub id_paciente_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles id_paciente_TextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles recebe_DateTimePicker.ValueChanged

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles id_doador_TextBox.TextChanged

    End Sub
    Private Sub id_doador_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles id_doador_TextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub doacao_DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles doacao_DateTimePicker.ValueChanged

    End Sub

    Private Sub doacao_Button_Click(sender As Object, e As EventArgs) Handles doacao_Button.Click
        Dim b As Boolean = False
        If String.IsNullOrEmpty(id_doador_TextBox.Text) Then
            MessageBox.Show("É necessário passar o ID de um doador")
            Return
        End If

        Dim BT = getBT("Doador")
        Dim codigo = getCodigo()
        Dim data_doacao = doacao_DateTimePicker.Value.Date.ToString("yyyy-MM-dd")

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
            Dim cmd As SqlCommand = New SqlCommand("MakeDonation", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", codigo)
            cmd.Parameters.AddWithValue("@id_doador", id_doador_TextBox.Text)
            cmd.Parameters.AddWithValue("@data_doacao", data_doacao)
            cmd.Parameters.AddWithValue("@tipo_sangue", BT)
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Doação registada com sucesso")
            codigo_TextBox.Text = codigo
            b = True
        Catch ex As SqlException
            MessageBox.Show("Erro: Doação não registada")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        If b Then
            recipientes_todos_Button_Click(sender, e)
        End If

    End Sub

    Private Sub armazenar_Button_Click(sender As Object, e As EventArgs) Handles armazenar_Button.Click
        If String.IsNullOrEmpty(codigo_TextBox.Text) Then
            MessageBox.Show("É necessário passar o código do recipiente de sangue que pretende armazenar")
            Return
        End If

        Dim data_armazenar = armazenamento_DateTimePicker.Value.Date.ToString("yyyy-MM-dd")
        Dim data_doacao = getDate("data_doa_sangue")
        Dim result = DateTime.Compare(data_doacao, data_armazenar)

        Dim armazenar = getDate("data_armazenamento_RS")

        If Not (armazenar Is DBNull.Value) Then
            MessageBox.Show("Recipiente já armazenado")
            Return
        End If

        If result > 0 Or result = 0 Then
            MessageBox.Show("A data de doação necessita de ser primeiro que a de armazenamento")
            Return
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
            Dim cmd As SqlCommand = New SqlCommand("ArmazenarRecipiente", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", codigo_TextBox.Text)
            cmd.Parameters.AddWithValue("@data_armazenar", data_armazenar)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Armazenamento de Recipiente de sangue executado com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Armazenamento não registada")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        recipientes_todos_Button_Click(sender, e)
        list_pacientes_Button_Click(sender, e)
    End Sub

    Private Sub recipiente_to_paciente_Button_Click(sender As Object, e As EventArgs) Handles recipiente_to_paciente_Button.Click
        If String.IsNullOrEmpty(codigo_TextBox.Text) Or String.IsNullOrEmpty(id_paciente_TextBox.Text) Then
            MessageBox.Show("É necessário passar o código do recipiente de sangue que pretende usar e o ID do paciente que o vai receber")
            Return
        End If

        Dim recebe = getDate("data_utilizacao")
        If Not (recebe Is DBNull.Value) Then
            MessageBox.Show("Recipiente já utilizado")
            Return
        End If

        Dim BT_p = getBT("Paciente")
        Dim BT_r = getBT("Recipiente")

        If BT_p <> BT_r Then
            MessageBox.Show("O tipo de sangue do Paciente tem de ser compativel com o do Recipiente")
            id_paciente_TextBox.Clear()
            Return
        End If

        Dim data_recebe = recebe_DateTimePicker.Value.Date.ToString("yyyy-MM-dd")
        Dim data_armazenamento = getDate("data_armazenamento_RS")
        Dim data_doacao = getDate("data_doa_sangue")
        Dim result = DateTime.Compare(data_doacao, data_recebe)
        Dim result1 = DateTime.Compare(data_armazenamento, data_recebe)

        If result > 0 Or result = 0 Then
            MessageBox.Show("A data de doação necessita de ser primeiro que a de receber")
            Return
        ElseIf result1 > 0 Then
            MessageBox.Show("A data de armazenamento necessita de ser primeiro ou no mesmo dia que a de receber")
            Return
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
            Dim cmd As SqlCommand = New SqlCommand("AtribuirRecipiente", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", codigo_TextBox.Text)
            cmd.Parameters.AddWithValue("@id_paciente", id_paciente_TextBox.Text)
            cmd.Parameters.AddWithValue("@data_recebe", data_recebe)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Registo de atribuição do Recipiente de sangue executado com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Atribuição não registada")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        ClearAll()
        listar_pacientes_ListBox.Items.Clear()
        recipientes_todos_Button_Click(sender, e)
    End Sub

    Private Sub recipientes_Label_Click(sender As Object, e As EventArgs) Handles recipientes_Label.Click

    End Sub

    Private Sub doadores_Label_Click(sender As Object, e As EventArgs) Handles doadores_Label.Click

    End Sub
End Class