<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="adminping.aspx.cs" Inherits="Admin_adminping" %>

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
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>评论设置</div>
				<div class="tablecontent" id="tablecontent_1">
                     
				  
	                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CssClass="table" DataKeyNames="id" DataSourceID="LinqDataSource1" 
                        ShowFooter="True" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <asp:CheckBox ID="cb1" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="cb1_CheckedChanged" />
                                    &nbsp;
                                    <asp:LinkButton ID="ping_dele" runat="server" onclick="ping_dele_Click">删除</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="编号" ReadOnly="True" 
                                SortExpression="id" />
                            <asp:BoundField DataField="nid" HeaderText="新闻id" SortExpression="nid" />
                            <asp:BoundField DataField="cont" HeaderText="评论内容" SortExpression="cont" />
                            <asp:CommandField ShowDeleteButton="True">
                            <ItemStyle Width="60px" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle CssClass="tfooter" />
                        <PagerStyle CssClass="pages" />
                        <EmptyDataTemplate>
                            没有数据
                        </EmptyDataTemplate>
                        <AlternatingRowStyle  CssClass="tcell_two" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        EnableDelete="True" EnableUpdate="True" OrderBy="id desc" TableName="ping">
                    </asp:LinqDataSource>
                     
				  
				  
	</div>
</div>

</asp:Content>

