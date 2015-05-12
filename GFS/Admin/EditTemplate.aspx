<%@ Page Title="Edit Template" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTemplate.aspx.cs" Inherits="GFS.Admin.EditTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <div>

                <br />

                <asp:Label ID="Label1" runat="server" Text="Your Saved Form Templates: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnInit="DropDownList1_Init" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>

            </div>
            <asp:ListView ID="feedbackFormList" runat="server" 
                DataKeyNames="FormID" GroupItemCount="1"
                ItemType="GFS.Models.Form" SelectMethod="GetQuestionForms" 
                OnItemCreated="feedbackFormList_ItemCreated" EnableViewState="true">
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
                                    <asp:TextBox ID="TitleBox" runat="server" ReadOnly="True" EnableViewState="true" Width="430px" Visible="true" Text=<%# Eval("Title") %>></asp:TextBox>
                                    <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click"
                                        Visible="true" />
                                    <asp:DropDownList ID="TypeDropDown" runat="server" OnSelectedIndexChanged="TypeDropDown_SelectedIndexChanged" AutoPostBack="true"
                                                Visible="false" EnableViewState="true">
                                            <asp:ListItem Selected="True" Value="null">--Select To Edit--</asp:ListItem>
                                    </asp:DropDownList>
                                    <br>
                                        <br />
                                        <asp:Button ID="SaveButton" runat="server" Text="Save Changes" OnClick="SaveButton_Click"
                                        Visible="false" />
                                        <br />
                                    </br>
                                    <asp:HiddenField ID="FormIDField" Value=<%# Eval("FormID") %> runat="server" />
                                    <asp:HiddenField ID="FormTypeField" Value=<%# Eval("FormType") %> runat="server" />
                                    <asp:TextBox ID="BodyTextbox" runat="server" Height="230px" 
                                        TextMode="MultiLine" Width="500px" EnableViewState="true" Visible="false" ReadOnly="true"></asp:TextBox>
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
        </div>
    </section>
</asp:Content>
