using ArmysalgClientDesktop.ControlLayer;
using ArmysalgClientDesktop.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmysalgClientDesktop.GuiLayer
{
    public partial class EmployeeGUI : Form
    {
        EmployeeControl employeeControl;

        public EmployeeGUI()
        {
            InitializeComponent();
            this.employeeControl = new();
            SetEmployeeList();
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            int idFromTextBox;
            Employee foundEmployee = null;
            if (int.TryParse(textBox1.Text, out idFromTextBox))
            {
                foundEmployee = await employeeControl.GetEmployee(idFromTextBox);
            }
            if(foundEmployee != null)
            {
                firstName.Text = foundEmployee.FirstName;
                lastName.Text = foundEmployee.LastName;
                phone.Text = foundEmployee.Phone;
            }
            else
            {
                lblErrorEmpNotFound.Text = "Employee not found";
            }
        }

        private async void SetEmployeeList()
        {
            List<Employee> employeesToShow = await employeeControl.GetAllEmployees();
            listOfEmployees.DataSource = employeesToShow;
        }

        private void listOfEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}