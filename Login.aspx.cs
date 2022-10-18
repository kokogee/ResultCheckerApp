using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    NewDataBaseDataContext db = new NewDataBaseDataContext();
        
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("UserInfo");

        var chkPass = (from i in db.Staffs
                   where i.StaffNumber == txtUsername.Text
                   && i.Password == txtPassword.Text
                   select i).SingleOrDefault();

        if (chkPass !=null)
        {
            cookie.Values.Add("Username", chkPass.StaffNumber);
            cookie.Values.Add("StaffNumber", chkPass.StaffNumber);
            cookie.Values.Add("Address", chkPass.Address);
            cookie.Values.Add("RoleID", Convert.ToString(chkPass.RoleID));
            cookie.Values.Add("RoleDescription", chkPass.Role.RoleDescription);
            cookie.Values.Add("StaffName", (chkPass.FirstName + " " + chkPass.LastName));
            cookie.Values.Add("StaffID", Convert.ToString(chkPass.StaffID));
            cookie.Expires.AddMinutes(5);
            HttpContext.Current.Response.AppendCookie(cookie);

            Response.Redirect("/FacultyAdd.aspx");
        }

       
        {

        }
        
        var chk = (from i in db.Staffs
                   where i.StaffNumber == txtUsername.Text
                   select i).SingleOrDefault();

        if(chk != null)
        {
            var chkPass1 = (from i in db.Staffs
                       where i.StaffNumber == txtUsername.Text
                       && i.Password == txtPassword.Text
                       select i).SingleOrDefault();

            if(chkPass1 != null)
            {
                Response.Redirect("/FacultyAdd.aspx");
            }
            else
            {
                MessageLabel.Text = "Invalid password.";
                MessageLabel.Focus();
            }
        }
        else
        {
            MessageLabel.Text = "Invalid username.";
            MessageLabel.Focus();
        }
    }
}