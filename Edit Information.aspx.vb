Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Newtonsoft.Json.Converters

Public Class Edit_Information
    Inherits System.Web.UI.Page

    Dim connstr As String = ConfigurationManager.ConnectionStrings("skis").ConnectionString
    Dim statesAndUTs As New List(Of String)() From {
            "Andhra Pradesh",
            "Arunachal Pradesh",
            "Assam",
            "Bihar",
            "Chhattisgarh",
            "Goa",
            "Gujarat",
            "Haryana",
            "Himachal Pradesh",
            "Jharkhand",
            "Karnataka",
            "Kerala",
            "Madhya Pradesh",
            "Maharashtra",
            "Manipur",
            "Meghalaya",
            "Mizoram",
            "Nagaland",
            "Odisha",
            "Punjab",
            "Rajasthan",
            "Sikkim",
            "Tamil Nadu",
            "Telangana",
            "Tripura",
            "Uttar Pradesh",
            "Uttarakhand",
            "West Bengal",
            "Andaman and Nicobar Islands",
            "Chandigarh",
            "Dadra and Nagar Haveli and Daman and Diu",
            "Lakshadweep",
            "Delhi",
            "Puducherry"
        }
    Dim districts As New List(Of String)() From {
            "Ariyalur",
            "Chengalpattu",
            "Chennai",
            "Coimbatore",
            "Cuddalore",
            "Dharmapuri",
            "Dindigul",
            "Erode",
            "Kallakurichi",
            "Kancheepuram",
            "Karur",
            "Krishnagiri",
            "Madurai",
            "Nagapattinam",
            "Namakkal",
            "Nilgiris",
            "Perambalur",
            "Pudukkottai",
            "Ramanathapuram",
            "Ranipet",
            "Salem",
            "Sivaganga",
            "Tenkasi",
            "Thanjavur",
            "Theni",
            "Thoothukudi",
            "Tiruchirappalli",
            "Tirunelveli",
            "Tirupathur",
            "Tiruppur",
            "Tiruvallur",
            "Tiruvannamalai",
            "Tiruvarur",
            "Vellore",
            "Viluppuram",
            "Virudhunagar"
        }

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
        Dim cmd As New SqlCommand("select * from StudentInformation where admission_id = " & id & ";", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        Return studentlist
    End Function

    Function findstatus(id As String)
        Dim ds = getTable()
        For Each student In ds.Tables(0).Rows
            If student("admission_id") = Convert.ToInt64(id) Then
                Dim year As String() = student("academic_year").split("-")
                Dim today As DateTime = DateTime.Now

                If Convert.ToInt32(year(1)) < today.Year Then
                    Return "Inactive"
                ElseIf Convert.ToInt32(year(1)) = today.Year Then
                    If today.Month > 5 Then
                        Return "Inactive"
                    End If
                Else
                    Return "Active"
                End If
                Return "Active"
            End If
        Next
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Int64 = Convert.ToInt64(Request.QueryString("id"))
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand("select * from Student where admission_id = " & id & ";", conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim studentlist As New DataSet()
        adapter.Fill(studentlist)
        singlestudentviewer.DataSource = studentlist
        singlestudentviewer.DataBind()
        If Not IsPostBack Then
            ddlgender.Items.Add("Male")
            ddlgender.Items.Add("Female")
            ddlgender.Items.Add("Others")
            ddlreligion.Items.Add("Hindu")
            ddlreligion.Items.Add("Muslim")
            ddlreligion.Items.Add("Christan")
            ddlfees.Items.Add("General")
            ddlfees.Items.Add("Type-1")
            ddlfees.Items.Add("Type-2")
            ddlfees.Items.Add("Type-3")
            ddlprimarycontact.Items.Add("Father")
            ddlprimarycontact.Items.Add("Mother")
            ddlprimarycontact.Items.Add("Brother")
            ddlprimarycontact.Items.Add("Sister")
            ddlprimarycontact.Items.Add("Uncle")
            ddlsecondarycontact.Items.Add("Father")
            ddlsecondarycontact.Items.Add("Mother")
            ddlsecondarycontact.Items.Add("Brother")
            ddlsecondarycontact.Items.Add("Sister")
            ddlsecondarycontact.Items.Add("Uncle")
            For Each i In statesAndUTs
                ddlstate.Items.Add(i)
            Next
            For Each i In districts
                ddldistrict.Items.Add(i)
            Next
            Dim conn1 As New SqlConnection(connstr)
            Dim cmd1 As New SqlCommand("select * from Docs where admission_id=" & id, conn1)
            Dim adapter1 As New SqlDataAdapter(cmd1)
            Dim filelist As New DataSet()
            adapter1.Fill(filelist)
            documentviewer.DataSource = filelist
            documentviewer.DataBind()
        End If

        profileimg.ImageUrl = studentlist.Tables(0).Rows(0).Item("photo")
        admission_no.Value = studentlist.Tables(0).Rows(0).Item("admission_id")
        aadhar.Value = studentlist.Tables(0).Rows(0).Item("aadhar")
        address.Value = studentlist.Tables(0).Rows(0).Item("address")
        firstname.Value = studentlist.Tables(0).Rows(0).Item("firstname")
        middlename.Value = studentlist.Tables(0).Rows(0).Item("middlename")
        lastname.Value = studentlist.Tables(0).Rows(0).Item("lastname")
        ddlfees.SelectedValue = studentlist.Tables(0).Rows(0).Item("fee_catagory")
        currentclass.Value = studentlist.Tables(0).Rows(0).Item("current_class")
        currentregno.Value = studentlist.Tables(0).Rows(0).Item("current_regno")
        ddlgender.SelectedValue = studentlist.Tables(0).Rows(0).Item("gender")
        dob.Text = studentlist.Tables(0).Rows(0).Item("dob")
        ddlreligion.SelectedValue = studentlist.Tables(0).Rows(0).Item("religion")
        ddlprimarycontact.SelectedValue = studentlist.Tables(0).Rows(0).Item("primary_contact_person")
        ddlsecondarycontact.SelectedValue = studentlist.Tables(0).Rows(0).Item("secondary_contact_person")
        pfirstname.Value = studentlist.Tables(0).Rows(0).Item("primary_firstname")
        pmiddlename.Value = studentlist.Tables(0).Rows(0).Item("primary_middlename")
        plastname.Value = studentlist.Tables(0).Rows(0).Item("primary_lastname")
        pphoneno.Value = studentlist.Tables(0).Rows(0).Item("primary_phoneno")
        pemail.Value = studentlist.Tables(0).Rows(0).Item("primary_emailid")
        ddlstate.SelectedValue = studentlist.Tables(0).Rows(0).Item("state")
        ddldistrict.SelectedValue = studentlist.Tables(0).Rows(0).Item("district")
        sfirstname.Value = studentlist.Tables(0).Rows(0).Item("secondary_firstname")
        smiddlename.Value = studentlist.Tables(0).Rows(0).Item("secondary_middlename")
        slastname.Value = studentlist.Tables(0).Rows(0).Item("secondary_lastname")
        sphoneno.Value = studentlist.Tables(0).Rows(0).Item("secondary_phoneno")
        semail.Value = studentlist.Tables(0).Rows(0).Item("secondary_emailid")
        Dim ds As DataSet = getTable()
        For i = 0 To studentlist.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item("admission_id") = Request.QueryString("id") Then
                If i + 1 = ds.Tables(0).Rows.Count Then
                    nextbtn.Enabled = False
                End If
            End If
        Next


    End Sub

    Protected Sub enrollsubmitbtn_Click(sender As Object, e As EventArgs) Handles enrollsubmitbtn.Click
        Dim state As String = ddlstate.SelectedValue.ToString()
        Dim district As String = ddldistrict.SelectedValue.ToString()
        Dim fees As String = ddlfees.SelectedValue.ToString()

        Dim minority As String
        If yes.Checked Then
            minority = "Yes"
        Else
            minority = "No"
        End If
        Dim gender As String = ddlgender.SelectedValue.ToString()
        Dim religion As String = ddlreligion.SelectedValue.ToString()
        Dim id As Int64 = Convert.ToInt64(Request.QueryString("id"))
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "updateenrollement"
        cmd.Parameters.AddWithValue("@firstname", Request.Form("firstname"))
        cmd.Parameters.AddWithValue("@class", Request.Form("currentclass"))
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@middlename", Request.Form("middlename"))
        cmd.Parameters.AddWithValue("@lastname", Request.Form("lastname"))
        cmd.Parameters.AddWithValue("@aadhar", Request.Form("aadhar"))
        cmd.Parameters.AddWithValue("@gender", gender)
        cmd.Parameters.AddWithValue("@religion", religion)
        cmd.Parameters.AddWithValue("@feecatagory", fees)
        cmd.Parameters.AddWithValue("@regno", Request.Form("currentregno"))
        cmd.Parameters.AddWithValue("@address", Request.Form("address"))
        cmd.Parameters.AddWithValue("@state", state)
        cmd.Parameters.AddWithValue("@district", district)
        cmd.Parameters.AddWithValue("@dob", DateTime.Now)
        cmd.Parameters.AddWithValue("@minority", minority)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("Edit Information.aspx?id=" & id)
    End Sub

    Protected Sub nextbtn_Click(sender As Object, e As EventArgs) Handles nextbtn.Click
        Dim ds As DataSet = getTable()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item("admission_id") = Request.QueryString("id") Then
                If i + 1 = ds.Tables(0).Rows.Count Then
                    nextbtn.Enabled = False
                Else
                    Dim nextid As Int64 = ds.Tables(0).Rows(i + 1).Item("admission_id")
                    Response.Redirect("Edit Information.aspx?id=" & nextid)
                End If
            End If
        Next


    End Sub

    Protected Sub previousbtn_Click(sender As Object, e As EventArgs) Handles previousbtn.Click
        Dim ds As DataSet = getTable()
        For i = ds.Tables(0).Rows.Count - 1 To 0 Step -1
            If ds.Tables(0).Rows(i).Item("admission_id") = Request.QueryString("id") Then
                If i = 0 Then
                    previousbtn.Enabled = False
                Else
                    Dim previd As Int64 = ds.Tables(0).Rows(i - 1).Item("admission_id")
                    Response.Redirect("Edit Information.aspx?id=" & previd)
                End If
            End If
        Next
    End Sub

    Protected Sub uploadbtn_Click(sender As Object, e As EventArgs)

        Dim filelocation = Server.MapPath("~/Documents/")
        If Not Directory.Exists(filelocation) Then
            Directory.CreateDirectory(filelocation)
        End If
        Dim fn = Path.GetFileName(uploaddoc.FileName)
        uploaddoc.SaveAs(filelocation + fn)
        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "adddocuments"
        cmd.Parameters.AddWithValue("@filetype", Request.Form("filetype"))
        cmd.Parameters.AddWithValue("@filedescription", Request.Form("filedescription"))
        cmd.Parameters.AddWithValue("@filename", fn)

        cmd.Parameters.AddWithValue("@updatedon", DateTime.Now)
        cmd.Parameters.AddWithValue("@updatedby", "admin")
        cmd.Parameters.AddWithValue("@documenttype", doctype.SelectedValue)
        cmd.Parameters.AddWithValue("@filepath", filelocation + fn)
        cmd.Parameters.AddWithValue("@comment", Request.Form("comment"))
        Dim district As String = ddldistrict.SelectedValue.ToString()
        cmd.Parameters.AddWithValue("@id", Convert.ToInt64(Request.QueryString("id")))
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        document.Style.Add(HtmlTextWriterStyle.Display, "block")
        enroll.Style.Add(HtmlTextWriterStyle.Display, "none")
        Dim conn1 As New SqlConnection(connstr)
        Dim cmd1 As New SqlCommand("select * from Docs where admission_id=" + Request.QueryString("id"), conn1)
        Dim adapter As New SqlDataAdapter(cmd1)
        Dim filelist As New DataSet()
        adapter.Fill(filelist)
        documentviewer.DataSource = filelist
        documentviewer.DataBind()
        getdoc.Style.Add(HtmlTextWriterStyle.Display, "none")
        enrollbt.Style.Add(HtmlTextWriterStyle.BorderWidth, "0px")
    End Sub

    Protected Sub adddocumentbtn_Click(sender As Object, e As EventArgs)
        getdoc.Style.Add(HtmlTextWriterStyle.Display, "block")
        document.Style.Add(HtmlTextWriterStyle.Display, "block")
        enroll.Style.Add(HtmlTextWriterStyle.Display, "none")
        photo.Style.Add(HtmlTextWriterStyle.Display, "none")
    End Sub

    Protected Sub picbtn_Click(sender As Object, e As EventArgs)
        Dim filelocation = Server.MapPath("~/Photos/")
        If Not Directory.Exists(filelocation) Then
            Directory.CreateDirectory(filelocation)
        End If
        Dim extension = Path.GetExtension(uploadphoto.FileName)

        If extension = ".jpg" Or extension = ".jpeg" Then
            Dim fn = Path.GetFileName(uploadphoto.FileName)
            uploadphoto.SaveAs(filelocation + fn)
            Dim conn As New SqlConnection(connstr)
            Dim cmd As New SqlCommand("update Student set photo=@url where admission_id=" + Request.QueryString("id"), conn)
            cmd.Parameters.AddWithValue("@url", "~\Photos\" + fn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Else
            errtext.Text = "Image should only be in jpg or jpeg format"
        End If
        'Response.Redirect("Edit Information.aspx?id=" & Request.QueryString("id"))
        enroll.Style.Add(HtmlTextWriterStyle.Display, "none")
        photo.Style.Add(HtmlTextWriterStyle.Display, "block")
        enrollbt.Style.Add(HtmlTextWriterStyle.BorderWidth, "0px")

    End Sub
End Class