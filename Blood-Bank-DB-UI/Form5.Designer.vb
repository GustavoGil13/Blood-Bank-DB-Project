<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.clientes_ListBox = New System.Windows.Forms.ListBox()
        Me.encomendas_ListBox = New System.Windows.Forms.ListBox()
        Me.encomendas_Label = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.clientes_Button = New System.Windows.Forms.Button()
        Me.Encomendas_Button = New System.Windows.Forms.Button()
        Me.nif_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.fornecidas_Button = New System.Windows.Forms.Button()
        Me.nao_fornecidas_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nome_TextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tipo_cliente_TextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.no_recipientes_TextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox_BT = New System.Windows.Forms.ComboBox()
        Me.cliente_encomenda_Button = New System.Windows.Forms.Button()
        Me.fornecer_Button = New System.Windows.Forms.Button()
        Me.inserir_Button = New System.Windows.Forms.Button()
        Me.no_cliente_TextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.no_encomenda_TextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.data_encomenda_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.data_fornecimento_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.stock = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'clientes_ListBox
        '
        Me.clientes_ListBox.FormattingEnabled = True
        Me.clientes_ListBox.ItemHeight = 15
        Me.clientes_ListBox.Location = New System.Drawing.Point(112, 37)
        Me.clientes_ListBox.Name = "clientes_ListBox"
        Me.clientes_ListBox.Size = New System.Drawing.Size(295, 49)
        Me.clientes_ListBox.TabIndex = 1
        '
        'encomendas_ListBox
        '
        Me.encomendas_ListBox.FormattingEnabled = True
        Me.encomendas_ListBox.ItemHeight = 15
        Me.encomendas_ListBox.Location = New System.Drawing.Point(12, 410)
        Me.encomendas_ListBox.Name = "encomendas_ListBox"
        Me.encomendas_ListBox.Size = New System.Drawing.Size(652, 154)
        Me.encomendas_ListBox.TabIndex = 2
        '
        'encomendas_Label
        '
        Me.encomendas_Label.AutoSize = True
        Me.encomendas_Label.Location = New System.Drawing.Point(12, 392)
        Me.encomendas_Label.Name = "encomendas_Label"
        Me.encomendas_Label.Size = New System.Drawing.Size(75, 15)
        Me.encomendas_Label.TabIndex = 6
        Me.encomendas_Label.Text = "Encomendas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(112, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Informação do Cliente"
        '
        'clientes_Button
        '
        Me.clientes_Button.Location = New System.Drawing.Point(282, 92)
        Me.clientes_Button.Name = "clientes_Button"
        Me.clientes_Button.Size = New System.Drawing.Size(125, 23)
        Me.clientes_Button.TabIndex = 8
        Me.clientes_Button.Text = "Mostrar Informação"
        Me.clientes_Button.UseVisualStyleBackColor = True
        '
        'Encomendas_Button
        '
        Me.Encomendas_Button.Location = New System.Drawing.Point(487, 570)
        Me.Encomendas_Button.Name = "Encomendas_Button"
        Me.Encomendas_Button.Size = New System.Drawing.Size(177, 23)
        Me.Encomendas_Button.TabIndex = 9
        Me.Encomendas_Button.Text = "Mostrar todas as Encomendas"
        Me.Encomendas_Button.UseVisualStyleBackColor = True
        '
        'nif_TextBox
        '
        Me.nif_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.nif_TextBox.Name = "nif_TextBox"
        Me.nif_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.nif_TextBox.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "NIF"
        '
        'fornecidas_Button
        '
        Me.fornecidas_Button.Location = New System.Drawing.Point(6, 113)
        Me.fornecidas_Button.Name = "fornecidas_Button"
        Me.fornecidas_Button.Size = New System.Drawing.Size(195, 23)
        Me.fornecidas_Button.TabIndex = 13
        Me.fornecidas_Button.Text = "Mostrar Encomendas fornecidas"
        Me.fornecidas_Button.UseVisualStyleBackColor = True
        '
        'nao_fornecidas_Button
        '
        Me.nao_fornecidas_Button.Location = New System.Drawing.Point(6, 142)
        Me.nao_fornecidas_Button.Name = "nao_fornecidas_Button"
        Me.nao_fornecidas_Button.Size = New System.Drawing.Size(195, 23)
        Me.nao_fornecidas_Button.TabIndex = 14
        Me.nao_fornecidas_Button.Text = "Mostrar Encomendas por fornecer"
        Me.nao_fornecidas_Button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nome"
        '
        'nome_TextBox
        '
        Me.nome_TextBox.Location = New System.Drawing.Point(6, 81)
        Me.nome_TextBox.Name = "nome_TextBox"
        Me.nome_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.nome_TextBox.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Tipo cliente"
        '
        'tipo_cliente_TextBox
        '
        Me.tipo_cliente_TextBox.Location = New System.Drawing.Point(6, 125)
        Me.tipo_cliente_TextBox.Name = "tipo_cliente_TextBox"
        Me.tipo_cliente_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.tipo_cliente_TextBox.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Quantidade de Recipientes"
        '
        'no_recipientes_TextBox
        '
        Me.no_recipientes_TextBox.Location = New System.Drawing.Point(8, 81)
        Me.no_recipientes_TextBox.Name = "no_recipientes_TextBox"
        Me.no_recipientes_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.no_recipientes_TextBox.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Tipo de Sangue"
        '
        'ComboBox_BT
        '
        Me.ComboBox_BT.FormattingEnabled = True
        Me.ComboBox_BT.Items.AddRange(New Object() {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"})
        Me.ComboBox_BT.Location = New System.Drawing.Point(8, 125)
        Me.ComboBox_BT.Name = "ComboBox_BT"
        Me.ComboBox_BT.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox_BT.TabIndex = 22
        Me.ComboBox_BT.Text = "Escolha o tipo de sangue"
        '
        'cliente_encomenda_Button
        '
        Me.cliente_encomenda_Button.Location = New System.Drawing.Point(226, 73)
        Me.cliente_encomenda_Button.Name = "cliente_encomenda_Button"
        Me.cliente_encomenda_Button.Size = New System.Drawing.Size(166, 23)
        Me.cliente_encomenda_Button.TabIndex = 26
        Me.cliente_encomenda_Button.Text = "Fazer nova encomenda"
        Me.cliente_encomenda_Button.UseVisualStyleBackColor = True
        '
        'fornecer_Button
        '
        Me.fornecer_Button.Location = New System.Drawing.Point(226, 118)
        Me.fornecer_Button.Name = "fornecer_Button"
        Me.fornecer_Button.Size = New System.Drawing.Size(166, 23)
        Me.fornecer_Button.TabIndex = 27
        Me.fornecer_Button.Text = "Fornecer encomenda"
        Me.fornecer_Button.UseVisualStyleBackColor = True
        '
        'inserir_Button
        '
        Me.inserir_Button.Location = New System.Drawing.Point(112, 92)
        Me.inserir_Button.Name = "inserir_Button"
        Me.inserir_Button.Size = New System.Drawing.Size(125, 23)
        Me.inserir_Button.TabIndex = 28
        Me.inserir_Button.Text = "Inserir Cliente"
        Me.inserir_Button.UseVisualStyleBackColor = True
        '
        'no_cliente_TextBox
        '
        Me.no_cliente_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.no_cliente_TextBox.Name = "no_cliente_TextBox"
        Me.no_cliente_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.no_cliente_TextBox.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 15)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Nº Cliente"
        '
        'no_encomenda_TextBox
        '
        Me.no_encomenda_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.no_encomenda_TextBox.Name = "no_encomenda_TextBox"
        Me.no_encomenda_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.no_encomenda_TextBox.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 15)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Nº encomenda"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 15)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Data da encomenda"
        '
        'data_encomenda_DateTimePicker
        '
        Me.data_encomenda_DateTimePicker.Location = New System.Drawing.Point(8, 169)
        Me.data_encomenda_DateTimePicker.Name = "data_encomenda_DateTimePicker"
        Me.data_encomenda_DateTimePicker.Size = New System.Drawing.Size(200, 23)
        Me.data_encomenda_DateTimePicker.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 15)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Data de Fornecimento"
        '
        'data_fornecimento_DateTimePicker
        '
        Me.data_fornecimento_DateTimePicker.Location = New System.Drawing.Point(6, 84)
        Me.data_fornecimento_DateTimePicker.Name = "data_fornecimento_DateTimePicker"
        Me.data_fornecimento_DateTimePicker.Size = New System.Drawing.Size(200, 23)
        Me.data_fornecimento_DateTimePicker.TabIndex = 35
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.nif_TextBox)
        Me.GroupBox1.Controls.Add(Me.inserir_Button)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.nome_TextBox)
        Me.GroupBox1.Controls.Add(Me.clientes_Button)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tipo_cliente_TextBox)
        Me.GroupBox1.Controls.Add(Me.clientes_ListBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 160)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.no_cliente_TextBox)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.no_recipientes_TextBox)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.data_encomenda_DateTimePicker)
        Me.GroupBox2.Controls.Add(Me.ComboBox_BT)
        Me.GroupBox2.Controls.Add(Me.fornecer_Button)
        Me.GroupBox2.Controls.Add(Me.cliente_encomenda_Button)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(652, 210)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Encomendas"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.no_encomenda_TextBox)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.data_fornecimento_DateTimePicker)
        Me.GroupBox3.Controls.Add(Me.nao_fornecidas_Button)
        Me.GroupBox3.Controls.Add(Me.fornecidas_Button)
        Me.GroupBox3.Location = New System.Drawing.Point(425, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(215, 174)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fornecimento"
        '
        'stock
        '
        Me.stock.FormattingEnabled = True
        Me.stock.ItemHeight = 15
        Me.stock.Location = New System.Drawing.Point(487, 21)
        Me.stock.Name = "stock"
        Me.stock.Size = New System.Drawing.Size(108, 139)
        Me.stock.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(487, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Stock"
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 604)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.stock)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Encomendas_Button)
        Me.Controls.Add(Me.encomendas_Label)
        Me.Controls.Add(Me.encomendas_ListBox)
        Me.Name = "Form5"
        Me.Text = "Gestão de Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clientes_ListBox As ListBox
    Friend WithEvents encomendas_ListBox As ListBox
    Friend WithEvents encomendas_Label As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents clientes_Button As Button
    Friend WithEvents Encomendas_Button As Button
    Friend WithEvents nif_TextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents fornecidas_Button As Button
    Friend WithEvents nao_fornecidas_Button As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents nome_TextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tipo_cliente_TextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents no_recipientes_TextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox_BT As ComboBox
    Friend WithEvents cliente_encomenda_Button As Button
    Friend WithEvents fornecer_Button As Button
    Friend WithEvents inserir_Button As Button
    Friend WithEvents no_cliente_TextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents no_encomenda_TextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents data_encomenda_DateTimePicker As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents data_fornecimento_DateTimePicker As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents stock As ListBox
    Friend WithEvents Label3 As Label
End Class
