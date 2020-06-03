Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Private Function getConn() As String
        Return My.Settings.Database1ConnectionString
    End Function
    Private Function getPeople() As DataTable
        Dim sql As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        Dim dt As New DataTable
        sql = "select * from People"
        conn = New SqlConnection(getConn())
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Private Sub addPeople(fname As String, lname As String)
        Dim sql As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        sql = "insert into people(firstname, lastname) values(@fname, @lname)"
        conn = New SqlConnection(getConn())
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.AddWithValue("@fname", txtFname.Text)
        cmd.Parameters.AddWithValue("@lname", txtLname.Text)
        cmd.ExecuteNonQuery()
        conn.Close()
        Button4.PerformClick()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dt As New DataTable
        dt = getPeople()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Label1.Text = dr.Cells(0).Value.ToString()
            txtFname.Text = dr.Cells(1).Value.ToString()
            txtLname.Text = dr.Cells(2).Value.ToString()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            addPeople(txtFname.Text, txtLname.Text)
            MessageBox.Show("Added")
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim sql As String
            Dim conn As SqlConnection
            Dim cmd As SqlCommand
            sql = "update People set FirstName=@fname, LastName=@lname where people_id = @id"
            conn = New SqlConnection(getConn())
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@fname", txtFname.Text)
            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
            cmd.Parameters.AddWithValue("@id", CInt(Label1.Text))
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Button4.PerformClick()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        sql = "delete from people where people_id = @id"
        conn = New SqlConnection(getConn())
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.AddWithValue("@id", CInt(Label1.Text))
        cmd.ExecuteNonQuery()
        conn.Close()
        Button4.PerformClick()
    End Sub
End Class
