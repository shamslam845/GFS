<%@ Page Title="Feedbacks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="GFS.Admin.FeedbackList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style="width:98%;">
        <tr>
           <td style="height: 485px; width: 200px">
                <div id="TitleContent" style="text-align: center">
                    <h1>Courses</h1>
                </div>
                <div id="CourseMenu" style="text-align: center">
                    <asp:ListView ID="CourseList" ItemType="GFS.Models.Section"
                        runat="server" SelectMethod="GetCourses">
                        <ItemTemplate>
                            <b style="font-size: medium; font-style: normal">
                                <a href="/Admin/FeedbackList.aspx?id=<%#: Item.SectionID %>">
                                    <%#: Item.CourseName %>
                                </a>
                        </ItemTemplate>
                        <ItemSeparatorTemplate> <br /> </ItemSeparatorTemplate>
                    </asp:ListView>

                </div>
               
               </td>

                <td style="height: 485px">
                 <%--
     <asp:ListView ID="ListView1" runat="server" DataKeyNames="FeedbackId" ItemType="GFS.Models.Feedback" SelectMethod="GetFeedbacks" SourceID="SqlDataSource1">
                        <AlternatingItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="FeedbackIdLabel" runat="server" Text='<%#: Item.FeedbackId %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="CourseNameLabel" runat="server" Text='<%#: Item.CourseName %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="SectionIDLabel" runat="server" Text='<%#: Item.SectionID %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%#: Item.Description.Substring(0,10) %>' /></a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server" style="">
                                <tr>
                                    <td>Theres no course feedback.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="FeedbackIdLabel" runat="server" Text='<%#: Item.FeedbackId %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="CourseNameLabel" runat="server" Text='<%#: Item.CourseName %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="SectionIDLabel" runat="server" Text='<%#: Item.SectionID %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%#: Item.Description.Substring(0,10) %>' /></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                            <tr runat="server" style="">
                                                <th runat="server">Delete</th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortByFeedbackId"
                                                  CommandName="Sort" Text="Feedback#" 
                                                  CommandArgument="FeedbackId"/></th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortByCourseName"
                                                  CommandName="Sort" Text="Course" 
                                                  CommandArgument="CourseName"/></th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortBySectionId"
                                                CommandName="Sort" Text="Section" 
                                                CommandArgument="SectionId"/></th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortByDescription"
                                                  CommandName="Sort" Text="Description" 
                                                  CommandArgument="Description"/></th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="">
                                        <asp:DataPager ID="DataPager1" runat="server">
                                            <Fields>
                                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="FeedbackIdLabel" runat="server" Text='<%#: Item.FeedbackId %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="CourseNameLabel" runat="server" Text='<%#: Item.CourseName %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="SectionIDLabel" runat="server" Text='<%#: Item.SectionID %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%#: Item.Description.Substring(0,10) %>' /></a>
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                    </asp:ListView>--%>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName" />
                            <asp:HyperLinkField HeaderText="Message" DataTextField="Message" SortExpression="Message" DataNavigateUrlFormatString="~/Admin/FeedbackList.aspx?FeedbackID={0}" DataNavigateUrlFields="FeedbackID"/>
                            <asp:BoundField DataField="DateTimes" HeaderText="Date" SortExpression="DateTimes" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="SectionNumber" HeaderText="Section Number" SortExpression="SectionNumber" />

                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GFSConnection %>" SelectCommand="SELECT Sections.CourseName, FeedbackContainers.DateTimes, Forms.Title, Sections.SectionID, Sections.SectionNumber, Feedbacks.FeedbackID, Feedbacks.Message FROM FeedbackContainers INNER JOIN Feedbacks ON FeedbackContainers.FeedbackContainerID = Feedbacks.FeedbackContainerID INNER JOIN FormContainers ON FeedbackContainers.FormContainerID = FormContainers.FormContainerID INNER JOIN Forms ON FormContainers.FormContainerID = Forms.FormContainerID INNER JOIN Sections ON Feedbacks.SectionID = Sections.SectionID"></asp:SqlDataSource>
                </td>

            </tr>
        <tr>
            <td style="width: 200px">

            </td>
            <td><%--
                <asp:FormView ID="FeedbackDetail" runat="server" ItemType="GFS.Models.Feedback" SelectMethod="GetFeedbackDetails" RenderOuterTable="false">
                    <ItemTemplate>
                        <div>
                            <h3>Course: <%#: Item.CourseName %></h3>
                            <h3>Section: <%#: Item.SectionID %></h3>
                            <h3>Feedback:</h3>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%#: Item.Description %>' />
                            <br />
                            
                            <asp:Button ID="Reply" runat="server" CommandArgument="<%#: Item.CourseId %>" Text="Reply" OnClick="Reply_Click"/>
                        </div>
                    </ItemTemplate>
                </asp:FormView>--%>

                <asp:FormView ID="FeedbackDetail" runat="server" ItemType="GFS.Models.Feedback" SelectMethod="GetFeedbackDetails" RenderOuterTable="false">
                    <ItemTemplate>
                        <div>
                            <h3> Section: <%#: Item.SectionID %></h3>
                            <h3> Feedback: </h3>
                            <asp:Label ID="MessageLabel" runat="server" Text="<%#: Item.Message %>" />
                            <br />
                            <asp:Button ID="Reply" runat="server" CommandArgument="<%# Item.SectionID %>" Text="Reply" OnClick="Reply_Click" />
                        </div>
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>

        </table>
    


    



    

</asp:Content>
<%-- PREVIOUS MODEL
    <div id="CourseMenu" style="text-align: center">
            <asp:ListView ID="courseList"
                ItemType="GFS.Models.Course"
                runat="server"
                SelectMethod="GetCourses" >
                <ItemTemplate>
                    <b style="font-size: medium; font-style: normal">
                        <a href="/Admin/FeedbackList.aspx?id=<%#: Item.CourseId %>">
                            <%#: Item.CourseName %>
                        </a>
                </ItemTemplate>
                <ItemSeparatorTemplate>  |  </ItemSeparatorTemplate>
            </asp:ListView>
        </div>



<asp:ListView ID="ListView2" runat="server"
        DataKeyNames="FeedbackId" ItemType="GFS.Models.Feedback" SelectMethod ="GetFeedbacks">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>There is no feedback for this course</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                                <%#: Item.FeedbackId %>
                            </a>
                        </td>
                        <td>
                            <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                            <%#: Item.CourseId %>
                        </td>
                        <td>
                            <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                            <%#: Item.SectionID %>
                        </td>
                        <td>
                            <a href="/Admin/FeedbackList.aspx?feedbackId=<%#: Item.FeedbackId %>">
                            <%#: Item.Description %>
                        </td>
                    </tr>
                </table>
        </ItemTemplate>
        <LayoutTemplate>
            <tr style="">
                <td>
                    <th>Feedback ID</th>
                    <th>Course</th>
                    <th>Section</th>
                    <th>Description</th>
                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                        <tr id="groupPlaceholder"></tr>
                    </table>

                </td>
            </tr>
        </LayoutTemplate>
    </asp:ListView>

     <asp:ListView ID="ListView1" runat="server" DataKeyNames="FeedbackId" DataSourceID="SqlDataSource1">
                        <AlternatingItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="FeedbackIdLabel" runat="server" Text='<%# Eval("FeedbackId") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="CourseNameLabel" runat="server" Text='<%# Eval("CourseName") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="SectionIDLabel" runat="server" Text='<%# Eval("SectionID") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description").ToString().Substring(0,10) %>' /></a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                                </td>
                                <td>
                                    <asp:Label ID="FeedbackIdLabel1" runat="server" Text='<%# Eval("FeedbackId") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CourseNameTextBox" runat="server" Text='<%# Bind("CourseName") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SectionIDTextBox" runat="server" Text='<%# Bind("SectionID") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server" style="">
                                <tr>
                                    <td>No data was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <InsertItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="CourseNameTextBox" runat="server" Text='<%# Bind("CourseName") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="SectionIDTextBox" runat="server" Text='<%# Bind("SectionID") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="FeedbackIdLabel" runat="server" Text='<%# Eval("FeedbackId") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="CourseNameLabel" runat="server" Text='<%# Eval("CourseName") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="SectionIDLabel" runat="server" Text='<%# Eval("SectionID") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description").ToString().Substring(0,10) %>' /></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                            <tr runat="server" style="">
                                                <th runat="server">Delete</th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortByFeedbackId"
                                                  CommandName="Sort" Text="Feedback#" 
                                                  CommandArgument="FeedbackId"/></th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortByCourseName"
                                                  CommandName="Sort" Text="Course" 
                                                  CommandArgument="CourseName"/></th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortBySectionId"
                                                CommandName="Sort" Text="Section" 
                                                CommandArgument="SectionId"/></th>
                                                <th runat="server"><asp:LinkButton runat="server" ID="SortByDescription"
                                                  CommandName="Sort" Text="Description" 
                                                  CommandArgument="Description"/></th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="">
                                        <asp:DataPager ID="DataPager1" runat="server">
                                            <Fields>
                                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="FeedbackIdLabel" runat="server" Text='<%# Eval("FeedbackId") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="CourseNameLabel" runat="server" Text='<%# Eval("CourseName") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="SectionIDLabel" runat="server" Text='<%# Eval("SectionID") %>' /></a>
                                </td>
                                <td>
                                    <a href="/Admin/Admin/FeedbackList.aspx?feedbackId=<%# Eval("FeedbackId") %>">
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description").ToString().Substring(0,10) %>' /></a>
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:GFSConnection %>" DeleteCommand="DELETE FROM [Feedbacks] WHERE [FeedbackId] = @original_FeedbackId AND [CourseName] = @original_CourseName AND [SectionID] = @original_SectionID AND [Description] = @original_Description" InsertCommand="INSERT INTO [Feedbacks] ([CourseName], [SectionID], [Description]) VALUES (@CourseName, @SectionID, @Description)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [FeedbackId], [CourseName], [SectionID], [Description] FROM [Feedbacks]" UpdateCommand="UPDATE [Feedbacks] SET [CourseName] = @CourseName, [SectionID] = @SectionID, [Description] = @Description WHERE [FeedbackId] = @original_FeedbackId AND [CourseName] = @original_CourseName AND [SectionID] = @original_SectionID AND [Description] = @original_Description">
                        <DeleteParameters>
                            <asp:Parameter Name="original_FeedbackId" Type="Int32" />
                            <asp:Parameter Name="original_CourseName" Type="String" />
                            <asp:Parameter Name="original_SectionID" Type="Int32" />
                            <asp:Parameter Name="original_Description" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CourseName" Type="String" />
                            <asp:Parameter Name="SectionID" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CourseName" Type="String" />
                            <asp:Parameter Name="SectionID" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="original_FeedbackId" Type="Int32" />
                            <asp:Parameter Name="original_CourseName" Type="String" />
                            <asp:Parameter Name="original_SectionID" Type="Int32" />
                            <asp:Parameter Name="original_Description" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
--%>