using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FloatButton
{
    public partial class frmExecuteQuery : Form
    {
        public frmExecuteQuery()
        {
            InitializeComponent();
        }

        private void frmExecuteQuery_Load(object sender, EventArgs e)
        {
            this.btnExecuteQuery.Text = ConfigurationManager.AppSettings["TextButton"].ToString();
        }


        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {

                string batDir = Path.GetFullPath(ConfigurationManager.AppSettings["FilePathQuery"].ToString());
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = ConfigurationManager.AppSettings["FileName"].ToString();
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

    }
}
