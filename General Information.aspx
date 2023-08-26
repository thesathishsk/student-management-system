<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="General Information.aspx.vb" Inherits="School_Management_School.General_Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
          <title>General Information</title>
          <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.7.0.min.js" integrity="sha256-2Pmvv0kuTBOenSvLm6bvfBSSHrUJ+3A7x6P5Ebd07/g=" crossorigin="anonymous"></script>
        <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">
        <style>
            body{
                margin: 0;
                box-sizing: border-box;
                background-color:  #e8e7e3;
    
                font-family: 'Poppins', sans-serif;
            }
           
            a{
        
                font-size: 12px;
            }
            #td , #ttd {
                width:100px;
            }
            @media only screen and (max-width:450px){
                #topbox{
                    flex-direction:column;
                }
                #topnav{
                    font-size:8px;
                    
                }
                #topnav a{
                    font-size:9px;
                }
            }

        </style>
    <script>
        function al() {
            alert("hii");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-fluid p-3" id="topnav" style="width:97%;" >
            <h5><b>General Information</b></h5>
            <div class="d-flex" >
                <a  class="text-decoration-none text-black">Home </a><span> <pre> > </pre> </span>
                <a  class=" text-decoration-none text-black">Student Management&nbsp; </a><span><pre> > </pre></span>
                <a  class=" text-decoration-none text-black">Student Information </a><span><pre> > </pre></span>
                <a class="text-decoration-none" style="color: blue">General Information</a>
            </div>
        </div>
        <div class="d-flex justify-content-center " style="margin-top: -20px;">
        
        <div class="bg-light border mb-3 rounded shadow container-fluid" style="width:97%; height: max-content;">
            
            <div class="d-flex p-4" style="justify-content: space-evenly;" id="topbox">
                <div class="form-outline mt-4">
                  <%--  <asp:TextBox runat="server" ID="nameidtxt" CssClass="form-control" ></asp:TextBox>--%>
                    <input type="text" class="form-control" name= "nameidtxt" placeholder="Enter Student Name Admission No"/>
                </div>
                 <div class="form-outline">
                    <lable class=" form-label text-secondary">Class</lable>
                     <asp:DropDownList runat="server" CSSCLASS="d-block rounded border-secondary" id="ddlclass" Height="38px" Width="200px"></asp:DropDownList>

                </div>
                 <div class="form-outline">
                    <lable class=" form-label text-secondary">Sort By</lable>
                    <asp:DropDownList runat="server" CSSCLASS="d-block rounded border-secondary" id="ddlsort" Height="38px" Width="200px"></asp:DropDownList>

                </div>
                 <div class="form-outline">
                    <lable class=" form-label text-secondary">As on Date</lable>
                    <input  runat="server" id="dt" type="date" name="dateinput" class="form-control"/>
                </div>
                 <div class="mt-4" >
                   <asp:button runat="server" id="viewbtn" Text="View" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:100px;height:35px;color:blue" CssClass="p-1" />
                </div>
                
                <div  class="mt-4">
                                      <asp:button runat="server" id="uploadphotobtn" Text="Upload Student Photo" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:200px;height:35px;color:blue" CssClass="p-1" />

                </div>
            </div>
            
            
            <div class="container mt-2 alert alert-primary rounded d-flex align-items-center" style="height:40px;"><div style="font-size: 13px;"> Status: Y-Current, P-Pass, F-Fail, W-Withdrawn, L-Long Leave, E-Exit Pending, C-Class Changed</div> </div>
        </div>
        </div>
        
         <div class="d-flex justify-content-center ">
         <div class="bg-light border  d-flex justify-content-center rounded shadow p-3 container-fluid" style="width:97%; height: 480px;">
             <asp:Label runat="server" ID="errmsg" CssClass="m-5 position-absolute"></asp:Label>
             <div class="container-fluid table-responsive">
             <asp:GridView runat="server" AutoGenerateColumns="false" ID="studentviewer" CssClass="table table-hover table-bordered w-100" >
                 <Columns>
                     <asp:TemplateField >
                         <HeaderTemplate>
                             S.No
                         </HeaderTemplate>
                         <ItemTemplate >
                             <%#Container.DataItemIndex + 1 %>
                         </ItemTemplate>
                     </asp:TemplateField>
                    
                     <asp:BoundField HeaderText="Student Name" DataField="student_name" />
                     <asp:BoundField HeaderText="Admission No" DataField="admission_id"/>
                     <asp:BoundField HeaderText="Class" DataField="current_class"/>
                      <asp:TemplateField>
                         <HeaderTemplate>
                             Date of Joining
                         </HeaderTemplate>
                         <ItemTemplate>
                             <%#getdate(Container.DataItem("joining_date"))%>
                         </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField>
                         <HeaderTemplate>
                             Status
                         </HeaderTemplate>
                         <ItemTemplate>
                             <%#findstatus(Container.DataItem("admission_id"))%>
                         </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField>
                         <HeaderTemplate>
                             Effective From
                         </HeaderTemplate>
                         <ItemTemplate>
                              <asp:label runat="server" id="lblfromyear" Text=' <%#fromyear(Container.DataItem("academic_year"))%>'></asp:label>
                           
                         </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField>
                         <HeaderTemplate>
                             Effective Till
                         </HeaderTemplate>
                         <ItemTemplate>
                            <asp:label runat="server" id="lbltoyear" Text=' <%#toyear(Container.DataItem("academic_year"))%>'></asp:label>
                         </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField>
                         <HeaderTemplate>
                             View
                         </HeaderTemplate>
                         <ItemTemplate>
                       <a href="Edit Information.aspx?id=<%#Eval("admission_id") %>">          <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger "  viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></a>
 

                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
                 </div>
           <%-- <table class="table table-hover table-bordered">
                <tr>
                    <th>S.No</th>
                    <th>Student Name</th>
                    <th>Admission</th>
                    <th>Class</th>
                    <th>Date of Joining</th>
                    <th>Status</th>
                    <th>Effective From</th>
                    <th>Effective To</th>
                    <th>View</th>

                </tr>
                <tr>
                    <td>1</td>
                    <td>Sathish Kumar</td>
                     <td>12312</td>
                     <td>XI-A</td>
                     <td>12-04-2002</td>
                     <td>Y</td>
                     <td>10-09-2021</td>
                     <td>12-10-2022</td>
                     <td><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger" viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></td>
                </tr>
                 <tr>
                    <td>2</td>
                    <td>Vijay Kumar</td>
                     <td>12312</td>
                     <td>XI-A</td>
                     <td>12-04-2002</td>
                     <td>Y</td>
                     <td>10-09-2021</td>
                     <td>12-10-2022</td>
                     <td><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger" viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></td>
                </tr>
                 <tr>
                    <td>3</td>
                     <td>Kishore</td>
                     <td>12312</td>
                     <td>XI-A</td>
                     <td>12-04-2002</td>
                     <td>Y</td>
                     <td>10-09-2021</td>
                     <td>12-10-2022</td>
                     <td><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger" viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></td>
                </tr>
                 <tr>
                    <td>4</td>
                    <td>Sujay</td>
                     <td>12312</td>
                     <td>XI-A</td>
                     <td>12-04-2002</td>
                     <td>Y</td>
                     <td>10-09-2021</td>
                     <td>12-10-2022</td>
                     <td><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger" viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></td>
                </tr>
                 <tr>
                    <td>5</td>
                    <td>Rahul</td>
                     <td>12312</td>
                     <td>XI-A</td>
                     <td>12-04-2002</td>
                     <td>Y</td>
                     <td>10-09-2021</td>
                     <td>12-10-2022</td>
                     <td><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger" viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></td>
                </tr>
                 <tr>
                    <td>6</td>
                    <td>Pronov</td>
                     <td>12312</td>
                     <td>XI-A</td>
                     <td>12-04-2002</td>
                     <td>Y</td>
                     <td>10-09-2021</td>
                     <td>12-10-2022</td>
                     <td><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger" viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg></td>
                </tr>
             </table>--%>
        </div>
        </div>
    </form>
</body>
</html>
