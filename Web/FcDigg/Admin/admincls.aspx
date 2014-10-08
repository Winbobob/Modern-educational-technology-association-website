<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="admincls.aspx.cs" Inherits="Admin_admincls" %>

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
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>栏目设置</div>
				<div class="tablecontent" id="tablecontent_1">
                     
				  
	                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CssClass="table" DataKeyNames="id" DataSourceID="LinqDataSource1" 
                        AllowPaging="True" ShowFooter="True" onrowcommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="编号" SortExpression="id">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                 
                                    <asp:DropDownList ID="drop" runat="server" onload="drop_init">
                                    </asp:DropDownList>
                                 
                                </FooterTemplate>
                                <FooterStyle Width="50px" />
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="名称" SortExpression="name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <asp:TextBox ID="t1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>

                                </FooterTemplate>
                                <ItemTemplate>
                                   <%# shuchu(Eval("jb").ToString().Length) + Eval("name") %>
                                </ItemTemplate>
                        
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="关键字" SortExpression="keywords">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("keywords") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("keywords") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                     <asp:TextBox ID="t2" runat="server" Text='<%# Bind("keywords") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="简介" SortExpression="description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                                     <asp:TextBox ID="t3" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序" SortExpression="sort">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("sort") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("sort") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                               <asp:TextBox ID="t5" runat="server"   Text='<%# Bind("sort") %>' Width="45px" ></asp:TextBox>

                                </FooterTemplate>
                                <FooterStyle Width="50px" />
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:CheckBoxField DataField="display" HeaderText="启用" 
                                SortExpression="display" >
                            <ItemStyle Width="30px" />
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
                                  <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                        CommandName="Insert"  Text="添加"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle  CssClass="tcell_two" />
                        <EmptyDataTemplate>
                            没有数据
                        </EmptyDataTemplate>
                        <PagerStyle CssClass="pages" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        TableName="cls" OrderBy="jb, sort" EnableDelete="True" EnableUpdate="True">
                    </asp:LinqDataSource>
                     
				  
				  
	</div>
</div>

</asp:Content>

