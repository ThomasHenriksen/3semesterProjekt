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
    public partial class Employee : Form
    {
        EmployeeControl employeeControl;

        public Employee()
        {
            InitializeComponent();
            this.employeeControl = new();
            SetEmployeeList();
            SetPicture();
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            int idFromTextBox;
            ModelLayer.Employee foundEmployee = null;
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
            List<ModelLayer.Employee> employeesToShow = await employeeControl.GetAllEmployees();
            listOfEmployees.DataSource = employeesToShow;
        }

        private void SetPicture()
        {
            //pictureBox1.Image = Image.FromFile("C:\\Users\\45218\\OneDrive\\Billeder\\Saved Pictures\\jessieGUI.jpg");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void listOfEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            string firstNameOfEmployee = textBox2.Text;
            string lastNameOfEmployee = textBox3.Text;
            string addressOfEmployee = textBox4.Text;
            string zipCodeOfEmployee = textBox5.Text;
            string CityOfEmployee = textBox6.Text;
            string phoneOfEmployee = textBox7.Text;
            string emailOfEmployee = textBox8.Text;
            double salaryOfEmployee = double.Parse(textBox9.Text);
            string positionOfEmployee = textBox10.Text;

            await employeeControl.SaveEmployee(firstNameOfEmployee, lastNameOfEmployee, addressOfEmployee, zipCodeOfEmployee, CityOfEmployee,
                phoneOfEmployee, emailOfEmployee, salaryOfEmployee, positionOfEmployee);
        }
    }
}