using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentAdd : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();

    string StudentNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Page.Request["passid"] != null)
            {
                StudentNumber = this.Page.Request["passid"];
                var su = (from i in db.Students
                          where i.StudentNumber == StudentNumber
                          select i).SingleOrDefault();
                if (su != null)
                {
                    txtStudentNumber.Text = su.StudentNumber;
                    txtStudentPhoneNumber.Text = su.StudentPhoneNumber;
                    txtParentPhoneNumber.Text = su.ParentPhoneNumber;
                    txtFirstName.Text = su.FirstName;
                    txtOtherName.Text = su.OtherName;
                    txtLastName.Text = su.LastName;
                    txtParentName.Text = su.ParentName;
                    txtGender.Text = su.Gender;
                    txtAddress.Text = su.Address;
                    
                    txtSubmit.Text = "Edit";
                    txtGender.Enabled = false;
                    txtStatus.Enabled = false;

                    txtStatus.CssClass = "form-control";
                    txtStatus.BackColor = System.Drawing.Color.White;
                    txtGender.CssClass = "form-control";
                    txtAddress.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtOtherName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtDateofBirth.ReadOnly = true;
                }
            }
            else
            {
                string lastStudentNumber = string.Empty;
                int lastUserNo = 0;

                var st = (from i in db.Students
                          orderby i.StudentNumber descending
                          select i).Take(1).SingleOrDefault();

                if (st != null)
                {
                    lastStudentNumber = st.StudentNumber;
                    lastUserNo = Convert.ToInt32(lastStudentNumber.Replace("STU", "")) + 1;
                    txtStudentNumber.Text = "STU" + lastUserNo;
                }
                else
                {
                    txtStudentNumber.Text = "STU1001";
                }
            }
        }
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (txtSubmit.Text == "Submit")
        {
            Student se = new Student();

            se.FirstName = txtFirstName.Text;
            se.LastName = txtLastName.Text;
            se.OtherName = txtOtherName.Text;
            se.ParentName = txtParentName.Text;
            se.ParentPhoneNumber = txtParentPhoneNumber.Text;
            se.Address = txtAddress.Text;
            se.Gender = txtGender.SelectedValue;
            se.StudentNumber = txtStudentNumber.Text;
            //msglb.InnerText = "Successfully updated";
            var chk = (from i in db.Students
                       where i.StudentNumber == se.StudentNumber
                       select i).SingleOrDefault();
            if (chk == null)
            {               
                db.Students.InsertOnSubmit(se);
                db.SubmitChanges();
                string Message = "Successfully record";
                Response.Write("<script language='javascript'>window.alert('" + Message + "');StudentRecord.aspx</script>");
            }
            else
            {
                string Message = "Record already exist";
                Response.Write("<script language='javascript'>window.alert('" + Message + "');</script>");

            }
        }
        else if (txtSubmit.Text == "Edit")
        {
            txtSubmit.Text = "Save";
            txtAddress.ReadOnly = false;
            txtFirstName.ReadOnly = false;
            txtOtherName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtDateofBirth.ReadOnly = false;
            txtGender.Enabled = true;
            txtStatus.Enabled = true;

            //txtPassportPhoto.Enabled = true;
        }
        else if (txtSubmit.Text == "Save")
        {
            if (this.Page.Request["passid"] != null)
            {
                StudentNumber = this.Page.Request["passid"];

                var sff = (from i in db.Students
                           where i.StudentNumber == StudentNumber
                           select i).SingleOrDefault();
                if (sff != null)
                {
                    sff.Gender = txtGender.SelectedValue;
                    sff.FirstName = txtFirstName.Text;
                    sff.LastName = txtLastName.Text;
                    sff.OtherName = txtOtherName.Text;
                    sff.Address = txtAddress.Text;
                    //msglb.InnerText = "Successfully updated";
                    db.SubmitChanges();
                    string Message = "Record successfully updated.";
                    Response.Write("<script language='javascript'>window.alert('" + Message + "');window.location='StudentRecord.aspx';</script>");
                }

            }
        }
    }
}






