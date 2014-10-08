<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="cate.aspx.cs" Inherits="cate" %>
 <%@ Import Namespace="System.Linq" %>
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
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- 左内容-->
<div id="pbleft">
   <% if(clss.Count()>0){ %>
		<div class="nav_sub"><ul class="subnav">
		<%foreach (var item in clss)
    { %>
		<li><a href="cate.aspx?id=<%=item.id%>"><% = item.name%></a></li>
		
		<%} %>
		</ul><div class="clear"></div></div>
	<%} %>
 
		<!-- 左侧主题内容 -->
		<div id="leftcategory">
		<!-- 排序 -->
		<div class="lefttop">
			<h3><span class="tool"><strong>发表时间</strong></span> <a href="cate.aspx?viewday=365&id=<%=cid %>" class="tool">365 天</a> &nbsp;<a href="cate.aspx?viewday=30&id=<%=cid %>" class="tool">30 天</a> &nbsp;<a href="cate.aspx?viewday=7&id=<%=cid %>" class="tool">7 天</a> &nbsp;<a href="cate.aspx?viewday=1&id=<%=cid %>" class="tool">最近24小时</a></h3>
			
			<h2><a href="default.aspx"><span>首页</span></a> 
			<%foreach (var item in dh)
     { %>
			&raquo; <a href="cate.aspx?id=<%=item.id %>"><span><%=item.name %></span></a>
			<%} %>
			</h2>
		
		</div>
		<div class="clear3">&nbsp;</div>
		<!-- 主题列表 -->
				<!-- pbdigg -->
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
                         <div ><%=item.ding %></div>
                         <a id="a_<%=item.id %>"></a>
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
                            <%=item.laiy %></a> | 标签: <a href="index.php?tag=%C3%C0%CD%BC%D0%C0%C9%CD">
                                <%=item.tags %></a>
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
       <div class="clear"></div>  
    </div>
   
  	<div class="clear"></div>
  	</div>
<!-- 右侧列表-->
<div id="pbright">
		
	
	
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
   	
	
	<!-- 评论 -->
	<div class="list bd-r">
   		<div class="list_title bg-r">最新评论</div>
   		<% foreach (var item in pings)
        { %>
           <div class="com_box">
               <div class="com_box_z avatar48">
                   <a href="user.aspx?id=<%=item.id %>"   target="_blank">
                       <img src="<%=item.user.photo %>"   /></a>
                       
                       </div>
               <div class="com_box_y">
                   <h3>
                       <a href="user.aspx?id=<%=item.id %>"   target="_blank" class="b">admin</a> 评论 <a
                           href="show.aspx?id=<%=item.nid %>"><% =item.cont %></a></h3>
                   <span></span><em><a href="show.aspx?id=<%=item.nid %>">全文...</a></em></div>
           </div>
           <%} %>
           <div class="clear">
           </div>
       </div>
	<!-- 3 -->
	 
 
</div>
<!-- 右列表结束 -->
</asp:Content>

