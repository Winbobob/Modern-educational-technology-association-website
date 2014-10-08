<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="adminuser.aspx.cs" Inherits="Admin_adminuser" %>

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
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>会员设置</div>
				<div class="tablecontent" id="tablecontent_1">
                     
				  
	                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CssClass="table" DataKeyNames="id" 
                        DataSourceID="LinqDataSource1" ShowFooter="True" 
                        onrowcommand="GridView1_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                                SortExpression="id" />
                            <asp:TemplateField HeaderText="用户名" SortExpression="name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="name" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="密码" SortExpression="pwd">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("pwd") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="pwd" runat="server" Text='<%# Bind("pwd") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("pwd") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="jb" HeaderText="jb" SortExpression="jb" />
                            <asp:TemplateField HeaderText="头像" SortExpression="photo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="photo" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("photo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                        CommandName="Insert" Text="添加"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="编辑"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Delete" Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            没有数据
                        </EmptyDataTemplate>
                        <PagerStyle CssClass="pages" />
                        <AlternatingRowStyle  CssClass="tcell_two" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        EnableDelete="True" EnableUpdate="True" TableName="user">
                    </asp:LinqDataSource>
                     
				  
				  
	</div>
</div>

</asp:Content>

