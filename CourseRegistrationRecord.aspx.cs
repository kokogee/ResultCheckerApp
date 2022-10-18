using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CourseRegistrationRecord : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        var rec = (from cr in db.CourseRegistrations
                   join c in db.Courses on cr.CourseCode equals c.CourseCode
                   join lv in db.Levels on cr.LevelID equals lv.LevelID
                   select new
                   {
                       StudentName = getName(cr.StudentNumber),
                       CourseName = c.CourseName,
                       LevelName = lv.LevelName,
                       cr.CourseRegistrationID

                   }).Distinct();
        if (rec.Count() > 0)
        {
            lstCourseRegistration.DataSource = rec;
            lstCourseRegistration.DataBind();
        }
    }

    protected void Delete(int UserId)
    {
        var det = (from i in db.CourseRegistrations
                   where i.CourseRegistrationID == UserId
                   select i).ToList();
        foreach (var a in det)
        {
            db.CourseRegistrations.DeleteOnSubmit(a);
            db.SubmitChanges();
            string Message = "Record successfully deleted.";
            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRegistrationRecord.aspx';</script>");
        }
    }
    protected string getName(string number)
    {
        string name = "";

        var std = (from i in db.Students
                   where i.StudentNumber == number
                   select i).SingleOrDefault();

        if (std != null)
        {
            if (!string.IsNullOrEmpty(std.FirstName) && !string.IsNullOrEmpty(std.LastName) && !string.IsNullOrEmpty(std.OtherName))
            {
                name = std.FirstName + " " + std.LastName + " " + std.OtherName;
            }
            else if (string.IsNullOrEmpty(std.FirstName) && !string.IsNullOrEmpty(std.LastName) && !string.IsNullOrEmpty(std.OtherName))
            {
                name = std.LastName + " " + std.OtherName;
            }
            else if (!string.IsNullOrEmpty(std.FirstName) && string.IsNullOrEmpty(std.LastName) && !string.IsNullOrEmpty(std.OtherName))
            {
                name = std.FirstName + " " + std.OtherName;
            }
            else if (!string.IsNullOrEmpty(std.FirstName) && !string.IsNullOrEmpty(std.LastName) && string.IsNullOrEmpty(std.OtherName))
            {
                name = std.FirstName + " " + std.LastName;
            }
        }

        return name;
    }

    protected void lstCourseRegistration_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
         case "Eit":
                Response.Redirect("CourseRegistrationAdd?passid=" + e.CommandArgument);
        break;
            case "Delet":
              int id = Convert.ToInt32(e.CommandArgument);
        Delete(id);
        break;
        }
       
    }
}
