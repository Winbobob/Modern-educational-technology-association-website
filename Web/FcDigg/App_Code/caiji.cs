using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
/// <summary>
///caiji 的摘要说明
/// </summary>
public class caiji
{
	public caiji()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public string listurl;
    public string listlink;
    public string title;
    /// <summary>
    /// 获取html代码
    /// </summary>
    /// <param name="Url"></param>
    /// <param name="charset"></param>
    /// <returns></returns>
    public string GetHtmlSource(string Url)
    {
         
        string text1 = "";
        try
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream stream1 = response1.GetResponseStream();
            string charset = response1.ContentType.Substring(response1.ContentType.IndexOf("=") + 1);
            StreamReader reader1 = new StreamReader(stream1, Encoding.GetEncoding(charset));
            text1 = reader1.ReadToEnd();
            stream1.Close();
            response1.Close();//5/1/a/s/px
        }
        catch (Exception exception1)
        {
            HttpContext.Current.Response.Write(exception1.Message);
        }
        return text1;
    }
    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="code">代码</param>
    /// <param name="wordsBegin">开始标签</param>
    /// <param name="wordsEnd">结束标签</param>
    /// <returns></returns>
    public string  webCode(string code, string wordsBegin, string wordsEnd)
    {
        string NewsTitle = "";
        Regex regex1 = new Regex("" + wordsBegin + @"(?<title>[\s\S]+?)" + wordsEnd + "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        for (Match match1 = regex1.Match(code); match1.Success; match1 = match1.NextMatch())
        {
            NewsTitle = match1.Groups["title"].ToString();
        }
        return NewsTitle;

    }
    /// <summary>
    ///  截取网址列表
    /// </summary>
    /// <param name="code"></param>
    /// <param name="wordsBegin"></param>
    /// <param name="wordsEnd"></param>
    /// <returns></returns>
    public ArrayList  webCodeReturnList(string code, string wordsBegin, string wordsEnd)
    {
        ArrayList urlList = new ArrayList();
        //string NewsTitle = "";
        Regex regex1 = new Regex("" + wordsBegin + @"(?<title>[\s\S]+?)" + wordsEnd + "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        for (Match match1 = regex1.Match(code); match1.Success; match1 = match1.NextMatch())
        {
            urlList.Add(match1.Groups["title"].ToString());
        }
        return urlList;

    }
   

}
