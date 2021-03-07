<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EsameStato.index" %>
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
                                        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                    <!-- ***** Contact Form End ***** -->
                    <div class="right-content col-lg-6 col-md-12 col-sm-12">
                        <h2>Registrazione Rapida <em>Cliente</em></h2>
                        <ul class="social">
                            <li><a href="https://fb.com/templatemo"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                            <li><a href="#"><i class="fa fa-rss"></i></a></li>
                            <li><a href="#"><i class="fa fa-dribbble"></i></a></li>
                        </ul>
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