﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_VTHP.BaoCao
{
    public partial class frmBaoCaoBangCapChungChi : Form
    {
        public frmBaoCaoBangCapChungChi()
        {
            InitializeComponent();
        }
        protected void LoadBaoCao()
        {
            try
            {
                BaoCaoBangCapChungChi reports = new BaoCaoBangCapChungChi(cmbTenBoPhan.Text, cmbTenBoPhan.SelectedValue.ToString());
                reports.Parameters["BoPhanID"].Value = cmbTenBoPhan.SelectedValue.ToString();
                documentViewer1.DocumentSource = reports;
                reports.CreateDocument();
            }
            catch (Exception)
            {

            }
        }

        private void cmbTenBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void frmBaoCaoBangCapChungChi_Load(object sender, EventArgs e)
        {
            LoadBaoCao();
            string sql = "select *from BoPhan";
            DataTable dt = Core.Core.GetData(sql);
            cmbTenBoPhan.DataSource = dt;
            cmbTenBoPhan.ValueMember = "BoPhanID";
            cmbTenBoPhan.DisplayMember = "TenBoPhan";
        }
    }
}
