<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.print_box = New System.Windows.Forms.ListBox()
        Me.Tables_name = New System.Windows.Forms.ComboBox()
        Me.Insert_Person = New System.Windows.Forms.Button()
        Me.gestor_box = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BS_Box = New System.Windows.Forms.ListBox()
        Me.RS_management_button = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nome_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.clientes_Button = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'print_box
        '
        Me.print_box.FormattingEnabled = True
        Me.print_box.ItemHeight = 15
        Me.print_box.Location = New System.Drawing.Point(12, 169)
        Me.print_box.Name = "print_box"
        Me.print_box.Size = New System.Drawing.Size(283, 289)
        Me.print_box.TabIndex = 0
        '
        'Tables_name
        '
        Me.Tables_name.FormattingEnabled = True
        Me.Tables_name.Items.AddRange(New Object() {"Cliente", "Doador", "Paciente", "Funcionario"})
        Me.Tables_name.Location = New System.Drawing.Point(112, 37)
        Me.Tables_name.Name = "Tables_name"
        Me.Tables_name.Size = New System.Drawing.Size(121, 23)
        Me.Tables_name.TabIndex = 1
        Me.Tables_name.Text = "Entidade"
        '
        'Insert_Person
        '
        Me.Insert_Person.Location = New System.Drawing.Point(15, 22)
        Me.Insert_Person.Name = "Insert_Person"
        Me.Insert_Person.Size = New System.Drawing.Size(201, 23)
        Me.Insert_Person.TabIndex = 3
        Me.Insert_Person.Text = "Gestão de Entidades"
        Me.Insert_Person.UseVisualStyleBackColor = True
        '
        'gestor_box
        '
        Me.gestor_box.FormattingEnabled = True
        Me.gestor_box.ItemHeight = 15
        Me.gestor_box.Location = New System.Drawing.Point(12, 82)
        Me.gestor_box.Name = "gestor_box"
        Me.gestor_box.Size = New System.Drawing.Size(283, 34)
        Me.gestor_box.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Gestor"
        '
        'BS_Box
        '
        Me.BS_Box.FormattingEnabled = True
        Me.BS_Box.ItemHeight = 15
        Me.BS_Box.Location = New System.Drawing.Point(12, 27)
        Me.BS_Box.Name = "BS_Box"
        Me.BS_Box.Size = New System.Drawing.Size(283, 34)
        Me.BS_Box.TabIndex = 7
        '
        'RS_management_button
        '
        Me.RS_management_button.Location = New System.Drawing.Point(15, 51)
        Me.RS_management_button.Name = "RS_management_button"
        Me.RS_management_button.Size = New System.Drawing.Size(201, 23)
        Me.RS_management_button.TabIndex = 8
        Me.RS_management_button.Text = "Gestão de Recipientes de Sangue"
        Me.RS_management_button.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Banco de Sangue"
        '
        'nome_TextBox
        '
        Me.nome_TextBox.Location = New System.Drawing.Point(6, 37)
        Me.nome_TextBox.Name = "nome_TextBox"
        Me.nome_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.nome_TextBox.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Nome"
        '
        'clientes_Button
        '
        Me.clientes_Button.Location = New System.Drawing.Point(15, 80)
        Me.clientes_Button.Name = "clientes_Button"
        Me.clientes_Button.Size = New System.Drawing.Size(201, 23)
        Me.clientes_Button.TabIndex = 13
        Me.clientes_Button.Text = "Gestão de Clientes e Encomendas"
        Me.clientes_Button.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Entidade"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RS_management_button)
        Me.GroupBox1.Controls.Add(Me.Insert_Person)
        Me.GroupBox1.Controls.Add(Me.clientes_Button)
        Me.GroupBox1.Location = New System.Drawing.Point(326, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(233, 111)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menu"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.nome_TextBox)
        Me.GroupBox2.Controls.Add(Me.Tables_name)
        Me.GroupBox2.Location = New System.Drawing.Point(326, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(242, 72)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pesquisar"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 470)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BS_Box)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gestor_box)
        Me.Controls.Add(Me.print_box)
        Me.Name = "Form2"
        Me.Text = "Gestão do Banco de Sangue"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents print_box As ListBox
    Friend WithEvents Tables_name As ComboBox
    Friend WithEvents Insert_Person As Button
    Friend WithEvents gestor_box As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BS_Box As ListBox
    Friend WithEvents RS_management_button As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents nome_TextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents clientes_Button As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
