using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
namespace MEM_CALC_R00
{
    public partial class HVAC
    {
        private void CustomRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            string designFile = String.Empty;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult.ToString() == "OK")
            {
                designFile = openFileDialog.FileName.ToString(); 
            }
            // Create connection string variable. Modify the "Data Source"
            // parameter as appropriate for your environment.
            String sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + designFile + ";Extended Properties=Excel 8.0;";

            //Provider = Microsoft.ACE.OLEDB.12.0; Data Source = c:\myFolder\myOldExcelFile.xls;
            //Extended Properties = "Excel 8.0;HDR=YES";

            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand("SELECT [Nombre (Razón social)] as RazonSocial FROM [RazonSocial] WHERE 1 = 1 AND [Nombre (Razón social)] IS NOT NULL", objConn);
            OleDbDataAdapter objAdapter = new OleDbDataAdapter();
            objAdapter.SelectCommand = objCmdSelect;
            DataTable dataTable = new DataTable();
            objAdapter.Fill(dataTable);
            FrmDataViewer frmDataViewer = new FrmDataViewer();
            DataGridView dgv = frmDataViewer.Controls.Find("dgdDataViewer", false).FirstOrDefault() as DataGridView;
            dgv.DataSource = dataTable;
            frmDataViewer.Show(); 
            objConn.Close();
            Globals.ThisDocument.ptcctrlRazonSocialCliente.Range.Text = dataTable.Rows[0]["RazonSocial"].ToString(); 
        }


    }
}
