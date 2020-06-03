
Public Class Form1
    Private newClass As New Class1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        dt = newClass.getEmployees()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = newClass.getNumEmployees.ToString()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = newClass.getXML()
    End Sub
End Class
