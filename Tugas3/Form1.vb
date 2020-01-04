Public Class Form1
    Sub kosongkan()
        txtKode.Text = ""
        txtNama.Text = ""
        cmbKelamin.Text = ""
        cmbJurusan.Text = ""
        txtTelp.Text = ""
        txtEmail.Text = ""
        txtAlamat.Text = ""
        txtKode.Focus()
    End Sub
    Sub matikan()
        txtKode.Enabled = False
        txtNama.Enabled = False
        txtTelp.Enabled = False
        txtEmail.Enabled = False
        txtAlamat.Enabled = False
        cmbKelamin.Enabled = False
        cmbJurusan.Enabled = False
    End Sub
    Sub hidupkan()
        txtKode.Enabled = True
        txtNama.Enabled = True
        txtTelp.Enabled = True
        txtEmail.Enabled = True
        txtAlamat.Enabled = True
        cmbKelamin.Enabled = True
        cmbJurusan.Enabled = True
    End Sub
    Sub tampilkan()
        Call KoneksiDB()
        DA = New OleDb.OleDbDataAdapter("select * from kontak", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call matikan()
        Call tampilkan()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Call hidupkan()
        Call kosongkan()

    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call matikan()
        Call kosongkan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKode.Text = "" Or txtNama.Text = "" Or cmbKelamin.Text = "" Then
            MsgBox("Data Belum Lengkap..!", MsgBoxStyle.Exclamation, "")
            Exit Sub
        Else
            Call KoneksiDB()
            CMD = New OleDb.OleDbCommand("select * from kontak where npm='" & txtKode.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call KoneksiDB()
                Dim simpan As String
                simpan = "insert into kontak values('" & txtKode.Text & "','" & txtNama.Text & "','" & cmbKelamin.Text & "','" & cmbJurusan.Text & "','" & txtTelp.Text & "','" & txtEmail.Text & "','" & txtAlamat.Text & "')"
                CMD = New OleDb.OleDbCommand(simpan, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Input Data Sukses!", MsgBoxStyle.DefaultButton1, "")
            Else
                MsgBox("Kode sudah ada.", MsgBoxStyle.Exclamation, "")
            End If
            Call matikan()
            Call kosongkan()
            Call tampilkan()
        End If
    End Sub

    Private Sub DGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        txtKode.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        txtNama.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        cmbKelamin.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        cmbJurusan.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        txtTelp.Text = DGV.Rows(e.RowIndex).Cells(4).Value
        txtEmail.Text = DGV.Rows(e.RowIndex).Cells(5).Value
        txtAlamat.Text = DGV.Rows(e.RowIndex).Cells(6).Value

        Call hidupkan()
        txtKode.Enabled = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtKode.Text = "" Or txtNama.Text = "" Or cmbKelamin.Text = "" Then
            MsgBox("Data belum lengkap!", MsgBoxStyle.Exclamation, "")
            Exit Sub
        Else
            Call KoneksiDB()
            CMD = New OleDb.OleDbCommand("update kontak set nama='" & txtNama.Text & "',jenis_kelamin='" & cmbKelamin.Text & "',jurusan='" & cmbJurusan.Text & "',no_telp='" & txtTelp.Text & "',email='" & txtEmail.Text & "',alamat='" & txtAlamat.Text & "' where npm='" & txtKode.Text & "'", CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Update Data Sukses!", MsgBoxStyle.DefaultButton2, "")
            Call matikan()
            Call kosongkan()
            Call tampilkan()
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If txtKode.Text = "" Then
            MsgBox("Tidak ada data yang dihapus!", MsgBoxStyle.Exclamation, "")
            Exit Sub
        Else
            If MessageBox.Show("Yakin akan menghapus?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call KoneksiDB()
                CMD = New OleDb.OleDbCommand("delete from kontak where npm='" & txtKode.Text & "'", CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Berhasil Hapus Data!", MsgBoxStyle.DefaultButton1, "")
                Call matikan()
                Call kosongkan()
                Call tampilkan()
            Else
                Call matikan()
                Call kosongkan()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Ferry Kurniawan | 180210099
Arif Hernawan | 180210071
Chania Aprilia Yonanta | 180210081
Galih Pragasiwi | 180210091
Windy")
    End Sub
End Class
