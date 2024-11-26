using Microsoft.Data.SqlClient;
using System.Data;

namespace DisconnectedModeTask
{
    public partial class Form1 : Form
    {
        //
        SqlConnection con;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dt;
        //
        public Form1()
        {
            con = new SqlConnection("Data Source=DESKTOP-6H9B8GJ\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            dt = new DataTable();
            InitializeComponent();
            FillEmployeesToGridView();
        }

        private void FillEmployeesToGridView()
        {
            command.CommandText = "select ssn,fname,lname,address from employee";
            command.Connection = con;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            gridEmployees.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["ssn"] = txtId.Text;
            dr["fname"] = txtFName.Text;
            dr["lname"] = txtLName.Text;
            dr["address"] = txtAddress.Text;

            //REMEMBER to Add new row to Datatable
            dt.Rows.Add(dr);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            //Insert
            SqlCommand InsCommand = new SqlCommand();
            InsCommand.CommandText = "insert into employee (ssn,fname,lname,address) values (@id,@fn,@ln,@address)";
            InsCommand.Parameters.Add("@id", SqlDbType.VarChar, 20, "ssn");
            InsCommand.Parameters.Add("@fn", SqlDbType.VarChar, 20, "fname");
            InsCommand.Parameters.Add("@ln", SqlDbType.VarChar, 20, "lname");
            InsCommand.Parameters.Add("@address", SqlDbType.VarChar, 20, "address");
            InsCommand.Connection = con;
            //

            //Update
            SqlCommand UpdCommand = new SqlCommand();
            UpdCommand.CommandText = "update employee set fname=@fn,lname=@ln,address=@address where ssn=@id";
            UpdCommand.Parameters.Add("@id", SqlDbType.VarChar, 20, "ssn");
            UpdCommand.Parameters.Add("@fn", SqlDbType.VarChar, 20, "fname");
            UpdCommand.Parameters.Add("@ln", SqlDbType.VarChar, 20, "lname");
            UpdCommand.Parameters.Add("@address", SqlDbType.VarChar, 20, "address");
            UpdCommand.Connection = con;
            //

            //Delete
            SqlCommand DelCommand = new SqlCommand();
            DelCommand.CommandText = "delete from employee where ssn=@id";
            DelCommand.Parameters.Add("@id", SqlDbType.VarChar, 20, "ssn");
            DelCommand.Connection = con;
            //

            adapter.UpdateCommand = UpdCommand;
            adapter.InsertCommand = InsCommand;
            adapter.DeleteCommand = DelCommand;

            //Return 1-open 2-sync 3-close   Update() 
            adapter.Update(dt);

        }
    }
}
