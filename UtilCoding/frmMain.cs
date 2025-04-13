using System;
using System.Windows.Forms;

namespace UtilCoding
{

    public partial class frmMain : Form
    {
        ContextMenu contextMenu = new ContextMenu();

        public frmMain()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            contextMenu.MenuItems.Add("&Replace", new EventHandler(this.Replace_Click));
            contextMenu.MenuItems.Add("&Search", new EventHandler(this.Search_Click));
            contextMenu.MenuItems.Add("&Spliter", new EventHandler(this.Spliter_Click));
            contextMenu.MenuItems.Add("&Database", new EventHandler(this.Database_Click));
            contextMenu.MenuItems.Add("&ApiTest", new EventHandler(this.ApiTest_Click));
            contextMenu.MenuItems.Add("&DeleteFolder", new EventHandler(this.DeleteFolder_Click));
            contextMenu.MenuItems.Add("&Exit", new EventHandler(this.Exit_Click));
            notifyIcon1.ContextMenu = contextMenu;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void DeleteFolder_Click(object sender, EventArgs e) {
            frmDeleteFolder f = new frmDeleteFolder();
            f.ShowDialog();
        }


        private void ApiTest_Click(object sender, EventArgs e) 
        {
            frmApiTest f = new frmApiTest();
            f.ShowDialog();
        }

        private void Database_Click(object sender, EventArgs e)
        {
            frmExportDatabase f = new frmExportDatabase();
            f.ShowDialog();
        }

        private void Spliter_Click(object sender, EventArgs e) 
        {
            frmSpliter f = new frmSpliter();
            f.ShowDialog();
        }

        private void Replace_Click(object sender, EventArgs e) 
        {
            FrmReplace f = new FrmReplace();
            f.ShowDialog();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            frmSearch f = new frmSearch();
            f.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
             

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void SendMailTheard()
        {
            //ThreadStart _tsSend = delegate { SendEmail(); };
            //Thread tSend = new Thread(_tsSend);
            //tSend.Name = "SendReporte";
            //tSend.Start();
        }

    }
}