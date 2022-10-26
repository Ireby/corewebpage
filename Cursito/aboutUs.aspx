<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutUs.aspx.cs" Inherits="Cursito.aboutUs" %>
<!-- codeBehind -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="public/bootstrap-5.2.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>About Us</title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <nav class="navbar  navbar-expand-lg bg-dark ">
 <div class="container">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active text-warning" aria-current="page" href="index.aspx" >Home</a>
               
        </li>
   
           <li class="nav-item">
          <a class="nav-link text-white" href="aboutUs.aspx">Abot us</a>
          
        </li>
            <li class="nav-item">
          <asp:HyperLink runat="server" NavigateUrl="~/Index.aspx">Home ASP</asp:HyperLink>
      </li>
                  </ul>
    </div>
</nav>
    </div>
        <div class="container">
            <h1>Controles de Servidor</h1>
            <pre>Se ejecutan en el server pero se codifica a html</pre>

            <asp:Label runat="server" ID="nombreAlControlDelServidor" Text="Permite agreguar al control de servidor">
           <p> <%=nombreAlControlDelServidor.Text%></p>
                <asp:Label runat="server"></asp:Label>
            </asp:Label>
        </div>
        
        <!--Validacion-->
        <h1>RequiredFioedValidator</h1>
        <h1>RegularExpressionValidator</h1>
        <h1>CustomValidator</h1>
        <h1>CompareValidator</h1>


    </form>
</body>
</html>
