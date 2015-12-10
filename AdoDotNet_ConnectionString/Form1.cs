using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDotNet_ConnectionString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS1"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from Employee", con))
                    {
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        BindingSource source = new BindingSource();
                        source.DataSource = rdr;
                        dgView.DataSource = source;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = "Could not get Employee data from database";
                
            }
                
                        

        }
    }
}
