
using Company.BusinessLayer;

namespace Company.PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillEmployeesList();
        }

        private void FillEmployeesList()
        {
            dataGridView1.DataSource = Company.BusinessLayer.EmployeeBL.GetAll();
            comboBox1.DataSource = Company.BusinessLayer.EmployeeBL.GetAll();
            comboBox1.DisplayMember = "fname";
            comboBox1.ValueMember = "ssn";

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                ssn = Int32.Parse(txtId.Text),
                fname = txtFName.Text,
                lname = txtLName.Text,
                Address = txtAddress.Text
            };
            var affected = Company.BusinessLayer.EmployeeBL.Add(emp);
            label5.Text = affected.ToString();
            FillEmployeesList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DT = Company.BusinessLayer.EmployeeBL.GetOne(comboBox1.SelectedValue.ToString());
            txtId.Text = DT.Rows[0]["ssn"].ToString();
            txtFName.Text = DT.Rows[0]["fname"].ToString();
            txtLName.Text = DT.Rows[0]["lname"].ToString();
            txtAddress.Text = DT.Rows[0]["address"].ToString();
            txtId.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee a = new Employee
            {
                ssn = Int32.Parse(txtId.Text),
                fname = txtFName.Text,
                lname = txtLName.Text,
                Address = txtAddress.Text
            };
            var affected = Company.BusinessLayer.EmployeeBL.Update(a);
            label5.Text = affected.ToString();
            FillEmployeesList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var affected = Company.BusinessLayer.EmployeeBL.Delete(comboBox1.SelectedValue.ToString());
            label5.Text = affected.ToString();
            FillEmployeesList();
        }
    }
}
