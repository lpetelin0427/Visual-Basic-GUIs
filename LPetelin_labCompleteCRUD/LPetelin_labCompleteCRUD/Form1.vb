Public Class Form1
    Public index As Integer = 0

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using db As New Database1Entities
            Dim p = New Table()
            p.FirstName = txtFname.Text
            p.LastName = txtLname.Text
            p.Id = CInt(txtID.Text)
            db.Tables.Add(p)
            db.SaveChanges()
            btnView.PerformClick()
        End Using
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Using db As New Database1Entities
            Dim query = From p In db.Tables
                        Select p.Id, p.FirstName, p.LastName

            DataGridView1.DataSource = query.ToList()

        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        txtEditFname.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
        txtEditLname.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Using db As New Database1Entities
                Dim toDelete = db.Tables.Where(Function(o) o.Id = index).FirstOrDefault()
                If Not IsNothing(toDelete) Then
                    db.Tables.Remove(toDelete)
                End If
                db.SaveChanges()
            End Using
        Catch ex As Exception
            MessageBox.Show("hey error fam" & ex.Message)
        End Try
        btnView.PerformClick()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Using db As New Database1Entities
                Dim toEdit = (From p In db.Tables
                              Where p.Id = index
                              Select p).FirstOrDefault()
                toEdit.FirstName = txtEditFname.Text
                toEdit.LastName = txtEditLname.Text

                db.SaveChanges()
            End Using
        Catch ex As Exception
            MessageBox.Show("hey error fam" & ex.Message)
        End Try
        btnView.PerformClick()
    End Sub
End Class
