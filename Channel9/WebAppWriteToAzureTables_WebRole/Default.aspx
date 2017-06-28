<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppWriteToAzureTables_WebRole._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <br />
        <asp:Table
            ID="Table1"
            runat="server" GridLines="Both" CellPadding="10" CellSpacing="10">
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <h1>Great Quotes</h1>
                    <asp:Label ID="lblMessage" Text="" runat="server" /><br />
                    <asp:Label
                        Text="The Quote"
                        runat="server" />
                    <br />
                    <asp:TextBox
                        ID="txtQuote"
                        Text="You only live once."
                        runat="server"
                        Height="52px"
                        Width="695px">
                    </asp:TextBox>
                    <br />
                    <asp:Label
                        Text="Author"
                        runat="server" />
                    <br />
                    <asp:TextBox
                        ID="txtAuthor"
                        Text="Anonymous"
                        runat="server"
                        Height="53px"
                        Width="420px">
                    </asp:TextBox>
                    <br />
                    <asp:Label
                        Text="Submitter"
                        runat="server" />
                    <br />
                    <asp:TextBox
                        ID="txtSubmitter"
                        Text="Submitter"
                        runat="server"
                        Height="43px"
                        Width="420px">
                    </asp:TextBox>
                    <br />
                    <asp:Button
                        ID="cmdAddQuote"
                        runat="server"
                        Text="Add Quote"
                        OnClick="cmdAddQuote_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label
                        Text="Insert a Batch"
                        runat="server" />
                    <br />
                    <asp:Button
                        ID="cmdAddBatch"
                        runat="server"
                        Text="Add Batch"
                        OnClick="cmdAddBatch_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <br />
                    <asp:Button
                        ID="cmdGetOscarWildeQuotes"
                        runat="server"
                        Text="Get Oscar Wilde Quotes"
                        OnClick="cmdGetOscarWildeQuotes_Click" />
                    <br />
                    <asp:ListBox ID="lbQuotes" runat="server" Visible="false"></asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

</asp:Content>
