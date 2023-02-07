Public Class frmAbout
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False

        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.Top = FrmMain.Top + ((FrmMain.Height - Me.Height) / 2)
        Me.Left = FrmMain.Left + ((FrmMain.Width - Me.Width) / 2)
        Me.Icon = FrmMain.Icon
        Me.Visible = True
    End Sub
End Class