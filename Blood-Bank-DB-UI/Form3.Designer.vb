<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.nome_box = New System.Windows.Forms.TextBox()
        Me.morada_box = New System.Windows.Forms.TextBox()
        Me.apelido_box = New System.Windows.Forms.TextBox()
        Me.telemovel_box = New System.Windows.Forms.TextBox()
        Me.idade_box = New System.Windows.Forms.TextBox()
        Me.CC_box = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Inserir_button = New System.Windows.Forms.Button()
        Me.Edit_button = New System.Windows.Forms.Button()
        Me.Remove_button = New System.Windows.Forms.Button()
        Me.ComboBox_BT = New System.Windows.Forms.ComboBox()
        Me.Fiil_button = New System.Windows.Forms.Button()
        Me.print_box_persons = New System.Windows.Forms.ListBox()
        Me.print_pessoas_button = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Patologias_ListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Medicamentos_ListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.person_type_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Salary_Box = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'nome_box
        '
        Me.nome_box.Location = New System.Drawing.Point(6, 81)
        Me.nome_box.Name = "nome_box"
        Me.nome_box.Size = New System.Drawing.Size(100, 23)
        Me.nome_box.TabIndex = 1
        '
        'morada_box
        '
        Me.morada_box.Location = New System.Drawing.Point(6, 168)
        Me.morada_box.Name = "morada_box"
        Me.morada_box.Size = New System.Drawing.Size(100, 23)
        Me.morada_box.TabIndex = 2
        '
        'apelido_box
        '
        Me.apelido_box.Location = New System.Drawing.Point(6, 125)
        Me.apelido_box.Name = "apelido_box"
        Me.apelido_box.Size = New System.Drawing.Size(100, 23)
        Me.apelido_box.TabIndex = 3
        '
        'telemovel_box
        '
        Me.telemovel_box.Location = New System.Drawing.Point(6, 256)
        Me.telemovel_box.Name = "telemovel_box"
        Me.telemovel_box.Size = New System.Drawing.Size(100, 23)
        Me.telemovel_box.TabIndex = 4
        '
        'idade_box
        '
        Me.idade_box.Location = New System.Drawing.Point(6, 212)
        Me.idade_box.Name = "idade_box"
        Me.idade_box.Size = New System.Drawing.Size(100, 23)
        Me.idade_box.TabIndex = 5
        '
        'CC_box
        '
        Me.CC_box.Location = New System.Drawing.Point(6, 37)
        Me.CC_box.Name = "CC_box"
        Me.CC_box.Size = New System.Drawing.Size(100, 23)
        Me.CC_box.TabIndex = 6
        Me.CC_box.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Cartão Cidadão"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Nome próprio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Apelido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Morada"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Idade"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 238)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Telemóvel"
        '
        'Inserir_button
        '
        Me.Inserir_button.Location = New System.Drawing.Point(6, 421)
        Me.Inserir_button.Name = "Inserir_button"
        Me.Inserir_button.Size = New System.Drawing.Size(75, 23)
        Me.Inserir_button.TabIndex = 13
        Me.Inserir_button.Text = "Inserir"
        Me.Inserir_button.UseVisualStyleBackColor = True
        '
        'Edit_button
        '
        Me.Edit_button.Location = New System.Drawing.Point(292, 421)
        Me.Edit_button.Name = "Edit_button"
        Me.Edit_button.Size = New System.Drawing.Size(75, 23)
        Me.Edit_button.TabIndex = 14
        Me.Edit_button.Text = "Editar"
        Me.Edit_button.UseVisualStyleBackColor = True
        '
        'Remove_button
        '
        Me.Remove_button.Location = New System.Drawing.Point(87, 421)
        Me.Remove_button.Name = "Remove_button"
        Me.Remove_button.Size = New System.Drawing.Size(75, 23)
        Me.Remove_button.TabIndex = 15
        Me.Remove_button.Text = "Remover"
        Me.Remove_button.UseVisualStyleBackColor = True
        '
        'ComboBox_BT
        '
        Me.ComboBox_BT.FormattingEnabled = True
        Me.ComboBox_BT.Items.AddRange(New Object() {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"})
        Me.ComboBox_BT.Location = New System.Drawing.Point(6, 37)
        Me.ComboBox_BT.Name = "ComboBox_BT"
        Me.ComboBox_BT.Size = New System.Drawing.Size(160, 23)
        Me.ComboBox_BT.TabIndex = 16
        Me.ComboBox_BT.Text = "Escolha o tipo de sangue"
        '
        'Fiil_button
        '
        Me.Fiil_button.Location = New System.Drawing.Point(168, 421)
        Me.Fiil_button.Name = "Fiil_button"
        Me.Fiil_button.Size = New System.Drawing.Size(118, 23)
        Me.Fiil_button.TabIndex = 17
        Me.Fiil_button.Text = "Preencher Campos"
        Me.Fiil_button.UseVisualStyleBackColor = True
        '
        'print_box_persons
        '
        Me.print_box_persons.FormattingEnabled = True
        Me.print_box_persons.ItemHeight = 15
        Me.print_box_persons.Location = New System.Drawing.Point(356, 27)
        Me.print_box_persons.Name = "print_box_persons"
        Me.print_box_persons.Size = New System.Drawing.Size(288, 379)
        Me.print_box_persons.TabIndex = 18
        '
        'print_pessoas_button
        '
        Me.print_pessoas_button.Location = New System.Drawing.Point(539, 421)
        Me.print_pessoas_button.Name = "print_pessoas_button"
        Me.print_pessoas_button.Size = New System.Drawing.Size(105, 23)
        Me.print_pessoas_button.TabIndex = 19
        Me.print_pessoas_button.Text = "Mostrar Pessoas"
        Me.print_pessoas_button.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Tipo de Sangue"
        '
        'Patologias_ListBox
        '
        Me.Patologias_ListBox.FormattingEnabled = True
        Me.Patologias_ListBox.Items.AddRange(New Object() {"Cancro", "Diabetes", "Doença autoimune", "Doença de Chagas", "Doença Psiquátrica", "Doença Pulmonar", "Epilepsia", "Hepatite", "HIV", "HTLV", "Malária", "Sífilis", "Tuberculose"})
        Me.Patologias_ListBox.Location = New System.Drawing.Point(6, 92)
        Me.Patologias_ListBox.Name = "Patologias_ListBox"
        Me.Patologias_ListBox.Size = New System.Drawing.Size(160, 130)
        Me.Patologias_ListBox.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Patologias"
        '
        'Medicamentos_ListBox
        '
        Me.Medicamentos_ListBox.FormattingEnabled = True
        Me.Medicamentos_ListBox.Items.AddRange(New Object() {"Acitretina", "Calvície", "Dutasterida", "Etretinato", "Finasterida", "Heparina", "Isotrentinoína", "Varfarina"})
        Me.Medicamentos_ListBox.Location = New System.Drawing.Point(6, 250)
        Me.Medicamentos_ListBox.Name = "Medicamentos_ListBox"
        Me.Medicamentos_ListBox.Size = New System.Drawing.Size(160, 130)
        Me.Medicamentos_ListBox.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 15)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Medicamentos"
        '
        'person_type_ComboBox
        '
        Me.person_type_ComboBox.FormattingEnabled = True
        Me.person_type_ComboBox.Items.AddRange(New Object() {"Doador", "Paciente", "Funcionário", "Gestor"})
        Me.person_type_ComboBox.Location = New System.Drawing.Point(6, 22)
        Me.person_type_ComboBox.Name = "person_type_ComboBox"
        Me.person_type_ComboBox.Size = New System.Drawing.Size(100, 23)
        Me.person_type_ComboBox.TabIndex = 25
        Me.person_type_ComboBox.Text = "Entidade"
        '
        'Salary_Box
        '
        Me.Salary_Box.Location = New System.Drawing.Point(6, 66)
        Me.Salary_Box.Name = "Salary_Box"
        Me.Salary_Box.Size = New System.Drawing.Size(100, 23)
        Me.Salary_Box.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 15)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Salário"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(356, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Entidades"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CC_box)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nome_box)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.apelido_box)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.morada_box)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.idade_box)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.telemovel_box)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(116, 288)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados Pessoais"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.person_type_ComboBox)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Salary_Box)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(115, 100)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Entidade"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.ComboBox_BT)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Patologias_ListBox)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Medicamentos_ListBox)
        Me.GroupBox3.Location = New System.Drawing.Point(148, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(177, 391)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ficha Clínica"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 456)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.print_pessoas_button)
        Me.Controls.Add(Me.print_box_persons)
        Me.Controls.Add(Me.Fiil_button)
        Me.Controls.Add(Me.Remove_button)
        Me.Controls.Add(Me.Edit_button)
        Me.Controls.Add(Me.Inserir_button)
        Me.Name = "Form3"
        Me.Tag = "String"
        Me.Text = "Gestão de Entidades"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nome_box As TextBox
    Friend WithEvents morada_box As TextBox
    Friend WithEvents apelido_box As TextBox
    Friend WithEvents telemovel_box As TextBox
    Friend WithEvents idade_box As TextBox
    Friend WithEvents CC_box As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Inserir_button As Button
    Friend WithEvents Edit_button As Button
    Friend WithEvents Remove_button As Button
    Friend WithEvents ComboBox_BT As ComboBox
    Friend WithEvents Fiil_button As Button
    Friend WithEvents print_box_persons As ListBox
    Friend WithEvents print_pessoas_button As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Patologias_ListBox As CheckedListBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Medicamentos_ListBox As CheckedListBox
    Friend WithEvents Label9 As Label
    Friend WithEvents person_type_ComboBox As ComboBox
    Friend WithEvents Salary_Box As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
