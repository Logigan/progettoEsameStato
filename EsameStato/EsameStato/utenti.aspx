<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaster.Master" AutoEventWireup="true" CodeBehind="utenti.aspx.cs" Inherits="EsameStato.utenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <div class="header-text">
         <div class="container">
            <div class="row">
               <div class="left-text col-md-12 col-sm-12 col-xs-12"
                     data-scroll-reveal="enter left move 10px over 0.6s after 0.4s">
                    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" DataKeyNames="idCliente" OnRowCommand="dgv_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="idCliente" HeaderText="idCliente" visible="false"/>
                            <asp:BoundField DataField="nome" HeaderText="Nome" />
                            <asp:BoundField DataField="cognome" HeaderText="Cognome"/>
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:BoundField DataField="altezza" HeaderText="Altezza" />
                            <asp:BoundField DataField="peso" HeaderText="Peso" />
                            <asp:BoundField DataField="pMassaGrassa" HeaderText="% Massa Grassa" />
                            <asp:ButtonField ButtonType="Button" CommandName="aggiorna" Text="Aggiorna" HeaderText="Aggiorna" ControlStyle-CssClass="btn btn-primary" />
                            <asp:ButtonField ButtonType="Button" CommandName="elimina" Text="Elimina" HeaderText="Elimina" ControlStyle-CssClass="btn btn-warning" />
                        </Columns>
                    </asp:GridView>
                   <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div></div></div></div>
</asp:Content>
