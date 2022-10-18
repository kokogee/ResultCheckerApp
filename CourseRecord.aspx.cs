using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CourseRecord : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var cou = (from co in db.Courses
                       select new
                       {
                           co.CourseName,
                           co.CourseCode
                         
                       }).Distinct();
            if (cou.Count() > 0)
            {
                lstCourse.DataSource = cou;
                lstCourse.DataBind();
            }
        }

      
    }
    protected void deleteCourse(string CourseCode)
    {
        var det = (from i in db.Courses
                   where i.CourseCode == CourseCode
                   select i).ToList();
        foreach (var a in det)
        {
            db.Courses.DeleteOnSubmit(a);
            db.SubmitChanges();
            string Message = "Record successfully deleted.";
            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRecord.aspx';</script>");
        }
    }

    protected void lstCourse_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Eit":
                Response.Redirect("AddCourse?passid=" + e.CommandArgument);
                break;
            case "Delet":
           string   id = Convert.ToString(e.CommandArgument);
                deleteCourse(id);
                break;
        }

    }
}