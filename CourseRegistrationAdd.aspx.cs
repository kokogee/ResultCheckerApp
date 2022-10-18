using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CourseRegistrationAdd : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (this.Page.Request["passid"] != null)
            {
                int CourseRegistrationID = Convert.ToInt32(this.Page.Request["passid"]);
                var su = (from i in db.CourseRegistrations
                          where i.CourseRegistrationID == CourseRegistrationID
                          select i).SingleOrDefault();
                if (su != null)
                {
                    ddlStudentnumber.SelectedValue = Convert.ToString(su.StudentNumber);
                    ddlCourstitle.SelectedValue = Convert.ToString(su.CourseCode);
                    ddlLevelid.SelectedValue = Convert.ToString(su.LevelID);

                    Button2.Text = "Edit";
                    ddlStudentnumber.Enabled = false;
                    ddlCourstitle.Enabled = false;
                    ddlLevelid.Enabled = false;

                    ddlStudentnumber.CssClass = "form-control";
                    ddlCourstitle.CssClass = "form-control";
                    ddlLevelid.CssClass = "form-control";

                    ddlStudentnumber.BackColor = System.Drawing.Color.White;
                    ddlCourstitle.BackColor = System.Drawing.Color.White;
                    ddlLevelid.BackColor = System.Drawing.Color.White;
                }
            }

            getdata();
            getStudent();
        }

    }
    protected void getStudent()
    {
        var fac = (from i in db.Students
                   select new
                   {
                       StudentName = getName(i.StudentNumber),
                       i.StudentNumber
                   }).ToList();
        if (fac.Count() > 0)
        {
            ddlStudentnumber.DataSource = fac;
            ddlStudentnumber.DataValueField = "StudentNumber";
            ddlStudentnumber.DataTextField = "StudentName";
            ddlStudentnumber.DataBind();
            ddlStudentnumber.Items.Insert(0, "Select Student Name");
        }
    }
    protected string getName(string StudentNumber)
    {
        string name = "";

        var re = (from i in db.Students
                  where i.StudentNumber == StudentNumber
                  select i).SingleOrDefault();
        if (re != null)
        {
            if (!string.IsNullOrEmpty(re.FirstName) && !string.IsNullOrEmpty(re.OtherName) && !string.IsNullOrEmpty(re.LastName))
            {
                name = re.FirstName + " " + re.OtherName + " " + re.LastName;
            }
            else if (!string.IsNullOrEmpty(re.FirstName) && string.IsNullOrEmpty(re.OtherName) && !string.IsNullOrEmpty(re.LastName))
            {
                name = re.FirstName + " " + re.LastName;
            }
            else if (!string.IsNullOrEmpty(re.ParentName))
            {
                name = re.ParentName;
            }
            else if (!string.IsNullOrEmpty(re.FirstName) && !string.IsNullOrEmpty(re.OtherName) && string.IsNullOrEmpty(re.LastName))
            {
                name = re.FirstName + " " + re.OtherName;
            }
            else if (string.IsNullOrEmpty(re.FirstName) && !string.IsNullOrEmpty(re.OtherName) && !string.IsNullOrEmpty(re.LastName))
            {
                name = re.LastName + " " + re.OtherName;
            }
        }

        return name;
    }
    protected void getdata()
    {
        var de = (from b in db.Courses
                  select new
                  {
                      b.CourseName,
                      b.CourseCode

                  }).ToList();
        if (de.Count() > 0)
        {
            ddlCourstitle.DataSource = de;
            ddlCourstitle.DataValueField = "CourseCode";
            ddlCourstitle.DataTextField = "CourseName";
            ddlCourstitle.DataBind();
            ddlCourstitle.Items.Insert(0, "Select a Course");
        }
        var ds = (from a in db.Levels
                  select new
                  {
                      a.LevelName,
                      a.LevelID,
                  }).ToList();
        if (ds.Count() > 0)
        {
            ddlLevelid.DataSource = ds;
            ddlLevelid.DataValueField = "LevelID";
            ddlLevelid.DataTextField = "LevelName";
            ddlLevelid.DataBind();
            ddlLevelid.Items.Insert(0, "Select a level");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Button2.Text == "Submit")
        {


            if (ddlCourstitle.SelectedItem.Text != "Select a course Title")
            {
                if (ddlLevelid.SelectedItem.Text != "Select Level")
                {
                    if (ddlStudentnumber.SelectedItem.Text != "Select a Student Name")
                    {
                        CourseRegistration ds = new CourseRegistration();
                        ds.CourseCode = ddlCourstitle.SelectedValue;
                        ds.StudentNumber = ddlStudentnumber.SelectedValue;
                        ds.LevelID = Convert.ToInt32(ddlLevelid.SelectedValue);
                        var chk = (from u in db.CourseRegistrations
                                   where u.CourseCode == ds.CourseCode
                                   && u.StudentNumber == ds.StudentNumber
                                   && u.LevelID == ds.LevelID
                                   select u).SingleOrDefault();
                        if (chk == null)
                        {
                            db.CourseRegistrations.InsertOnSubmit(ds);
                            db.SubmitChanges();
                            string Message = "Course sucessfully Registered.";
                            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRegistrationRecord.aspx';</script>");
                        }
                        else
                        {
                            string Message = "Course Already Registered .";
                            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRegistrationRecord.aspx';</script>");
                        }

                    }
                    else
                    {
                        string Message = "please Select a course";
                        Response.Write("<script language = 'javascript'>window.alert ('" + Message + "');</script>");
                        //lbl2.Text = "Please select a Level";
                    }
                }
                else
                {
                    string Message = "please Select a course";
                    Response.Write("<script language = 'javascript'>window.alert ('" + Message + "');</script>");
                    //lbl2.Text = "Please select a Level";
                }
            }
            else
            {
                string Message = "please Select a course";
                Response.Write("<script language = 'javascript'>window.alert ('" + Message + "');</script>");
                //lbl2.Text = "Please select a Level";
            }
        }
        else if (Button2.Text == "Edit")
        {
            Button2.Text = "Save";
            ddlStudentnumber.Enabled = true;
            ddlLevelid.Enabled = true;
            ddlCourstitle.Enabled = true;

        }
        else if (Button2.Text == "Save")
        {
            if (this.Page.Request["passid"] != null)

            {
                int CourseRegistrationID = Convert.ToInt32(this.Page.Request["passid"]);

                var de = (from i in db.CourseRegistrations
                          where i.CourseRegistrationID == CourseRegistrationID
                          select i).SingleOrDefault();

                if (de != null)
                {
                    db.SubmitChanges();

                    string Message = "Course Registration was Suceessfully Updated.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='CourseRegistrationRecord.aspx';</script>");
                }
            }
            else
            {
                string Message = "Please select faculty name";
                Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
            }
        }

    }
}