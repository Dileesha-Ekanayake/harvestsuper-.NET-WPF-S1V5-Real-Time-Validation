using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace S1V5
{
    public partial class EmployeeUi : Form
    {
        private DataGridView tblEmployee;
        private Employee employee;
        private Employee Oldemployee;
        private Color valid;
        private Color invalid;
        private Color initial;
        private Color updated;
        private List<Employee> empList;
        private List<Gender> genderList;
        private List<Designation> designationList;
        private List<Employeestatus> empStatusList;
        public EmployeeUi()
        {
            InitializeComponent();
            initialize();           
        }

        private void initialize()
        {
            LoadView();
            LoadTable();
            LoadForm();
        }
        private void LoadView()
        {
            valid = Color.LightGreen;
            invalid = Color.LightPink;
            initial = Color.White;
            updated = Color.Khaki;
            employee = new Employee();
            tblEmployee = new DataGridView();
            tblEmployee.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(tblEmployee);
            tblEmployee.SelectionChanged += TblEmployee_SelectionChanged;
        }
        private void TblEmployee_SelectionChanged(object? sender, EventArgs e)
        {
            if (tblEmployee.Focused)
            {
                DataGridViewSelectedRowCollection selectedRows = tblEmployee.SelectedRows;

                if (selectedRows != null && selectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.Tag is Employee employee)
                        {
                            FillForm(employee);
                        }
                        else
                        {
                            MessageBox.Show("Employee information not available.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No row selected.");
                }
            }
        }
        private void FillForm(Employee emp)
        {
            Oldemployee = emp;

            employee = new Employee();
            employee.Name = emp.Name;
            employee.Nic = emp.Nic;
            employee.Mobile = emp.Mobile;
            employee.Email = emp.Email;
            employee.DOB = emp.DOB;
            employee.Gender = emp.Gender;
            employee.Designation = emp.Designation;
            employee.Employeestatus = emp.Employeestatus;

            txtName.Text = emp.Name;
            txtNic.Text = emp.Nic;
            txtMobile.Text = emp.Mobile;
            txtEmail.Text = emp.Email;
            txtDate.Value = emp.DOB;

            int selectedGenIndex = genderList.FindIndex(g => g.Name.Equals(emp.Gender.Name));
            if (selectedGenIndex != -1)
            {
                cmbGender.SelectedIndex = selectedGenIndex + 1;
            }

            int selectedDesIndex = designationList.FindIndex(d => d.Name.Equals(emp.Designation.Name));
            if (selectedDesIndex != -1)
            {
                cmbDesignation.SelectedIndex = selectedDesIndex + 1;
            }

            int selectedStsIndex = empStatusList.FindIndex(s => s.Name.Equals(emp.Employeestatus.Name));
            if (selectedStsIndex != -1)
            {
                cmbStatus.SelectedIndex = selectedStsIndex + 1;
            }

            setStyle(valid);
        }
        private void LoadForm()
        {
            employee = new Employee();
            LoadGender();
            LoadDesignation();
            LoadStatus();

            txtName.Text = "";
            txtNic.Text = "";
            txtDate.Value = DateTime.Now.AddMinutes(-1);
            txtMobile.Text = "076";
            txtEmail.Text = "@gmail.com";
            
        }

        private void LoadTable()
        {
            
            empList = EmployeeController.Get(null);
            FillTable(empList);
        }

        private void LoadGender()
        {
            genderList = GenderController.Get();
            cmbSearchGender.Items.Clear();
            cmbGender.Items.Clear();
            cmbSearchGender.Items.Add("Select a Gender");
            cmbGender.Items.Add("Select a Gender");
            cmbSearchGender.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;

            foreach (Gender gender in genderList)
            {
                cmbSearchGender.Items.Add(gender);
                cmbGender.Items.Add(gender);
            }
            cmbSearchGender.DisplayMember = "Name";
            cmbGender.DisplayMember = "Name";
        }

        public void LoadDesignation()
        {
            designationList = DesignationController.Get();
            cmbDesignation.Items.Clear();
            cmbDesignation.Items.Add("Select a Designation");
            cmbDesignation.SelectedIndex = 0;

            foreach (Designation designation in designationList)
            {
                cmbDesignation.Items.Add(designation);
            }
            cmbDesignation.DisplayMember = "Name";
        }

        public void LoadStatus()
        {
            empStatusList = EmployeestatusController.Get();
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Select a Status");
            cmbStatus.SelectedIndex = 0;

            foreach (Employeestatus employeestatus in empStatusList)
            {
                cmbStatus.Items.Add(employeestatus);
            }
            cmbStatus.DisplayMember = "Name";
        }

        private void FillTable(List<Employee> employees)
        {
            tblEmployee.Rows.Clear();
            tblEmployee.Columns.Clear();

            tblEmployee.Columns.Add("ID", "ID");
            tblEmployee.Columns.Add("Name", "Name");
            tblEmployee.Columns.Add("NIC", "NIC");
            tblEmployee.Columns.Add("Gender", "Gender");
            tblEmployee.Columns.Add("Designation", "Designation");
            tblEmployee.Columns.Add("Status", "Status");

            foreach (Employee emp in employees)
            {
                int rowIndex = tblEmployee.Rows.Add();
                DataGridViewRow row = tblEmployee.Rows[rowIndex];
                row.Cells["ID"].Value = emp.Id;
                row.Cells["Name"].Value = emp.Name;
                row.Cells["NIC"].Value = emp.Nic;
                row.Cells["Gender"].Value = emp.Gender.Name;
                row.Cells["Designation"].Value = emp.Designation.Name;
                row.Cells["Status"].Value = emp.Employeestatus.Name;

                row.Tag = emp;
            }
        }
        private void ClearSearch(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure To Clear?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtSearchName.Text = "";
                cmbSearchGender.SelectedIndex = 0;
                LoadTable();
            }
        }

        private void SeachByName(object sender, EventArgs e)
        {
            Hashtable hashtable = new Hashtable();
            string name = txtSearchName.Text.Trim();

            if (!string.IsNullOrEmpty(name))
            {
                hashtable.Add("name", name);
            }

            if (cmbSearchGender.SelectedItem != null && cmbSearchGender.SelectedIndex != 0)
            {
                Gender selectedGender = (Gender)cmbSearchGender.SelectedItem;
                hashtable.Add("gender", selectedGender);
            }

            if (hashtable.Count > 0)
            {
                empList = EmployeeController.Get(hashtable);
                FillTable(empList);
            }
            else
            {
                MessageBox.Show("Please provide at least one search value.");
            }
        }

        private string GetErrors()
        {
            string errors = "";

            if (employee.Name == null) errors = errors + "\n Invalid Name"; 
            if (employee.DOB == null || (DateTime.Now.Year - employee.DOB.Year) < 18) errors = errors + "\n Invalid DOB"; 
            if (employee.Nic == null) errors = errors + "\n Invalid Nic"; 
            if (employee.Mobile == null) errors = errors + "\n Invalid Mobile"; 
            if (employee.Email == null || employee.Email.Equals("@gmail.com")) errors = errors + "\n Invalid Email"; 
            if (employee.Gender == null) errors = errors + "\n Invalid Gender"; 
            if (employee.Designation == null) errors = errors + "\n Invalid Designation"; 
            if (employee.Employeestatus == null) errors = errors + "\n Invalid Employeestatus"; 

            return errors;
        }

        private void txtNameKC(object sender, KeyEventArgs e)
        {
            string name = txtName.Text;
            string namepttn = "^[A-Z][a-z]*$";
            Match nameMatch = Regex.Match(name, namepttn);
            if (nameMatch.Success)
            {
                employee.Name = name;
                txtName.BackColor = valid;
                if(Oldemployee != null)
                {
                    if (!employee.Name.Equals(Oldemployee.Name)) 
                    {
                        txtName.BackColor = updated;
                    }
                }
            }
            else { txtName.BackColor = invalid; }
        }
        private void txtNicKC(object sender, KeyEventArgs e)
        {
            string nic = txtNic.Text;
            string nicpttn = "^(([\\d]{9}[vVxX])|([\\d]{12}))$";
            Match nicMatch = Regex.Match(nic, nicpttn);
            if (nicMatch.Success)
            {
                employee.Nic = nic;
                txtNic.BackColor = valid;
                if (Oldemployee != null)
                {
                    if (!employee.Nic.Equals(Oldemployee.Nic))
                    {
                        txtNic.BackColor = updated;
                    }
                }
            }
            else { txtNic.BackColor = invalid; }
        }
        private void txtMobileKC(object sender, KeyEventArgs e)
        {
            string mobile = txtMobile.Text;
            string mobilepttn = "^0[0-9]{9}$";
            Match mobileMatch = Regex.Match(mobile, mobilepttn);
            if (mobileMatch.Success)
            {
                employee.Mobile = mobile;
                txtMobile.BackColor = valid;
                if (Oldemployee != null)
                {
                    if (!employee.Mobile.Equals(Oldemployee.Mobile))
                    {
                        txtMobile.BackColor = updated;
                    }
                }
            }
            else { txtMobile.BackColor = invalid; }
        }
        private void txtEmailKC(object sender, KeyEventArgs e)
        {
            string email = txtEmail.Text;
            string emailpttn = "^[a-z]*@[a-z]*.[a-z]*$";
            Match emailMatch = Regex.Match(email, emailpttn);
            if (emailMatch.Success)
            {
                employee.Email = email;
                txtEmail.BackColor = valid;
                if (Oldemployee != null)
                {
                    if (!employee.Email.Equals(Oldemployee.Email))
                    {
                        txtEmail.BackColor = updated;
                    }
                }
            }
            else { txtEmail.BackColor = invalid; }
        }
        private void cmbGenderAP(object sender, EventArgs e)
        {
            if (cmbGender.SelectedItem != null && cmbGender.SelectedIndex != 0 && cmbGender.SelectedItem is Gender)
            {
                employee.Gender = (Gender)cmbGender.SelectedItem;
                cmbGender.BackColor = valid;
                if(Oldemployee != null)
                {
                    if (!employee.Gender.Id.Equals(Oldemployee.Gender.Id))
                    {
                        cmbGender.BackColor= updated;
                    }
                }
            }
            else { cmbGender.BackColor = invalid; }
        }
        private void cmbDesignationAP(object sender, EventArgs e)
        {
            if (cmbDesignation.SelectedItem != null && cmbDesignation.SelectedIndex != 0 && cmbDesignation.SelectedItem is Designation)
            {
                employee.Designation = (Designation)cmbDesignation.SelectedItem;
                cmbDesignation.BackColor = valid;
                if(Oldemployee != null)
                {
                    if (!employee.Designation.Id.Equals(Oldemployee.Designation.Id))
                    {
                        cmbDesignation.BackColor = updated;
                    }
                }
            }
            else { cmbDesignation.BackColor = invalid; }
        }
        private void cmbStatusAP(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem != null && cmbStatus.SelectedIndex != 0 && cmbStatus.SelectedItem is Employeestatus)
            {
                employee.Employeestatus = (Employeestatus)cmbStatus.SelectedItem;
                cmbStatus.BackColor = valid;
                if(Oldemployee != null)
                {
                    if (!employee.Employeestatus.Id.Equals(Oldemployee.Employeestatus.Id))
                    {
                        cmbStatus.BackColor = updated;
                    }
                }
            }
            else { cmbStatus.BackColor = invalid; }
        }

        private void txtDatePC(object sender, EventArgs e)
        {
            DateTime dobirth = txtDate.Value;
            employee.DOB = dobirth;
            if (!((DateTime.Now.Year - dobirth.Year) < 18))
            {
                 
                txtDate.BackColor = valid;
                txtDate.CalendarTitleBackColor = valid;
                txtDate.CalendarForeColor = valid;
                txtDate.CalendarMonthBackground = valid;
                employee.DOB = dobirth;
            }
            else
            {
                txtDate.BackColor = invalid;
                txtDate.CalendarTitleBackColor = invalid;
                txtDate.CalendarForeColor = invalid;
                txtDate.CalendarMonthBackground = invalid;
            }
        }

        private void setStyle(Color clr)
        {
            txtName.BackColor = clr;
            txtMobile.BackColor = clr;
            txtEmail.BackColor = clr;
            txtNic.BackColor = clr;

            cmbDesignation.BackColor = clr;
            cmbGender.BackColor = clr;
            cmbStatus.BackColor = clr;
        }

        private void Add(object sender, EventArgs e)
        {
            string errors = GetErrors();

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors);
            }
            else
            {                
                string confMsg = "Are you sure to add this Employee?\n\n";
                confMsg += "Name: " + employee.Name + "\n";
                confMsg += "DOB: " + employee.DOB + "\n";
                confMsg += "NIC: " + employee.Nic + "\n";
                confMsg += "Mobile: " + employee.Mobile + "\n";
                confMsg += "Email: " + employee.Email + "\n";
                if (employee.Gender != null)
                    confMsg += "Gender: " + employee.Gender.Name + "\n";
                if (employee.Designation != null)
                    confMsg += "Designation: " + employee.Designation.Name + "\n";
                if (employee.Employeestatus != null)
                    confMsg += "Status: " + employee.Employeestatus.Name + "\n";

                DialogResult result = MessageBox.Show(confMsg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {                 
                   string sr = EmployeeController.Post(employee);
                    if(sr == "1")
                    {
                        LoadTable();
                        LoadForm();
                        MessageBox.Show("Successfully Saved");
                    }
                    else { MessageBox.Show("Failed to Saved as : " + sr); }
                }
            }
        }

        private void ClearForm(object sender, EventArgs e) {

            DialogResult result = MessageBox.Show("Are you sure to clear ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {                
                LoadForm();
                setStyle(initial);
                tblEmployee.ClearSelection();
            }
        }
    }
}

