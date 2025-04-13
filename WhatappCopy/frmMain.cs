using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace WhatappCopy
{
    public partial class frmMain : Form
    {
        private ContextMenu contextMenu = new ContextMenu();

        public frmMain()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(frmMain_SizeChanged);
            contextMenu.MenuItems.Add("&Exit", new EventHandler(this.Exit_Click));
            notifyIcon1.ContextMenu = contextMenu;
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sPathStorage = string.Empty;
            string sPathLocal = string.Empty;
            string sTypeCopy = string.Empty;
            string sExcludePhone = string.Empty;
            List<string> lExcludePhone = new List<string>();
            int iTimeSecondRefresh = 0;

            sPathStorage = ConfigurationManager.AppSettings["WhatApp.PathStorage"].ToString();
            sPathLocal = ConfigurationManager.AppSettings["WhatApp.PathLocal"].ToString();
            sTypeCopy = ConfigurationManager.AppSettings["WhatApp.TypeCopy"].ToString();
            iTimeSecondRefresh = int.Parse(ConfigurationManager.AppSettings["WhatApp.TimeSecondRefresh"].ToString()) * 1000;
            sExcludePhone = ConfigurationManager.AppSettings["WhatApp.ExcludePhones"].ToString();
            lExcludePhone = sExcludePhone.Split(',').ToList();
            try
            {
                WhatAppCopy.Instance.Copy(sPathStorage, sPathLocal, sTypeCopy, lExcludePhone);
            }
            catch { }
        }
    }
}
