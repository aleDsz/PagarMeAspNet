<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PagarMeAspNet.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="ValidateRequest.aspx" method="post">
        <input name="current_status" value="paid" /><br />
        <input name="transaction[id]" value="123456789" /><br />
        <input name="transaction[boleto_url]" value="http://pagar.me" /><br />
        <input type="submit" value="Enviar" />
    </form>
</body>
</html>