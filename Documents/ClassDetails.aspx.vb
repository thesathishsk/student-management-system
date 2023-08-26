Imports System.Data.SqlClient
Public Class ClassDetails
    Inherits System.Web.UI.Page
    Dim connstr As String = ConfigurationManager.ConnectionStrings("Schooldb").ConnectionString
    Dim classid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim conn As New sqlconnection(connstr)
        Dim cmd As New SqlCommand("select class_name,class_id from class where teacher_id = " + Session("staffid"), conn)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        lblclassname.Text = ds.Tables(0).Rows(0)(0)
        classid = ds.Tables(0).Rows(0)(1)
    End Sub

    Protected Sub generaterank_Click(sender As Object, e As EventArgs) Handles generaterank.Click
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "generaterank"
        cmd.Parameters.AddWithValue("@classid", 102)
        cmd.Parameters.AddWithValue("@examtype", "c1")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        'rankrepeater.DataSource = ds
        'rankrepeater.DataBind()
        rankgrid.DataSource = ds
        rankgrid.DataBind()

    End Sub


    Protected Sub sortbyname_Click(sender As Object, e As EventArgs) Handles sortbyname.Click, sortbyname.Click
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from rankcard order by name", conn)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        'rankrepeater.DataSource = ds
        'rankrepeater.DataBind()
        rankgrid.DataSource = ds
        rankgrid.DataBind()
    End Sub


    Protected Sub sortbyrank_Click(sender As Object, e As EventArgs) Handles sortbyname.Click, sortbyrank.Click
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from rankcard order by Ranklist", conn)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        'rankrepeater.DataSource = ds
        'rankrepeater.DataBind()
        rankgrid.DataSource = ds
        rankgrid.DataBind()
    End Sub
End Class