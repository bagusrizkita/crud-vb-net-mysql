Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class Form1
    Sub kosongkan()
        txtNama.Clear()
        txtNpm.Clear()
        txtAlamat.Clear()
        txtTlp.Clear()
    End Sub
    Sub aturDGV()
        Try
            dgv.Columns(0).Width = 70
            dgv.Columns(1).Width = 70
            dgv.Columns(2).Width = 130
            dgv.Columns(3).Width = 100
            dgv.Columns(0).HeaderText = "Nama"
            dgv.Columns(1).HeaderText = "Npm"
            dgv.Columns(2).HeaderText = "Alamat"
            dgv.Columns(3).HeaderText = "Tlp"
        Catch ex As Exception
        End Try
    End Sub
    Sub tampilsiswa()
        Call koneksi()
        da = New MySqlDataAdapter("select nama, npm, alamat, tlp from pelajar", conn)
        ds = New DataSet
        da.Fill(ds, "pelajar")
        dgv.DataSource = ds.Tables("pelajar")
    End Sub
    Sub hapusSiswa()
        Try
            Call koneksi()
            Dim str As String
            str = "delete from pelajar where npm = '" & txtNpm.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Siswa Berhasil Dihapus.")
        Catch ex As Exception
            MessageBox.Show("Data Siswa Gagal Dihapus.")
        End Try
    End Sub
    Sub tambahSiswa()
        Try
            Call koneksi()
            Dim str As String
            str = "insert into pelajar values('','" & txtNama.Text & "','" & txtNpm.Text & "', '" & txtAlamat.Text & "', '" & txtTlp.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Siswa Berhasil Diinput.")
        Catch ex As Exception
            MessageBox.Show("Data Siswa Gagal Diinput.")
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub editSiswa()
        Try
            Call koneksi()
            Dim str As String
            str = "Update pelajar set nama = '" & txtNama.Text & "', alamat = '" & txtAlamat.Text & "' where npm = '" & txtNpm.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Siswa Berhasil Disimpan.")
        Catch ex As Exception
            MessageBox.Show("Data Siswa Gagal Disimpan.")
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilsiswa()
        Call aturDGV()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Call hapusSiswa()
        Call tampilsiswa()
        Call kosongkan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Call editSiswa()
        Call tampilsiswa()
        Call kosongkan()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSelect.Click
        txtNama.Text = dgv.SelectedCells(0).Value
        txtNpm.Text = dgv.SelectedCells(1).Value
        txtAlamat.Text = dgv.SelectedCells(2).Value
        txtTlp.Text = dgv.SelectedCells(3).Value

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call tambahSiswa()
        Call tampilsiswa()
        Call kosongkan()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()

    End Sub
End Class
