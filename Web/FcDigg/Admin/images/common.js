/*
 * PBDigg 2.0.0
 * Copyright 2007 PBDigg (http://www.pbdigg.com)
 */
//删除确认
function checkDel(param)
{
	if (window.confirm("确认删除？"))
	{
		location.href = param;
	}
	else
	{
		return false;
	}
}
//确认
function checkAction(param, action)
{
	var actionText = action ? ("确认" + action + "？") : "确认删除？";
	if (window.confirm(actionText))
	{
		location.href = param;
	}
	else
	{
		return false;
	}
}
//退出登陆
function userExit()
{
	var ht = document.getElementsByTagName("html")[0];
	ht.style.filter = "progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)";
	var ifout = window.confirm("您真的要退出登录？");
	if (ifout)
	{
		location.href = "admincp.php?action=logout";
	}
	else
	{
		ht.style.filter = "";
	}
}
var ifcheck = true;
//选择所有checkbox
function PBchoseAll(form)
{
	for(var i = 0; i < form.elements.length; i ++)
	{
		var e = form.elements[i];
		if (e.type == 'checkbox')
		{
			e.checked = ifcheck;
		}
	}
	ifcheck = (ifcheck == true) ? false : true;
}

//弹出窗口
function pb_pop(url,width,height)
{
    var w = 1024;
    var h = 768;
    if (document.all || document.layers)
    {
        w = screen.availWidth;
        h = screen.availHeight;
    }
    var leftPos = (w/2-width/2);
    var topPos = (h/2.3-height/2.3);
    window.open(url,'',"width="+width+",height="+height+",top="+topPos+",left="+leftPos+",scrollbars=no,resizable=no,status=no");
}
//收放菜单
function show_menu(obj,id)
{
	$('#'+obj+id).slideToggle("slow",menu_icon(obj,id)); 
}
function menu_icon(obj,id)
{
	var src = $('#'+obj+'icon_'+id).attr("src");
	if ($('#'+obj+id).css('display') == 'none')
	{
		var re = /expand\.gif/g;
		src = src.replace(re, 'collapse.gif');
		$('#'+obj+'icon_'+id).attr("src", src);
		$('#'+obj+'icon_'+id).attr("alt", 'Collapse');
	}
	else
	{
		var re = /collapse\.gif/g;
		src = src.replace(re, 'expand.gif');
		$('#'+obj+'icon_'+id).attr("src", src);
		$('#'+obj+'icon_'+id).attr("alt", 'Expand');
	}
}

function delavatar(uid)
{
	var editorbox = textobj;
	var newheight = parseInt(editorbox.style.height, 10) + change;
	if (newheight >= 100)
	{
		editorbox.style.height = newheight + 'px';
	}
}
$(document).ready(
function(){
$('#type_thread').click(function(){$('#tpl_comment').css('display', 'none');$('#tpl_member').css('display', 'none');$('#tpl_thread').css('display', '')});
$('#type_comment').click(function(){$('#tpl_thread').css('display', 'none');$('#tpl_member').css('display', 'none');$('#tpl_comment').css('display', '')});
$('#type_member').click(function(){$('#tpl_comment').css('display', 'none');$('#tpl_thread').css('display', 'none');$('#tpl_member').css('display', '')});
});
function cktpl(obj)
{

	if (obj.tplname.value.length == 0 || !/^[_\d\u4e00-\u9fa5]{1,255}$/i.test(obj.tplname.value))
	{
		alert('模板名称不符合规范');
		obj.tplname.focus();
		return false;
	}
	if (!/^[0-9]+$/i.test(obj.tplnum.value))
	{
		alert('请填写调用数量');
		obj.tplnum.focus();
		return false;
	}
	if (!obj.template.value)
	{
		alert('请填写模板内容');
		obj.template.focus();
		return false;
	}
	return true;
}

function cateself(obj)
{
	if (obj.checked)
	{
		$('input:checkbox').attr('disabled', 'disabled');
		obj.disabled = '';
	}
	else
	{
		$('input:checkbox').attr('disabled', '');
	}
}

