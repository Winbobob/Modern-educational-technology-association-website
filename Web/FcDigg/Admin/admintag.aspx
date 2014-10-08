<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="admintag.aspx.cs" Inherits="Admin_admintag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- include -->
				<!-- tip -->
		<%--	<div class="msgbox">
				<div class="msgtitle">操作提示</div>
				<div class="msgcontent">
					<li>网站初始设置 网站优化设置</li>
					 
				</div>
			</div>--%>
			<!-- tip end -->
			<!-- item -->
			<div class="tablebody">
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>Tag标签设置</div>
				<div class="tablecontent" id="tablecontent_1">
                     
				  
	                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CssClass="table" DataKeyNames="id" DataSourceID="LinqDataSource1" 
                        AllowPaging="True"  >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                                SortExpression="id" />
                            <asp:BoundField DataField="name" HeaderText="tag标签" SortExpression="name" >
                            <ItemStyle Width="65%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="hits" HeaderText="文章数" SortExpression="hits">
                             
                            </asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True">
                            <ItemStyle Width="80px" />
                            </asp:CommandField>
                        </Columns>
                        <PagerStyle CssClass="pages" />
                        <EmptyDataTemplate>
                            没有数据
                        </EmptyDataTemplate>
                        <AlternatingRowStyle  CssClass="tcell_two" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" OrderBy="id desc" 
                        TableName="tag">
                    </asp:LinqDataSource>
                     
				  
				  
	</div>
</div>
</asp:Content>

