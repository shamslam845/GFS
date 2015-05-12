<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFeedbackForm.aspx.cs" Inherits="GFS.CreateFeedbackForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            
            <br />
            <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Please enter all required information." Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="NameLabel" runat="server" Text="Enter name of this new form template(Required): "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="25px" MaxLength="100" Width="512px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter description for the new form template (Optional):"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="263px" MaxLength="1000" TextMode="MultiLine" Width="542px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="What type of form would you like this form template to start with? (Required)"></asp:Label>
            <br />
            <asp:DropDownList ID="TypeDropDown" runat="server" OnSelectedIndexChanged="TypeDropDown_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="null">--Select One--</asp:ListItem>
                <asp:ListItem Value="1">Question</asp:ListItem>
                <asp:ListItem Value="2">Star Rating</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter the title or question for this new form(Required):" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" MaxLength="200" Visible="False" Width="570px"></asp:TextBox>
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
