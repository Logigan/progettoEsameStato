<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aggiornamentoSuccesso.aspx.cs" Inherits="EsameStato.aggiornamentoSuccesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Segreteria</h1>
        <h2>Dati di: <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label> aggiornati con successo</h2> 
        <br />
        <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
    </form>
</body>
</html>
