Public Class Frm_Login
    Dim Koneksi As New ClassKoneksi
    Dim DataTabelOperator As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim QUERY As String
        Dim username As String

        QUERY = "SELECT * FROM pelajar Where NRS = '" & txtUserName.Text & "' and NIP = '" & txtPassword.Text & "'"
        DataTabelOperator = Koneksi.ExecuteQuery(QUERY)
        If DataTabelOperator.Rows.Count = 0 Then
            MsgBox("Username atau password salah !", MsgBoxStyle.Critical, "Peringatan !")
        Else
            username = DataTabelOperator.Rows(0).Item(1)

            MsgBox("Selamat Datang " & username, MsgBoxStyle.Information, "Informasi")
            txtUserName.Text = vbNull
            txtPassword.Text = vbNull

            Frm_Menu.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub

    Private Sub Frm_Login_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub


End Class
