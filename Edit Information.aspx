<%@ Page Language="vb" AutoEventWireup="false"  MaintainScrollPositionOnPostBack="true" CodeBehind="Edit Information.aspx.vb" Inherits="School_Management_School.Edit_Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Information</title>
          <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.7.0.min.js" integrity="sha256-2Pmvv0kuTBOenSvLm6bvfBSSHrUJ+3A7x6P5Ebd07/g=" crossorigin="anonymous"></script>
        <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">
    <script src="edit.js"></script>
            <style>
            body{
                margin: 0;
                box-sizing: border-box;
                background-color:  #e8e7e3;
    
                font-family: 'Poppins', sans-serif;
            }
               
               td, th{
                   width:670px;
               }

               .bordercolor{
                   border-bottom:4px solid blue;
               }
               
               ul{
                list-style: none;
                display: flex;
                justify-content: space-around;
               }
               
               @media only screen and (max-width:450px){

                   a{
                       font-size: 7px;
                   }
                   span{
                     font-size: 9px;
                   }
                   .topbtn{
                       font-size: 10px;
                      height: 35px;
                   }
                   .belowline{
                       flex-direction: column;
                   }
                   table{
                       width:320px;
                       font-size: 14px;
                   }
                   
               }
               .opt{
                   min-width: 130px;
                  cursor:pointer;
               }
               
               
        </style>
   <script>

   </script>
   
</head>
<body>
    <form id="form1" runat="server">
   <div class="p-2 container-fluid" style="width:97%;">
            <h5><b>Edit Information</b></h5>
            <div class="d-flex p-2">
                <a  class="text-decoration-none text-black">Home </a><span> <pre> > </pre> </span>
                <a  class=" text-decoration-none text-black">Student Management&nbsp; </a><span><pre> > </pre></span>
                <a  class=" text-decoration-none text-black">Student Information </a><span><pre> > </pre></span>
                <a  class=" text-decoration-none text-black" href="General Information.aspx">General Information </a><span><pre> > </pre></span>
                <a class="text-decoration-none" style="color: blue">Edit Information</a>
            </div>
        </div>
        
            <div class="rounded bg-light border mb-3 shadow p-3 container-fluid position-relative " style="width:97%; height:max-content; margin-top: -20px;">
                <div class="d-flex justify-content-between">
                <div><b class="d-inline-block">Profile Details</b><span>&nbsp;|</span> <span class="text-secondary" style="font-size: 13px;" id="feat">Student List</span></div>
                
                <div class="d-flex " style="width: 300px; justify-content: space-evenly">
                                 <asp:button runat="server" id="previousbtn" Text="Previous" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:100px;height:30px;color:blue" CssClass="p-1 " />

                    
                                <asp:button runat="server" id="nextbtn" Text="Next" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:100px;height:30px;color:blue" CssClass="p-1" />

            
                    
                    </div>
                </div>
                <hr/>
                
                <div class="position-absolute container bg-danger" id="stl" style="width:70%; display:none"> hiii</div>
                <div class="belowline d-flex">
                    <div class="text-center"><asp:Image runat="server" ID="profileimg" Width="150" Height="150" CssClass="img-thumbnail rounded-circle"/></div>
                    <div class="m-3">
                        <asp:FormView ID="singlestudentviewer" runat="server">
                             <HeaderTemplate>
                                  <table>
                            <tr>
                                <td class="text-left">Student Name</td>
                                <td class="text-left">Admission No</td>
                                <td class="text-left">Status</td>
                                <td class="text-left">Current Class</td>
                            </tr>
                                      </table>
                             </HeaderTemplate>
                            <ItemTemplate>
                                <table>
                                <tr>
                                <th class="text-left"><%#Eval("firstname") %></th>
                                <th class="text-left"><%#Eval("admission_id") %></th>
                                <th class="text-left"><%# findstatus(Eval("admission_id"))%></th>
                                <th class="text-left"><%#Eval("current_class") %></th>
                            </tr>
                        </table>
                            </ItemTemplate>
                        </asp:FormView>
                       <%-- <table>
                            <tr>
                                <td >Student Name</td>
                                <td >Admission No</td>
                                <td >Status</td>
                                <td >Current Class</td>
                            </tr>
                             <tr>
                                <th>Sathish Kumar R</th>
                                <th>12312</th>
                                <th>Active</th>
                                <th>XI-A</th>
                            </tr>
                        </table>--%>
                    </div>
                
                </div>
            </div>
        
        <div class="d-flex justify-content-center position-relative">
            <div class="bg-light border rounded shadow p-3 container-fluid" style="width:  97%; height:900px;">
                <div class="form-title d-flex justify-content-between table-responsive">
                    <div class="opt text-center enrollbtn  " style="border-bottom:4px solid blue;" onclick="showenroll()" runat="server"   id="enrollbt"> Enrollment </div>
                    <div class="opt text-center photobtn" onclick="showphoto()" id="photobtn" runat="server"> Photo </div>
                    <div class="opt  text-center contactbtn" onclick="showcontact()"> Contact Details </div>
                    <div class="opt text-center healthbtn" onclick="showhealth()"> Health </div>
                    <div class="opt text-center parentbtn" onclick="showparent()"> Parent's Details </div>
                    
                    <div class="opt text-center lunchbtn" onclick="showlunch()"> Lunch </div>
                    <div class="opt text-center documentbtn " onclick="showdocument()"> Document </div>
                    <div class="opt  text-center signbtn" onclick="showsign()"> Parent's/photo </div>
                    <div class="opt text-center siblingsbtn" onclick="showsiblings()"> Siblings </div>
                </div>
            </div>
              
            
    
        <div class="container-fluid position-absolute  mt-5 "  id="enroll" runat="server" onclick="showenroll()" style="width:  96%; height:max-content; display:block;" >
            <div class="container p-3">
                <div class="form-outline">
                    <label class="form-label">Admission No</label>
                    <input type="text" class="form-control" runat="server" id="admission_no" style="width: max-content;" readonly/>
                </div>
            
                <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">First Name</label>
                            <input type="text" runat="server" id="firstname" class="form-control"  />
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Middle Name</label>
                            <input type="text" runat="server" id="middlename" class="form-control" />
                    </div>
                      <div class="form-outline  col">
                            <label class="form-label">Last Name</label>
                            <input type="text"  runat="server" id="lastname" class="form-control"  />
                    </div>
                </div>
            
                  <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">Gender</label>
                             <asp:dropdownlist ID="ddlgender" runat="server" CssClass="form-select"></asp:dropdownlist>
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Date of Birth</label>
                           <asp:TextBox runat="server" TextMode="Date" ID="dob" CssClass="form-control" ></asp:TextBox>
                            <%--<input type="date" runat="server" id="dob" class="form-control" />--%>
                    </div>
                </div>
                
                <div class="mt-2 row">
                    <div class="form-outline col">
                          <label class="form-label">Aadhar No</label>
                            <input type="text" class="form-control" runat="server" id="aadhar"  style="width:max-content;"/>
                    </div>
                </div>
                
                   <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">Address</label>
                            <input type="text" runat="server" id="address" class="form-control"  />
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">District</label>
                               <asp:DropDownList runat="server" ID="ddldistrict" CssClass="form-select"></asp:DropDownList>
                    </div>
                      <div class="form-outline  col">
                            <label class="form-label">State</label>
                            <asp:DropDownList runat="server" ID="ddlstate" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                
                  <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">Religion</label>
                           <asp:dropdownlist ID="ddlreligion" runat="server" CssClass="form-select" AutoPostBack="false"></asp:dropdownlist>
                      </div>
                      <div class="form-outline col">
                          <label class="form-label d-inline">Minority</label>
                          <div class="mt-2">
                              <Asp:radiobutton text="Yes" GroupName="Minority"  id="yes" runat="server" CssClass="m-2"/>
                          <Asp:radiobutton text="No" GroupName="Minority"  id="no" runat="server" CssClass="m-2"/>
                          </div>
                            
                    </div>
                     
                       
                <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">Fees Catagory</label>
                            <asp:dropdownlist ID="ddlfees" runat="server" CssClass="form-select"></asp:dropdownlist>
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Current Register Number</label>
                            <input type="text" class="form-control" runat="server" id="currentregno" />
                    </div>
                      <div class="form-outline  col">
                            <label class="form-label">Current Class</label>
                            <input type="text" class="form-control" runat="server" id="currentclass"  />
                    </div>
                </div>
                     
                </div>
              <asp:button runat="server" id="enrollsubmitbtn" Text="Update" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:100px;height:30px;color:blue" CssClass="p-1 mt-3" />
                
            
            </div>
        </div>
         <div class="container-fluid position-absolute  mt-5"  id="photo"  runat="server" style="width:  96%; height:max-content;display:none;" >
           <div class="container p-3 " style="width:80%;">

               <div class="d-flex justify-content-between">
                   <div class="form-outline">
                       <label class="form-label">Upload Photo</label>
                          <asp:FileUpload ID="uploadphoto" runat="server" cssclass="form-control"/>    <asp:label runat="server" ID="errtext" ForeColor="red"></asp:label>
                   </div>
                
               </div>
            
               <asp:button Text="upload" runat="server" ID="picbtn" cssclass="btn btn-primary mt-4" OnClick="picbtn_Click"/>


           </div>








        </div>
        <div class="container-fluid position-absolute mt-5"  id="document"  runat="server" style="width:  96%; height:max-content;display:none;" >
           
            <div class="container p-3 position-relative">
        <asp:button runat="server" id="adddocumentbtn" Text="Add New Document"  onclick="adddocumentbtn_Click" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:200px;height:30px;color:blue" CssClass=" float-end mb-3" />
               <div class="container-fluid table-responsive" style="width:95%;"><asp:GridView runat="server" ID="documentviewer" AutoGenerateColumns="FALSE" CssClass="table table-bordered table-hover">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>S.No</HeaderTemplate>
                            <ItemTemplate><%#Container.DataItemIndex + 1%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField headertext="File Type" DataField="file_type"/>
                        <asp:BoundField headertext="File Name" DataField="name"/>
                        <asp:BoundField headertext="File Description" DataField="file_description"/>
                        <asp:BoundField headertext="Document Type" DataField="document_type"/>
                        <asp:boundfield headertext="Updated On" DataField="updated_on"/>
                        <asp:boundfield headertext="Updated By" DataField="updated_by"/>
                      <asp:TemplateField>
                         <HeaderTemplate>
                             View
                         </HeaderTemplate>
                         <ItemTemplate>
                               <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye text-danger "  viewBox="0 0 16 16">
  <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"/>
  <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"/>
</svg>
 

                         </ItemTemplate>
                     </asp:TemplateField>
                    </Columns>
                </asp:GridView>
               
                   </div> 
                <div class="container p-5 getdoc " id="getdoc"  runat="server" style="display:none;">
                    <div class="row mt-3">
                  <div class=" col">
                    <label class="form-label">File Type</label>
                    <input type="text" class="form-control" style="width:max-content;" id="filetype" runat="server"/>
                </div>

                       <div class="col mt-2">
                          <label class="form-label ">Document Type</label>
                          <asp:RadioButtonList ID="doctype" runat="server" RepeatDirection="Horizontal" CssClass="mr-2">
                         
                              <asp:ListItem   text=" Original" style="margin-left:4px;"></asp:ListItem>
                              <asp:ListItem class="m-1" Text=" Scan Copy" Value="Scan Copy"> </asp:ListItem>
                              <asp:ListItem class="m-1" Text=" Xerox"></asp:ListItem>
                              <asp:ListItem class="m-1" Text=" Image"></asp:ListItem>
                             
                          </asp:RadioButtonList>
                            
                    </div>
                    </div>

                    <div class="row mt-2">
                    <div class="col ">
                    <label class="form-label">File Description</label>
                    <input type="text" class="form-control" id="filedescription" runat="server"/>
                    </div>

                        <div class="col">
                            <label class="form-label">Upload Document</label>
                            <asp:FileUpload id="uploaddoc" runat="server" CssClass="form-control" />
                        </div>

                        </div>


                    <div class="row mt-3">
                    <div class="form-outline col ">
                    <label class="form-label">comment</label>
                    <textarea rows="5" cols="17" class="form-control"  id="comment" runat="server" style="max-width:390px;"></textarea>
                </div>
                     <input type="hidden" id="current" value="enroll"/>
               
                </div>
             
                    <asp:button runat="server" id="uploadbtn"   Text="Upload" BorderStyle="Solid" onclick="uploadbtn_Click" BorderColor="Blue" BorderWidth="1px" style="border-radius:18px;width:100px;height:30px;color:blue" CssClass="p-1 mt-3 text-center " />
                     
                 
                 
            </div>


                </div>
            </div>
         <div class="container-fluid position-absolute mt-5"  id="contact" style="width:  96%; height:max-content; display:none;" >
            <div class="container p-3">
                <div class="form-outline mt-2 row">
                    <div class="col-4">
                    <label class="form-label"><h5>Primary Contact</h5></label>
                   <asp:DropDownList ID="ddlprimarycontact" runat="server" CssClass="form-select" >

                   </asp:DropDownList></div>
                </div>
                 <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">First Name</label>
                            <input type="text" runat="server" id="pfirstname" class="form-control"  />
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Middle Name</label>
                            <input type="text" runat="server" id="pmiddlename" class="form-control" />
                    </div>
                      <div class="form-outline  col">
                            <label class="form-label">Last Name</label>
                            <input type="text" runat="server" id="plastname" class="form-control"  />
                    </div>
                </div>
                 <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">Phone Number</label>
                            <input type="text" runat="server" id="pphoneno" class="form-control"  />
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Email Id</label>
                            <input type="text"  runat="server" id="pemail" class="form-control" />
                    </div>
                </div>
                
                <div class="form-outline mt-4 row">
                    <div class="col-4">
                    <label class="form-label"><h5>Secondary Contact</h5></label>
                        
                      <asp:DropDownList ID="ddlsecondarycontact" runat="server" CssClass="form-select">

                   </asp:DropDownList></div>
                </div>
                 <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">First Name</label>
                            <input type="text" runat="server" id="sfirstname" class="form-control"  />
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Middle Name</label>
                            <input type="text"  runat="server" id="smiddlename" class="form-control" />
                    </div>
                      <div class="form-outline  col">
                            <label class="form-label">Last Name</label>
                            <input type="text" runat="server" id="slastname" class="form-control"  />
                    </div>
                </div>
                 <div class="row mt-2">
                      <div class="form-outline col">
                            <label class="form-label">Phone Number</label>
                            <input type="text" runat="server" id="sphoneno" class="form-control"  />
                      </div>
                      <div class="form-outline col">
                          <label class="form-label">Email Id</label>
                            <input type="text"  runat="server" id="semail" class="form-control" />
                    </div>
                </div>
                
                   <div class="previousbtn topbtn d-flex justify-content-center align-items-center  float-start mt-4" style="border: 1px solid blue; border-radius: 17px;  width:100px; ;color: blue;"> Update </div>
                
             </div>
          
        </div>
        <div class="container-fluid position-absolute mt-5"  id="parent" style="width:  96%; height:max-content;display:none;" >
            <div class="container p-3">

                  <div class="form-outline mt-2">
                    <label class="form-label">Family Card Number</label>
                    <input type="text" class="form-control"style="width:max-content"/>
                </div>

                <div class="row mt-2">
                <div class="form-outline col">
                    <label class="form-label">Father's FirstName</label>
                    <input type="text" class="form-control"/>
                </div>
                     <div class="form-outline col">
                    <label class="form-label">Father's MiddleName</label>
                    <input type="text" class="form-control"/>
                </div>
                     <div class="form-outline col">
                    <label class="form-label">Father's LastName</label>
                    <input type="text" class="form-control"/>
                </div>
                    </div>

             <div class="row mt-2">
                  <div class="form-outline col">
                    <label class="form-label">Father's Occupuation</label>
                    <input type="text" class="form-control"/>
                </div>

                  <div class="form-outline col">
                    <label class="form-label">Father's Annual Income</label>
                    <input type="text" class="form-control"/>
                </div>
             </div>
               

               <div class="row mt-5">
                <div class="form-outline col">
                    <label class="form-label">Mother's FirstName</label>
                    <input type="text" class="form-control"/>
                </div>
                     <div class="form-outline col">
                    <label class="form-label">Mother's MiddleName</label>
                    <input type="text" class="form-control"/>
                </div>
                     <div class="form-outline col">
                    <label class="form-label">Mother's LastName</label>
                    <input type="text" class="form-control"/>
                </div>
                    </div>

             
              <div class="row mt-2">
                  <div class="form-outline col">
                    <label class="form-label">Mother's Occupuation</label>
                    <input type="text" class="form-control" />
                </div>

                  <div class="form-outline col">
                    <label class="form-label">Mother's Annual Income</label>
                    <input type="text" class="form-control"  />
                </div>
             </div>

            </div>
        </div>
         <div class="container-fluid position-absolute mt-5 "  id="health" style="width:  96%; height:max-content;display:none;" >
            <div class="container p-3">
                   <div class="form-outline">
                    <label class="form-label">Age</label>
                    <input type="text" class="form-control" style="width:max-content"/>
                </div>
                 <div class="row mt-2">
                  <div class="form-outline col-sm-3">
                    <label class="form-label">Height</label>
                    <input type="text" class="form-control"  style="width:max-content"/>
                </div>

                  <div class="form-outline col-sm-3">
                    <label class="form-label">Weight</label>
                    <input type="text" class="form-control"  style="width:max-content"/>
                </div>
             </div>
                 <div class="form-outline mt-3">
                          <label class="form-label d-inline">Physically Disabled</label>
                          <div class="">
                              <input type="Radio" class="m-3" />Yes 
                          <input type="Radio"  class="m-3"/>No
                          </div>
                            
                    </div>
                 <div class="form-outline col-sm-3">
                    <label class="form-label">Disablity</label>
                    <input type="text" class="form-control"  style="width:max-content"/>
                </div>

            </div>
        </div>
        <div class="container-fluid position-absolute mt-5"  id="lunch" style="width:  96%; height:max-content;display:none;" >
            <div class="container p-3">
                 <div class="form-outline mt-3">
                          <label class="form-label d-inline">Whether Student opt for Food Provided by School </label>
                     <div class="d-inline-block">
                              <input type="Radio" class="m-3" />Yes 
                          <input type="Radio"  class="m-3"/>No
                      </div>
                            
                    </div>
                  <div class="form-outline col-sm-3">
                    <label class="form-label">Food Type</label>
                    <input type="text" class="form-control"  style="width:max-content"/>
                </div>
            </div>
        </div>
         <div class="container-fluid position-absolute mt-5"  id="sign" style="width:  96%; height:max-content;display:none;" >
            parent's sign
        </div>
        <div class="container-fluid position-absolute mt-5"  id="siblings" style="width:  96%; height:max-content;display:none;" >
            siblings
        </div>
        </div>
          
    </form>
</body>
</html>
