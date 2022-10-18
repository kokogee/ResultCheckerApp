using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DepartmentAdd : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();

    string DepartmentName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Page.Request["passid"] != null)
            {
                int DeptId = Convert.ToInt32(this.Page.Request["passid"]);
                var su = (from i in db.Departments
                          where i.DepartmentID == DeptId
                          select i).SingleOrDefault();
                if (su != null)
                {
                    txtDepartmentName.Text = su.DepartmentName;
                    ddlFacultyName.SelectedValue = Convert.ToString(su.FacultyID);
                    ddlHeadofDeptName.SelectedValue = Convert.ToString(su.HeadofDeptID);

                    txtSubmit.Text = "Edit";
                    txtDepartmentName.ReadOnly = true;
                    ddlFacultyName.Enabled = false;
                    ddlHeadofDeptName.Enabled = false;

                    txtDepartmentName.CssClass = "form-control";
                    ddlFacultyName.CssClass = "form-control";
                    ddlHeadofDeptName.CssClass = "form-control";

                    txtDepartmentName.BackColor = System.Drawing.Color.White;
                    ddlFacultyName.BackColor = System.Drawing.Color.White;
                    ddlHeadofDeptName.BackColor = System.Drawing.Color.White;
                }
            }
            getDepartment();

            getFaculty();

            getdata();
        }
    }

    protected void getDepartment()
    {
        var dep = (from i in db.Departments
                   select new
                   {
                       i.DepartmentName,
                       i.DepartmentID
                   }).ToList();
        if (dep.Count() > 0)
        {
            ddlHeadofDeptName.DataSource = dep;
            ddlHeadofDeptName.DataValueField = "DepartmentID";
            ddlHeadofDeptName.DataTextField = "DepartmentName";
            ddlHeadofDeptName.DataBind();
            ddlHeadofDeptName.Items.Insert(0, "Select Department Name");
        }
    }
    protected void getFaculty()
    {
        var fac = (from i in db.Faculties
                   select new
                   {
                       i.FacultyID,
                       i.FacultyName
                   }).ToList();
        if (fac.Count() > 0)
        {
            ddlFacultyName.DataSource = fac;
            ddlFacultyName.DataValueField = "FacultyID";
            ddlFacultyName.DataTextField = "FacultyName";
            ddlFacultyName.DataBind();
            ddlFacultyName.Items.Insert(0, "Select Faculty Name");
        }
    }
    protected void getdata()
    {
        var sta = (from i in db.Staffs
                   select new
                   {
                       i.StaffID,
                       i.LastName,
                       i.FirstName,
                       i.OtherName,
                       Name = getName(i.StaffNumber),
                   }).ToList();
        if (sta.Count() > 0)
        {
            ddlHeadofDeptName.DataSource = sta;
            ddlHeadofDeptName.DataValueField = "StaffID";
            ddlHeadofDeptName.DataTextField = "Name";
            ddlHeadofDeptName.DataBind();
            ddlHeadofDeptName.Items.Insert(0, "Select Head of Department");
        }
    }
    protected string getName(string StaffNumber)
    {
        string name = "";
        var na = (from i in db.Staffs
                  where i.StaffNumber == StaffNumber
                  select i).SingleOrDefault();
        if (na != null)
        {
            if (!string.IsNullOrEmpty(na.FirstName) && !string.IsNullOrEmpty(na.OtherName) && !string.IsNullOrEmpty(na.LastName))
            {
                name = na.FirstName + " " + na.OtherName + " " + na.LastName;
            }
           else if (string.IsNullOrEmpty(na.FirstName) && !string.IsNullOrEmpty(na.OtherName) && !string.IsNullOrEmpty(na.LastName))
            {
                name = na.OtherName + " " + na.LastName;
            }
            else if (!string.IsNullOrEmpty(na.FirstName) && string.IsNullOrEmpty(na.OtherName) && !string.IsNullOrEmpty(na.LastName))
            {
                name = na.FirstName + " " + na.LastName;
            }
           
        }
        return name;
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
       
        if (txtSubmit.Text == "Submit")
        {

            if (ddlHeadofDeptName.SelectedItem.Text != "Select Head of Department")
            {
                if (ddlFacultyName.SelectedItem.Text != "Select Faculty Name")
                {

                    Department de = new Department();
                    de.DepartmentName = txtDepartmentName.Text;
                    de.FacultyID = Convert.ToInt32(ddlFacultyName.SelectedValue);
                    de.HeadofDeptID = Convert.ToInt32(ddlHeadofDeptName.SelectedValue);

                    var chk = (from i in db.Departments
                               where i.DepartmentName == de.DepartmentName
                               select i).SingleOrDefault();

                    if (chk == null)
                    {
                        db.Departments.InsertOnSubmit(de);
                        db.SubmitChanges();

                        string Message = "Department name was successfully.";
                        Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='DepartmentRecord.aspx';</script>");
                    }
                }
                else
                {
                    string Message = "Please Select Head of Department";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
                }
            }
            else
            {
                string Message = "Please select faculty name";
                Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
            }

        }
        else if (txtSubmit.Text == "Edit")
        {
            txtSubmit.Text = "Save";
            txtDepartmentName.ReadOnly = false;
            ddlFacultyName.Enabled = true;
            ddlHeadofDeptName.Enabled = true;

        }
        else if (txtSubmit.Text == "Save")
        {
            if (this.Page.Request["passid"] != null)
               
            {
               int DepartmentID = Convert.ToInt32(this.Page.Request["passid"]);

                var de = (from i in db.Departments
                          where i.DepartmentID == DepartmentID
                          select i).SingleOrDefault();

                if (de != null)
                {
                    de.DepartmentName = txtDepartmentName.Text;
                    de.FacultyID = Convert.ToInt32(ddlFacultyName.SelectedValue);
                    de.HeadofDeptID = Convert.ToInt32(ddlHeadofDeptName.SelectedValue);

                    db.SubmitChanges();

                    string Message = "Department was Suceessfully Updated.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='DepartmentRecord.aspx';</script>");
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
           