<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ClassDetails.aspx.vb" Inherits="Attendance_Module.ClassDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        th{
           width:70px;
        }
        td{
           width:70px;
        }

      /*  @media only screen and (max-width:450px){
                    th , td{
                     width:10px;
                    
                    }
        }*/
    </style>
     <script src="https://code.jquery.com/jquery-3.7.0.min.js" integrity="sha256-2Pmvv0kuTBOenSvLm6bvfBSSHrUJ+3A7x6P5Ebd07/g=" crossorigin="anonymous"></script>
      <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <script>
        $(document).ready(function () {

           
          
        




            $("#sortdiv .btn").click(function () {
                $("#showoption").slideToggle();
            });
        });

    

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid bg-dark">
            <h3 class="text-center text-light">Class Details</h3>
        </div>
        <div class=" align-items-center row " style="width:200px; height:90px;">
            <h1 class="text-center"><asp:label runat="server" id="lblclassname"></asp:label></h1>
        </div>
    <asp:Button runat="server" id="generaterank" CssClass="btn btn-primary m-2" Text="Generate Rank" />

        <div style="position:relative;display:inline-block; " class="m-2"  id="sortdiv">
                    <div   id="sortbtnamebtn" class="btn btn-secondary p-1" >Sort By </div>
                    <div class=" bg-light p-2 border shadow"  style="display:none; position:absolute; width:60px;" id="showoption">
                   <asp:linkbutton runat="server" ID="sortbyname" CssClass="d-block text-decoration-none text-dark" onclick="sortbyname_Click"> Name</asp:linkbutton>
                       <asp:linkbutton runat="server" ID="sortbyrank" CssClass="d-block text-decoration-none text-dark" onclick="sortbyrank_Click"> Rank</asp:linkbutton>     
                    </div>
        </div>

        <br />

        <%--<asp:Repeater runat="server" ID="rankrepeater">
           
            <HeaderTemplate>
               <div class="table-responsive">
                <table class="table table-hover ">
                    <thead>
                    <tr>
                          <th class="text-center">Student Id</th>
                        <th class="text-center">Name</th>
                        <th class="text-center">Tamil</th>
                        <th class="text-center">English</th>
                               <th class="text-center">Maths</th>
                        <th class="text-center">Science</th>
                        <th class="text-center">Social</th>
                               <th class="text-center">Total Mark</th>
                        <th class="text-center">Rank</th>
                
                    </tr>
                  </thead>
                </table>
               
            </HeaderTemplate>
            <ItemTemplate>
                  
                <table class="table table-hover">
                    <tr>
                        <td class="text-center">
                           <asp:label runat="server" ID="lblid" Text='<%# Eval("student_id") %>'></asp:label>
                        </td>
                        <td class="text-center">
                           <asp:label runat="server" ID="Label1" Text='<%# Eval("name") %>'></asp:label>
                        </td>
                        <td class="text-center">
                           <asp:label runat="server" ID="Label2" Text='<%# Eval("Tamil") %>'></asp:label>
                        </td>
                        <td class="text-center">
                           <asp:label runat="server" ID="Label3" Text='<%# Eval("English") %>'></asp:label>   </td>
                            <td class="text-center">
                           <asp:label runat="server" ID="Label4" Text='<%# Eval("Maths") %>'></asp:label>                        </td>
                                <td class="text-center">
                           <asp:label runat="server" ID="Label5" Text='<%# Eval("Science") %>'></asp:label>     </td>
                                    <td class="text-center">
                           <asp:label runat="server" ID="Label6" Text='<%# Eval("Social") %>'></asp:label>     </td>
                                        <td class="text-center">
                           <asp:label runat="server" ID="Label7" Text='<%# Eval("TotalMarks") %>'></asp:label>
                
                        </td>
                                            <td class="text-center">
                           <asp:label runat="server" ID="Label8" Text='<%# Eval("Ranklist") %>'></asp:label>
                
                        </td>
                    </tr>
                </table>
                      </div>
            </ItemTemplate>
        </asp:Repeater>--%>
        <div class="table-responsive">
        <asp:GridView runat="server" ID="rankgrid" cssclass="table table-hover  ">
           
        </asp:GridView>
             </div>
    </form>
</body>
</html>
