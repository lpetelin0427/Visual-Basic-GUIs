Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class Class1
    Private Function getConnectionString() As String
        Return My.Settings.NORTHWNDConnectionString
    End Function
    Public Function getEmployees() As DataTable
        Dim sql As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        Dim dt As New DataTable()
        sql = "select FirstName, LastName, Title, BirthDate from Employees"
        conn = New SqlConnection(getConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function getNumEmployees() As Integer
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        sql = "Select count(*) from Employees"
        conn = New SqlConnection(getConnectionString)
        cmd = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        Dim employeeNum As Integer
        conn.Open()
        employeeNum = CInt(cmd.ExecuteScalar())
        conn.Close()
        Return employeeNum
    End Function
    Public Function getXML() As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        sql = "Select FirstName, LastName from Employees for XML Auto"
        conn = New SqlConnection(getConnectionString)
        cmd = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        conn.Open()
        Dim reader As XmlReader = cmd.ExecuteXmlReader()
        Dim myXMl As String = ""
        reader.Read()
        Do While reader.ReadState <> Xml.ReadState.EndOfFile
            myXMl += reader.ReadOuterXml().ToString() & vbCrLf
        Loop
        reader.Close()
        conn.Close()
        Return myXMl
    End Function
End Class
