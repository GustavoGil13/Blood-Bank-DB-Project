<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BS_select = New System.Windows.Forms.ComboBox()
        Me.BS_in = New System.Windows.Forms.Button()
        Me.Criar_Button = New System.Windows.Forms.Button()
        Me.morada_TextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nome_TextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BS_select
        '
        Me.BS_select.FormattingEnabled = True
        Me.BS_select.Items.AddRange(New Object() {"IPO", "São João", "Centro de Sangue e Transplantação de Coimbra"})
        Me.BS_select.Location = New System.Drawing.Point(12, 30)
        Me.BS_select.Name = "BS_select"
        Me.BS_select.Size = New System.Drawing.Size(272, 23)
        Me.BS_select.TabIndex = 0
        Me.BS_select.Text = "Escolha o Banco de Sangue"
        '
        'BS_in
        '
        Me.BS_in.Location = New System.Drawing.Point(72, 71)
        Me.BS_in.Name = "BS_in"
        Me.BS_in.Size = New System.Drawing.Size(75, 23)
        Me.BS_in.TabIndex = 1
        Me.BS_in.Text = "Entrar"
        Me.BS_in.UseVisualStyleBackColor = True
        '
        'Criar_Button
        '
        Me.Criar_Button.Location = New System.Drawing.Point(23, 221)
        Me.Criar_Button.Name = "Criar_Button"
        Me.Criar_Button.Size = New System.Drawing.Size(75, 23)
        Me.Criar_Button.TabIndex = 2
        Me.Criar_Button.Text = "Criar"
        Me.Criar_Button.UseVisualStyleBackColor = True
        '
        'morada_TextBox
        '
        Me.morada_TextBox.Location = New System.Drawing.Point(12, 189)
        Me.morada_TextBox.Name = "morada_TextBox"
        Me.morada_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.morada_TextBox.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Morada"
        '
        'nome_TextBox
        '
        Me.nome_TextBox.Location = New System.Drawing.Point(12, 135)
        Me.nome_TextBox.Name = "nome_TextBox"
        Me.nome_TextBox.Size = New System.Drawing.Size(100, 23)
        Me.nome_TextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nome do Banco de Sangue"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 287)
        Me.Controls.Add(Me.morada_TextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nome_TextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Criar_Button)
        Me.Controls.Add(Me.BS_in)
        Me.Controls.Add(Me.BS_select)
        Me.Name = "Form1"
        Me.Text = "Banco de Sangue"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BS_select As ComboBox
    Friend WithEvents BS_in As Button
    Friend WithEvents Criar_Button As Button
    Friend WithEvents morada_TextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents nome_TextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
