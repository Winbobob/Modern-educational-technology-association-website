<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="active-tip">
        <p>
            <a href="/"><span>首页</span></a> » <span>修改信息</span></p>
    </div>
    <!--第一步 -->
   
    <div class="post-main">
        <h1>
            发布新内容</h1>
        <div class="post-s">
            <div class="post-ss">
                标题(<span class="red">*</span>)</div>
            <div class="post-sss">
                <input id="title1" size="35" type="text" name="title1" runat="server"><span
                    id="title1Tip" class="post-cktip"></span></div>
        </div>
          
           <div class="post-s">
            <div class="post-ss">
                栏目(<span class="red">*</span>)</div>
            <div class="post-sss">
                <asp:DropDownList ID="drop2" runat="server" OnLoad="drop2_Load"  >
                </asp:DropDownList>
                
                </div>
        </div>
         <div class="post-s">
            <div class="post-ss">
                来源</div>
            <div class="post-sss">
                <input id="laiy" size="35" type="text" name="laiy"  runat="server"/>
                <span id="laiyTip" >如果是原创文章请留空</span>
             </div>
        </div>
          <div class="post-s">
            <div class="post-ss">
                作者</div>
            <div class="post-sss">
                <input id="author" runat="server" size="35" type="text" name="author" />
                <span id="authorTip" ></span>
             </div>
        </div>
           <div class="post-s">
            <div class="post-ss">
                tag标签</div>
            <div class="post-sss">
                <input id="tag" size="35" runat="server" type="text" name="tag">
                <span id="Span1"  >多个标签之间请用逗号分隔</span>
             </div>
        </div>
       
        <div class="post-s">
            <div class="post-ss">
                主题图标</div>
            <div class="post-sss">
                <input id="uploadavatar" runat="server" type="file" size="50" name="uploadavatar"></div>
        </div>
        <div class="post-s">
            <div class="post-ss">
                内容(<span class="red">*</span>)</div>
            <div class="post-sss">
                <div>
                    <FCKeditorV2:FCKeditor ID="cont" runat="server" Height="400px"  
                        Width="100%"></FCKeditorV2:FCKeditor>
                </div>
            </div>
            <p>
                <span id="ckcontent" class="cktip"></span>
            </p>
        </div>
     
    </div>
    <!-- 上传 -->
    <div class="post-side">
        <h1>
            操作指南</h1>
        <div class="jj">
            
                </div>
        
         
        </div>
        
        
    </div>
    <div class="clear">
    </div>
    <div class="post-s">
        <input value="1" type="hidden" name="submitted">
        <input value="8b64029823" type="hidden" name="verifyhash">
        <input value="7f616598c11cfc5906a0f524012ab4d9" type="hidden" name="fsid">
        <input id="submit" class="button" value="递交"    type="submit" name="submit">
        <input id="cancel" class="button" onclick="history.go(-1);" value="取消" type="button"
            name="cancel"></div>
</asp:Content>

