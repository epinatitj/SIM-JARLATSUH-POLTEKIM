Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class ClassKoneksi
    Dim SQL As String
    Dim Cn As New MySqlConnection
    Dim Cmd As New MySql.Data.MySqlClient.MySqlCommand
    Dim Da As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim Ds As New DataSet
    Dim Dt As DataTable

    Sub CobaOpenConn()
        Cn = New MySqlConnection("server=localhost;" _
           & "user id=root;" _
           & "password=;" _
           & "database=simpoltekim")
        Try
            Cn.Open()
            MsgBox("Koneksi Berhasil Tersambung")
        Catch ex As Exception
            MsgBox("Koneksi Gagal " & vbCrLf & "Pesan Error : " & ex.Message, MsgBoxStyle.Critical, "Peringatan")
        End Try
    End Sub
    Sub CobaCloseConn()
        Try
            If Not IsNothing(Cn) Then
                Cn.Close()
                Cn = Nothing
                MsgBox("Koneksi Berhasil Terputus")
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal Diputus " & vbCrLf & "Pesan Error : " & ex.Message, MsgBoxStyle.Critical, "Peringatan")
        End Try
    End Sub
    Public Function OpenConn() As Boolean
        Cn = New MySqlConnection("server=localhost;" _
           & "user id=root;" _
           & "password=;" _
           & "database=simpoltekim")
        Cn.Open()
        If Cn.State <> ConnectionState.Open Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub CloseConn()
        If Not IsNothing(Cn) Then
            Cn.Close()
            Cn = Nothing
        End If
    End Sub
    Public Sub ExecuteNonQuery(ByVal Query As String)
        If Not OpenConn() Then
            MsgBox("Koneksi Gagal..!!", MsgBoxStyle.Critical, "Access Failed..!!")
            Exit Sub
        End If

        Cmd = New MySql.Data.MySqlClient.MySqlCommand
        Cmd.Connection = Cn
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Query
        Cmd.ExecuteNonQuery()
        Cmd = Nothing
        CloseConn()
    End Sub

    Public Function ExecuteQuery(ByVal Query As String) As DataTable
        If Not OpenConn() Then
            MsgBox("Koneksi Gagal..!!", MsgBoxStyle.Critical, "Access Failed")
            Return Nothing
            Exit Function
        End If

        Cmd = New MySql.Data.MySqlClient.MySqlCommand(Query, Cn)
        Da = New MySql.Data.MySqlClient.MySqlDataAdapter
        Da.SelectCommand = Cmd
        Ds = New Data.DataSet
        Da.Fill(Ds)

        Dt = Ds.Tables(0)

        Return Dt

        Dt = Nothing
        Ds = Nothing
        Da = Nothing
        Cmd = Nothing

        CloseConn()

    End Function
End Class