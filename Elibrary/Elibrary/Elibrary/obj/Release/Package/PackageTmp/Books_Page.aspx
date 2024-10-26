<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" Async="true"  AutoEventWireup="true" CodeBehind="Books_Page.aspx.cs" Inherits="Elibrary.Books_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
          <div class="container-fluid">
               <div class="row">
                   <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/book.jpg" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>    
                    <asp:Label ID="lblMessage" runat="server" CssClass="alert" Style="display:none;" />
                     <div class="col-md-6">
                        <label>Title</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtTitle" required="" runat="server" placeholder="Book Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Author Name</label>
                        <div class="form-group">
                          <asp:TextBox CssClass="form-control" ID="txtAuthor" runat="server" required="" placeholder="Author Name"></asp:TextBox>
                        </div>
                        <label>Edition</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtEdition" runat="server" required="" placeholder="Edition"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Publisher</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtPublisher" runat="server" required="" placeholder="Publisher"></asp:TextBox>
                        </div>
                        <label>Publish Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtPublication_Date" runat="server" required="" placeholder="Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Genre</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="txtGenre" required="" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />
                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  
                  <div class="row">
                     <div class="col-md-4">
                        <label>ISBN</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtISBN" runat="server" required="" placeholder="ISBN"></asp:TextBox>
                        </div>
                         </div>

                       


                             <div class="col-md-4">
                             <label>Actual Stock</label>
                             <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="stock" runat="server" required="" placeholder="Actual Stock" ></asp:TextBox>
                             </div>
                                 </div>
                     </div>
                     

                    <div class="row">
    <div class="col-12">
       <label>Book Description</label>
       <div class="form-group">
          <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" required="" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
       </div>
    </div>
 </div>
              
                   <div class="row">
   <div class="col-12">
      <asp:Button  ID="login"  OnClick="Register_Click" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" />
   </div>
</div>
   
<div class="row" style="margin-top: 20px;">
    <div class="col-md-4 offset-md-4">
        <div class="text-center">
            <label for="TextBox1" class="form-label" style="font-weight: bold;">Book ID:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" Placeholder="Enter Book ID"></asp:TextBox>
        </div>
    </div>
</div>

  <br />
<div class="row">
   <div class="col-6">
      <asp:Button ID="update" OnClick="Update_Click" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" />
   </div>
   <div class="col-6">
      <asp:Button ID="delete" OnClick="Delete_Click" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" />
   </div>
</div>
                    
                  </div>
                 
                      
               </div>

                                      
            </div>
           
            
         </div>
<br>

       <div class="col-md-12">
          <div class="card">
             <div class="card-body">
                <div class="row">
                   <div class="col">
                      <center>
                         <h4>Book List</h4>
                      </center>
                   </div>
                </div>


                 <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                
                
                <div class="row">
                   <div class="col">
                      <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                   </div>
                </div>
             </div>
          </div>
       </div>
    </div>
 </div>






</asp:Content>
