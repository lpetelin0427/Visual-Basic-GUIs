Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = DataSet1.Tables("Products")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub fillData_Click(sender As Object, e As EventArgs) Handles fillData.Click

        Dim newRow As DataRow = DataSet1.Tables("Products").NewRow()

        newRow.Item("ProductName") = "Chai"
        newRow.Item("UnitPrice") = 12
        newRow.Item("UnitsInStock") = 300
        newRow.Item("SupplierID") = 1
        DataSet1.Tables("Products").Rows.Add(newRow)

        Dim newRow2 As DataRow = DataSet1.Tables("Products").NewRow()

        newRow2.Item("ProductName") = "Aniseed Syrup"
        newRow2.Item("UnitPrice") = 8.08
        newRow2.Item("UnitsInStock") = 200
        newRow2.Item("SupplierID") = 2
        DataSet1.Tables("Products").Rows.Add(newRow2)

        Dim newRow3 As DataRow = DataSet1.Tables("Products").NewRow()
        newRow3.Item("ProductName") = "Ikura"
        newRow3.Item("UnitPrice") = 5.99
        newRow3.Item("UnitsInStock") = 450
        newRow3.Item("SupplierID") = 3
        DataSet1.Tables("Products").Rows.Add(newRow3)


        Dim newRow4 As DataRow = DataSet1.Tables("Suppliers").NewRow()
        newRow4.Item("CompanyName") = "Random Company Name"
        newRow4.Item("SupplierID") = 1
        DataSet1.Tables("Suppliers").Rows.Add(newRow4)

        Dim newRow5 As DataRow = DataSet1.Tables("Suppliers").NewRow()
        newRow5.Item("CompanyName") = "Another Random Company Name"
        newRow5.Item("SupplierID") = 2
        DataSet1.Tables("Suppliers").Rows.Add(newRow5)

        Dim newRow6 As DataRow = DataSet1.Tables("Suppliers").NewRow()
        newRow6.Item("CompanyName") = "A Third Random Company Name"
        newRow6.Item("SupplierID") = 3
        DataSet1.Tables("Suppliers").Rows.Add(newRow6)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim Product As Integer = CInt(DataGridView1.SelectedRows(0).Cells("ProductID").Value)
        Dim rows() As DataRow = DataSet1.Tables("Products").Select("ProductID=" & Product)
        Dim supplierList As String = ""
        For Each r As DataRow In rows(0).GetChildRows("productsSuppliers")
            supplierList += r.Item("CompanyName").ToString() & Environment.NewLine
        Next
        MessageBox.Show(supplierList)
    End Sub
End Class
