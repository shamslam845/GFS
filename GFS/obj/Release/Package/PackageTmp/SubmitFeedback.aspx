<%@ Page Title="Feedback Form Creation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="SubmitFeedback.aspx.cs" Inherits="GFS.SubmitFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2>&nbsp;</h2>
            </hgroup>
            <div>
                &nbsp;&nbsp;<asp:Label ID="CourseLabel" runat="server" Text="Select Your Course ID: "></asp:Label>
                <asp:DropDownList ID="CourseDropdown" AutoPostBack="True" runat="server"
                OnInit="CourseDropdown_Init" OnSelectedIndexChanged = "CourseDropdown_SelectedIndexChanged"
                AppendDataBoundItems="true">
                <asp:ListItem Text="--Select One--" Value="null" />
            </asp:DropDownList>
            &nbsp;<div>
                </div>
            </div>
            <div>
                <asp:Label ID="SectionLabel" runat="server" Text="Select Your Section ID:   " Visible="False"></asp:Label>
                <asp:DropDownList ID="SectionDropdown" runat="server" Visible="False"
                    AutoPostBack="True" OnSelectedIndexChanged = "SectionDropdown_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <asp:ListView ID="feedbackFormList" runat="server" 
                DataKeyNames="FormID" GroupItemCount="1"
                ItemType="GFS.Models.Form" SelectMethod="GetQuestionForms" 
                OnItemCreated="feedbackFormList_ItemCreated" OnLoad="feedbackFormList_Load" EnableViewState="true">
                <EmptyDataTemplate>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server" enableviewstate="true">
                        <td id="itemPlaceholder" runat="server" enableviewstate="true"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <%#:String.Format("{0:c}", Item.Title)%>
                                    <br>
                                    </br>
                                    <asp:Label ID="MissLabel" runat="server" Text="You did not fill this out." ForeColor="Red" Visible="False"></asp:Label>
                                    <br>
                                    </br>
                                    <asp:HiddenField ID="FormIDField" Value=<%# Eval("FormID") %> runat="server" />
                                    <asp:HiddenField ID="FormTypeField" Value=<%# Eval("FormType") %> runat="server" />
                                    <asp:TextBox ID="BodyTextbox" runat="server" Height="230px" 
                                        TextMode="MultiLine" Width="500px" EnableViewState="true" Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="RatingDropDown" runat="server" EnableViewState="true" Visible="false">
                                        <asp:ListItem Value="null">--Select One--</asp:ListItem>
                                        <asp:ListItem Value="1">1 Star</asp:ListItem>
                                        <asp:ListItem Value="2">2 Stars</asp:ListItem>
                                        <asp:ListItem Value="3">3 Stars</asp:ListItem>
                                        <asp:ListItem Value="4">4 Stars</asp:ListItem>
                                        <asp:ListItem Value="5">5 Stars</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <asp:Button ID="FeedbackSubmitBtn" OnClick="FeedbackSubmitBtn_Click" runat="server" Text="Submit" 
                Visible="false" />
            <asp:Label ID="ThankYouLabel" runat="server" Text="Thank you for the feedback!" ForeColor="Red" ViewStateMode="Enabled" Visible="False"></asp:Label>
        </div>
    </section>
</asp:Content>