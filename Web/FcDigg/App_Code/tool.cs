using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Mail;
/// <summary>
///tool 的摘要说明
/// </summary>
public class tool
{
	public tool()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
      public static  bool SendMail(string SmtpServer, string PassWord, string SendMail, string SendName, string ReceiverMail, string ReceiverName, string MailSubject, string MailBody, string Attachments)
        {
            System.Net.Mail.SmtpClient smtp;
            smtp = new System.Net.Mail.SmtpClient(SmtpServer);
            smtp.Timeout = 60000;
            smtp.UseDefaultCredentials = true;
            //设置发件人用户密码 
            smtp.Credentials = new System.Net.NetworkCredential(SendMail.Split('@')[0], PassWord);
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            //设置发件人地址姓名 
            message.From = new System.Net.Mail.MailAddress(SendMail, SendName, System.Text.Encoding.UTF8);
            //设置收件人地址姓名 
            message.To.Add(new System.Net.Mail.MailAddress(ReceiverMail, ReceiverName, System.Text.Encoding.UTF8));
            message.IsBodyHtml = true;
            message.Subject = MailSubject;
            message.Body = MailBody;
            if (Attachments != "" && Attachments!=null)
            message.Attachments.Add(new System.Net.Mail.Attachment(Attachments));
            try
            {
                smtp.Send(message);
                return true;
            }
            catch(Exception ex)
            {
                string mes=ex.Message;
                return false;
            }
        } 
     public static string tagsplit(string tags)
    {
        if (StrIsNullOrEmpty(tags))
        {
            return "";
        }
   
        string str1 = "";
         var str =tags.Split(' ');
         foreach (var item in str)
         {
             if (item.Trim() != "")
             {
                 str1 += "<a href='defualt.aspx?tag="+item+"'>"+item+"</a>&nbsp;&nbsp;";
             }
         }
         return str1;
    }
    public static void SendMailMessage(MailMessage message)
    {
        if (message == null)
            throw new ArgumentNullException("message");
        var mail = System.Configuration.ConfigurationManager.AppSettings;
        try
        {
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            SmtpClient smtp = new SmtpClient(mail["server"]);
            smtp.Credentials = new System.Net.NetworkCredential(mail["username"], mail["userpwd"]);
            smtp.Port =Convert.ToInt32(mail["port"]);
            smtp.EnableSsl = false;
            smtp.Send(message);
           
        }
        catch (SmtpException)
        {
            
        }
        finally
        {
            // Remove the pointer to the message object so the GC can close the thread.
            message.Dispose();
            message = null;
        }
    }
    /// <summary>
    /// 字段截取
    /// </summary>
    /// <param name="str">字符串</param>
    /// <param name="n">数量</param>
    /// <returns></returns>
    public static string sub(string str, int n)
    {
        if (str.Length > n) str = str.Substring(0,n);
        return str;
    }
    /// <summary>
    /// 判断是不是数字
    /// </summary>
    /// <param name="expression">object</param>
    /// <returns></returns>
    public static bool IsNumeric(object expression)
    {
        if (expression != null)
        {
            return IsNumeric(expression.ToString());
        }
        return false;

    }
    /// <summary>
    /// 判断是不是数字
    /// </summary>
    /// <param name="expression">string</param>
    /// <returns></returns>
    public static bool IsNumeric(string expression)
    {
        if (expression != null)
        {
            string str = expression;
            if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
            {
                if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                {
                    return true;
                }
            }
        }
        return false;

    }
    /// <summary>
    /// 判断是否来自搜索引擎链接
    /// </summary>
    /// <returns>是否来自搜索引擎链接</returns>
    public static bool IsSearchEnginesGet()
    {
        if (HttpContext.Current.Request.UrlReferrer == null)
        {
            return false;
        }
        string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
        string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
        for (int i = 0; i < SearchEngine.Length; i++)
        {
            if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 获得当前页面客户端的IP
    /// </summary>
    /// <returns>当前页面客户端的IP</returns>
    public static string GetIP()
    {


        string result = String.Empty;

        result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(result))
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        if (string.IsNullOrEmpty(result))
        {
            result = HttpContext.Current.Request.UserHostAddress;
        }

        if (string.IsNullOrEmpty(result) || !tool.IsIP(result))
        {
            return "127.0.0.1";
        }

        return result;

    }

    /// <summary>
    /// 保存用户上传的文件
    /// </summary>
    /// <param name="path">保存路径</param>
    public static void SaveRequestFile(string path)
    {
        if (HttpContext.Current.Request.Files.Count > 0)
        {
            HttpContext.Current.Request.Files[0].SaveAs(path);
        }
    }
    public static string GetMapPath(string strPath)
    {
        if (HttpContext.Current != null)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }
        else //非web程序引用
        {
            strPath = strPath.Replace("/", "\\");
            if (strPath.StartsWith("\\"))
            {
                strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
            }
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }
    }
    public static bool IsIP(string ip)
    {
        return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");

    }
    /// <summary>
    /// 移除Html标记
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string RemoveHtml(string content)
    {
        string regexstr = @"<[^>]*>";
        return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
    }
    /// <summary>
    /// 过滤HTML中的不安全标签
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string RemoveUnsafeHtml(string content)
    {
        content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
        content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
        return content;
    }
    /// <summary>
    /// 从HTML中获取文本,保留br,p,img
    /// </summary>
    /// <param name="HTML"></param>
    /// <returns></returns>
    public static string GetTextFromHTML(string HTML)
    {
        System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"</?(?!br|/?p|img)[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        return regEx.Replace(HTML, "");
    }
    /// <summary>
    /// 删除最后一个字符
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ClearLastChar(string str)
    {
        if (str == "")
            return "";
        else
            return str.Substring(0, str.Length - 1);
    }

    /// <summary>
    /// 字段串是否为Null或为""(空)
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool StrIsNullOrEmpty(string str)
    {
        //#if NET1
        if (str == null || str.Trim() == "")
        {
            return true;
        }
        //#else
        //            if (string.IsNullOrEmpty(str))
        //            {
        //                return true;
        //            }
        //#endif

        return false;
    }
    /// <summary>
    /// 根据Url获得源文件内容
    /// </summary>
    /// <param name="url">合法的Url地址</param>
    /// <returns></returns>
    public static string GetSourceTextByUrl(string url)
    {
        WebRequest request = WebRequest.Create(url);
        request.Timeout = 20000;//20秒超时
        WebResponse response = request.GetResponse();

        Stream resStream = response.GetResponseStream();
        StreamReader sr = new StreamReader(resStream);
        return sr.ReadToEnd();
    }

    public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag)
    {
        if (pagetag == "")
            pagetag = "page";
        if (url.Contains(pagetag))
        {
            string t = url.Substring(url.IndexOf(pagetag) - 1,1);
            t= t+pagetag +"="+ HttpContext.Current.Request.QueryString[pagetag].ToString();
            url = url.Replace(t, "");
            
        }
        int startPage = 1;
        int endPage = 1;

        if (url.IndexOf("?") > 0)
        {
            url = url + "&";
        }
        else
        {
            url = url + "?";
        }
        
        string t1 = "<a href=\"" + url + "&" + pagetag + "=1";
        string t2 = "<a href=\"" + url + "&" + pagetag + "=" + countPage;
        
        t1 += "\">&laquo;</a>";
        t2 += "\">&raquo;</a>";

        if (countPage < 1)
            countPage = 1;
        if (extendPage < 3)
            extendPage = 2;

        if (countPage > extendPage)
        {
            if (curPage - (extendPage / 2) > 0)
            {
                if (curPage + (extendPage / 2) < countPage)
                {
                    startPage = curPage - (extendPage / 2);
                    endPage = startPage + extendPage - 1;
                }
                else
                {
                    endPage = countPage;
                    startPage = endPage - extendPage + 1;
                    t2 = "";
                }
            }
            else
            {
                endPage = extendPage;
                t1 = "";
            }
        }
        else
        {
            startPage = 1;
            endPage = countPage;
            t1 = "";
            t2 = "";
        }

        StringBuilder s = new StringBuilder("");

        s.Append(t1);
        for (int i = startPage; i <= endPage; i++)
        {
            if (i == curPage)
            {
                s.Append("<span>");
                s.Append(i);
                s.Append("</span>");
            }
            else
            {
                s.Append("<a href=\"");
                s.Append(url);
                s.Append(pagetag);
                s.Append("=");
                s.Append(i);
               
                s.Append("\">");
                s.Append(i);
                s.Append("</a>");
            }
        }
        s.Append(t2);

        return s.ToString();
    }

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    public static void WriteCookie(string strName, string strValue)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie.Value = strValue;
        HttpContext.Current.Response.AppendCookie(cookie);

    }

    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    public static void WriteCookie(string strName, string key, string strValue)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie[key] = strValue;
        HttpContext.Current.Response.AppendCookie(cookie);

    }
    /// <summary>
    /// 写cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <param name="strValue">值</param>
    /// <param name="strValue">过期时间(分钟)</param>
    public static void WriteCookie(string strName, string strValue, int expires)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie.Value = strValue;
        cookie.Expires = DateTime.Now.AddMinutes(expires);
        HttpContext.Current.Response.AppendCookie(cookie);

    }

    /// <summary>
    /// 读cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <returns>cookie值</returns>
    public static string GetCookie(string strName)
    {
        if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
        {
            return HttpContext.Current.Request.Cookies[strName].Value.ToString();
        }

        return "";
    }

    /// <summary>
    /// 读cookie值
    /// </summary>
    /// <param name="strName">名称</param>
    /// <returns>cookie值</returns>
    public static string GetCookie(string strName, string key)
    {
        if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
        {
            return HttpContext.Current.Request.Cookies[strName][key].ToString();
        }

        return "";
    }
    /// <summary>
    /// 过滤非法sql字符串
    /// </summary>
    /// <param name="sInput"></param>
    /// <returns></returns>
    public static string Filter(string sInput)
    {
        if (sInput == null || sInput.Trim() == string.Empty)
            return null;
        string sInput1 = sInput.ToLower();
        string output = sInput;
        string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
        if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
        {
            throw new Exception("字符串中含有非法字符!");
        }
        else
        {
            output = output.Replace("'", "''");
        }
        return output;
    }

}
