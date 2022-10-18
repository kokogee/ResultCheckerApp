using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentRecord : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }

    }
    protected void getdata()
    {
        var sed = (from i in db.Students
                   select new
                   {
                       i.StudentID,
                       i.StudentNumber,
                       i.ParentName,
                       i.ParentPhoneNumber,
                       i.LastName,
                       i.FirstName,
                       i.OtherName,
                       i.DateCreated,
                       i.Address,
                       i.Gender,
                       StudentName = getName(i.StudentNumber),

                   }).ToList();
        if (sed.Count() > 0)
        {
            lstStudentRecord.DataSource = sed;
            lstStudentRecord.DataBind();
        }
    }
    protected void deleteStudent(String UserId)
    {
        var det = (from i in db.Students
                   where i.StudentNumber == UserId
                   select i).ToList();
        foreach (var x in det)
        {
            db.Students.DeleteOnSubmit(x);
            db.SubmitChanges();
            string Message = "Record successfully deleted.";
            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='StudentRecord.aspx';</script>");
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
    protected void lstStudentRecord_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edt":
                Response.Redirect("StudentAdd.aspx?passid=" + e.CommandArgument);
                break;
            case "Delet":
                deleteStudent(Convert.ToString(e.CommandArgument));
                break;
        }


    }

   
}