<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaster.Master" AutoEventWireup="true" CodeBehind="servizi.aspx.cs" Inherits="EsameStato.servizi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <div class="header-text">
         <div class="container">
            <div class="row">
               <div class="left-text col-md-12 col-sm-12 col-xs-12"
                     data-scroll-reveal="enter left move 10px over 0.6s after 0.4s">
                    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" DataKeyNames="idServizio" OnRowCommand="dgv_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="idServizio" HeaderText="idServizio" visible="false"/>
                            <asp:BoundField DataField="tipologia" HeaderText="Tipologia" />
                            <asp:BoundField DataField="prezzo" HeaderText="Prezzo"/>
                            <asp:BoundField DataField="percorso" HeaderText="Percorso" />
                            <asp:ButtonField ButtonType="Button" CommandName="elimina" Text="Elimina" HeaderText="Elimina" ControlStyle-CssClass="btn btn-warning" />
                        </Columns>
                    </asp:GridView>
                   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div></div></div></div>
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
                                            <asp:TextBox ID="txtTipologia" runat="server" placeholder="Tipologia"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <fieldset>
                                            <asp:TextBox ID="txtPrezzo" runat="server" placeholder="Prezzo"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <div class="col-lg-12">
                                        <fieldset>
                                            <div>
                                                    Seleziona File &nbsp;<asp:FileUpload ID="fup" runat="server" /><br />
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="col-lg-12">
                                        <fieldset>
                                            <asp:Button ID="btnRegistrazioneServizio" runat="server" Text="Registra" OnClick="btnRegistrazioneServizio_Click" />
                                        </fieldset>
                                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                    <!-- ***** Contact Form End ***** -->
                    <div class="right-content col-lg-6 col-md-12 col-sm-12">
                        <h2>Registrazione <em>Servizio</em></h2>
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
