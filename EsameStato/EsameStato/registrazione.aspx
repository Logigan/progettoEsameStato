<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaster.Master" AutoEventWireup="true" CodeBehind="registrazione.aspx.cs" Inherits="EsameStato.registrazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <div class="header-text">
         <div class="container">
            <div class="row">
               <div class="left-text col-lg-6 col-md-12 col-sm-12 col-xs-12"
                     data-scroll-reveal="enter left move 10px over 0.6s after 0.4s">
        <div class="banner">
          <h1>Segreteria</h1>
        </div>
        <div class="item">
            <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label><br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="item">
            <asp:Label ID="lblCognome" runat="server" Text="Cognome"></asp:Label><br />
            <asp:TextBox ID="txtCognome" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="item">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="item">
            <asp:Label ID="lblAltezza" runat="server" Text="Altezza"></asp:Label><br />
            <asp:TextBox ID="txtAltezza" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="item">
          <asp:Label ID="Label1" runat="server" Text="Peso"></asp:Label><br />
            <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="item">
          <asp:Label ID="Label2" runat="server" Text="Percentuale massa grassa"></asp:Label><br />
           <asp:TextBox ID="txtPercentualeMassaGrassa" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="item">
            <asp:Button ID="Button1" runat="server" Text="Invia" OnClick="Button1_Click" />
        </div>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
</div></div></div></div>
</asp:Content>
