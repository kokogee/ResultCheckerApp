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
        //Declaring the Cookie here as a Global Variable
        HttpCookie cookie = new HttpCookie("UserInfo");

        //Database >>>
        var chkPass = (from i in db.Staffs
                   where i.StaffNumber == txtUsername.Text
                   && i.Password == txtPassword.Text
                   select i).SingleOrDefault();

        if (chkPass !=null)
        {
            //print the properties of each cookie object
            cookie.Values.Add("Username", chkPass.StaffNumber);
            cookie.Values.Add("StaffNumber", chkPass.StaffNumber);
            cookie.Values.Add("Address", chkPass.Address);
            cookie.Values.Add("RoleID", Convert.ToString(chkPass.RoleID));
            cookie.Values.Add("RoleDescription", chkPass.Role.RoleDescription);
            cookie.Values.Add("StaffName", (chkPass.FirstName + " " + chkPass.LastName));
            cookie.Values.Add("StaffID", Convert.ToString(chkPass.StaffID));

            //Set expires to cookie object - It will clear the cookie within one Hour
            cookie.Expires = DateTime.Now.AddHours(1); 
            
            //Get or sets the HttpContext object for the current HTTP request.
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