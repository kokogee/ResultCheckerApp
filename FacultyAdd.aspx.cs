using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyAdd : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            getdata();
            if (this.Page.Request["passid"] != null)
            {
                int facId = Convert.ToInt32(this.Page.Request["passid"]);
                var su = (from i in db.Faculties
                          where i.FacultyID == facId
                          select i).SingleOrDefault();
                if (su != null)
                {
                    txtFacultyName.Text = su.FacultyName;
                    ddlDeanOfFaculty.SelectedValue = Convert.ToString(su.FacultyDean);

                    txtSubmit.Text = "Edit";
                    txtFacultyName.ReadOnly = true;
                    ddlDeanOfFaculty.Enabled = false;

                    ddlDeanOfFaculty.CssClass = "form-control";
                    txtFacultyName.CssClass = "form-control";

                    ddlDeanOfFaculty.BackColor = System.Drawing.Color.White;
                    txtFacultyName.BackColor = System.Drawing.Color.White;

                }

              

            }
        }
    }
    protected void getdata()
    {
        var sta = (from i in db.Staffs
                   select new
                   {
                       i.StaffNumber,
                       i.LastName,
                       i.FirstName,
                       i.OtherName,
                       Name = getName(i.StaffNumber),
                   }).ToList();
        if (sta.Count() > 0)
        {
            ddlDeanOfFaculty.DataSource = sta;
           ddlDeanOfFaculty.DataValueField = "StaffNumber";
           ddlDeanOfFaculty.DataTextField = "Name";
           ddlDeanOfFaculty.DataBind();
           ddlDeanOfFaculty.Items.Insert(0, "Select Faculty  Dean ");
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
            if (string.IsNullOrEmpty(na.FirstName) && !string.IsNullOrEmpty(na.OtherName) && !string.IsNullOrEmpty(na.LastName))
            {
                name = na.OtherName + " " + na.LastName;
            }
            if (!string.IsNullOrEmpty(na.FirstName) && string.IsNullOrEmpty(na.OtherName) && !string.IsNullOrEmpty(na.LastName))
            {
                name = na.FirstName + " " + na.LastName;
            }
            if (!string.IsNullOrEmpty(na.FirstName) && !string.IsNullOrEmpty(na.OtherName) && string.IsNullOrEmpty(na.LastName))
            {
                name = na.FirstName + " " + na.OtherName;
            }
        }
        return name;
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (txtSubmit.Text == "Submit")
        {
            if (ddlDeanOfFaculty.SelectedItem.Text != "Select Faculty Dean")
            {
                Faculty de = new Faculty();
                de.FacultyName = txtFacultyName.Text;
                de.FacultyDean = ddlDeanOfFaculty.SelectedValue;
                var chk = (from i in db.Faculties
                           where i.FacultyName == de.FacultyName
                           select i).SingleOrDefault();
                if (chk == null)
                {
                    db.Faculties.InsertOnSubmit(de);
                    db.SubmitChanges();

                    string Message = "Faculty name was successfully inserted into the database.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='FacultyRecordAdd.aspx';</script>");
                }

                else
                {
                    string Message = "Please select faculty dean.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
                }

            }
        }
        else if (txtSubmit.Text == "Edit")
        {
            txtSubmit.Text = "Save";
            txtFacultyName.ReadOnly = false;
            ddlDeanOfFaculty.Enabled = true;
        }
        else if (txtSubmit.Text == "Save")
        {
            if (this.Page.Request["passid"] != null)

            {
                int FacId = Convert.ToInt32(this.Page.Request["passid"]);

                var de = (from i in db.Faculties
                          where i.FacultyID == FacId
                          select i).SingleOrDefault();

                if (de != null)
                {
                    de.FacultyName = txtFacultyName.Text;
                    de.FacultyDean = ddlDeanOfFaculty.SelectedValue;

                    db.SubmitChanges();

                    string Message = "Faculty was Suceessfully Updated.";
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
