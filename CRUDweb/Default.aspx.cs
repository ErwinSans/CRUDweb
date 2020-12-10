using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUDweb.ServiceReference1;

namespace CRUDweb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertUser u = new InsertUser();
            u.Name = TextBox1.Text;
            u.Email = TextBox2.Text;
            string r = client.Insert(u);
            lblmsg.Text = r.ToString();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.gettestdata gettestdata = new ServiceReference1.gettestdata();
            gettestdata = client.GetInfo();
            DataTable dataTable = new DataTable();
            dataTable = gettestdata.usertab;
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            updateUser.UID = int.Parse(txtuid.Text);
            updateUser.Name = TextBox1.Text;
            updateUser.Email = TextBox2.Text;
            string result = client.Update(updateUser);
            lblmsg.Text = result.ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser();
            deleteUser.UID = int.Parse(txtuid.Text);
            string res = client.Delete(deleteUser);
            lblmsg.Text = res.ToString();
        }
    }
}