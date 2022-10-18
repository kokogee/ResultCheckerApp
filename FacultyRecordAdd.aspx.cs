using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyRecordAdd : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var rec = (from c in db.Faculties
                       select new
                       {
                           FacultyDean = getName(c.FacultyDean),
                           c.FacultyName,
                           c.FacultyID,
                           c.DateCreated,

                       }).Distinct();
            if (rec.Count() > 0)
            {
                lstFaculrtRecordAdd.DataSource = rec;
                lstFaculrtRecordAdd.DataBind();
            }
        }
    }

    protected void delete(int? UserId)
    {
        var fac = (from i in db.Faculties
                   where i.FacultyID == UserId
                   select i).ToList();
        foreach (var x in fac)
        {
            db.Faculties.DeleteOnSubmit(x);
            db.SubmitChanges();
            string Message = "Record successfully deleted.";
            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='DepartmentRecord.aspx';</script>");
        }
    }
    protected string getName(string StaffNumber)
    {
        string name = "";

        var std = (from i in db.Staffs
                   where i.StaffNumber == StaffNumber
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
    protected void lstFaculrtRecordAdd_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edt":
                Response.Redirect("FacultyAdd.aspx?passid=" + e.CommandArgument);
                break;
            case "Del":
                delete(Convert.ToInt32(e.CommandArgument));
                break;
        }
    }
}
