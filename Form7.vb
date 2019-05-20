Imports System.Data.OleDb
Public Class Form7
    Dim sqlnya As String
    Sub panggildata()
        konek()
        da = New OleDb.OleDbDataAdapter("SELECT * from tb_user", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tb_user")
        DataGridView1.DataSource = ds.Tables("tb_user")
        DataGridView1.Enabled = True

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
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data Masih Ada yang Kosong !", MsgBoxStyle.Critical, "WARNING")
            TextBox1.Focus()
        Else
            Call konek()
            Dim str As String
            str = "insert into tb_user values ('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')"
            cmd = New OleDbCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Simpan Data Berhasil Dilakukan")
            Call panggildata()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlnya = "delete from tb_user where nama='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil DIhapus")
        Call panggildata()
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(2, i).Value
        ComboBox1.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(3, i).Value
        TextBox4.Text = DataGridView1.Item(4, i).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlnya = "update tb_user set username='" & TextBox3.Text & "',jabatan='" & ComboBox1.Text & "',no_hp='" & TextBox2.Text & "',pass='" & TextBox4.Text & "' where nama='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terubah")
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Call panggildata()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()
        Me.Close()
    End Sub
End Class