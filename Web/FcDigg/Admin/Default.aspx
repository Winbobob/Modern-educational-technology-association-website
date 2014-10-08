<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
			<!-- include -->
				<!-- tip -->
			<%--<div class="msgbox">
				<div class="msgtitle">操作提示</div>
				<div class="msgcontent">
					<li>网站初始设置 网站优化设置</li>
					 
				</div>
			</div>--%>
			<!-- tip end -->
			<!-- item -->
			<div class="tablebody">
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>基本设置</div>
				<div class="tablecontent" id="tablecontent_1">
                    <asp:DetailsView ID="DetailsView1" CssClass="table" runat="server"   
                        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="LinqDataSource1">
                        <Fields>
                            <asp:BoundField DataField="name"  HeaderText="网站名称" SortExpression="name">
                            <HeaderStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="网站url" SortExpression="url">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("url") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("url") %>'></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("url") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="统计代码" SortExpression="jscode">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("jscode") %>' TextMode="MultiLine" Width="90%"></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("jscode") %>'></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                 <asp:TextBox ID="TextBox3" ReadOnly="true" runat="server" Text='<%# Bind("jscode") %>' TextMode="MultiLine" Width="90%"></asp:TextBox>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="icp" HeaderText="icp" SortExpression="icp" />
                            <asp:CheckBoxField DataField="state" HeaderText="网站状态" 
                                SortExpression="state" />
                            <asp:TemplateField HeaderText="关闭原因" SortExpression="state_demo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("state_demo") %>' 
                                        TextMode="MultiLine" Width="90%"></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("state_demo") %>' ></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox2" ReadOnly="true" TextMode="MultiLine" Width="90%" runat="server" Text='<%# Bind("state_demo") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="title" HeaderText="网站标题" SortExpression="title" />
                            <asp:BoundField DataField="Keywords" HeaderText="关键字" 
                                SortExpression="Keywords" />
                            <asp:BoundField DataField="Description" HeaderText="网站简介" 
                                SortExpression="Description" />
                            <asp:CommandField ShowEditButton="True" />
                        </Fields>
                        <AlternatingRowStyle  CssClass="tcell_two" />
                    </asp:DetailsView>
				  
	                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        EnableUpdate="True" TableName="she">
                    </asp:LinqDataSource>
				  
	</div>
</div>
 
</asp:Content>

