namespace MEM_CALC_R00
{
    partial class HVAC : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HVAC()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCombinar = this.Factory.CreateRibbonTab();
            this.groupDestino = this.Factory.CreateRibbonGroup();
            this.btnImportDesign = this.Factory.CreateRibbonButton();
            this.cbxDesignList = this.Factory.CreateRibbonComboBox();
            this.btnDataViewer = this.Factory.CreateRibbonButton();
            this.tabCombinar.SuspendLayout();
            this.groupDestino.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCombinar
            // 
            this.tabCombinar.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabCombinar.Groups.Add(this.groupDestino);
            this.tabCombinar.Label = "Combinar";
            this.tabCombinar.Name = "tabCombinar";
            // 
            // groupDestino
            // 
            this.groupDestino.Items.Add(this.btnImportDesign);
            this.groupDestino.Items.Add(this.cbxDesignList);
            this.groupDestino.Items.Add(this.btnDataViewer);
            this.groupDestino.Label = "Destino";
            this.groupDestino.Name = "groupDestino";
            // 
            // btnImportDesign
            // 
            this.btnImportDesign.Label = "Importar diseño...";
            this.btnImportDesign.Name = "btnImportDesign";
            this.btnImportDesign.ShowImage = true;
            this.btnImportDesign.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportDesign_Click);
            // 
            // cbxDesignList
            // 
            this.cbxDesignList.Label = "Vincular diseño";
            this.cbxDesignList.Name = "cbxDesignList";
            this.cbxDesignList.ShowImage = true;
            this.cbxDesignList.Text = null;
            this.cbxDesignList.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cbxDesignList_TextChanged);
            // 
            // btnDataViewer
            // 
            this.btnDataViewer.Label = "Ver datos...";
            this.btnDataViewer.Name = "btnDataViewer";
            this.btnDataViewer.ShowImage = true;
            this.btnDataViewer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDataViewer_Click);
            // 
            // HVAC
            // 
            this.Name = "HVAC";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabCombinar);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CustomRibbon_Load);
            this.tabCombinar.ResumeLayout(false);
            this.tabCombinar.PerformLayout();
            this.groupDestino.ResumeLayout(false);
            this.groupDestino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabCombinar;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupDestino;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDataViewer;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox cbxDesignList;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportDesign;
    }

    partial class ThisRibbonCollection
    {
        internal HVAC CustomRibbon
        {
            get { return this.GetRibbon<HVAC>(); }
        }
    }
}
