using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourse : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
    string CourseCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Page.Request["passid"] != null)
            {
             string CourseCode = this.Page.Request["passid"];
                var su = (from i in db.Courses
                          where i.CourseCode == CourseCode
                          select i).SingleOrDefault();
                if (su != null)
                {
                    txtCoursecode.Text = su.CourseCode;
                    txtCoursetitle.Text = su.CourseName;

                    Button1.Text = "Edit";
                    txtCoursecode.ReadOnly = true;
                    txtCoursetitle.ReadOnly = true;


                    txtCoursecode.CssClass = "form-control";
                    txtCoursetitle.CssClass = "form-control";


                    txtCoursecode.BackColor = System.Drawing.Color.White;
                    txtCoursetitle.BackColor = System.Drawing.Color.White;

                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl1.Text = "";

        if (Button1.Text == "Submit")
        {
            Course di = new Course();
            di.CourseName = txtCoursetitle.Text;
            di.CourseCode = txtCoursecode.Text;
            var dx = (from m in db.Courses
                      where m.CourseName == di.CourseName
                      select m).SingleOrDefault();
            if (dx == null)
            {
                db.Courses.InsertOnSubmit(di);
                db.SubmitChanges();
                string Message = "Course Sucessfully Added ";
                Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRecord.aspx';</script>");
            }
            else
            {
                lbl1.Text = "No Record was Inserted. Reason: Record already exist";
            }
        }
        else if (Button1.Text == "Edit")
        {
            Button1.Text = "Save";
            txtCoursecode.ReadOnly = true;
            txtCoursetitle.ReadOnly = false;
        }

        else if (Button1.Text == "Save")
        {
            if (this.Page.Request["passid"] != null)
            {

                CourseCode = this.Page.Request["passid"];
                var su = (from i in db.Courses
                          where i.CourseCode == CourseCode
                          select i).SingleOrDefault();
                if (su != null)
                {
                    su.CourseName = txtCoursetitle.Text;
                    su.CourseCode = txtCoursecode.Text;
                    db.SubmitChanges();

                    string Message = "Course was Suceessfully Updated.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRecord.aspx';</script>");
                }
            }
            else
            {
                string Message = "Please select Course name";
                Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
            }
        }
    }
}

