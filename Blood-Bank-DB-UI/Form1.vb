Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form1
    Public BS As String
    ' change the db_name
    Dim db_name = "BS_Management"
    Public connection As String = "data source=localhost\SQLEXPRESS;integrated security=true;initial catalog=" + db_name
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Private Sub addItemsToBox()
        Dim RDR As SqlDataReader
        CMD.CommandText = "select nome from Banco_Sangue"
        Try
            CN.Open()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: Não connectado")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
            Return
        End Try

        BS_select.Items.Clear()
        Try
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                While RDR.Read()
                    BS_select.Items.Add(RDR.Item("nome"))
                End While
            Else
                MessageBox.Show("Não existem Bancos de Sangue")
            End If
        Catch ex As Exception
            MessageBox.Show("Erro: Não foi possível executar")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BS_select.SelectedIndexChanged

    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BS_select.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BS_in.Click
        Dim myForms As New Form2
        BS = BS_select.Text
        If BS = "Escolha o Banco de Sangue" Then
            MessageBox.Show("Escolha um Banco de Sangue para prosseguir")
        Else
            myForms.Show()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection(connection)
        CMD = New SqlCommand
        CMD.Connection = CN
        addItemsToBox()
    End Sub

    Private Sub Criar_Button_Click(sender As Object, e As EventArgs) Handles Criar_Button.Click
        Dim morada

        If String.IsNullOrEmpty(morada_TextBox.Text) Then
            morada = DBNull.Value
        Else
            morada = morada_TextBox.Text
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
            Dim cmd As SqlCommand = New SqlCommand("InsertBanco", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nome", nome_TextBox.Text)
            cmd.Parameters.AddWithValue("@morada", morada)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Banco inserido com sucesso")
        Catch ex As SqlException
            MessageBox.Show("Erro: Banco não inserido")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        addItemsToBox()
    End Sub
    Private Sub nome_TextBox_TextChanged(sender As Object, e As EventArgs) Handles nome_TextBox.TextChanged

    End Sub
    Private Sub nome_TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nome_TextBox.KeyPress
        Select Case Asc(e.KeyChar)
            Case 8, 32, 65 To 90, 97 To 122
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub morada_TextBox_TextChanged(sender As Object, e As EventArgs) Handles morada_TextBox.TextChanged

    End Sub
    Private Sub morada_TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles morada_TextBox.KeyPress
        Select Case Asc(e.KeyChar)
            Case 8, 32, 65 To 90, 97 To 122
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub
End Class
