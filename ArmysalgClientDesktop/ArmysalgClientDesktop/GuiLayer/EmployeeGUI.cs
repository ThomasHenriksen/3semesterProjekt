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
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            int idFromTextBox;
            Employee foundEmployee = null;
            if (int.TryParse(textBox1.Text, out idFromTextBox))
            {
                foundEmployee = await employeeControl.GetEmployee(idFromTextBox);
            }
            firstName.Text = foundEmployee.FirstName;
        }
    }
}