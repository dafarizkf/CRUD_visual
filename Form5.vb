﻿Imports System.Data.OleDb
Public Class Form5
    Dim sqlnya As String
    Dim gam As String

    Sub tampilcombo()
        Call konek()
        Dim str As String
        str = "select rayon from tb_rayon"
        cmd = New OleDbCommand(str, conn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                ComboBox1.Items.Add(dr("RAYON"))
            Loop
        Else
        End If

    End Sub
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub
    Sub panggildata()
        konek()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_siswa")
        DataGridView1.DataSource = ds.Tables("tb_siswa")
        DataGridView1.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
         If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Data Masih Ada yang Kosong !", MsgBoxStyle.Critical, "WARNING")
            TextBox1.Focus()
        Else
            Call konek()
            Dim rdb As String = ""
            If RadioButton1.Checked = True Then
                rdb = "Pria"
            ElseIf RadioButton2.Checked = True Then
                rdb = "Wanita"
            End If
            Dim str As String
            str = "insert into tb_siswa values ('" & TextBox1.Text & "','" & TextBox2.Text & "', ' " & rdb & " ', '" & DateTimePicker1.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox3.Text & "','" & TextBox7.Text & "')"
            cmd = New OleDbCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Simpan Data Siswa Berhasil Dilakukan")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            Call panggildata()
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilcombo()
        Call panggildata()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlnya = "delete from tb_siswa where nis='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil DIhapus")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Call panggildata()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        If DataGridView1.Item(2, i).Value = "Wanita" Then
            RadioButton2.Checked = True
        Else
            RadioButton1.Checked = True
        End If
        DateTimePicker1.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        ComboBox1.Text = DataGridView1.Item(5, i).Value
        ComboBox2.Text = DataGridView1.Item(6, i).Value
        TextBox4.Text = DataGridView1.Item(7, i).Value
        TextBox5.Text = DataGridView1.Item(8, i).Value
        ComboBox3.Text = DataGridView1.Item(9, i).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rdb As String = ""
        If RadioButton1.Checked = True Then
            rdb = "Pria"
        ElseIf RadioButton2.Checked = True Then
            rdb = "Wanita"
        End If
        sqlnya = "UPDATE tb_siswa set nama =  '" & TextBox2.Text & "', jk = '" & rdb & "', ttl ='" & DateTimePicker1.Text & "', alamat = '" & TextBox3.Text & "', rayon = '" & ComboBox1.Text & "', jurusan = '" & ComboBox2.Text & "', email = '" & TextBox4.Text & "', nohp = '" & TextBox5.Text & "', goldarah = '" & ComboBox3.Text & "',foto = '" & TextBox7.Text & "' where nis = '" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("data terupdate !")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Call panggildata()
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        konek()
        da = New OleDb.OleDbDataAdapter("select * from tb_siswa where nama like '%" & TextBox6.Text & "%'", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_siswa")
        DataGridView1.DataSource = ds.Tables("tb_siswa")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
        Me.Close()
    End Sub
    Private PathFile As String = Nothing
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
            Button5.Enabled = True
            PathFile = OpenFileDialog1.FileName
            TextBox8.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
            TextBox7.Text = OpenFileDialog1.FileName
            gam = OpenFileDialog1.FileName
            PictureBox1.Image = Image.FromFile(TextBox7.Text)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class