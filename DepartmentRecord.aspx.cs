using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DepartmentRecord : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            getdata();
        }
       
    }
    protected void getdata ()
    {
        var rec = (from cr in db.Departments
                   join s in db.Staffs on cr.HeadofDeptID equals s.StaffID
                   join f in db.Faculties on cr.FacultyID equals f.FacultyID
                   select new
                   {
                       HeadofDeptID = getName(cr.HeadofDeptID),
                       FacultyID = f.FacultyName,
                       DepartmentName = cr.DepartmentName,
                       cr.DateCreated,
                       cr.DepartmentID
                   }).Distinct();
        if (rec.Count() > 0)
        {
            lstDepartmentRecord.DataSource = rec;
            lstDepartmentRecord.DataBind();
        }
    }
    protected void deleteDepartment(int? UserId)
    {
        var det = (from i in db.Departments
                   where i.DepartmentID == UserId
                   select i).ToList();
        foreach (var x in det)
        {
            db.Departments.DeleteOnSubmit(x);
            db.SubmitChanges();
            string Message = "Record successfully deleted.";
            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='DepartmentRecord.aspx';</script>");
        }
    }
    protected string getName(int? ID)
    {
        string name = "";

        var std = (from i in db.Staffs
                   where i.StaffID == ID
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



    protected void lstDepartmentRecord_ItemCommand1(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edt":
                Response.Redirect("DepartmentAdd.aspx?passid=" + e.CommandArgument);
                break;
            case "Del":
                deleteDepartment(Convert.ToInt32(e.CommandArgument));
                break;
        }
    }
}


  