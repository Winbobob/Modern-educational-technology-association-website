<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="tools.aspx.cs" Inherits="Admin_tools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.fieldset{
   border:solid 1px #abc;
   width:80%;
   margin:auto;
   margin-top:5px;
   margin-bottom:5px;
   padding:10px;
   padding-top:none;
   clear:both;
   display:block;
}
.fieldset legend{
     font-size:14px;
     color:Green;
     font-weight:bold;
     padding:5px;
}
.fieldset input[type='text']{
     border:solid 1px #ccc;
     width:400px;
     margin-right:12px;
     line-height:25px;
     
     vertical-align:middle;
     padding:2px;
}
.fieldset textarea{
     border:solid 1px #ccc;
     width:400px;
     height:200px;
     margin-right:12px;
     
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
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               <asp:Button ID="Button1"
                   runat="server" Text="执行" onclick="Button1_Click" />
                   <span>格式:\目录\</span>
           </fieldset>
           
            <fieldset class="fieldset">
           <legend>执行sql语句</legend>
               <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="Button2"
                   runat="server" Text="执行" onclick="Button2_Click" />
                   
           </fieldset>
            <br />
         </div>
        </div>
    </div>
</asp:Content>

