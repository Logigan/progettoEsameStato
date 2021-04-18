<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EsameStato.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
        <div class="header-text">
            <div class="container">
                <div class="row">
                    <div class="left-text col-lg-6 col-md-12 col-sm-12 col-xs-12"
                        data-scroll-reveal="enter left move 10px over 0.6s after 0.4s">
                        <h1>Segreteria <em>Golden Sports Club</em></h1>
                        <asp:LinkButton ID="lnkReg2" runat="server" OnClick="lnkReg2_Click">Registrazione</asp:LinkButton><br /><br /> <asp:LinkButton ID="lnkUtenti2" runat="server" OnClick="lnkUtenti2_Click">Utenti</asp:LinkButton><br /><br /> <asp:LinkButton ID="lnkSrv" runat="server" OnClick="lnkSrv2_Click">Servizi</asp:LinkButton><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphIndex" runat="server">
    <footer id="contact-us">
        <div class="container">
            <div class="footer-content">
                <div class="row">
                    <!-- ***** Contact Form Start ***** -->
                    <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="contact-form">
                            <form id="contact" action="" method="post">
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <fieldset>
                                            <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <fieldset>
                                            <asp:TextBox ID="txtCognome" runat="server" placeholder="Cognome"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div class="col-lg-12">
                                        <fieldset>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div class="col-lg-12">
                                        <fieldset>
                                            <asp:Button ID="btnRegistraRapido" runat="server" Text="Invia" OnClick="btnRegistraRapido_Click" />
                                        </fieldset>
                                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                    <!-- ***** Contact Form End ***** -->
                    <div class="right-content col-lg-6 col-md-12 col-sm-12">
                        <h2>Registrazione Rapida <em>Cliente</em></h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="sub-footer">
                        <p>Questa pagina è riservata alla segreteria del centro Golden Sports Club || Copyright &copy; 2020 Golden Sports Club</p> 
                    </div>
                </div>
            </div>
        </div>
    </footer>
</asp:Content>