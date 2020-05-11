using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AssignmentUsingListViewCrudOperation
{
    public partial class AddEmployeeData : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeDetail();
            }
        }
        void GetEmployeeDetail()
        {
            SqlConnection con = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand("sp_FillData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            ListEmployee.DataSource = cmd.ExecuteReader();
            ListEmployee.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertEmployeeData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@EmpName", SqlDbType.VarChar).Value = txtName.Text.Trim();
                    cmd.Parameters.AddWithValue("@City", SqlDbType.NChar).Value = DropDownList1.Text.Trim();
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = RadioButtonList1.Text.Trim();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtName.Text = String.Empty;
                    DropDownList1.Text = String.Empty;
                    RadioButtonList1.Text = String.Empty;
                }
            }
            GetEmployeeDetail();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployeeData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpID", Convert.ToInt32(hfRecord.Value));
            cmd.Parameters.AddWithValue("@EmpName", SqlDbType.VarChar).Value = txtName.Text.Trim();
            cmd.Parameters.AddWithValue("@City", SqlDbType.NChar).Value = DropDownList1.Text.Trim();
            cmd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = RadioButtonList1.Text.Trim();

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GetEmployeeDetail();

            btnSave.Visible = true;
            btnUpdate.Visible = false;

            hfRecord.Value = string.Empty;
            txtName.Text = String.Empty;
            DropDownList1.Text = String.Empty;
            RadioButtonList1.Text = String.Empty;
        }
        protected void ListEmployee_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("EmpDelete"):
                    int EmpID = Convert.ToInt32(e.CommandArgument);
                    deleteEmployee(EmpID);
                    break;
                case ("EmpEdit"):
                    EmpID = Convert.ToInt32(e.CommandArgument);
                    UpdateEmployeeDetail(EmpID);
                    break;
            }
        }
        void deleteEmployee(int EmpID)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_DeleteEmployeeData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GetEmployeeDetail();
        }
        void UpdateEmployeeDetail(int EmpID)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_SelectEmployeeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", EmpID);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                hfRecord.Value = dr["EmpID"].ToString();
                txtName.Text = dr["EmpName"].ToString();
                DropDownList1.Text = dr["City"].ToString();
                RadioButtonList1.Text = dr["Gender"].ToString();
            }
            dr.Dispose();

            con.Close();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            GetEmployeeDetail();
        }

    }
}