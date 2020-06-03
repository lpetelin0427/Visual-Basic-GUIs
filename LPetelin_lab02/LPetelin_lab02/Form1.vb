Public Class Form1
    Private imageNum As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '*********Couldn't figure out how to add multiple items to the TreeView so I just left it at one. Spent 2 hours googling************

        If ListBox1.SelectedItem IsNot Nothing Then
            TreeView1.Nodes.Add(New TreeNode(ListBox1.SelectedItem))
        Else
            MessageBox.Show("Please select an Item from the ListBox to add to the TreeView")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TreeView1.SelectedNode IsNot Nothing Then
            ListBox1.Items.Add(TreeView1.SelectedNode)
        Else
            MessageBox.Show("Please select a Node from the Treeview to add to the ListBox")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text IsNot "" Then
            ListBox1.Items.Add(TextBox1.Text)
        Else
            MessageBox.Show("Please enter an item to add to the ListBox")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TreeView1.ExpandAll()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TreeView1.CollapseAll()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        Static counter As Integer = 1

        If counter > ImageList2.Images.Count - 1 Then
            counter = 0
        End If
        PictureBox1.Image = ImageList2.Images(counter)
        counter += 1
    End Sub
End Class
