Imports System.Data.OleDb
Module mdlcon
    Public CONN As OleDbConnection
    Public DA As OleDbDataAdapter
    Public DS As DataSet
    Public CMD As OleDbCommand
    Public DR As OleDbDataReader

    Sub KoneksiDB()
        Try
            CONN = New OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=db.accdb")
            CONN.Open()
            'MsgBox("Koneksi Database SUKSES")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
