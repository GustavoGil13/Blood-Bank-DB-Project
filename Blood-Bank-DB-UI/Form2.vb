Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form2
    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles print_box.SelectedIndexChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection(Form1.connection)
        CMD = New SqlCommand
        CMD.Connection = CN
        ShowGestor()
        BS_Box.Items.Add(Form1.BS)
        nome_TextBox.Enabled = False
    End Sub
    Private Sub ShowGestor()
        Dim RDR As SqlDataReader
        CMD.CommandText = "select ID_Funcionario, CC_Funcionario, P.nome, P.apelido 
                                from Funcionario Join Banco_Sangue On nome=Funcionario_BS_nome Join Pessoa As P On P.CC=CC_Funcionario 
                                where Funcionario_BS_nome = '" + Form1.BS + "' and ID_Funcionario=ID_gestor"
        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        gestor_box.Items.Clear()
        Try
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                gestor_box.Items.Add(RDR.Item("nome") + " " + RDR.Item("apelido"))
            Else
                gestor_box.Items.Add("Gestor não encontrado")
            End If
        Catch ex As Exception
            MessageBox.Show("Erro: Não foi possível executar")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tables_name.SelectedIndexChanged
        nome_TextBox.Enabled = True
        nome_TextBox.Clear()
        Dim opt = Tables_name.Text
        Dim table_name As String
        Select Case opt
            Case "Funcionario"
                CMD.CommandText = "select CC, nome + ' ' + apelido as nome_completo, idade, telemovel from Pessoa join Funcionario on CC=CC_Funcionario where Funcionario_BS_nome='" + Form1.BS + "'"
                table_name = "Funcionários"
            Case "Cliente"
                CMD.CommandText = "select distinct NIF, nome_cliente, tipo_cliente from Cliente join Faz On no_cliente=no_cliente_faz join Encomendas On no_encomendas_faz=no_encomenda join Fornece On no_encomenda_F=no_encomenda where nome_BS='" + Form1.BS + "'"
                table_name = "Clientes"
            Case "Doador"
                CMD.CommandText = "select CC, nome + ' ' + apelido as nome_completo, idade, telemovel from Pessoa join Doador on CC=CC_Doador where nome_bs_d='" + Form1.BS + "'"
                table_name = "Doadores"
            Case "Paciente"
                CMD.CommandText = "select CC, nome + ' ' + apelido as nome_completo, idade, telemovel from Pessoa join Paciente on CC=CC_Paciente where nome_bs_p='" + Form1.BS + "'"
                table_name = "Pacientes"
        End Select
        Label6.Text = table_name

        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        If RDR.HasRows() Then
            print_box.Items.Clear()
            Dim n_column = RDR.FieldCount - 1
            Dim head = ""
            For i = 0 To n_column
                head += RDR.GetName(i) + "     "
            Next
            print_box.Items.Add(head)
            While RDR.Read
                Dim line = ""
                For i = 0 To n_column
                    line += IIf(RDR.IsDBNull(i), " ------ ", RDR.Item(i).ToString() + "  ")
                Next
                print_box.Items.Add(line)
            End While
        Else
            print_box.Items.Add("Este banco não possui " + table_name)
        End If

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        If opt = "Funcionario" Then
            ShowGestor()
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tables_name.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Insert_Person.Click
        Dim myForms_3 As New Form3
        myForms_3.Show()
    End Sub

    Private Sub gestor_box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gestor_box.SelectedIndexChanged

    End Sub

    Private Sub BS_Box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BS_Box.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles RS_management_button.Click
        Dim myForms_4 As New Form4
        myForms_4.Show()
    End Sub

    Private Sub nome_TextBox_TextChanged(sender As Object, e As EventArgs) Handles nome_TextBox.TextChanged
        Try
            CN.Open()
            Select Case Tables_name.Text
                Case "Paciente"
                    CMD.CommandText = "select CC, nome + ' ' + apelido as nome_completo, idade, telemovel from Pessoa join Paciente on CC=CC_Paciente where nome like '" + nome_TextBox.Text + "' + '%' and nome_bs_p='" + Form1.BS + "' Order By CC"
                Case "Doador"
                    CMD.CommandText = "select CC, nome + ' ' + apelido as nome_completo, idade, telemovel from Pessoa join Doador on CC=CC_Doador where nome like '" + nome_TextBox.Text + "' + '%' and nome_bs_d='" + Form1.BS + "' Order By CC"
                Case "Funcionario"
                    CMD.CommandText = "select CC, nome + ' ' + apelido as nome_completo, idade, telemovel from Pessoa join Funcionario on CC=CC_Funcionario where nome like '" + nome_TextBox.Text + "' + '%' and Funcionario_BS_nome='" + Form1.BS + "' Order By CC"
                Case "Cliente"
                    CMD.CommandText = "select NIF, nome_cliente, tipo_cliente from Cliente join Faz on no_cliente=no_cliente_faz join Encomendas on no_encomendas_faz=no_encomenda join Fornece on no_encomenda_F=no_encomenda where nome_BS='" + Form1.BS + "' and nome_cliente like '" + nome_TextBox.Text + "' + '%' Order By NIF"
            End Select
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                print_box.Items.Clear()
                Dim n_column = RDR.FieldCount - 1
                Dim head = ""
                For i = 0 To n_column
                    head += RDR.GetName(i) + "     "
                Next
                print_box.Items.Add(head)
                While RDR.Read
                    Dim line = ""
                    For i = 0 To n_column
                        line += IIf(RDR.IsDBNull(i), " ------ ", RDR.Item(i).ToString() + "  ")
                    Next
                    print_box.Items.Add(line)
                End While
            Else
                print_box.Items.Clear()
                print_box.Items.Add("Este banco não possui " + Tables_name.Text)
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub
    Private Sub nome_box_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nome_TextBox.KeyPress

        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub clientes_Button_Click(sender As Object, e As EventArgs) Handles clientes_Button.Click
        Dim myForms_5 As New Form5
        myForms_5.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class