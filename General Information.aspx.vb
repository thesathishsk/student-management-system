Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Microsoft.Ajax.Utilities

Public Class General_Information
    Inherits System.Web.UI.Page

    Dim connstr As String = ConfigurationManager.ConnectionStrings("skis").ConnectionString

    Function getTable() As DataSet
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function




    Function getTable(id As Int64) As DataSet
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where admission_id=" + (id.ToString()), conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getTable(id As Int64, cls As String) As DataSet
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where admission_id=" + (id.ToString()) + "and current_class='" + cls + "'", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Function getTable(name As String, cls As String) As DataSet
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where student_name='" + name + "'and current_class='" + cls + "'", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getTable(name As String, cls As String, sort As String) As DataSet
        If sort.Equals("Name") Then
            sort = "student_name"
        ElseIf sort.Equals("Admission No") Then
            sort = "admission_id"
        ElseIf sort.Equals("Date Of Joining") Then
            sort = "joining_date"
        ElseIf sort.Equals("Class") Then
            sort = "current_class"
        Else
            sort = "student_name"
        End If
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where student_name='" + name + "'and current_class='" + cls + "' order by " + sort, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getTable(name As String) As DataSet
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where student_name='" + name + "'", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getsorttable(sort As String)
        If sort.Equals("Name") Then
            sort = "student_name"
        ElseIf sort.Equals("Admission No") Then
            sort = "admission_id"
        ElseIf sort.Equals("Date Of Joining") Then
            sort = "joining_date"
        ElseIf sort.Equals("Class") Then
            sort = "current_class"
        Else
            sort = "student_name"
        End If
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation order by " + sort, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function



    Function getsorttable(name As String, sort As String)
        If sort.Equals("Name") Then
            sort = "student_name"
        ElseIf sort.Equals("Admission No") Then
            sort = "admission_id"
        ElseIf sort.Equals("Date Of Joining") Then
            sort = "joining_date"
        ElseIf sort.Equals("Class") Then
            sort = "current_class"
        Else
            sort = "student_name"
        End If
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where student_name='" + name + "' order by " + sort, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function
    Function getclsTable(cls As String) As DataSet
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where current_class='" + cls + "'", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getclsTable(cls As String, sort As String) As DataSet
        If sort.Equals("Name") Then
            sort = "student_name"
        ElseIf sort.Equals("Admission No") Then
            sort = "admission_id"
        ElseIf sort.Equals("Date Of Joining") Then
            sort = "joining_date"
        ElseIf sort.Equals("Class") Then
            sort = "current_class"
        Else
            sort = "student_name"
        End If
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from StudentInformation where current_class='" + cls + "' order by " + sort, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            errmsg.Style.Add("display", "none")
            studentviewer.DataSource = getTable()
            studentviewer.DataBind()
            ddlclass.Items.Add("Select Class")
            ddlclass.Items.Add("10-A")
            ddlclass.Items.Add("10-B")
            ddlclass.Items.Add("10-C")

            ddlsort.Items.Add("Select")

            ddlsort.Items.Add("Name")
            ddlsort.Items.Add("Admission No")
            ddlsort.Items.Add("Class")
            ddlsort.Items.Add("Date Of Joining")
        End If
    End Sub

    Protected Sub edit()
        Response.Redirect("Edit Information.aspx")

    End Sub




    Function findstatus(id As String)
        Dim ds = getTable()
        For Each student In ds.Tables(0).Rows
            If student("admission_id") = Convert.ToInt64(id) Then
                Dim year As String() = student("academic_year").split("-")
                Dim today As DateTime = DateTime.Now

                If Convert.ToInt32(year(1)) < today.Year Then
                    Return "P"
                ElseIf Convert.ToInt32(year(1)) = today.Year Then
                    If today.Month > 5 Then
                        Return "P"
                    End If
                Else
                    Return "Y"
                End If
                Return "Y"
            End If
        Next
    End Function

    Function fromyear(year As String)
        Dim years As String() = year.Split("-")
        Return "1-6-" + years(0)
    End Function

    Function toyear(year As String)
        Dim years As String() = year.Split("-")
        Return "1-5-" + years(1)
    End Function

    Function getdate(joindate As DateTime)
        Dim dateonly As String() = joindate.ToString.Split(" ")
        Return dateonly(0)
    End Function

    Function getbyyear(ondate As Date, name As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbydatename"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@name", name)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Function getbyyearnamesort(ondate As Date, name As String, sort As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearnamesort"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@sort", sort)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getbyyearclsname(ondate As Date, name As String, cls As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearclsname"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@cls", cls)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getbyyearclsid(ondate As Date, id As Int64, cls As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearclsid"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@cls", cls)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Function getbyyearnamesortcls(ondate As Date, name As String, sort As String, cls As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearnamesortcls"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@cls", cls)
        cmd.Parameters.AddWithValue("@sort", sort)

        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Function getbyyearidsortcls(ondate As Date, id As Int64, sort As String, cls As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearidsortcls"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@cls", cls)
        cmd.Parameters.AddWithValue("@sort", sort)

        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Function getbyyearcls(ondate As Date, cls As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearcls"
        cmd.Parameters.AddWithValue("@date", ondate)

        cmd.Parameters.AddWithValue("@cls", cls)


        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function


    Function getbyyear(ondate As Date)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbydate"
        cmd.Parameters.AddWithValue("@date", ondate)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function getbyyearsortcls(ondate As Date, sort As String, cls As String)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "getbyyearsortcls"
        cmd.Parameters.AddWithValue("@date", ondate)
        cmd.Parameters.AddWithValue("@sort", sort)
        cmd.Parameters.AddWithValue("@cls", cls)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function





    Function isname(name As String)
        Return Regex.IsMatch(name.Trim, "^[A-Za-z ]+$")
    End Function


    Protected Sub viewbtn_Click(sender As Object, e As EventArgs) Handles viewbtn.Click
        Dim txtfield = Request.Form("nameidtxt")
        Dim cls = ddlclass.SelectedValue
        Dim ondate = dt.Value
        If Not txtfield.Equals("") Then
            If cls.Equals("Select Class") Then
                If ddlsort.SelectedValue.Equals("Select") Then
                    If ondate = "" Then

                        If isname(txtfield) Then
                            Dim name As String = txtfield
                            Dim ds As DataSet = getTable(name)

                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If
                        ElseIf IsNumeric(txtfield) Then
                            Dim id As Int64 = txtfield
                            Dim ds As DataSet = getTable(id)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                            End If
                        End If
                    Else
                        'find name with date
                        If isname(txtfield) Then
                            Dim name As String = txtfield
                            Dim ds As DataSet = getbyyear(ondate, name)

                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If
                        End If
                    End If

                Else
                    If ondate = "" Then
                        If isname(txtfield) Then

                            Dim ds As DataSet = getsorttable(txtfield, ddlsort.SelectedValue)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If

                        End If
                    Else
                        'find name with sorting and date
                        If isname(txtfield) Then

                            Dim ds As DataSet = getbyyearnamesort(ondate, txtfield, ddlsort.SelectedValue)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If

                        End If
                    End If
                End If


            Else
                If ddlsort.SelectedValue.Equals("Select") Then
                    If ondate = "" Then
                        If isname(txtfield) Then
                            Dim name As String = txtfield
                            Dim ds As DataSet = getTable(name, cls)

                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If
                        ElseIf IsNumeric(txtfield) Then
                            Dim id As Int64 = txtfield
                            Dim ds As DataSet = getTable(id, cls)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                            End If
                        End If
                    Else
                        ' name id class date
                        If isname(txtfield) Then
                            Dim name As String = txtfield
                            Dim ds As DataSet = getbyyearclsname(ondate, name, cls)

                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If
                        ElseIf IsNumeric(txtfield) Then
                            Dim id As Int64 = txtfield
                            Dim ds As DataSet = getbyyearclsid(ondate, id, cls)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                            End If
                        End If
                    End If

                Else
                    If ondate = "" Then
                        If isname(txtfield) Then
                            Dim name As String = txtfield
                            Dim ds As DataSet = getTable(name, cls, ddlsort.SelectedValue)

                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If
                        ElseIf IsNumeric(txtfield) Then
                            Dim id As Int64 = txtfield
                            Dim ds As DataSet = getTable(id, cls, ddlsort.SelectedValue)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                            End If
                        End If
                    Else
                        ' name sort cls date
                        If isname(txtfield) Then
                            Dim name As String = txtfield
                            Dim ds As DataSet = getbyyearnamesortcls(ondate, name, ddlsort.SelectedValue, cls)

                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()

                            End If
                        ElseIf IsNumeric(txtfield) Then
                            Dim id As Int64 = txtfield
                            Dim ds As DataSet = getbyyearidsortcls(ondate, id, ddlsort.SelectedValue, cls)
                            If ds.Tables(0).Rows.Count = 0 Then
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                                errmsg.Style.Add("display", "flex")
                                errmsg.Text = "No Details Found"
                            Else
                                errmsg.Text = ""
                                errmsg.Style.Add("display", "none")
                                studentviewer.DataSource = ds
                                studentviewer.DataBind()
                            End If
                        End If

                    End If





                End If

            End If
        Else
            If cls.Equals("Select Class") Then
                If ondate = "" Then
                    Dim ds As DataSet = getsorttable(ddlsort.SelectedValue)
                    If ds.Tables(0).Rows.Count = 0 Then
                        studentviewer.DataSource = ds
                        studentviewer.DataBind()
                        errmsg.Style.Add("display", "flex")
                        errmsg.Text = "No Details Found"
                    Else
                        errmsg.Text = ""
                        errmsg.Style.Add("display", "none")
                        studentviewer.DataSource = ds
                        studentviewer.DataBind()

                    End If
                Else
                    'with date
                    Dim ds As DataSet = getbyyear(ondate)
                    If ds.Tables(0).Rows.Count = 0 Then
                        studentviewer.DataSource = ds
                        studentviewer.DataBind()
                        errmsg.Style.Add("display", "flex")
                        errmsg.Text = "No Details Found"
                    Else
                        errmsg.Text = ""
                        errmsg.Style.Add("display", "none")
                        studentviewer.DataSource = ds
                        studentviewer.DataBind()

                    End If
                End If

            Else
                If ddlsort.SelectedValue.Equals("Select") Then
                    If ondate = "" Then
                        Dim ds As DataSet = getclsTable(cls)
                        If ds.Tables(0).Rows.Count = 0 Then
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                            errmsg.Style.Add("display", "flex")
                            errmsg.Text = "No Details Found"
                        Else
                            errmsg.Text = ""
                            errmsg.Style.Add("display", "none")
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                        End If
                    Else
                        'class date
                        Dim ds As DataSet = getbyyearcls(ondate, cls)
                        If ds.Tables(0).Rows.Count = 0 Then
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                            errmsg.Style.Add("display", "flex")
                            errmsg.Text = "No Details Found"
                        Else
                            errmsg.Text = ""
                            errmsg.Style.Add("display", "none")
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                        End If
                    End If

                Else
                    If ondate = "" Then
                        Dim ds As DataSet = getclsTable(cls, ddlsort.SelectedValue)
                        If ds.Tables(0).Rows.Count = 0 Then
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                            errmsg.Style.Add("display", "flex")
                            errmsg.Text = "No Details Found"
                        Else
                            errmsg.Text = ""
                            errmsg.Style.Add("display", "none")
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                        End If
                    Else
                        'sort clss date
                        Dim ds As DataSet = getbyyearsortcls(ondate, ddlsort.SelectedValue, cls)
                        If ds.Tables(0).Rows.Count = 0 Then
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                            errmsg.Style.Add("display", "flex")
                            errmsg.Text = "No Details Found"
                        Else
                            errmsg.Text = ""
                            errmsg.Style.Add("display", "none")
                            studentviewer.DataSource = ds
                            studentviewer.DataBind()
                        End If
                    End If

                End If


                End If


            End If


    End Sub

    Protected Sub btn_Click(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub viewbtn_Click(sender As Object, e As EventArgs) Handles viewbtn.Click
    '    Dim txtfield = Request.Form("nameidtxt")
    '    Dim cls = ddlclass.SelectedValue
    '    'Dim ondate
    '    'If dt.Value = "" Then
    '    '    ondate = ""
    '    'Else
    '    '    ondate = CDate(dt.Value)
    '    'End If
    '    ''Dim ondate = CDate(dt.Value)
    '    ''Response.Write(ondate)

    '    If Not txtfield.Equals("") Then
    '        If cls.Equals("Select Class") Then
    '            If ddlsort.SelectedValue.Equals("Select") Then
    '                If isname(txtfield) Then
    '                    Dim name As String = txtfield
    '                    Dim ds As DataSet = getTable(name)

    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()

    '                    End If
    '                ElseIf IsNumeric(txtfield) Then
    '                    Dim id As Int64 = txtfield
    '                    Dim ds As DataSet = getTable(id)
    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                    End If
    '                End If
    '            Else
    '                If isname(txtfield) Then

    '                    Dim ds As DataSet = getsorttable(txtfield, ddlsort.SelectedValue)
    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()

    '                    End If

    '                End If
    '            End If

    '        Else
    '            If ddlsort.SelectedValue.Equals("Select") Then
    '                If isname(txtfield) Then
    '                    Dim name As String = txtfield
    '                    Dim ds As DataSet = getTable(name, cls)

    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()

    '                    End If
    '                ElseIf IsNumeric(txtfield) Then
    '                    Dim id As Int64 = txtfield
    '                    Dim ds As DataSet = getTable(id, cls)
    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                    End If
    '                End If
    '            Else
    '                If isname(txtfield) Then
    '                    Dim name As String = txtfield
    '                    Dim ds As DataSet = getTable(name, cls, ddlsort.SelectedValue)

    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()

    '                    End If
    '                ElseIf IsNumeric(txtfield) Then
    '                    Dim id As Int64 = txtfield
    '                    Dim ds As DataSet = getTable(id, cls, ddlsort.SelectedValue)
    '                    If ds.Tables(0).Rows.Count = 0 Then
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                        errmsg.Style.Add("display", "flex")
    '                        errmsg.Text = "No Details Found"
    '                    Else
    '                        errmsg.Text = ""
    '                        errmsg.Style.Add("display", "none")
    '                        studentviewer.DataSource = ds
    '                        studentviewer.DataBind()
    '                    End If
    '                End If





    '            End If

    '        End If
    '    Else
    '        If cls.Equals("Select Class") Then
    '            Dim ds As DataSet = getsorttable(ddlsort.SelectedValue)
    '            If ds.Tables(0).Rows.Count = 0 Then
    '                studentviewer.DataSource = ds
    '                studentviewer.DataBind()
    '                errmsg.Style.Add("display", "flex")
    '                errmsg.Text = "No Details Found"
    '            Else
    '                errmsg.Text = ""
    '                errmsg.Style.Add("display", "none")
    '                studentviewer.DataSource = ds
    '                studentviewer.DataBind()

    '            End If
    '        Else
    '            If ddlsort.Equals("Select") Then
    '                Dim ds As DataSet = getclsTable(cls)
    '                If ds.Tables(0).Rows.Count = 0 Then
    '                    studentviewer.DataSource = ds
    '                    studentviewer.DataBind()
    '                    errmsg.Style.Add("display", "flex")
    '                    errmsg.Text = "No Details Found"
    '                Else
    '                    errmsg.Text = ""
    '                    errmsg.Style.Add("display", "none")
    '                    studentviewer.DataSource = ds
    '                    studentviewer.DataBind()
    '                End If
    '            Else
    '                Dim ds As DataSet = getclsTable(cls, ddlsort.SelectedValue)
    '                If ds.Tables(0).Rows.Count = 0 Then
    '                    studentviewer.DataSource = ds
    '                    studentviewer.DataBind()
    '                    errmsg.Style.Add("display", "flex")
    '                    errmsg.Text = "No Details Found"
    '                Else
    '                    errmsg.Text = ""
    '                    errmsg.Style.Add("display", "none")
    '                    studentviewer.DataSource = ds
    '                    studentviewer.DataBind()
    '                End If
    '            End If

    '        End If


    '    End If

    'End Sub

End Class