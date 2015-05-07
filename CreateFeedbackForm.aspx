<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFeedbackForm.aspx.cs" Inherits="GFS.CreateFeedbackForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            
            <br />
            <br />
            <asp:Label ID="NameLabel" runat="server" Text="Enter name of this new form: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="25px" MaxLength="100" Width="512px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter description for the new form (Optional):"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="263px" MaxLength="1000" TextMode="MultiLine" Width="542px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Which sections would you like to associate with this form?(Optional)"></asp:Label>
            <br />
            <br />
            <asp:CheckBoxList ID="SectionCheckboxList" runat="server" OnInit="AddSections">
            </asp:CheckBoxList>
            
            <br />
            <br />
            <asp:Button ID="CreateButton" runat="server" Text="Create Form!" OnClick="CreateButton_Click" />
            
        </div>
    </section>
</asp:Content>
