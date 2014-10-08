<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="adminlink.aspx.cs" Inherits="Admin_adminlink" %>

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
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>友情链接设置</div>
				<div class="tablecontent" id="tablecontent_1">
	                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CssClass="table" DataKeyNames="id" DataSourceID="LinqDataSource1" 
                        AllowPaging="True" ShowFooter="True" onrowcommand="GridView1_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="编号" ReadOnly="True" 
                                SortExpression="id" />
                            <asp:TemplateField HeaderText="网站名称" SortExpression="name">
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
                            <asp:TemplateField HeaderText="网站url" SortExpression="url">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("url") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="url" runat="server" Text='<%# Bind("url") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("url") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="25%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="网站logo" SortExpression="logo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("logo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="logo" runat="server" Text='<%# Bind("logo") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("logo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="25%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="简介" SortExpression="demo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("demo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="demo" runat="server" Text='<%# Bind("demo") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("demo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="位置" SortExpression="display">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("display") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="display" runat="server" Width="45px" Text='<%# Bind("display") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("display") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                                <FooterStyle Width="50px" />
                                <HeaderStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:CheckBoxField DataField="state" HeaderText="状态" 
                                SortExpression="state" >
                            <ItemStyle Width="20px" />
                            </asp:CheckBoxField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="编辑"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Delete" Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="Insert" Text="添加"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemStyle Width="80px" />
                                <FooterStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            没有数据
                        </EmptyDataTemplate>
                        <AlternatingRowStyle  CssClass="tcell_two" />
                        <PagerStyle CssClass="pages" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        TableName="link" EnableDelete="True" EnableUpdate="True" 
                        AutoGenerateOrderByClause="True">
                    </asp:LinqDataSource>
                     
				  
				  
	</div>
</div>


</asp:Content>

