Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form5
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection(Form1.connection)
        CMD = New SqlCommand
        CMD.Connection = CN
        data_encomenda_DateTimePicker.MinDate = DateTime.Now
        getStock(Form1.BS)
    End Sub

    Private Sub getStock(ByVal banco As String)
        Dim tipo_sangue, no_stock As String
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
            Dim cmd As SqlCommand = New SqlCommand("GetStock", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            Dim RDR As SqlDataReader
            RDR = cmd.ExecuteReader
            If RDR.HasRows() Then
                stock.Items.Clear()
                Dim n_column = RDR.FieldCount - 1
                While RDR.Read()
                    tipo_sangue = RDR.Item("tipo_sangue_RS")
                    no_stock = RDR.Item("stock")
                    stock.Items.Add(tipo_sangue + "            " + no_stock)
                End While
            Else
                stock.Items.Add("Não tem recipientes de sangue")
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Não foi possível obter o stock")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    Private Function getNextNumber(ByVal column_name As String, ByVal table_name As String) As String
        Dim number As String

        Try
            CN.Open()
            CMD.CommandText = "select top 1 " + column_name + " from " + table_name + " order by " + column_name + " desc"
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                number = RDR.Item(column_name) + 1
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

        Return number
    End Function
    Private Function getCurrentNumber(ByVal column_name As String, ByVal table_name As String, ByVal key_name As String, ByVal key As String) As String
        Dim number As String

        Try
            CN.Open()
            CMD.CommandText = "select " + column_name + " from " + table_name + " where " + key_name + "=" + key
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                number = RDR.Item(column_name)
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

        Return number
    End Function
    Private Function getDate(ByVal column_name As String, ByVal table_name As String, ByVal key_name As String, ByVal key_value As String) As DateTime
        Dim d As DateTime

        Try
            CN.Open()
            CMD.CommandText = "select " + column_name + " from " + table_name + " where " + key_name + "=" + key_value
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                RDR.Read()
                If RDR.IsDBNull(RDR.GetOrdinal(column_name)) Then
                    d = CType(Nothing, DateTime)
                Else
                    d = CType(RDR.Item(column_name), DateTime).ToShortDateString
                End If
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Erro: " + table_name + " está vazia")
            If CN.State = ConnectionState.Open Then
                CN.Close()
            End If
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        Return d
    End Function

    Private Sub clientes_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clientes_ListBox.SelectedIndexChanged

    End Sub

    Private Sub encomendas_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles encomendas_ListBox.SelectedIndexChanged

    End Sub

    Private Sub clientes_Button_Click(sender As Object, e As EventArgs) Handles clientes_Button.Click
        If String.IsNullOrEmpty(nif_TextBox.Text) Then
            MessageBox.Show("É necessário passar o NIF do Cliente para visualizar as suas informações")
            Return
        End If
        encomendas_Label.Text = "Encomendas"
        Dim no_cliente, nome_cliente, tipo_cliente As String
        CMD.CommandText = "select no_cliente, nome_cliente, tipo_cliente from Cliente where NIF=" + nif_TextBox.Text

        Dim head = "{0, -15} {1, -30} {2, 20}"
        Dim line = "{0, -10} {1, 30} {2, 20}"

        Try
            CN.Open()
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                clientes_ListBox.Items.Clear()
                Dim n_column = RDR.FieldCount - 1
                clientes_ListBox.Items.Add(String.Format(head, "Nº Cliente", "Nome", "Tipo de Cliente"))
                RDR.Read()
                no_cliente = RDR.Item("no_cliente")
                nome_cliente = RDR.Item("nome_cliente")
                tipo_cliente = IIf(RDR.IsDBNull(RDR.GetOrdinal("tipo_cliente")), " ------ ", RDR.Item("tipo_cliente"))
                clientes_ListBox.Items.Add(String.Format(line, no_cliente, nome_cliente, tipo_cliente))
            Else
                MessageBox.Show("Cliente com NIF=" + nif_TextBox.Text + " não existe")
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Não connectado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        'Encomendas_Button_Click(sender, e)

    End Sub

    Private Sub nif_TextBox_TextChanged(sender As Object, e As EventArgs) Handles nif_TextBox.TextChanged

    End Sub
    Private Sub nif_TextBox_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nif_TextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Encomendas_Button_Click(sender As Object, e As EventArgs) Handles Encomendas_Button.Click
        encomendas_Label.Text = "Encomendas"
        Dim no_encomenda, quantidade_recipientes, tipo_sangue_encomenda, data_encomenda As String

        CMD.CommandText = "select no_encomenda, data_encomenda, quantidade_recipientes, tipo_sangue_encomenda
                            from Cliente join Faz On no_cliente=no_cliente_faz join Encomendas On no_encomendas_faz=no_encomenda join Fornece On no_encomenda_F=no_encomenda 
                            where nome_BS='" + Form1.BS + "' and NIF=" + nif_TextBox.Text

        Dim head = "{0, -15} {1, 13} {2, 20} {3, 15}"
        Dim line = "{0, -30} {1, 10} {2, 20} {3, 18}"

        Try
            CN.Open()
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                encomendas_ListBox.Items.Clear()
                Dim n_column = RDR.FieldCount - 1
                encomendas_ListBox.Items.Add(String.Format(head, "Nº Encomenda", "Data", "Nº Recipientes", "Tipo de Sangue"))
                While RDR.Read
                    no_encomenda = RDR.Item("no_encomenda")
                    quantidade_recipientes = RDR.Item("quantidade_recipientes")
                    tipo_sangue_encomenda = RDR.Item("tipo_sangue_encomenda")
                    data_encomenda = CType(RDR.Item("data_encomenda"), DateTime).ToShortDateString
                    encomendas_ListBox.Items.Add(String.Format(line, no_encomenda, data_encomenda, quantidade_recipientes, tipo_sangue_encomenda))
                End While
            Else
                encomendas_ListBox.Items.Clear()
                MessageBox.Show("Cliente com NIF=" + nif_TextBox.Text + " não fez encomendas")
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Não connectado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    Private Sub fornecidas_Button_Click(sender As Object, e As EventArgs) Handles fornecidas_Button.Click
        encomendas_Label.Text = "Encomendas fornecidas"
        Dim no_encomenda, quantidade_recipientes, tipo_sangue_encomenda, data_encomenda, data_fornecimento As String

        CMD.CommandText = "select no_encomenda, data_encomenda, quantidade_recipientes, tipo_sangue_encomenda, data_fornecimento
                            from Cliente join Faz On no_cliente=no_cliente_faz join Encomendas On no_encomendas_faz=no_encomenda join Fornece On no_encomenda_F=no_encomenda 
                            where nome_BS='" + Form1.BS + "' and NIF=" + nif_TextBox.Text + " and data_fornecimento is not null"

        Dim head = "{0, -15} {1, 13} {2, 20} {3, 15} {4, 20}"
        Dim line = "{0, -30} {1, 10} {2, 20} {3, 18} {4, 23}"

        Try
            CN.Open()
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                encomendas_ListBox.Items.Clear()
                Dim n_column = RDR.FieldCount - 1
                encomendas_ListBox.Items.Add(String.Format(head, "Nº Encomenda", "Data", "Nº Recipientes", "Tipo de Sangue", "Data fornecimento"))
                While RDR.Read
                    no_encomenda = RDR.Item("no_encomenda")
                    quantidade_recipientes = RDR.Item("quantidade_recipientes")
                    tipo_sangue_encomenda = RDR.Item("tipo_sangue_encomenda")
                    data_encomenda = CType(RDR.Item("data_encomenda"), DateTime).ToShortDateString
                    data_fornecimento = CType(RDR.Item("data_fornecimento"), DateTime).ToShortDateString
                    encomendas_ListBox.Items.Add(String.Format(line, no_encomenda, data_encomenda, quantidade_recipientes, tipo_sangue_encomenda, data_fornecimento))
                End While
            Else
                encomendas_ListBox.Items.Clear()
                MessageBox.Show("Não foram fornecidas Encomendas ao Cliente com NIF=" + nif_TextBox.Text)
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Não connectado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    Private Sub nao_fornecidas_Button_Click(sender As Object, e As EventArgs) Handles nao_fornecidas_Button.Click
        encomendas_Label.Text = "Encomendas por fornecer"
        Dim no_encomenda, quantidade_recipientes, tipo_sangue_encomenda, data_encomenda As String

        CMD.CommandText = "select no_encomenda, data_encomenda, quantidade_recipientes, tipo_sangue_encomenda
                            from Cliente join Faz On no_cliente=no_cliente_faz join Encomendas On no_encomendas_faz=no_encomenda join Fornece On no_encomenda_F=no_encomenda 
                            where nome_BS='" + Form1.BS + "' and NIF=" + nif_TextBox.Text + " and data_fornecimento is null"

        Dim head = "{0, -15} {1, 13} {2, 20} {3, 15}"
        Dim line = "{0, -30} {1, 10} {2, 20} {3, 18}"

        Try
            CN.Open()
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            If RDR.HasRows() Then
                encomendas_ListBox.Items.Clear()
                Dim n_column = RDR.FieldCount - 1
                encomendas_ListBox.Items.Add(String.Format(head, "Nº Encomenda", "Data", "Nº Recipientes", "Tipo de Sangue"))
                While RDR.Read
                    no_encomenda = RDR.Item("no_encomenda")
                    quantidade_recipientes = RDR.Item("quantidade_recipientes")
                    tipo_sangue_encomenda = RDR.Item("tipo_sangue_encomenda")
                    data_encomenda = CType(RDR.Item("data_encomenda"), DateTime).ToShortDateString
                    encomendas_ListBox.Items.Add(String.Format(line, no_encomenda, data_encomenda, quantidade_recipientes, tipo_sangue_encomenda))
                End While
            Else
                encomendas_ListBox.Items.Clear()
                MessageBox.Show("Encomendas do Cliente com NIF=" + nif_TextBox.Text + " já foram fornecidas")
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Não connectado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
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

    Private Sub tipo_cliente_TextBox_TextChanged(sender As Object, e As EventArgs) Handles tipo_cliente_TextBox.TextChanged

    End Sub
    Private Sub tipo_cliente_TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tipo_cliente_TextBox.KeyPress
        Select Case Asc(e.KeyChar)
            Case 8, 32, 65 To 90, 97 To 122
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub no_recipientes_TextBox_TextChanged(sender As Object, e As EventArgs) Handles no_recipientes_TextBox.TextChanged

    End Sub

    Private Sub no_recipientes_TextBox_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles no_recipientes_TextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboBox_BT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_BT.SelectedIndexChanged

    End Sub
    Private Sub ComboBox_BT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox_BT.KeyPress
        e.Handled = True
    End Sub

    Private Sub cliente_encomenda_Button_Click(sender As Object, e As EventArgs) Handles cliente_encomenda_Button.Click
        Dim b As Boolean = False
        If String.IsNullOrEmpty(no_cliente_TextBox.Text) Or String.IsNullOrEmpty(no_recipientes_TextBox.Text) Or ComboBox_BT.Text = "Escolha o tipo de sangue" Then
            MessageBox.Show("É necessário passar o nº cliente, nº de recipientes e escolher o tipo de sangue da encomenda")
            Return
        End If

        Dim numero_encomenda As String
        Dim today As DateTime = FormatDateTime(Now, DateFormat.ShortDate)

        numero_encomenda = getNextNumber("no_encomenda", "Encomendas")

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
            Dim cmd As SqlCommand = New SqlCommand("InsertEncomenda", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@no_cliente", no_cliente_TextBox.Text)
            cmd.Parameters.AddWithValue("@numero_encomenda", numero_encomenda)
            cmd.Parameters.AddWithValue("@data_encomenda", today)
            cmd.Parameters.AddWithValue("@quantidade_recipientes", no_recipientes_TextBox.Text)
            cmd.Parameters.AddWithValue("@tipo_sangue", ComboBox_BT.Text)
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Encomenda efetuada com sucesso")
            no_recipientes_TextBox.Clear()
            ComboBox_BT.Text = "Escolha o tipo de sangue"
            data_encomenda_DateTimePicker.Value = DateTime.Now
            b = True
        Catch ex As SqlException
            MessageBox.Show("Erro: Não foi possível efetuar a Encomenda")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        If b Then
            Encomendas_Button_Click(sender, e)
        End If

    End Sub

    Private Sub fornecer_Button_Click(sender As Object, e As EventArgs) Handles fornecer_Button.Click
        Dim b As Boolean = False
        If String.IsNullOrEmpty(no_encomenda_TextBox.Text) Then
            MessageBox.Show("É necessário passar o número de encomenda")
            Return
        End If

        Dim data_fornecimento As DateTime = data_fornecimento_DateTimePicker.Value '.Date.ToString("yyyy-MM-dd")
        Dim data_encomenda As DateTime = getDate("data_encomenda", "Faz", "no_encomendas_faz", no_encomenda_TextBox.Text)

        Dim result = DateTime.Compare(data_encomenda, data_fornecimento)

        If result > 0 Then
            MessageBox.Show("A data de encomenda necessita de ser primeiro que a de fornecimento")
            Return
        End If

        Dim d = data_fornecimento.Date.ToString("yyyy-MM-dd")

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
            Dim cmd As SqlCommand = New SqlCommand("Fornecimento", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            cmd.Parameters.AddWithValue("@numero_encomenda", no_encomenda_TextBox.Text)
            cmd.Parameters.AddWithValue("@data_fornecimento", data_fornecimento)
            Dim rows = cmd.ExecuteNonQuery()
            If rows > 0 Then
                MessageBox.Show("Fornecimento registado com sucesso")
                b = True
            Else
                MessageBox.Show("não há recipientes suficientes para fornecer a encomenda")
            End If
        Catch ex As SqlException
            MessageBox.Show("Erro: Fornecimento não registado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        If b Then
            fornecidas_Button_Click(sender, e)
        End If

        getStock(Form1.BS)

    End Sub

    Private Sub inserir_Button_Click(sender As Object, e As EventArgs) Handles inserir_Button.Click
        Dim b As Boolean
        If String.IsNullOrEmpty(nif_TextBox.Text) Or String.IsNullOrEmpty(nome_TextBox.Text) Then
            MessageBox.Show("É necessário passar o NIF e nome do novo Cliente que pretende inserir")
            Return
        End If

        Dim no_cliente As String = getNextNumber("no_cliente", "Cliente")

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
            Dim cmd As SqlCommand = New SqlCommand("InsertCliente", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@no_cliente", no_cliente)
            cmd.Parameters.AddWithValue("@NIF", nif_TextBox.Text)
            cmd.Parameters.AddWithValue("@nome", nome_TextBox.Text)
            cmd.Parameters.AddWithValue("@tipo_cliente", tipo_cliente_TextBox.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Cliente inserido com sucesso")
            nome_TextBox.Clear()
            tipo_cliente_TextBox.Clear()
            b = True
        Catch ex As SqlException
            MessageBox.Show("Erro: Cliente não inserido")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        If b Then
            clientes_Button_Click(sender, e)
        End If

    End Sub

    Private Sub no_cliente_TextBox_TextChanged(sender As Object, e As EventArgs) Handles no_cliente_TextBox.TextChanged

    End Sub
    Private Sub no_cliente_TextBox_box_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles no_cliente_TextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub no_encomenda_TextBox_TextChanged(sender As Object, e As EventArgs) Handles no_encomenda_TextBox.TextChanged

    End Sub

    Private Sub data_encomenda_DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles data_encomenda_DateTimePicker.ValueChanged

    End Sub

    Private Sub data_fornecimento_DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles data_fornecimento_DateTimePicker.ValueChanged

    End Sub

    Private Sub cancelar_Button_Click(sender As Object, e As EventArgs)
        Dim b As Boolean = False
        If String.IsNullOrEmpty(no_encomenda_TextBox.Text) Then
            MessageBox.Show("É necessário passar o número de encomenda")
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
            Dim cmd As SqlCommand = New SqlCommand("CancelEncomenda", CN)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@numero_encomenda", no_encomenda_TextBox.Text)
            cmd.Parameters.AddWithValue("@banco", Form1.BS)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Cancelamento registado com sucesso")
            b = True
        Catch ex As SqlException
            MessageBox.Show("Erro: Cancelamento não registado")
        End Try

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        If b Then
            Encomendas_Button_Click(sender, e)
        End If

    End Sub

    Private Sub encomendas_Label_Click(sender As Object, e As EventArgs) Handles encomendas_Label.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles stock.SelectedIndexChanged

    End Sub
End Class