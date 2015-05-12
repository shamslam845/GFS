<%@ Page Title="Edit Template" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTemplate.aspx.cs" Inherits="GFS.Admin.EditTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <div>

                <asp:Label ID="Label1" runat="server" Text="Your Saved Form Templates: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnInit="DropDownList1_Init">
                </asp:DropDownList>

            </div>

        </div>
    </section>
</asp:Content>
