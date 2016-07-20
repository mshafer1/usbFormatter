using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


using System.Diagnostics;


namespace USBFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblProgress.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var driveList = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable).ToList();
            if (driveList.Count > 0)
            {
                cbDrives.DataSource = driveList;
                btnFormat.Enabled = true;
            }
            else
            {
                cbDrives.Visible = false;
                lblSelect.Text = "No Removable Drives Found";
            }

        }

        private void bgFormatter_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;           
                    // Perform a time consuming operation and report progress.
            string drive = e.Argument as string;
            if (drive == null)
            {
                throw new Exception("Error");
            }

            if (drive.IndexOf("\\") != -1)
            {
                drive = drive.Substring(0, drive.IndexOf("\\"));
            }


            Console.WriteLine("test");
            Console.WriteLine(drive);
            Console.WriteLine("test");

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("format /fs:ntfs /q /x " + drive);
            cmd.StandardInput.WriteLine("");
            cmd.StandardInput.WriteLine("");

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            string error = cmd.StandardError.ReadToEnd().Trim();

            e.Result =  error=="" ? "0" : error;
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Formmatting will completely erase the drive - are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                btnFormat.Enabled = btnCancel.Enabled = cbDrives.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                lblProgress.Text = "Formatting ";
                lblProgress.Visible = true;
                bgFormatter.RunWorkerAsync(cbDrives.SelectedItem.ToString());
                timer1.Enabled = true;
                this.ControlBox = false;
            }
        }

        private void bgFormatter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Enabled = false;
            lblProgress.Visible = false;

            this.ControlBox = btnFormat.Enabled = btnCancel.Enabled = cbDrives.Enabled = true;
            this.Cursor = Cursors.Default;

            string message = "Formattting Drive " + cbDrives.SelectedItem.ToString() + "\nSuccesful.";

            if ((string)e.Result != "0")
            {
                message = (string)e.Result;
                MessageBox.Show(message, "ERROR: An error occured while formatting the drive.");
            }
            lblProgress.Text = message;
            lblProgress.Visible = true;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProgress.Visible = false;
        }

        private void cbDrives_DropDown(object sender, EventArgs e)
        {
            var initialCount = cbDrives.Items.Count;
            var driveList = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable).ToList();
            if (driveList.Count > 0 && driveList.Count != initialCount)
            {
                cbDrives.DataSource = driveList;
                btnFormat.Enabled = true;
            }
            else if(driveList.Count == 0)
            {
                cbDrives.Visible = false;
                lblSelect.Text = "No Removable Drives Found";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var value = lblProgress.Text.Count(x => x=='.');
            if (value == 3)
            {
                lblProgress.Text = "Formatting ";
            }
            else
            {
                lblProgress.Text += ". ";
            }
        }
    }
}
