<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="admincaiji.aspx.cs" Inherits="Admin_admincaiji" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.fieldset{
   border:solid 1px #abc;
   width:80%;
   margin:auto;
   margin-top:5px;
   margin-bottom:5px;
   padding:10px;
   
   clear:both;
   display:block;
}
.fieldset legend{
     font-size:14px;
     color:Green;
     font-weight:bold;
     padding:5px;
}
 
 .fieldset table td{
     padding:2px;
     border:solid 1px #99bbe8;
 }
.fieldset span{
     color:Green;
     margin-left:12px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="tablebody">
        <div class="tabletitle" onclick="show_menu('tablecontent_','1');">
            <span style="float: right;">
                <img src="images/collapse.gif" class="leftmenuicon" alt="Collapse" id="tablecontent_icon_1" /></span>工具包</div>
        <div class="tablecontent" id="tablecontent_1">
        <div style=" border:solid 1px #99bbe8;  border-top:none;">&nbsp;
          <fieldset class="fieldset">
           <legend>提示信息</legend>
           
                 <asp:Label ID="tj" runat="server" Text=""></asp:Label>
           </fieldset>
           <fieldset class="fieldset">
           <legend>网站目录删除</legend>
               <table class="" style="border-collapse: collapse; width:100%;">
                   <tr>
                       <td style="width: 180px">
                           列表url<span>http://www.wjk3.cn</span>
                       </td>
                       <td>
                           <asp:TextBox ID="listurl"  Width="250px"  runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                               ControlToValidate="listurl"></asp:RequiredFieldValidator>
                       </td>
                       
                   </tr>
                    <tr>
                       <td style="width: 180px">
                           列表url<span>&lt;link&gt;|&lt;/link&gt;</span>
                       </td>
                       <td>
                           <asp:TextBox ID="listlink"  Width="250px"  runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="不能为空"
                               ControlToValidate="listlink"></asp:RequiredFieldValidator>
                       </td>
                       
                   </tr>
                   <tr>
                       <td style="width: 180px">
                           连接url<span>&lt;a&gt;|&lt;/a&gt;</span>
                       </td>
                       <td>
                           <asp:TextBox ID="linkurl"  Width="250px"  runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="不能为空"
                               ControlToValidate="linkurl"></asp:RequiredFieldValidator>
                       </td>
                       
                   </tr>
                   <tr>
                       <td>
                           标题<span>&lt;div&gt;|&lt;/div&gt;</span>
                       </td>
                       <td>
                           <asp:TextBox ID="t_title"  Width="250px" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空"
                               ControlToValidate="t_title"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           作者<span>&lt;span&gt;|&lt;/span&gt;</span>
                       </td>
                       <td>
                           <asp:TextBox ID="t_author"  Width="250px" runat="server"></asp:TextBox>
                            
                       </td>
                   </tr>
                   <tr>
                       <td>
                           来源<span>&lt;div&gt;|&lt;/div&gt;</span>
                       </td>
                       <td>
                           <asp:TextBox ID="t_laiy"  Width="250px" runat="server"></asp:TextBox>
                           
                       </td>
                   </tr>
                   <tr>
                       <td>
                           内容<span>&lt;div&gt;|&lt;/div&gt</span>
                       </td>
                       <td>
                           <asp:TextBox ID="t_cont"  Width="250px" runat="server"></asp:TextBox>
                           
                       </td>
                   </tr>
                   <tr>
                   <td>
                   栏目  <asp:DropDownList ID="drop2" runat="server" OnLoad="drop2_Load"  >
                </asp:DropDownList>
                   </td>
                       <td  >
                           <asp:Button ID="Button1" runat="server" Text="采集" OnClick="Button1_Click" />
                       </td>
                   </tr>
               </table>
            
           </fieldset>
           
          
            <br />
         </div>
        </div>
    </div>
</asp:Content>

