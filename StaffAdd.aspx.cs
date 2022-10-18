using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffAdd : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();

    string StaffNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            roleList();

            if (this.Page.Request["passid"] != null)
            {
                StaffNumber = this.Page.Request["passid"];
                var su = (from i in db.Staffs
                          where i.StaffNumber == StaffNumber
                          select i).SingleOrDefault();
                if (su != null)
                {
                    txtStaffNumber.Text = su.StaffNumber;

                    txtFirstName.Text = su.FirstName;
                    txtOtherName.Text = su.OtherName;
                    txtLastName.Text = su.LastName;
                    txtRoleId.SelectedValue = Convert.ToString(su.RoleID);
                    txtGender.Text = su.Gender;
                    txtPassword.Text = su.Password;
                    //txtPassportPhoto.Text = su.PassportPhoto;
                    txtAddress.Text = su.Address;
                    txtStatus.Text = su.Status;
                    txtSubmit.Text = "Edit";
                    txtGender.Enabled = false;
                    txtStatus.Enabled = false;
                    txtRoleId.Enabled = false;

                    txtStatus.CssClass = "form-control";
                    txtStatus.BackColor = System.Drawing.Color.White;
                    txtGender.CssClass = "form-control";
                    txtRoleId.Enabled = false;
                    txtRoleId.CssClass = "form-control";
                    txtRoleId.BackColor = System.Drawing.Color.White;
                    txtStaffNumber.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtOtherName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtDateofBirth.ReadOnly = true;
                }
            }



            else
            {


                string lastStaffNumber = string.Empty;
                int lastUserNo = 0;

                var st = (from i in db.Staffs
                          orderby i.StaffID descending
                          select i).Take(1).SingleOrDefault();

                if (st != null)
                {
                    lastStaffNumber = st.StaffNumber;
                    lastUserNo = Convert.ToInt32(lastStaffNumber.Replace("CD", "")) + 1;
                    txtStaffNumber.Text = "CD" + lastUserNo;
                }
                else
                {
                    txtStaffNumber.Text = "CD1005";
                }

            }
            
        }
    }
    protected void roleList()
    {
            var Sa = (from i in db.Roles
                      select new
                      {
                          i.RoleDescription,
                          i.RoleID
                      }).ToList();
            if (Sa.Count() > 0)
            {
                txtRoleId.DataSource = Sa;
                txtRoleId.DataValueField = "RoleID";
                txtRoleId.DataTextField = "RoleDescription";
                txtRoleId.DataBind();
                txtRoleId.Items.Insert(0, "Select Role");
            }
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (txtSubmit.Text == "Submit")
        {
            try
            {
                if (txtRoleId.SelectedItem.Text != "Select Role")
                {
                    Staff s = new Staff();
                    s.FirstName = txtFirstName.Text;
                    s.OtherName = txtOtherName.Text;
                    s.LastName = txtLastName.Text;
                    s.Gender = txtGender.SelectedValue;
                    s.Status = txtStatus.SelectedValue;
                    s.RoleID = Convert.ToInt32(txtRoleId.SelectedValue);
                    s.Address = txtAddress.Text;
                    s.StaffNumber = txtStaffNumber.Text;
                    //s.PassportPhoto = txtPassportPhoto.Text;
                    s.DateCreated = DateTime.Now;
                    s.CreatedBy = 1;


                    var chk = (from i in db.Staffs
                               where i.Status == txtStatus.SelectedValue
                               select i).SingleOrDefault();
                    if (chk == null)
                    {
                        db.Staffs.InsertOnSubmit(s);
                        db.SubmitChanges();
                        string Message = "Successfully record";
                        Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
                    }
                    else
                    {
                        string Message = "Record already exist";
                        Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
                    }

                }
                else
                {
                    string Message = "Please Select Role";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
                }
            }
            catch (Exception i)
            {
                if (i.Message.Contains("Object reference"))
                {
                    string Message = "Please fil all required fields";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('" + i.Message + "');</script>");
                }

                //    Response.Write("<script language='javascript'>window.alert('" + i.Message + "');</script>");
            }
        }

        else if (txtSubmit.Text == "Edit")
        {
            txtSubmit.Text = "Save";
            txtStaffNumber.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtFirstName.ReadOnly = false;
            txtOtherName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtDateofBirth.ReadOnly = false;
            txtGender.Enabled = true;
            txtStatus.Enabled = true;
            txtRoleId.Enabled = true;
            //txtPassportPhoto.Enabled = true;
        }
        else if (txtSubmit.Text == "Save")
        {
            if (this.Page.Request["passid"] != null)
            {
                StaffNumber = this.Page.Request["passid"];

                var sff = (from i in db.Staffs
                           where i.StaffNumber == StaffNumber
                           select i).SingleOrDefault();
                if (sff != null)
                {

                    sff.Gender = txtGender.SelectedValue;
                    sff.FirstName = txtFirstName.Text;
                    sff.LastName = txtLastName.Text;
                    sff.OtherName = txtOtherName.Text;
                    sff.Status = txtStatus.SelectedValue;
                    sff.Address = txtAddress.Text;
                    sff.RoleID = Convert.ToInt32(txtRoleId.SelectedValue);
                    sff.StaffNumber = txtStaffNumber.Text;
                    sff.Password = txtPassword.Text;
                    //msglb.InnerText = "Successfully updated";
                    string Message = "Record successfully updated.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='StaffRecord.aspx';</script>");
                }
            }
        }
    }
}
