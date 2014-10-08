<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
<script src="Scripts/jquery.cookie.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {

        $(".pb_box_r a").click(function() {
            var aid = this.id.substring(2);
            if ($.cookie("ip" + aid) == null || $.cookie("ip" + aid) != "<%=tool.GetIP()%>|" + aid)
                $.get("ajaxding.aspx", { nid: aid }, function(data) {
                    $("#digg_" + aid + ">div").html(data);
                });
            else {
                alert("已经提交过了");
            }
        });

        $("#login").click(function() {
            aspnetForm.submit();
        });

    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
  
    <!-- 左内容-->
<div id="pbleft">
	<!-- 头部 -->
	<div id="indexhot">
		<div class="indexhot_1">
			<script src="../scripts/flashobject.js" type="text/javascript"></script>
			<div id="flashcontent">
				<object codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" 
				height="0" width="0" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">
					<param name="quality" value="high" />
					<param name="movie" value="../images/focus.swf" />
					<embed src="../images/focus.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="0" height="0"></embed>
				</object>
			</div>
			<script type="text/javascript">
			    var pics = "upfile/1.jpg|upfile/2.jpg|upfile/3.jpg|upfile/4.jpg";
			    pics = "<%=hd_img%>";
			    var fo = new FlashObject("../images/focus.swf", "focus", "290", "230", "7", "#336699");
			    fo.addParam("quality", "high");
			    fo.addParam("menu", "false");
			    fo.addParam("wmode", "transparent");
			    fo.addVariable("pics", pics);
			    fo.addVariable("links", "<%=hd_link %>");
			    fo.addVariable("texts", "<%=hd_title %>");
			    fo.write("flashcontent");
			</script>
		</div>
		<div class="indexhot_2">
			
            <h3 >
                <a href="show.aspx?id=<%=tou.id %>" title="" style="overflow:hidden;  white-space:nowrap;text-overflow:ellipsis;  display:block;" ><span style="color: #ffa500;">
                    <%=tou.title %></span></a>
                <p>
                    <%=tool.sub(tool.RemoveHtml(tou.cont),190)%>
                </p>
            </h3>
			<ul>
			<%foreach (var item in tuij){ %>
			<li>[推荐] <a href="show.aspx?id=<%=item.id %>"  target="_blank"><%=item.title %></a></li>
			<%} %>
			</ul>
		</div>
		<!-- 头部 bannar -->
  		<div class="clear"></div>
	</div>
	<!-- 头部 end -->
   
	<div id="leftcontainer">
		<!-- 排序 -->
		<div class="lefttop">
			<h3><span class="tool"><strong>发表时间</strong></span> <a href="default.aspx?viewday=365" class="tool">365 天</a> <a href="default.aspx?viewday=30" class="tool">30 天</a> <a href="default.aspx?viewday=7" class="tool">7 天</a> <a href="default.aspx?viewday=1" class="tool">最近24小时</a></h3>
			<h2>发掘 &amp; 分享</h2>
		</div>
		<div class="clear"></div>

		<div class="clear5">&nbsp;</div>
		<!-- 文章列表 -->
	 
		
		<%foreach (var item in art)
    { %>
				<!-- pbdigg -->
        <div class="newslist">
            <dl>
                <img src="<%=item.user.photo %>" alt="<%=item.user.name %>" class="small_user_avatar" /><dt
                    class="topic"><a href="show.aspx?id=<%=item.id %>" target="_blank"><strong><%=item.title %></strong></a><p
                        class="author">
                        <a href="user.aspx?id=<%=item.user.id %>">
                            <%=item.user.name %></a>&nbsp;在 <span class="d">
                                <%=item.ndate %></span> 发表于 ［<a href="cate.aspx?id=<%=item.cls.id %>"><%=item.cls.name %></a>］|
                        <%=item.ping %>
                        条评论 |
                        <%=item.hit %>
                        次阅读</p>
                </dt>
            </dl>
            <dl>
                <dd class="desc">
                    <!--digg & bury-->
                    <div class="pb_box_r" id="digg_<%=item.id %>">
                         <div><% =item.ding %></div>
                         <a  id="a_<%=item.id %>" ></a>
                    </div>
                    <% if (!tool.StrIsNullOrEmpty(item.pic))
                       { %>
                    <img alt="<% =item.title %>" src="<%=item.pic %>" style=" width:90px; height:96px; float:right; margin:5px;" />
                    <%} %>
                    <%=tool.sub(tool.RemoveHtml(item.cont),200) %>
                    <span class="ddmove">(<a href="show.aspx?id=<%=item.id %>" target="_blank">详细内容>></a>)</span></dd>
            </dl>
            <dl>
                <dd class="detail">
                    <p>
                        来源: <a href="show.aspx?id=<%=item.id %>" target="_blank">
                            <%=item.laiy %></a> | 标签: 
                                <%=tool.tagsplit(item.tags) %> 
                    </p>
                </dd>
            </dl>
        </div>
		
		<!-- pbdigg -->
		<%} %>
		    <div class="clear5">&nbsp;</div>
	<!-- 分页链接 -->
        <div class="pages">
          <%=pagestr %>
        </div>
    </div>
  	<div class="clear"></div></div>

<!-- 右侧列表 -->
<div id="pbright">

<% if (!User.Identity.IsAuthenticated)
   { %>
		<div class="list">
	<div class="list_title">网站登录</div>
	<p>
	<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="195" height="30" align="left">帐&nbsp;&nbsp;户：<input name="username" type="text" class="log-inputbox" size="22" maxlength="20" /></td>
		<td width="70" rowspan="2" align="right"><img type="image" id="login"  name="login"  src="../images/btn-login.gif"   style="width:62px;height:44px;border:0; outline:none; cursor:pointer;" /></td>
	</tr>
	<tr>
		<td height="30" align="left">密&nbsp;&nbsp;码：<input name="password" type="password" class="log-inputbox" size="23" maxlength="20" /></td>
	</tr>
		<tr align="left">
		<td height="15" colspan="2"><input class="checkbox" type="checkbox" name="persistent" value="1" id="persistent" title="为了确保你的信息安全，请不要在网吧或者公共机房选择此项。" style="margin-left:50px"/> 记住我 <img src="../images/register.gif" width="11" height="14" align="absmiddle" /> <a href="register.aspx">快速注册</a>&nbsp;<img src="../images/forgetpw.gif" width="12" height="15" align="absmiddle" /> <a href="getpw.aspx" target="_blank">忘记密码</a></td>
	</tr>
	</table>
	<input type="hidden" name="verifyhash1" id="verifyhash1" value="<%= Session["code1"] %>" />
	</p>
	</div>
	<%} %>
	
		<div class="list bd-g">
		<div class="list_title bg-g">最新文章</div>
		<div class="list_content">
		<ul>
			<%foreach (var item in zuix)
     { %>
			<li><a href="show.aspx?id=<%=item.id %>"  target="_blank"><%=item.title %></a></li>
			<%} %>
			</ul>
		</div><div class="clear"></div>
	</div>
    	<!-- 标签-->
    <div class="list bd-r">
   		<div class="list_title bg-r"><span><a href="tags.aspx" target="_blank">更多...</a></span>标签聚合</div>
			<div class="list_content hottags">
			<% foreach (var item in tags)
      { %>
						<a href="default.aspx?tag=<%=item.name %>" target="_blank"><span style="font-size:8pt;color:#dc86ba"><%=item.name %></span><em>(<%=item.hits %>)</em></a> 
						<%} %>
						</div>
	<div class="clear"></div></div>
	<!-- 2 -->
   	<div class="list bd-r">
   		<div class="list_title bg-r">最新评论</div>
   		<% foreach (var item in pings)
        { %>
           <div class="com_box">
               <div class="com_box_z avatar48">
                   <a href="user.aspx?id=<%=item.id %>"   target="_blank">
                       <img src="<%=item.user.photo %>"  /></a>
                       
                       </div>
               <div class="com_box_y">
                   <h3>
                       <a href="user.aspx?uid=<%=item.id %>"   target="_blank" class="b">admin</a> 评论 <a
                           href="show.aspx?id=<%=item.nid %>"><% =item.cont %></a></h3>
                   <span></span><em><a href="show.aspx?id=<%=item.nid %>">全文...</a></em></div>
           </div>
           <%} %>
           <div class="clear">
           </div>
       </div>
	
	<!-- 评论 -->
	<div class="list bd-g">
		<div class="list_title bg-g">一周热门</div>
		<div class="list_content">
			<ul>
			<% foreach (var item in hots)
      { %>
            	<li><a href="show.aspx?id=<%=item.id %>" target="_blank" title="<%=item.title %>"><%=item.title %></a>(<%=item.hit %>)</li>
			<%} %></ul>
		</div><div class="clear"></div>
	</div>
	<!-- 3 -->
	<div class="list">
		<div class="list_title"><span><a href="user_list.php" target="_blank">更多...</a></span>活跃会员</div>
		<div id="user-list">
			<ul>
			<% foreach (var item in users)
      { %>
				<li><a href="user.aspx?id<%=item.id %> " target="_blank"><img alt="<%=item.name %>" src="<%=item.photo %>" /><br /><%=item.name %></a></li>	
		<%} %>	</ul>
		</div><div class="clear"></div>
	</div>

 
</div>
<!-- 右列表结束 -->

</asp:Content>

