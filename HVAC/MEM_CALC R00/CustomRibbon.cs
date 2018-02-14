using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Interop.Word; 

namespace MEM_CALC_R00
{
    public partial class HVAC
    {
        DataSet dataSet;

        private void CustomRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            dataSet = new DataSet();
            dataSet.Tables.Add("Cliente");
            dataSet.Tables["Cliente"].Columns.Add("Id", System.Type.GetType("System.Int32"));
            dataSet.Tables["Cliente"].Columns.Add("RazonSocialCliente", System.Type.GetType("System.String"));
            dataSet.Tables["Cliente"].Columns.Add("AreaCliente", System.Type.GetType("System.String"));
            dataSet.Tables["Cliente"].Columns.Add("RFCCliente", System.Type.GetType("System.String"));
            dataSet.Tables["Cliente"].PrimaryKey = new DataColumn[] { dataSet.Tables["Cliente"].Columns["Id"] };
            //Binding binding2 = new Binding("Text", dataSet, "Cliente.AreaCliente", true);
            //Globals.ThisDocument.ptcctrlAreaCliente.DataBindings.Add(binding2);
        }

        public static OleDbDataAdapter CreateDataAdapter(string selectCommand, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand, connection);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // Create the Insert, Update and Delete commands.
            adapter.InsertCommand = new OleDbCommand("INSERT INTO Cliente (Id,RazonSocialCliente,AreaCliente,RFCCliente) VALUES (?,?,?)");
            // Create the parameters.
            adapter.InsertCommand.Parameters.Add("@Id", OleDbType.Integer, 0, "Id");
            adapter.InsertCommand.Parameters.Add("@RazonSocialCliente", OleDbType.VarChar, 255, "RazonSocialCliente");
            adapter.InsertCommand.Parameters.Add("@AreaCliente", OleDbType.VarChar, 255, "AreaCliente");
            adapter.InsertCommand.Parameters.Add("@RFCCliente", OleDbType.VarChar, 255, "RFCCliente");
            // Create Update command
            adapter.UpdateCommand = new OleDbCommand("UPDATE Cliente SET RazonSocialCliente=?,AreaCliente=?,RFCCliente=? WHERE Id=?");
            adapter.UpdateCommand.Parameters.Add("@Id", OleDbType.Integer, 0, "Id");
            adapter.UpdateCommand.Parameters.Add("@RazonSocialCliente", OleDbType.Char, 5, "RazonSocialCliente");
            adapter.UpdateCommand.Parameters.Add("@AreaCliente", OleDbType.VarChar, 40, "AreaCliente");
            adapter.UpdateCommand.Parameters.Add("@RFCCliente", OleDbType.VarChar, 40, "RFCCliente");
            //adapter.UpdateCommand.Parameters.Add("@oldCustomerID", OleDbType.Char, 5, "CustomerID").SourceVersion = DataRowVersion.Original;
            return adapter;
        }

        private void btnDataViewer_Click(object sender, RibbonControlEventArgs e)
        {
            FrmDataViewer frmDataViewer = new FrmDataViewer();
            DataGridView dgv = frmDataViewer.Controls.Find("dgdDataViewer", false).FirstOrDefault() as DataGridView;
            dgv.DataSource = dataSet.Tables["Cliente"];
            frmDataViewer.Show();
        }

        private void btnImportDesign_Click(object sender, RibbonControlEventArgs e)
        {
            string sourceFilePath = String.Empty;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult.ToString() == "OK")
            {
                string fileId = ImportDesign(openFileDialog.FileName.ToString());
                ReloadDesignList(fileId);
                LinkDesignToDocument();
            }
        }

        private void cbxDesignList_TextChanged(object sender, RibbonControlEventArgs e)
        {
            LinkDesignToDocument();
        }

        private string ImportDesign(string sourceFilePath)
        {
            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFilePath + ";Extended Properties=Excel 8.0;";
            string fileId = sourceFilePath.GetHashCode().ToString();
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();
            string strCmdSelect = "SELECT " +
                "A.Id,A.RazonSocialCliente,B.AreaCliente,C.RFCCliente " +
                "FROM (SELECT " + fileId + " AS Id,[F1] as RazonSocialCliente FROM [VSRazonSocialCliente] WHERE [F1] IS NOT NULL) A " +
                "LEFT OUTER JOIN (" + 
                "   (SELECT " + fileId + " AS Id,[F1] as AreaCliente FROM [VSAreaCliente] WHERE [F1] IS NOT NULL) B " + 
                "   LEFT OUTER JOIN (" +
                "       (SELECT " + fileId + " AS Id,[F1] as RFCCliente FROM [VSRFCCliente] WHERE [F1] IS NOT NULL) C " + 
                "   ) ON B.Id=C.Id" + 
                ") ON A.Id=B.Id"; 

            OleDbDataAdapter objAdapter = CreateDataAdapter(strCmdSelect, objConn);
            objAdapter.Fill(dataSet, "Cliente");
            objConn.Close();
            return fileId; 
        }

        private string DSSelectValue(string DSTable,int DSIndex,string ControlTag)
        {
            string DSValue = string.Empty; 
            switch (ControlTag)
            {
                case "RazonSocialCliente":
                    DSValue = dataSet.Tables[DSTable].Rows.Find(DSIndex)[ControlTag].ToString();
                    break;
                case "AreaCliente":
                    DSValue = dataSet.Tables[DSTable].Rows.Find(DSIndex)[ControlTag].ToString();
                    break;
            }
            return DSValue; 
        }

        private void LinkDesignToDocument()
        {
            //Change to dataset recordset active row 
            int Id;
            bool tryParseResult = Int32.TryParse(cbxDesignList.Text, out Id);
            if (tryParseResult)
            {
                foreach (Section section in Globals.ThisDocument.Sections)
                {
                    foreach (HeaderFooter header in section.Headers)
                    {
                        foreach (Microsoft.Office.Interop.Word.ContentControl hcc in header.Range.ContentControls)
                        {
                            hcc.Range.Text = DSSelectValue("Cliente",Id,hcc.Tag.ToString()); 
                        }
                    }
                }
                foreach (Microsoft.Office.Interop.Word.ContentControl bcc in Globals.ThisDocument.ContentControls)
                {
                    bcc.Range.Text = DSSelectValue("Cliente", Id, bcc.Tag.ToString());
                }
            }
        }
        private void ReloadDesignList(string fileId)
        {
            cbxDesignList.Items.Clear();
            for (int i = 0; i < dataSet.Tables["Cliente"].Rows.Count; i++)
            {
                RibbonDropDownItem ribbonDropDownItem = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                ribbonDropDownItem.Label = dataSet.Tables["Cliente"].Rows[i]["Id"].ToString();
                cbxDesignList.Items.Add(ribbonDropDownItem);
            }
            cbxDesignList.Text = fileId; 
        }
    }
}
