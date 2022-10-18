using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffRecord : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }
    }
    protected void delete(String UserId)
    {
        var det = (from i in db.Staffs
                   where i.StaffNumber == UserId
                   select i).ToList();
        foreach (var x in det)
        {
            db.Staffs.DeleteOnSubmit(x);
            db.SubmitChanges();
            string Message = "Record successfully deleted.";
            Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='StaffRecord.aspx';</script>");
        }
    }
    protected void getdata()
    {
        var rec = (from i in db.Staffs
                   select new 
                   {
                       i.StaffID,
                       i.LastName,
                       i.FirstName,
                       i.OtherName,
                       i.DateCreated,
                       i.StaffNumber,
                       i.Address,
                       i.Gender,
                       Name = getName(i.StaffNumber),

                   }).ToList();
        if (rec.Count() > 0)
        {
            lstStaffRecord.DataSource = rec;

            lstStaffRecord.DataBind();
        }
    }

    protected string getName(string StaffNumber)
    {
        string name = "";
        var re = (from i in db.Staffs
                  where i.StaffNumber == StaffNumber
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
    protected void lstStaffRecord_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edt":
                Response.Redirect("StaffAdd.aspx?passid=" + e.CommandArgument);
                break;
            case "Del":
                string id = Convert.ToString(e.CommandArgument);
                delete(id);
                break;
        }
    }
}