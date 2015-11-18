<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FotoFilter.aspx.cs" Inherits="FotoFilter" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div>
        
        <asp:FileUpload ID="FileUpload1"
            runat="server" /><asp:Button ID="Button1" runat="server" Text="Button" 
            onclick="Button1_Click" />
                
            <hr />
               ortalama:<br />
        <asp:Label ID="lblOrt" runat="server" Text="Label"></asp:Label>
        
    </div>
    
    <br />
    
 
</asp:Content>

