using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class Admin_tools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!tool.StrIsNullOrEmpty(TextBox1.Text))
        {
             DirectoryInfo dr=new DirectoryInfo(Server.MapPath(TextBox1.Text));
             if (dr.Exists)
             {
                 deletefile(dr);
                 dr.Delete();
             }
             else
             {
                 tj.Text = TextBox1.Text + "　目录不存在";
             }
            tj.Text = TextBox1.Text + "　目录已经删除";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if(!tool.StrIsNullOrEmpty(TextBox2.Text))
            using (dbcms db = new dbcms())
            {
                try
                {
                    db.ExecuteCommand(TextBox2.Text);
                }
                catch(Exception error)
                {
                    tj.Text = TextBox2.Text + "　错误信息:" + error.Message;
                }
                tj.Text = TextBox2.Text + "　sql语句执行完毕";
            }
    }
    private void deletefile(System.IO.DirectoryInfo path)
    {
        foreach (System.IO.DirectoryInfo d in path.GetDirectories())
        {
            deletefile(d);
            d.Delete();
        }
        foreach (System.IO.FileInfo f in path.GetFiles())
        {
            f.Delete();
        }
    }


 }
