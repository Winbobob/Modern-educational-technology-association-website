<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="adminnews.aspx.cs" Inherits="Admin_adminnews" %>
 <%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">

.msgtitle select {
    
}
.msgtitle input[type="text"]{
     border:solid 1px #abc;
     padding:3px;
}

</style>
    
    <!-- IE 6 hacks -->
<!--[if lt IE 7]>
<link type='text/css' href='../SimpleModal/css/basic_ie.css' rel='stylesheet' media='screen' />
<![endif]-->

    <script src="../lhgdialog/lhgdialog.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript">
          function dialog(n){
            lhgdialog.opendlg('����ҳΪ�ⲿ���ӵĴ���', $("#" + n.id).attr("rel"), 640, 540, false, true);
        }
      
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">              
    <!-- include -->
				<!-- tip -->
 		<div class="msgbox">
				<div class="msgtitle">��ѯ������<asp:DropDownList ID="drop" runat="server" OnLoad="drop_Init">  
                     </asp:DropDownList>
                     <asp:TextBox runat="server" ID="text1">
                    </asp:TextBox>
                    <asp:Button runat="server" ID="button1" Text="��ѯ" onclick="button1_Click" />
               
                </div>
				 
			</div> 
			<!-- tip end -->
			<!-- item -->
			<div class="tablebody">
				<div class="tabletitle" onclick="show_menu('tablecontent_','1');"><span style="float:right;"><img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>��������</div>
				<div class="tablecontent"  id="tablecontent_1">
                     
				  
	                <asp:GridView  ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CssClass="table" DataKeyNames="id" 
                        DataSourceID="LinqDataSource1" onload="load" onselectedindexchanged="GridView1_SelectedIndexChanged"  
                         >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="���" ReadOnly="True" 
                                SortExpression="id" />
                            <asp:BoundField DataField="title" HeaderText="����" SortExpression="title" />
                            <asp:BoundField DataField="author" HeaderText="����" SortExpression="author" />
                            <asp:BoundField DataField="ndate" HeaderText="ʱ��" SortExpression="ndate" />
                            <asp:BoundField DataField="ping" HeaderText="������" SortExpression="ping" />
                            <asp:BoundField DataField="cid" HeaderText="��Ŀ" SortExpression="cid" />
                            <asp:BoundField DataField="hit" HeaderText="�����" SortExpression="hit" />
                            <asp:BoundField DataField="ding" HeaderText="��" SortExpression="ding" />
     
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                     <%--           <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="Select" Text="�༭"></asp:LinkButton> --%>
                                        <a href="/edit.aspx?id=<%#Eval("id") %>" id="d<%#Eval("id") %>" >�༭</a> 
                                     <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Delete" Text="ɾ��"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle  CssClass="tcell_two" />
                        <PagerStyle CssClass="pages" />
                        <EmptyDataTemplate>
                            û������
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dbcms" 
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" OrderBy="ndate desc" 
                        TableName="news"   Where="cls.jb.Contains(@cid+@ge)&&title.Contains(@title)" >
                        <WhereParameters>
                            <asp:ControlParameter ControlID="drop" Name="cid" PropertyName="SelectedValue" 
                                Type="Int32" />
                                <asp:ControlParameter ControlID="text1" Name="title" PropertyName="Text" Type="String" DefaultValue=" " />
                                <asp:Parameter Name="ge" DbType="String" DefaultValue="|" Size="2" />
                                
                        </WhereParameters>
                        
                    </asp:LinqDataSource>
                  
			   
				  
	</div>
</div>

 
</asp:Content>

