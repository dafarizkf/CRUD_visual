Imports System.Data.OleDb
Public Class Form6
    Dim sqlnya As String
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        TextBox1.Text = ""

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


    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Form4.TextBox1.Text = DataGridView1.Item(0, i).Value
        Form4.TextBox2.Text = DataGridView1.Item(1, i).Value
        Form4.TextBox3.Text = DataGridView1.Item(5, i).Value
        Form4.TextBox4.Text = DataGridView1.Item(6, i).Value
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
    End Sub
End Class