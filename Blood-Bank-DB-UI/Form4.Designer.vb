<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.Recipientes_box = New System.Windows.Forms.ListBox()
        Me.recipientes_todos_Button = New System.Windows.Forms.Button()
        Me.reci_disponiveis_button = New System.Windows.Forms.Button()
        Me.listar_pacientes_ListBox = New System.Windows.Forms.ListBox()
        Me.list_pacientes_Button = New System.Windows.Forms.Button()
        Me.list_doadores_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.codigo_TextBox = New System.Windows.Forms.TextBox()
        Me.armazenamento_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.id_paciente_TextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.recebe_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.id_doador_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.doacao_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.doacao_Button = New System.Windows.Forms.Button()
        Me.armazenar_Button = New System.Windows.Forms.Button()
        Me.recipiente_to_paciente_Button = New System.Windows.Forms.Button()
        Me.recipientes_Label = New System.Windows.Forms.Label()
        Me.doadores_Label = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Recipientes_box
        '
        Me.Recipientes_box.FormattingEnabled = True
        Me.Recipientes_box.ItemHeight = 15
        Me.Recipientes_box.Location = New System.Drawing.Point(391, 18)
        Me.Recipientes_box.Name = "Recipientes_box"
        Me.Recipientes_box.Size = New System.Drawing.Size(614, 214)
        Me.Recipientes_box.TabIndex = 0
        '
        'recipientes_todos_Button
        '
        Me.recipientes_todos_Button.Location = New System.Drawing.Point(6, 95)
        Me.recipientes_todos_Button.Name = "recipientes_todos_Button"
        Me.recipientes_todos_Button.Size = New System.Drawing.Size(171, 23)
        Me.recipientes_todos_Button.TabIndex = 1
        Me.recipientes_todos_Button.Text = "Mostrar todos os recipientes"
        Me.recipientes_todos_Button.UseVisualStyleBackColor = True
        '
        'reci_disponiveis_button
        '
        Me.reci_disponiveis_button.Location = New System.Drawing.Point(6, 66)
        Me.reci_disponiveis_button.Name = "reci_disponiveis_button"
        Me.reci_disponiveis_button.Size = New System.Drawing.Size(171, 23)
        Me.reci_disponiveis_button.TabIndex = 2
        Me.reci_disponiveis_button.Text = "Recipientes disponiveis"
        Me.reci_disponiveis_button.UseVisualStyleBackColor = True
        '
        'listar_pacientes_ListBox
        '
        Me.listar_pacientes_ListBox.FormattingEnabled = True
        Me.listar_pacientes_ListBox.ItemHeight = 15
        Me.listar_pacientes_ListBox.Location = New System.Drawing.Point(391, 253)
        Me.listar_pacientes_ListBox.Name = "listar_pacientes_ListBox"
        Me.listar_pacientes_ListBox.Size = New System.Drawing.Size(614, 214)
        Me.listar_pacientes_ListBox.TabIndex = 3
        '
        'list_pacientes_Button
        '
        Me.list_pacientes_Button.Location = New System.Drawing.Point(6, 66)
        Me.list_pacientes_Button.Name = "list_pacientes_Button"
        Me.list_pacientes_Button.Size = New System.Drawing.Size(171, 23)
        Me.list_pacientes_Button.TabIndex = 4
        Me.list_pacientes_Button.Text = "Listar pacientes compativeis"
        Me.list_pacientes_Button.UseVisualStyleBackColor = True
        '
        'list_doadores_Button
        '
        Me.list_doadores_Button.Location = New System.Drawing.Point(6, 66)
        Me.list_doadores_Button.Name = "list_doadores_Button"
        Me.list_doadores_Button.Size = New System.Drawing.Size(177, 23)
        Me.list_doadores_Button.TabIndex = 5
        Me.list_doadores_Button.Text = "Listar doadores"
        Me.list_doadores_Button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Código"
        '
        'codigo_TextBox
        '
        Me.codigo_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.codigo_TextBox.Name = "codigo_TextBox"
        Me.codigo_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.codigo_TextBox.TabIndex = 7
        '
        'armazenamento_DateTimePicker
        '
        Me.armazenamento_DateTimePicker.Location = New System.Drawing.Point(112, 37)
        Me.armazenamento_DateTimePicker.Name = "armazenamento_DateTimePicker"
        Me.armazenamento_DateTimePicker.Size = New System.Drawing.Size(200, 23)
        Me.armazenamento_DateTimePicker.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Data de Armazenamento"
        '
        'id_paciente_TextBox
        '
        Me.id_paciente_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.id_paciente_TextBox.Name = "id_paciente_TextBox"
        Me.id_paciente_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.id_paciente_TextBox.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(112, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Data de Transfusão"
        '
        'recebe_DateTimePicker
        '
        Me.recebe_DateTimePicker.Location = New System.Drawing.Point(112, 37)
        Me.recebe_DateTimePicker.Name = "recebe_DateTimePicker"
        Me.recebe_DateTimePicker.Size = New System.Drawing.Size(200, 23)
        Me.recebe_DateTimePicker.TabIndex = 12
        '
        'id_doador_TextBox
        '
        Me.id_doador_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.id_doador_TextBox.Name = "id_doador_TextBox"
        Me.id_doador_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.id_doador_TextBox.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(112, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 15)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Data de Doação"
        '
        'doacao_DateTimePicker
        '
        Me.doacao_DateTimePicker.Location = New System.Drawing.Point(112, 37)
        Me.doacao_DateTimePicker.Name = "doacao_DateTimePicker"
        Me.doacao_DateTimePicker.Size = New System.Drawing.Size(200, 23)
        Me.doacao_DateTimePicker.TabIndex = 16
        '
        'doacao_Button
        '
        Me.doacao_Button.Location = New System.Drawing.Point(189, 66)
        Me.doacao_Button.Name = "doacao_Button"
        Me.doacao_Button.Size = New System.Drawing.Size(171, 23)
        Me.doacao_Button.TabIndex = 18
        Me.doacao_Button.Text = "Fazer doação"
        Me.doacao_Button.UseVisualStyleBackColor = True
        '
        'armazenar_Button
        '
        Me.armazenar_Button.Location = New System.Drawing.Point(183, 66)
        Me.armazenar_Button.Name = "armazenar_Button"
        Me.armazenar_Button.Size = New System.Drawing.Size(171, 23)
        Me.armazenar_Button.TabIndex = 19
        Me.armazenar_Button.Text = "Armazenar recipiente"
        Me.armazenar_Button.UseVisualStyleBackColor = True
        '
        'recipiente_to_paciente_Button
        '
        Me.recipiente_to_paciente_Button.Location = New System.Drawing.Point(183, 66)
        Me.recipiente_to_paciente_Button.Name = "recipiente_to_paciente_Button"
        Me.recipiente_to_paciente_Button.Size = New System.Drawing.Size(171, 23)
        Me.recipiente_to_paciente_Button.TabIndex = 20
        Me.recipiente_to_paciente_Button.Text = "Atribuir recipiente a paciente"
        Me.recipiente_to_paciente_Button.UseVisualStyleBackColor = True
        '
        'recipientes_Label
        '
        Me.recipientes_Label.AutoSize = True
        Me.recipientes_Label.Location = New System.Drawing.Point(391, 0)
        Me.recipientes_Label.Name = "recipientes_Label"
        Me.recipientes_Label.Size = New System.Drawing.Size(125, 15)
        Me.recipientes_Label.TabIndex = 21
        Me.recipientes_Label.Text = "Recipientes de Sangue"
        '
        'doadores_Label
        '
        Me.doadores_Label.AutoSize = True
        Me.doadores_Label.Location = New System.Drawing.Point(391, 235)
        Me.doadores_Label.Name = "doadores_Label"
        Me.doadores_Label.Size = New System.Drawing.Size(57, 15)
        Me.doadores_Label.TabIndex = 22
        Me.doadores_Label.Text = "Doadores"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.id_doador_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.doacao_DateTimePicker)
        Me.GroupBox1.Controls.Add(Me.list_doadores_Button)
        Me.GroupBox1.Controls.Add(Me.doacao_Button)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 245)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 103)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Doador"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.id_paciente_TextBox)
        Me.GroupBox2.Controls.Add(Me.recebe_DateTimePicker)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.recipiente_to_paciente_Button)
        Me.GroupBox2.Controls.Add(Me.list_pacientes_Button)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 364)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 103)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paciente"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.codigo_TextBox)
        Me.GroupBox3.Controls.Add(Me.armazenamento_DateTimePicker)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.reci_disponiveis_button)
        Me.GroupBox3.Controls.Add(Me.armazenar_Button)
        Me.GroupBox3.Controls.Add(Me.recipientes_todos_Button)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(367, 126)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Recipientes"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 479)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.doadores_Label)
        Me.Controls.Add(Me.recipientes_Label)
        Me.Controls.Add(Me.listar_pacientes_ListBox)
        Me.Controls.Add(Me.Recipientes_box)
        Me.Name = "Form4"
        Me.Text = "Gestão de Recipientes de Sangue"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Recipientes_box As ListBox
    Friend WithEvents recipientes_todos_Button As Button
    Friend WithEvents reci_disponiveis_button As Button
    Friend WithEvents listar_pacientes_ListBox As ListBox
    Friend WithEvents list_pacientes_Button As Button
    Friend WithEvents list_doadores_Button As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents codigo_TextBox As TextBox
    Friend WithEvents armazenamento_DateTimePicker As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents id_paciente_TextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents recebe_DateTimePicker As DateTimePicker
    Friend WithEvents id_doador_TextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents doacao_DateTimePicker As DateTimePicker
    Friend WithEvents doacao_Button As Button
    Friend WithEvents armazenar_Button As Button
    Friend WithEvents recipiente_to_paciente_Button As Button
    Friend WithEvents recipientes_Label As Label
    Friend WithEvents doadores_Label As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
