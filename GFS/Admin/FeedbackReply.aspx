<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedbackReply.aspx.cs" Inherits="GFS.Admin.FeedbackReply" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:FormView ID="FeedbackReplys" runat="server" ItemType="GFS.Models.Email" SelectMethod="GetEmails" RenderOuterTable="false">
        <ItemTemplate>
           
            <div>
                <h3>Reply:</h3>
                <p>You are sending a reply to Section: <%# Item.SectionID %></p>
            </div>
        </ItemTemplate>
    </asp:FormView>
                To:&nbsp&nbsp&nbsp&nbsp&nbsp<br />
                <asp:TextBox ID="To" runat="server" MaxLength="1000" Height="75px" Width="600px" TextMode="MultiLine"></asp:TextBox>
                <br />Subject:&nbsp&nbsp&nbsp&nbsp&nbsp<br />
                <asp:TextBox ID="Subject" runat="server" MaxLength="100" Height="30" Width="600px" TextMode="MultiLine"></asp:TextBox>
                <br />Message:&nbsp&nbsp&nbsp&nbsp&nbsp<br />
                <asp:TextBox ID="Message" runat="server" MaxLength="500" Height="100px" Width="600px"  TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button ID="ReplyButton" runat="server" Text="Reply" OnClick="SendReply" CausesValidation="false" />


</asp:Content>
