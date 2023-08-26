Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Generate_Id_card
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim reportdoc As New ReportDocument
        'reportdoc.Load(Server.MapPath("~/CrystalReport1.rpt"))
        'CrystalReportViewer1.ReportSource = reportdoc
    End Sub

    Protected Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        showdata()
    End Sub

    Sub showdata()
        Dim reportdoc As New ReportDocument
        reportdoc.Load(Server.MapPath("~/Idcard.rpt"))
        Dim st As std = getdata(Convert.ToInt64(searchfield.Text))
        reportdoc.SetDataSource(st)
        showid.ReportSource = reportdoc
        Response.Write(st.Tables(0).Rows(0).Item("student_name"))

        showid.DataBind()
        Response.Write("hii")
    End Sub

    Function getdata(num As Int64)
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("skis").ConnectionString)
        Dim cmd As New SqlCommand("select firstname+middlename+lastname as student_name,admission_id,current_class,primary_phoneno,address,bloodgroup from student where admission_id=" & num, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim st As New std
        adapter.Fill(st, "Student")
        Return st

    End Function

End Class