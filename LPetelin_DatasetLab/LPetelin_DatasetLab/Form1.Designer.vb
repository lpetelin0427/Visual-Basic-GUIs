<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataSet1 = New System.Data.DataSet()
        Me.Products = New System.Data.DataTable()
        Me.ProductID = New System.Data.DataColumn()
        Me.ProductName = New System.Data.DataColumn()
        Me.UnitPrice = New System.Data.DataColumn()
        Me.UnitsInStock = New System.Data.DataColumn()
        Me.SupplierID = New System.Data.DataColumn()
        Me.Suppliers = New System.Data.DataTable()
        Me.SupID = New System.Data.DataColumn()
        Me.CompanyName = New System.Data.DataColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.fillData = New System.Windows.Forms.Button()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Products, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Suppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Relations.AddRange(New System.Data.DataRelation() {New System.Data.DataRelation("productsSuppliers", "Products", "Suppliers", New String() {"SupplierID"}, New String() {"SupplierID"}, False)})
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.Products, Me.Suppliers})
        '
        'Products
        '
        Me.Products.Columns.AddRange(New System.Data.DataColumn() {Me.ProductID, Me.ProductName, Me.UnitPrice, Me.UnitsInStock, Me.SupplierID})
        Me.Products.Constraints.AddRange(New System.Data.Constraint() {New System.Data.UniqueConstraint("Constraint1", New String() {"ProductID"}, False), New System.Data.UniqueConstraint("Constraint2", New String() {"SupplierID"}, False)})
        Me.Products.TableName = "Products"
        '
        'ProductID
        '
        Me.ProductID.AllowDBNull = False
        Me.ProductID.AutoIncrement = True
        Me.ProductID.ColumnName = "ProductID"
        Me.ProductID.DataType = GetType(Integer)
        '
        'ProductName
        '
        Me.ProductName.AllowDBNull = False
        Me.ProductName.ColumnName = "ProductName"
        '
        'UnitPrice
        '
        Me.UnitPrice.AllowDBNull = False
        Me.UnitPrice.ColumnName = "UnitPrice"
        Me.UnitPrice.DataType = GetType(Double)
        '
        'UnitsInStock
        '
        Me.UnitsInStock.AllowDBNull = False
        Me.UnitsInStock.ColumnName = "UnitsInStock"
        Me.UnitsInStock.DataType = GetType(Integer)
        '
        'SupplierID
        '
        Me.SupplierID.AllowDBNull = False
        Me.SupplierID.ColumnName = "SupplierID"
        Me.SupplierID.DataType = GetType(Integer)
        '
        'Suppliers
        '
        Me.Suppliers.Columns.AddRange(New System.Data.DataColumn() {Me.SupID, Me.CompanyName})
        Me.Suppliers.Constraints.AddRange(New System.Data.Constraint() {New System.Data.UniqueConstraint("Constraint1", New String() {"SupplierID"}, True), New System.Data.ForeignKeyConstraint("FK_SupplierProduct", "Products", New String() {"ProductID"}, New String() {"SupplierID"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade), New System.Data.ForeignKeyConstraint("productsSuppliers", "Products", New String() {"SupplierID"}, New String() {"SupplierID"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)})
        Me.Suppliers.PrimaryKey = New System.Data.DataColumn() {Me.SupID}
        Me.Suppliers.TableName = "Suppliers"
        '
        'SupID
        '
        Me.SupID.AllowDBNull = False
        Me.SupID.AutoIncrement = True
        Me.SupID.ColumnName = "SupplierID"
        Me.SupID.DataType = GetType(Integer)
        '
        'CompanyName
        '
        Me.CompanyName.AllowDBNull = False
        Me.CompanyName.ColumnName = "CompanyName"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(32, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(653, 231)
        Me.DataGridView1.TabIndex = 0
        '
        'fillData
        '
        Me.fillData.Location = New System.Drawing.Point(32, 286)
        Me.fillData.Name = "fillData"
        Me.fillData.Size = New System.Drawing.Size(122, 23)
        Me.fillData.TabIndex = 1
        Me.fillData.Text = "Fill Dataset"
        Me.fillData.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 365)
        Me.Controls.Add(Me.fillData)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Products, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Suppliers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataSet1 As DataSet
    Friend WithEvents Products As DataTable
    Friend WithEvents ProductID As DataColumn
    Friend WithEvents ProductName As DataColumn
    Friend WithEvents UnitPrice As DataColumn
    Friend WithEvents UnitsInStock As DataColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SupplierID As DataColumn
    Friend WithEvents Suppliers As DataTable
    Friend WithEvents SupID As DataColumn
    Friend WithEvents CompanyName As DataColumn
    Friend WithEvents fillData As Button
End Class
