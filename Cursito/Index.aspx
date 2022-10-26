<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Cursito.Index" %>
<!-- 
    Page es el codigo que se ejecuta y compila del lado del servidor y entrega resultados 
    html
    Language="C#" con el que trabajaremos
     CodeBehind="Index.aspx.cs" con el que trabajaremos en forma directa
    con la clase de c#  
    Inherits="Cursito.Index"  es el que define el nombre de la clase 
    al archivo que va a estar asociado nuestro code behind 
    es decir project Cursito : Index.aspx.c
    -->
<!-- si se coloca el caracter ~ automaticamente reconoce que el directorio public
    se encuentra donde tu lo colocaste
     -->
<meta charset="utf-8" />
<link href="public/bootstrap-5.2.2-dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="public/bootstrap-5.2.2-dist/css/bootstrap.css" rel="stylesheet" />
<link href="public/bootstrap-5.2.2-dist/css/bootstrap.min.css.map" rel="stylesheet"  />

<html>
<head runat="server">
    <title>Cursito ASP.NET</title>
</head>
<body >
  <form id="form1" runat="server">
   <!--NAV BAR -->
<nav class="navbar  navbar-expand-lg bg-dark ">
 <div class="container">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active text-warning" aria-current="page" href="index.aspx" >Home</a>
         </li>
        <li class="nav-item">
          <a class="nav-link text-white" href="#csharp">datos en C#</a>
        </li>

         <li class="nav-item">
          <a class="nav-link text-white" href="#cmetod">Metodos</a>
        </li>
           <li class="nav-item">
          <a class="nav-link text-white" href="aboutUs.aspx">Abot us</a>
          
        </li>

      </ul>
    </div>
</nav>
<!-- -->
      
<div class="container">
    <hr />
        <div >
            Aplicando boostrap
            <div class="row">
                <div class="panel panel-pimary">
                    <div class="panel-heading">
                        <div class="tab-pane">
                                   ejemplo cursito
                        </div>
                     </div>
                </div>
            </div>
        </div>
    <hr />
            <!-- Con asistente codigo-->
            <asp:Wizard ID="Wizard1" runat="server" Height="324px" Width="413px">
                <WizardSteps>
                    <asp:WizardStep runat="server" title="1">
                         <p>Este es un ejemplo de Desing que te entrega lavels</p>
                        <img src="public/img/example.png"class="img-fluid"  />
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" title="2">
                        <p>WEB forms es parte de la estructura de .NET</p>
                                <p>Cuando le colocas un runat="server" a un html se conviente en un html controlserver</p>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
         <!-- Con asistente codigo fin-->
    <hr />
        <div id="csharp">
            <h2 class="text-success">data types en c#</h2>
            <p> abrimos < % para escribir codigo en c# %></p>
            <% //comentarios
                /** de muchas lineas **/
                string text = "string text='variable declarada o.o'";
                const string tconst = "variable constante ";
                // <% % > es igual a {} en JS  
                //en tiempo de ejecucion las variables 
                //pueden cambiar, mientras que las constantes no
                int tnum = '2';//con este no podes hacer operaciones aritmeticas
                int num = 2;//con este si
                long n3 =12;
                float flotante = 1.7f;
                double doble =1.7;
                decimal dec = 10m;//siempre que llevemos datos a un excel que sea en 
                //formato decimal
            

                
            %>
            <div class="p-3 mb-4 text-warning rounded bg-black">
                <h1>Code</h1>
              <ul>
                  <li>
                      <% Response.Write(text); %>
                  </li>
                  <li>
                      <% Response.Write(tconst);%>
                  </li>
                      <%=tnum+n3%><!--concateno--> 
                  <li>
                      <%=flotante%>
                  </li>
                  <li>
                      <%=doble%>
                  </li>
                  <li>
                      <%=dec%>
                  </li>
              </ul>
                <p>Conversiones cuando declaramos una var con un tipo de dato por demos declarar una nueva var con  otro tipo de dato ej de num a lag y asignarle el valor anterior para convertirlo|</p>
            </div>
            <div class="container">
                <div id="#cmetod">
                <h2>Metodos de ejecucion</h2>
                    <button id="#btnEjec">Ejecuta y hace algo</button>
                <h2>Metodos de retorno</h2>
                         <button id="#btnReturn">Ejecuta, hace, retorna</button>
                <h2>Metodos de estaticos</h2>
                         <button id="#btnStatic" >Ejecuta un proceso</button>
                    <ul>
                        
                    </ul>
                </div>
            </div>


        </div>
      </div>
    </form>


  
</body>
</html>
