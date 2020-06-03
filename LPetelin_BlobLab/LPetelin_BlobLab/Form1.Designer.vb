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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDatabaseTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BLOBList = New System.Windows.Forms.ComboBox()
        Me.SaveBlobButton = New System.Windows.Forms.Button()
        Me.FetchBlobButton = New System.Windows.Forms.Button()
        Me.Database1DataSet = New LPetelin_BlobLab.Database1DataSet()
        Me.Database1DataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Database1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Database1DataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(787, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateDatabaseTableToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CreateDatabaseTableToolStripMenuItem
        '
        Me.CreateDatabaseTableToolStripMenuItem.Name = "CreateDatabaseTableToolStripMenuItem"
        Me.CreateDatabaseTableToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.CreateDatabaseTableToolStripMenuItem.Text = "Create Database Table"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(45, 24)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'BLOBList
        '
        Me.BLOBList.DataSource = Me.Database1DataSetBindingSource
        Me.BLOBList.FormattingEnabled = True
        Me.BLOBList.Location = New System.Drawing.Point(49, 149)
        Me.BLOBList.Name = "BLOBList"
        Me.BLOBList.Size = New System.Drawing.Size(281, 24)
        Me.BLOBList.TabIndex = 1
        '
        'SaveBlobButton
        '
        Me.SaveBlobButton.Location = New System.Drawing.Point(49, 213)
        Me.SaveBlobButton.Name = "SaveBlobButton"
        Me.SaveBlobButton.Size = New System.Drawing.Size(281, 23)
        Me.SaveBlobButton.TabIndex = 2
        Me.SaveBlobButton.Text = "Save BLOB to Database"
        Me.SaveBlobButton.UseVisualStyleBackColor = True
        '
        'FetchBlobButton
        '
        Me.FetchBlobButton.Location = New System.Drawing.Point(49, 261)
        Me.FetchBlobButton.Name = "FetchBlobButton"
        Me.FetchBlobButton.Size = New System.Drawing.Size(281, 23)
        Me.FetchBlobButton.TabIndex = 2
        Me.FetchBlobButton.Text = "Fetch BLOB From Database"
        Me.FetchBlobButton.UseVisualStyleBackColor = True
        '
        'Database1DataSet
        '
        Me.Database1DataSet.DataSetName = "Database1DataSet"
        Me.Database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Database1DataSetBindingSource
        '
        Me.Database1DataSetBindingSource.DataSource = Me.Database1DataSet
        Me.Database1DataSetBindingSource.Position = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 414)
        Me.Controls.Add(Me.FetchBlobButton)
        Me.Controls.Add(Me.SaveBlobButton)
        Me.Controls.Add(Me.BLOBList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Database1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Database1DataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BLOBList As ComboBox
    Friend WithEvents SaveBlobButton As Button
    Friend WithEvents FetchBlobButton As Button
    Friend WithEvents CreateDatabaseTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Database1DataSetBindingSource As BindingSource
    Friend WithEvents Database1DataSet As Database1DataSet
End Class
