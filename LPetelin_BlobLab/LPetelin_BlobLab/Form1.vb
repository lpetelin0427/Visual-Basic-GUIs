Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    Private databaseConnection As New SqlConnection(My.Settings.Database1ConnectionString)
    Private CompleteFilePath As String = ""
    Private SavePath As String = ""

    Private Sub CreateDatabaseTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDatabaseTableToolStripMenuItem.Click
        Dim response As DialogResult =
    MessageBox.Show("Create the Document Storage Table?" &
                    "Click Yes to create a new DocumentStorage table. " &
                    "Click No if you already have one!",
                    "Create DocumentStorage table", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        Select Case response
            Case Is = Windows.Forms.DialogResult.Yes
                CreateDocumentStorageTable()
            Case Is = Windows.Forms.DialogResult.No
                RefreshBlobList()
        End Select
    End Sub

    Private Sub GetCompleteFilePath()
        Dim OpenDialog As New OpenFileDialog
        OpenDialog.Title = "Select Document File to Save"
        OpenDialog.ShowDialog()
        CompleteFilePath = OpenDialog.FileName
    End Sub

    Private Sub GetSavePath()
        Dim SavePathDialog As New FolderBrowserDialog
        SavePathDialog.Description = "Select a folder to restore BLOB file to"
        SavePathDialog.ShowDialog()
        SavePath = SavePathDialog.SelectedPath
    End Sub

    'Create a table to hold our BLOB values
    Private Sub CreateDocumentStorageTable()
        Dim CreateTableCommand As New SqlCommand

        CreateTableCommand.Connection = databaseConnection
        CreateTableCommand.CommandType = CommandType.Text
        CreateTableCommand.CommandText =
            "IF OBJECT_ID ('DocumentStorage' ) IS NOT NULL " &
            "DROP TABLE DocumentStorage; " &
            "CREATE TABLE DocumentStorage(" &
            "DocumentID int IDENTITY(1,1) NOT NULL, " &
            "FileName nvarchar(255) NOT NULL, " &
            "DocumentFile varbinary(max) NOT NULL)"

        CreateTableCommand.Connection.Open()
        CreateTableCommand.ExecuteNonQuery()
        CreateTableCommand.Connection.Close()
    End Sub

    Private Sub RefreshBlobList()
        Dim GetBLOBListCommand As New SqlCommand("SELECT FileName FROM DocumentStorage", databaseConnection)
        Dim reader As SqlDataReader

        GetBLOBListCommand.Connection.Open()
        reader = GetBLOBListCommand.ExecuteReader
        While reader.Read
            BLOBList.Items.Add(reader(1))
        End While

        reader.Close()
        GetBLOBListCommand.Connection.Close()

        BLOBList.SelectedIndex = 0         'Sets first item in list as selected
    End Sub

    Private Sub SaveBLOBToDatabase()

        'This call lets you select a binary file to save as BLOB in the database
        GetCompleteFilePath()

        'The BLOB holds the byte array to save
        Dim BLOB() As Byte

        'The FileStream is the stream of bytes that represent the binary file
        Dim FileStream As New IO.FileStream(CompleteFilePath, IO.FileMode.Open, IO.FileAccess.Read)
        'The reader reads the binary data from the FileStream
        Dim reader As New IO.BinaryReader(FileStream)

        'The BLOB is assigned the bytes from the reader.
        'The file length is passed to the ReadBytes method telling it how many bytes to read
        BLOB =
            reader.ReadBytes(CInt(My.Computer.FileSystem.GetFileInfo(CompleteFilePath).Length))

        FileStream.Close()
        reader.Close()

        'Create a command object to save the BLOB value
        Dim SaveDocCommand As New SqlCommand
        SaveDocCommand.Connection = databaseConnection
        SaveDocCommand.CommandText = "INSERT INTO DocumentStorage" &
            "(FileName, DocumentFile)" &
            "VALUES (@FileName, @DocumentFile)"

        'Create parameters to store the filename and BLOB data
        Dim FileNameParameter As New SqlParameter("@FileName", SqlDbType.NChar)
        Dim DocumentFileParameter As New SqlParameter("@DocumentFile", SqlDbType.Binary)
        SaveDocCommand.Parameters.Add(FileNameParameter)
        SaveDocCommand.Parameters.Add(DocumentFileParameter)

        'Parse the filename out of the complete path
        FileNameParameter.Value =
            CompleteFilePath.Substring(CompleteFilePath.LastIndexOf("\") + 1)

        'Set the DocumentFile parameter to the BLOB value
        DocumentFileParameter.Value = BLOB


        'Execute the command and save the BLOB to the database
        Try
            SaveDocCommand.Connection.Open()
            SaveDocCommand.ExecuteNonQuery()
            MessageBox.Show(FileNameParameter.Value.ToString &
                            " saved to database.", "BLOB Saved!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SaveDocCommand.Connection.Close()
        End Try

    End Sub

    Private Sub FetchBlobFromDatabase()

        'Verify there is a BLOB selected to retrieve
        If BLOBList.Text = "" Then
            MessageBox.Show("Select a BLOB to fetch from the ComboBox")
            Exit Sub
        End If

        'Get the path to save the BLOB to
        GetSavePath()

        'Create the Command object to fetch the selected BLOB
        Dim GetBlobCommand As New SqlCommand(
            "SELECT FileName, DocumentFile " &
            "FROM DocumentStorage " &
            "WHERE FileName = @DocName", databaseConnection)
        GetBlobCommand.Parameters.Add("@DocName", SqlDbType.NVarChar).Value =
            BLOBList.Text

        'Current index to write the bytes to
        Dim CurrentIndex As Long = 0

        'Number of bytes to store in the BLOB
        Dim BufferSize As Integer = 100

        'Actual number of bytes returned when calling GetBytes
        Dim BytesReturned As Long

        'The Byte array used to hold the buffer
        Dim Blob(BufferSize - 1) As Byte

        GetBlobCommand.Connection.Open()

        Dim reader As SqlDataReader =
            GetBlobCommand.ExecuteReader(CommandBehavior.SequentialAccess)

        Do While reader.Read
            'Create or open the selected file
            Dim FileStream As New IO.FileStream(SavePath & "\" &
                                                reader("FileName").ToString, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)

            'Set the writer to write the BLOB to the file
            Dim writer As New IO.BinaryWriter(FileStream)

            'Reset the index to the beginning of the file
            CurrentIndex = 0

            'Set the BytesReturned to the actual number of bytes returned by the GetBytes call
            BytesReturned = reader.GetBytes(1, CurrentIndex, Blob, 0, BufferSize)

            'If the BytesReturned fills the buffer keep appending to the file
            Do While BytesReturned = BufferSize
                writer.Write(Blob)
                writer.Flush()

                CurrentIndex += BufferSize
                BytesReturned = reader.GetBytes(1, CurrentIndex, Blob, 0, BufferSize)
            Loop

            'When the BytesReturned no longer fills the buffer, write the remaining bytes
            writer.Write(Blob, 0, CInt(BytesReturned - 1))
            writer.Flush()

            writer.Close()
            FileStream.Close()

        Loop

        reader.Close()
        GetBlobCommand.Connection.Close()

    End Sub

    Private Sub SaveBlobButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBlobButton.Click
        SaveBLOBToDatabase()
        RefreshBlobList()
    End Sub

    Private Sub FetchBlobButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FetchBlobButton.Click
        FetchBlobFromDatabase()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class

