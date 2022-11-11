<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    Tdr<asp:UpdatePanel ID="atualizar" UpdateMode="Conditional">
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="Label1" runat="server" Text="UpLoad de Arquivo"></asp:Label>
            </div>
            <asp:FileUpload ID="fuArquivo" runat="server" Auto />
            <p>
                <asp:Label ID="Label2" runat="server" Text="Nome do Arquivo"></asp:Label>
                <asp:TextBox ID="txbNome" runat="server"></asp:TextBox>
            </p>
            <asp:Label ID="Label3" runat="server" Text="Tamanho do arquivo"></asp:Label>
            <asp:TextBox ID="txbTamanho" runat="server"></asp:TextBox>
            <p>
            </p>
            <asp:Label ID="Label4" runat="server" Text="Primeira Coluna, primeira célula: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Segunda Coluna, primeira célula: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Terceira Coluna, primeira célula: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                           
            <asp:GridView
                ID="GridView1"
                runat="server"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Loja" HeaderText="Loja" SortExpression="Loja" />
                    <asp:BoundField DataField="Tipo_de_gasto" HeaderText="Tipo_de_gasto" SortExpression="Tipo_de_gasto" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                </Columns>
            </asp:GridView>
             <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            <asp:GridView
                ID="GridView2"
                runat="server"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Loja" HeaderText="Loja" SortExpression="Loja" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                </Columns>
            </asp:GridView>
            
            <asp:GridView
                ID="GridView3"
                runat="server"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Tipo_de_gasto" HeaderText="Tipo_de_gasto" SortExpression="Tipo_de_gasto" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                </Columns>
            </asp:GridView>
           

            <p>
                <asp:Button ID="btEnviar" runat="server" OnClick="Button1_Click" Text="Enviar Arquivo" Width="146px" />
            </p>
        </form>
    </asp:UpdatePanel>
</body>
</html>
