using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

//This uses the new version 2 translations
namespace FAPI_Inventory_Import
{
    public partial class FrmGrowerCodeTranslation : Form
    {
        DataSet VarietyDataSet = new DataSet();  //Dataset for the commodity's varieties
        DataSet StyleDataSet = new DataSet();  //Dataset for the commodity's style
        DataSet SizeDataSet = new DataSet();  //Dataset for the commodity's Size
        DataTable VarietyTable = new DataTable();  //Holds table of varieties
        DataTable StyleTable = new DataTable();  //Holds table of style
        DataTable SizeTable = new DataTable();  //Holds table of size
        DataTable TranslationTable;  //holds translation information by grower ID
        System.Data.SqlClient.SqlConnection conn;  //connection object for database
        string connString;
        Int32 SelectedRowIDInView;

        //GCV variables
        string GrowerID;
        string GrowerName;
        string CommodityCode = "";
        string CommodityName;
        string GrowerCommodityCode = "";
        string VarietyCode = "";
        string VarietyName;
        string GrowerVarietyCode = "";
        string StoneFruit;
        //string GCV_ID;
        string GCVInfoTable;
        string TranslationDetailsTable;


        //Details variables
        string StyleCode;
        string GrowerStyle;
        string SizeCode;
        string GrowerSize;
        string Packcode = "";
        string GrowerPackcode = "";
        string Grade;
        string GrowerGrade;
        string LabelCode;
        string GrowerLabel;
        string PalletType;
        string GrowerPalletType;


        public FrmGrowerCodeTranslation()
        {
            InitializeComponent();
        }

        private void FrmGrowerCodeTranslation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataPalletType.Famous_Color_Data' table. You can move, or remove it, as needed.
            this.famous_Color_DataTableAdapter.Fill(this.pBIApplicationTablesDataPalletType.Famous_Color_Data);
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataLabel.Famous_Label_Data' table. You can move, or remove it, as needed.
            this.famous_Label_DataTableAdapter.Fill(this.pBIApplicationTablesDataLabel.Famous_Label_Data);
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataGrade.Famous_Grade_Data' table. You can move, or remove it, as needed.
            this.famous_Grade_DataTableAdapter.Fill(this.pBIApplicationTablesDataGrade.Famous_Grade_Data);
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataPackCode.Export_Values' table. You can move, or remove it, as needed.
            this.adams_ValuesTableAdapter.Fill(this.pBIApplicationTablesDataPackCode.Adams_Values);
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataSize.Famous_Size_Data' table. You can move, or remove it, as needed.
            this.famous_Size_DataTableAdapter.Fill(this.pBIApplicationTablesDataSize.Famous_Size_Data);
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataSet3.Famous_Style_Data' table. You can move, or remove it, as needed.
            this.famous_Style_DataTableAdapter.Fill(this.pBIApplicationTablesDataSet3.Famous_Style_Data);
            // TODO: This line of code loads data into the 'pBIApplicationTablesDataSet.Famous_Commodity_Data' table. You can move, or remove it, as needed.
            this.famous_Commodity_DataTableAdapter.Fill(this.pBIApplicationTablesDataSet.Famous_Commodity_Data);
            // TODO: This line of code loads data into the 'pBIApplicationTablesGrowerDataSet.Grower_Name' table. You can move, or remove it, as needed.
            this.grower_NameTableAdapter.Fill(this.pBIApplicationTablesGrowerDataSet.Grower_Name);
            lblGCVCode.Text = "Select/Enter Grower, Commodity and Variety Info";   //changes once the grower, commodity and variety are selected.


            connString = Properties.Settings.Default.ConnectionString;  //get connection string from the application settings
            conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.ConnectionString);  // create connection object

            buttonViewTranslationTable.Enabled = false;
            //Gray out lower controls and text boxes until grower, commmodity and variety are selected.
            cboGrade.Enabled = false;
            cboLabel.Enabled = false;
            cboPackCode.Enabled = false;
            cboPalletType.Enabled = false;
            cboSize.Enabled = false;
            cboStyle.Enabled = false;
            tbGrade.Enabled = false;
            tbLabel.Enabled = false;
            tbPackCode.Enabled = false;
            tbPalletType.Enabled = false;
            tbSize.Enabled = false;
            tbStyle.Enabled = false;
            lblGCVCode.BackColor = Color.Red;

            cboVariety.SelectedItem = null;
            cboCommodity.SelectedItem = null;



            //log Editor in test mode.
            if (Properties.Settings.Default.Mode == "Test")
            {
                lblMode.Text = "Running Editor in test mode";
                Error_Logging el = new Error_Logging("Starting Editor in test mode.");
                lDetailsID.Enabled = true;  //visible only in test mode
                lStoneFruit.Enabled = true;  //visible only in test mode
            }
            else
            {
                lblMode.Text = "";
                lDetailsID.Enabled = false;
                lStoneFruit.Enabled = false;
            }



            if (Properties.Settings.Default.Mode == "Test")
            {
                GCVInfoTable = "GCV_Information_Test2";
                TranslationDetailsTable = "Translation_Details_Test2";
            }
            else
            {
                GCVInfoTable = "GCV_Information2";
                TranslationDetailsTable = "Translation_Details2";
            }


            dgvTranslations.Visible = false;


        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCommodity_SelectedIndexChanged(object sender, EventArgs e)  // Method for when Commodity is selected.
        {
           
            if (cboCommodity.SelectedValue != null)  // only if selected value is not null
            {
                try
                {
                    //get Variety data from database
                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlDataAdapter VarietyDataAdaptor;
                    SqlCommand Command = new SqlCommand();
                    SqlParameter ParamCommodity;  //Parameter to pass commodity to GetVarietiesForCommodity sp

                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);

                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.CommandText = "GetVarietiesForCommodity";   // Stored procedure to get all Famous varieties for this commodity
                    ParamCommodity = new SqlParameter("@Commodity", cboCommodity.SelectedValue.ToString());
                    ParamCommodity.Direction = ParameterDirection.Input;
                    ParamCommodity.DbType = DbType.String;
                    Command.Parameters.Add(ParamCommodity);

                    VarietyDataSet = new DataSet();

                    // create data adapter
                    VarietyDataAdaptor = new System.Data.SqlClient.SqlDataAdapter(Command);
                    // this will query the database and return the result to your datatable
                    VarietyDataAdaptor.Fill(VarietyDataSet);
                    conn.Close();
                    VarietyDataAdaptor.Dispose();
                    VarietyTable = new DataTable(); // table of varities for the selected commodity
                    if (VarietyDataSet.Tables[0] != null)
                    {
                        VarietyTable = VarietyDataSet.Tables[0];  //set the variety table
                    }
                    VarietyDataSet.Dispose();
                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to load the variety table.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to load the variety Table. \n" + exp);
                    VarietyDataSet.Dispose();
                    //return false;
                }

                try   //Get the style info and fill the table
                {
                    //get Style data from database
                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlDataAdapter StyleDataAdaptor;
                    SqlCommand Command = new SqlCommand();
                    SqlParameter ParamCommodity;  //Parameter to pass commodity to GetStyleForCommodity sp

                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);

                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.CommandText = "GetStyleForCommodity";   // Stored procedure to get all Famous styles for this commodity
                    ParamCommodity = new SqlParameter("@Commodity", cboCommodity.SelectedValue.ToString());
                    ParamCommodity.Direction = ParameterDirection.Input;
                    ParamCommodity.DbType = DbType.String;
                    Command.Parameters.Add(ParamCommodity);

                    StyleDataSet = new DataSet();

                    // create data adapter
                    StyleDataAdaptor = new System.Data.SqlClient.SqlDataAdapter(Command);
                    // this will query the database and return the result to your datatable
                    StyleDataAdaptor.Fill(StyleDataSet);
                    conn.Close();
                    StyleDataAdaptor.Dispose();
                    StyleTable = new DataTable(); // table of styles for the selected commodity
                    if (StyleDataSet.Tables[0] != null)
                    {
                        StyleTable = StyleDataSet.Tables[0];  //set the style table
                    }
                    StyleDataSet.Dispose();
                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to load the Style table.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to load the Style Table. \n" + exp);
                    StyleDataSet.Dispose();
                    //return false;
                }


                try   //Get the size info and fill the table
                {
                    //get Size data from database
                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlDataAdapter SizeDataAdaptor;
                    SqlCommand Command = new SqlCommand();
                    SqlParameter ParamCommodity;  //Parameter to pass commodity to GetizeForCommodity sp

                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);

                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.CommandText = "GetSizeForCommodity";   // Stored procedure to get all Famous sizes for this commodity
                    ParamCommodity = new SqlParameter("@Commodity", cboCommodity.SelectedValue.ToString());
                    ParamCommodity.Direction = ParameterDirection.Input;
                    ParamCommodity.DbType = DbType.String;
                    Command.Parameters.Add(ParamCommodity);

                    SizeDataSet = new DataSet();

                    // create data adapter
                    SizeDataAdaptor = new System.Data.SqlClient.SqlDataAdapter(Command);
                    // this will query the database and return the result to your datatable
                    SizeDataAdaptor.Fill(SizeDataSet);
                    conn.Close();
                    SizeDataAdaptor.Dispose();
                    SizeTable = new DataTable(); // table of styles for the selected commodity
                    if (SizeDataSet.Tables[0] != null)
                    {
                        SizeTable = SizeDataSet.Tables[0];  //set the style table
                    }
                    SizeDataSet.Dispose();
                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to load the Size table.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to load the Size Table. \n" + exp);
                    StyleDataSet.Dispose();
                    //return false;
                }


                // populate the Variety combobox
                if ((VarietyTable != null) & VarietyTable.Rows.Count > 0)  //must have varieties
                {
                    cboVariety.DataSource = VarietyTable;
                    cboVariety.DisplayMember = "Variety_Name";
                    cboVariety.ValueMember = "Variety_Code";
                    cboVariety.SelectedItem = null;
                }


                // populate the Style combobox
                if ((StyleTable != null) & StyleTable.Rows.Count > 0)  //must have Styles
                {
                    cboStyle.DataSource = StyleTable;
                    cboStyle.DisplayMember = "Style_Code";
                    cboStyle.ValueMember = "Style_Code";
                }

                // populate the Size combobox
                if ((SizeTable != null) & SizeTable.Rows.Count > 0)  //must have Sizes
                {
                    cboSize.DataSource = SizeTable;
                    cboSize.DisplayMember = "Size_Code";
                    cboSize.ValueMember = "Size_Code";
                }


                if (cboCommodity.SelectedValue != null)  // Set the commodity and commodity code if valid select item in CBO
                {
                    CommodityName = cboCommodity.Text.ToString();
                    CommodityCode = cboCommodity.SelectedValue.ToString();
                    StoneFruit = VarietyTable.Rows[0][4].ToString();
                    lStoneFruit.Text = "Is Stone Fruit? " + StoneFruit;


                    DataRow[] CommodityRows = TranslationTable.Select("Commodity_Code = '" + CommodityCode + "'");    //Set export value
                   
                }




            }
            /*
            if (TranslationTable != null)  // check if null, in the case where edit is cancelled with no selections.
            {
                if (TranslationTable.Select("Commodity_Code = '" + CommodityCode + "'").Count() > 0) //Is commodity in tranlation table
                {                                                                        // If so, find and set the grower commodity code
                    tbGrowerCommodityCode.Text = TranslationTable.Select("Commodity_Code = '" + CommodityCode + "'")[0][2].ToString();
                    GrowerCommodityCode = tbGrowerCommodityCode.Text;   // Setting grower commodity code variable

                }
            }
            */

        }

        private void cboGrower_SelectedIndexChanged(object sender, EventArgs e)   //  Method for when grower is selected.
        {
            if (cboGrower.SelectedValue != null)  // Grower ID must be non null
            {
                GrowerName = cboGrower.Text.ToString();  // Set Grower name variable
                GrowerID = cboGrower.SelectedValue.ToString();  // Set Grower ID variable


                try
                {
                    //get current Translation data from database for this grower from the GCV_data and Details tables
                    connString = Properties.Settings.Default.ConnectionString;
                    string query =
                        "SELECT Grower_Name, Grower_Commodity_Code, Commodity_Code, Commodity, Grower_Variety_Code, " +
                        "Variety_Code, Variety,  Grower_Style_Code, " +
                            "Famous_Style_Code, Grower_Size_Code, Famous_Size_Code, Grower_Pack_Code, " +
                            "Famous_Pack_Code, Grower_Label_Code, Famous_Label_Code, " +
                            "Grower_Grade_Code, Famous_Grade_Code, " +
                            "Grower_Pallet_Type, Famous_Pallet_Type, " +
                            "Grower_ID,  Stone_Fruit, " + GCVInfoTable.ToString() + ".GCV_Code " +
                        "FROM " + GCVInfoTable.ToString() + " INNER JOIN " + TranslationDetailsTable.ToString() +
                            " ON " + GCVInfoTable.ToString() + ".GCV_Code = " + TranslationDetailsTable.ToString() + ".GCV_Code " +
                         "WHERE " + GCVInfoTable.ToString() + ".Grower_ID = " + GrowerID.ToString(); // Form translation table for grower from the ;
                    // GCV_Info and Translation_Detail tables.
                    conn = new System.Data.SqlClient.SqlConnection(connString);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                    conn.Open();

                    DataSet translationDataSet = new DataSet();  // Dataset holds all current translation data for the selected grower
                    // create data adapter
                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    // this will query the database and return the result to the datatable
                    da.Fill(translationDataSet);
                    conn.Close();
                    da.Dispose();
                    TranslationTable = translationDataSet.Tables[0];  // Fill the translationTable with the groweres current translatin data
                    translationDataSet.Dispose();

                    buttonViewTranslationTable.Enabled = true;  // Now that there is data in the TranslationTable, the Translation view buttion is active


                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to create and load the translation data in editor.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to create and load translation data in editor. \n" + exp);
                    //ds.Dispose();
                    return;
                }

            }
        }

        private void cboVariety_SelectedIndexChanged(object sender, EventArgs e)  // Method for when the Variety is selected.
        {
            if (cboVariety.SelectedValue != null)  // Value of selected value must not be null
            {
                VarietyName = cboVariety.Text.ToString();  // Set Varitety Name Variable
                VarietyCode = cboVariety.SelectedValue.ToString();  // Set Variety Code Variable
                CommodityName = cboCommodity.Text.ToString();
                CommodityCode = cboCommodity.SelectedValue.ToString();
                StoneFruit = VarietyTable.Rows[0][4].ToString();
                lStoneFruit.Text = "Is Stone Fruit? " + StoneFruit;

                GrowerVarietyCode = UppercaseWords.Uppercase(tbGrowerVarietyCode.Text);
                //tbGrowerVarietyCode.Text = GrowerVarietyCode;
                GrowerCommodityCode = UppercaseWords.Uppercase(tbGrowerCommodityCode.Text);
                //tbGrowerCommodityCode.Text = GrowerCommodityCode;

                if (GrowerID != null & CommodityCode.ToString().Length > 2 & VarietyCode.ToString().Length > 2 &
                GrowerVarietyCode.ToString().Length > 2 & GrowerCommodityCode.ToString().Length > 2 
                & VarietyCode != "System.Data.DataRowView")
                {
                    lblGCVCode.Text = GrowerID.ToString() + "-"
                            + CommodityCode.ToString() + "-" + GrowerCommodityCode.ToString() +
                            "-" + VarietyCode.ToString() + "-" + GrowerVarietyCode.ToString();   // Set the GCV Code variable

                    //Once variety has been selected then enable remaining controls
                    cboGrade.Enabled = true;
                    cboLabel.Enabled = true;
                    cboPackCode.Enabled = true;
                    cboPalletType.Enabled = true;
                    cboSize.Enabled = true;
                    cboStyle.Enabled = true;
                    tbGrade.Enabled = true;
                    tbLabel.Enabled = true;
                    tbPackCode.Enabled = true;
                    tbPalletType.Enabled = true;
                    tbSize.Enabled = true;
                    tbStyle.Enabled = true;
                    lblGCVCode.BackColor = Color.LightGreen;

                    cboPalletType.SelectedValue = "HT Wood";  // Make HT Wood default
                    tbPalletType.Text = "HT Wood";



                }
                if (VarietyCode != null & VarietyCode != "System.Data.DataRowView")
                {

                    DataRow[] VarietyRows = TranslationTable.Select("Variety_Code = '" + VarietyCode + "'");
            

                    if (TranslationTable.Select("Variety_Code = '" + VarietyCode + "'").Count() > 0) //Is the variety in tranlation table
                    {                                                                               // if so, set the grower Variety code
                        
                        tbGrowerVarietyCode.Text = TranslationTable.Select("Variety_Code = '" + VarietyCode + "'")[0][7].ToString();
                        GrowerVarietyCode = tbGrowerVarietyCode.Text;  // Set grower variety code variable

                       

                        //enable other controls
                        cboGrade.Enabled = true;
                        cboLabel.Enabled = true;
                        cboPackCode.Enabled = true;
                        cboPalletType.Enabled = true;
                        cboSize.Enabled = true;
                        cboStyle.Enabled = true;
                        tbGrade.Enabled = true;
                        tbLabel.Enabled = true;
                        tbPackCode.Enabled = true;
                        tbPalletType.Enabled = true;
                        tbSize.Enabled = true;
                        tbStyle.Enabled = true;
                        lblGCVCode.BackColor = Color.LightGreen;


                        cboPalletType.SelectedValue = "HT Wood";  // Make HT Wood default
                        tbPalletType.Text = "HT Wood";

                    }
                }


            }
        }
        // Set translation details vartiables if editor values change
        private void tbGrowerCommodityCode_TextChanged(object sender, EventArgs e)
        {
             // set the grower commodity variable
            //GrowerVarietyCode = UppercaseWords.Uppercase(tbGrowerVarietyCode.Text);     
            GrowerCommodityCode = UppercaseWords.Uppercase(tbGrowerCommodityCode.Text);
            DataRow[] CommodityRows = TranslationTable.Select("Commodity_Code = '" + CommodityCode + "'");
            

            if (GrowerID != null & CommodityCode.ToString().Length > 2 & VarietyCode.ToString().Length > 2 &
                GrowerVarietyCode.ToString().Length > 2 & GrowerCommodityCode.ToString().Length > 2 
                & VarietyCode != "System.Data.DataRowView")
            {
                //GrowerCommodityCode = UppercaseWords.Uppercase(GrowerCommodityCode.ToString());
                //GrowerVarietyCode = UppercaseWords.Uppercase(GrowerVarietyCode.ToString());
                //tbGrowerCommodityCode.Text = GrowerCommodityCode;
                //tbGrowerVarietyCode.Text = GrowerVarietyCode;
                lblGCVCode.Text = GrowerID.ToString() + "-"
                        + CommodityCode.ToString() + "-" + GrowerCommodityCode +
                        "-" + VarietyCode.ToString() + "-" + GrowerVarietyCode;   // Set the GCV Code variable


                //Once variety has been selected then enable remaining controls
                cboGrade.Enabled = true;
                cboLabel.Enabled = true;
                cboPackCode.Enabled = true;
                cboPalletType.Enabled = true;
                cboSize.Enabled = true;
                cboStyle.Enabled = true;
                tbGrade.Enabled = true;
                tbLabel.Enabled = true;
                tbPackCode.Enabled = true;
                tbPalletType.Enabled = true;
                tbSize.Enabled = true;
                tbStyle.Enabled = true;
                lblGCVCode.BackColor = Color.LightGreen;


                cboPalletType.SelectedValue = "HT Wood";  // Make HT Wood default
                tbPalletType.Text = "HT Wood";

                //tbGrowerVarietyCode.Text = GrowerVarietyCode;
                //tbGrowerCommodityCode.Text = GrowerCommodityCode;

            }
        }

        private void tbGrowerVarietyCode_TextChanged(object sender, EventArgs e)
        {
            GrowerVarietyCode = UppercaseWords.Uppercase(tbGrowerVarietyCode.Text);  // set the grower variety variable
            if (GrowerID != null & CommodityCode.ToString().Length > 2 & VarietyCode.ToString().Length > 2 &
                GrowerVarietyCode.ToString().Length > 2 & GrowerCommodityCode.ToString().Length > 2 
                & VarietyCode != "System.Data.DataRowView")
            {
                //GrowerCommodityCode = UppercaseWords.Uppercase(GrowerCommodityCode.ToString());
                //GrowerVarietyCode = UppercaseWords.Uppercase(GrowerVarietyCode.ToString());
                //tbGrowerCommodityCode.Text = GrowerCommodityCode;
                
                lblGCVCode.Text = GrowerID.ToString() + "-"
                        + CommodityCode.ToString() + "-" + GrowerCommodityCode +
                        "-" + VarietyCode.ToString() + "-" + GrowerVarietyCode;   // Set the GCV Code variable




                //Once variety has been selected then enable remaining controls
                cboGrade.Enabled = true;
                cboLabel.Enabled = true;
                cboPackCode.Enabled = true;
                cboPalletType.Enabled = true;
                cboSize.Enabled = true;
                cboStyle.Enabled = true;
                tbGrade.Enabled = true;
                tbLabel.Enabled = true;
                tbPackCode.Enabled = true;
                tbPalletType.Enabled = true;
                tbSize.Enabled = true;
                tbStyle.Enabled = true;
                lblGCVCode.BackColor = Color.LightGreen;


                cboPalletType.SelectedValue = "HT Wood";  // Make HT Wood default
                tbPalletType.Text = "HT Wood";


            }
        }

        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStyle.SelectedValue != null)
            {
                if (cboStyle.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    StyleCode = cboStyle.SelectedValue.ToString();  // set the style variable

                    tbGrowerVarietyCode.Text = GrowerVarietyCode;
                    tbGrowerCommodityCode.Text = GrowerCommodityCode;
                }
                else
                {
                    StyleCode = "";
                }
            }
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSize.SelectedValue != null)
            {
                if (cboStyle.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    SizeCode = cboSize.SelectedValue.ToString();  // Set size code variable

                    tbGrowerVarietyCode.Text = GrowerVarietyCode;
                    tbGrowerCommodityCode.Text = GrowerCommodityCode;
                }
                else
                {
                    SizeCode = "";
                }
            }
        }

        private void cboPackCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPackCode.SelectedValue != null)
            {
                Packcode = cboPackCode.SelectedValue.ToString();  // set packcode variable
                tbPackCode.Text = Packcode;

                tbGrowerVarietyCode.Text = GrowerVarietyCode;
                tbGrowerCommodityCode.Text = GrowerCommodityCode;
            }

        }

        private void tbStyle_TextChanged(object sender, EventArgs e)
        {
            if (tbStyle.Text != null)
            {
                GrowerStyle = tbStyle.Text;  // set grower style variable
            }
        }

        private void tbSize_TextChanged(object sender, EventArgs e)
        {
            if (tbSize.Text != null)
            {
                GrowerSize = tbSize.Text;  //set grower size variable
            }
        }

        private void tbPackCode_TextChanged(object sender, EventArgs e)
        {
            if (tbPackCode.Text != null)
            {
                GrowerPackcode = tbPackCode.Text;  //Set grower packocde variable
            }
        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrade.SelectedValue != null)
            {
                Grade = cboGrade.SelectedValue.ToString();  //set grade variable
                tbGrade.Text = Grade;
            }
        }

        private void cboLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLabel.SelectedValue != null)
            {
                LabelCode = cboLabel.SelectedValue.ToString();  //set label variable
                tbLabel.Text = LabelCode;
            }
        }

        private void cboPalletType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPalletType.SelectedValue != null)
            {
                PalletType = cboPalletType.SelectedValue.ToString();  // set pallet type variable
                tbPalletType.Text = PalletType;
            }
        }

        private void tbGrade_TextChanged(object sender, EventArgs e)
        {
            if (tbGrade.Text != null)
            {
                GrowerGrade = tbGrade.Text;  // set grower grade variable
            }
        }

        private void tbLabel_TextChanged(object sender, EventArgs e)
        {
            if (tbLabel.Text != null)
            {
                GrowerLabel = UppercaseWords.Uppercase(tbLabel.Text);  // set grower label variable
            }
        }

        private void tbPalletType_TextChanged(object sender, EventArgs e)
        {
            if (tbPalletType.Text != null & cboPalletType.SelectedValue != null)
            {
                GrowerPalletType = UppercaseWords.Uppercase(tbPalletType.Text);  // set grower pallet type variable
            }
        }


        private bool SaveChanges()  // Method for saving changes or new translations to database
        {
            StringBuilder notSelectedError = new StringBuilder();  //list to hold the name of dropdowns/variables and text boxes not populated
            //for error message box
            if (String.IsNullOrEmpty(GrowerID))
            {
                notSelectedError.Append("Grower, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(CommodityCode) || CommodityCode == "System.Data.DataRowView")
            {
                notSelectedError.Append("Commodity, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(VarietyCode) || VarietyCode == "System.Data.DataRowView")
            {
                notSelectedError.Append("Variety, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(StyleCode) || StyleCode == "System.Data.DataRowView")
            {
                notSelectedError.Append("Style, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(GrowerStyle) & String.IsNullOrEmpty(GrowerPackcode))
            {
                notSelectedError.Append("Grower Style, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(SizeCode) || SizeCode == "System.Data.DataRowView")
            {
                notSelectedError.Append("Size, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(GrowerSize) & String.IsNullOrEmpty(GrowerPackcode))
            {
                notSelectedError.Append("Grower Size, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(Packcode) & String.IsNullOrEmpty(StyleCode) & String.IsNullOrEmpty(SizeCode) & String.IsNullOrEmpty(GrowerPackcode))
            {
                notSelectedError.Append("Pack Code, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(GrowerPackcode) & String.IsNullOrEmpty(GrowerStyle) & String.IsNullOrEmpty(GrowerSize))
            {
                notSelectedError.Append("Grower Pack Code, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(Grade) & StoneFruit == "N")
            {
                notSelectedError.Append("Grade, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(GrowerGrade) & StoneFruit == "N")
            {
                notSelectedError.Append("Grower Grade, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(LabelCode))
            {
                notSelectedError.Append("Label, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(GrowerLabel))
            {
                notSelectedError.Append("Grower Label, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(PalletType))
            {
                notSelectedError.Append("Pallet Type, ");  //add to not selected list
            }
            if (String.IsNullOrEmpty(GrowerPalletType))
            {
                // GrowerPalletType = "HT Wood";
                notSelectedError.Append("Grower Pallet Type, ");  //add to not selected list
            }
            if (lblGCVCode.Text == "Select/Enter Grower, Commodity and Variety Info" || lblGCVCode.Text.Length < 5)
            {
                notSelectedError.Append("No GCV Code was generated, ");
                Error_Logging el = new Error_Logging("No GCV Code was generated for grower " + GrowerName);
            }


            if (StoneFruit == "Y")  //special case for stone/berry fruit.   Grade is not used
            {
                Grade = "";
                GrowerGrade = "";
            }


            //set Grower Style and Size to blank if there is a grower PackCode and they are null or 
            //set packcode to blank if Style and Size are null
            if (String.IsNullOrEmpty(GrowerStyle) & !String.IsNullOrEmpty(GrowerPackcode))
            {
                GrowerStyle = "";
            }

            if (String.IsNullOrEmpty(GrowerSize) & !String.IsNullOrEmpty(GrowerPackcode))
            {
                GrowerSize = "";
            }

            if (String.IsNullOrEmpty(GrowerPackcode) & !String.IsNullOrEmpty(GrowerStyle) & !String.IsNullOrEmpty(GrowerSize))
            {
                GrowerPackcode = "";
            }


            tbGrowerVarietyCode.Text = GrowerVarietyCode;
            tbGrowerCommodityCode.Text = GrowerCommodityCode;



            if (notSelectedError.Length == 0)  //if it is 0 then all dropdowns have been selected and complete export process
            {
                try
                {
                    //Update or add the translation data to GCV-Information and Translation_Details tables
                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlCommand Command = new SqlCommand();

                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);

                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;
                    if (Properties.Settings.Default.Mode == "Test")
                    {
                        Command.CommandText = "UpdateGCV_InfoandTranslationDetailsTest2";
                    }
                    else
                    {
                        Command.CommandText = "UpdateGCV_InfoandTranslationDetails2";
                    }
                    //parameter and data to save
                    Command.Parameters.Add(new SqlParameter("@GrowerName", UppercaseWords.Uppercase(GrowerName)));  //converted to First-Letter-Uppercase
                    Command.Parameters.Add(new SqlParameter("@GrowerID", GrowerID));
                    Command.Parameters.Add(new SqlParameter("@CommodityName", CommodityName));
                    Command.Parameters.Add(new SqlParameter("@CommodityCode", CommodityCode));
                    Command.Parameters.Add(new SqlParameter("@GrowerCommodityCode", UppercaseWords.Uppercase(GrowerCommodityCode)));  //converted to First-Letter-Uppercase
                    Command.Parameters.Add(new SqlParameter("@VarietyName", VarietyName));
                    Command.Parameters.Add(new SqlParameter("@VarietyCode", VarietyCode));
                    Command.Parameters.Add(new SqlParameter("@GrowerVarietyCode", UppercaseWords.Uppercase(GrowerVarietyCode)));  //converted to First-Letter-Uppercase
                    Command.Parameters.Add(new SqlParameter("@StoneFruit", StoneFruit));
                    Command.Parameters.Add(new SqlParameter("@GCV_ID", lblGCVCode.Text));
                    Command.Parameters.Add(new SqlParameter("@Style", StyleCode));
                    Command.Parameters.Add(new SqlParameter("@GrowerStyle", GrowerStyle.ToUpper()));
                    Command.Parameters.Add(new SqlParameter("@Size", SizeCode));
                    Command.Parameters.Add(new SqlParameter("@GrowerSize", GrowerSize.ToUpper()));
                    Command.Parameters.Add(new SqlParameter("@Packcode", Packcode));
                    Command.Parameters.Add(new SqlParameter("@GrowerPackcode", GrowerPackcode));
                    Command.Parameters.Add(new SqlParameter("@Grade", Grade));
                    Command.Parameters.Add(new SqlParameter("@GrowerGrade", GrowerGrade.ToUpper()));
                    Command.Parameters.Add(new SqlParameter("@Label", LabelCode));
                    Command.Parameters.Add(new SqlParameter("@GrowerLabel", UppercaseWords.Uppercase(GrowerLabel)));  //converted to First-Letter-Uppercase
                    Command.Parameters.Add(new SqlParameter("@PalletType", PalletType));
                    Command.Parameters.Add(new SqlParameter("@GrowerPalletType", UppercaseWords.Uppercase(GrowerPalletType)));  //converted to First-Letter-Uppercase

                    Command.ExecuteNonQuery();  //run the stored procedure on the SQL server


                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to save translation data.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to save translation data. \n" + exp);
                    VarietyDataSet.Dispose();
                    return false;
                }

                return true;
            }

            else  //not all required dropdowns or text boxes selected or filled out.
            {
                MessageBox.Show("Please fill out or select the following parameters: " + notSelectedError
                    + " and try saving again.");
                return false;
            }

        }

        private void bSave_Click(object sender, EventArgs e)  // Save button pushed.
        {
            if (SaveChanges())  //SaveChanges returns true if there were no errors in the SaveChanges method
            {
                MessageBox.Show("Changes Saved");
                RefreshDataGridView(); //refresh and show changes in the grid view
            }
            else
            {
                MessageBox.Show("Changes not saved");
            }
        }

        private void bSaveExit_Click(object sender, EventArgs e)  // Exit putton pushed
        {
            if (SaveChanges())
            {
                MessageBox.Show("Changes saved and closing window");  // Let the user know the changes/additions were saved
                this.Close();
            }

        }

        private void buttonViewTranslationTable_Click(object sender, EventArgs e)
        {
            //refresh view of translation table

            RefreshDataGridView();
        }

        private void RefreshDataGridView()  //Method to get the data and refresh the Datagridview from the database tables.
        {
            try
            {
                //get current translation data from database
                string connString = Properties.Settings.Default.ConnectionString;
                string query =
                    "SELECT  Grower_Name, Grower_Commodity_Code, Commodity_Code, Commodity, " +
                    "Grower_Variety_Code, Variety_Code, Variety, Grower_Style_Code, " +
                        "Famous_Style_Code, Grower_Size_Code, Famous_Size_Code, Grower_Pack_Code, " +
                        "Famous_Pack_Code, Grower_Label_Code, Famous_Label_Code, " +
                        "Grower_Grade_Code, Famous_Grade_Code, " +
                        "Grower_Pallet_Type, Famous_Pallet_Type, " +
                        "Grower_ID, Stone_Fruit, " + GCVInfoTable.ToString() + ".GCV_Code, Translation_Details_ID " +
                    "FROM " + GCVInfoTable.ToString() + " INNER JOIN " + TranslationDetailsTable.ToString() +
                        " ON " + GCVInfoTable.ToString() + ".GCV_Code = " + TranslationDetailsTable.ToString() + ".GCV_Code " +
                     "WHERE " + GCVInfoTable.ToString() + ".Grower_ID = " + GrowerID.ToString(); // Form translation table for grower;

                conn = new System.Data.SqlClient.SqlConnection(connString);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                conn.Open();

                DataSet translationDataSet = new DataSet();
                // create data adapter
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                // this will query the database and return the result to the datatable
                da.Fill(translationDataSet);
                conn.Close();
                da.Dispose();
                TranslationTable = translationDataSet.Tables[0];  //set the translation table
                translationDataSet.Dispose();
            }

            catch (Exception exp)
            {
                MessageBox.Show("There was an error while trying to refresh the view table in editor.  \n" +
                 " Note what happened and contact administrator for help or see error log.  \n");
                Error_Logging el = new Error_Logging("There was an error while trying to refresh the view table in editor. \n" + exp);
                //ds.Dispose();
                return;
            }
            dgvTranslations.Visible = true;
            dgvTranslations.DataSource = TranslationTable;  // Put the data into the data grid view.
        }

        private void dgvTranslations_SelectionChanged(object sender, EventArgs e)  //Gets the ID of the selected row
        {
            if (dgvTranslations.Visible == true)  //if the view table is visible, enable the edit/delete buttons
            {
                bDelete.Enabled = true;
                bEdit.Enabled = true;
            }
            if (dgvTranslations.SelectedCells.Count > 0) //get the row id from selected row.
            {
                int selectedrowindex = dgvTranslations.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvTranslations.Rows[selectedrowindex];

                SelectedRowIDInView = Convert.ToInt32(selectedRow.Cells["Translation_Details_ID"].Value);
                lDetailsID.Text = "Details ID: " + SelectedRowIDInView.ToString();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete selected translation record?", "Warning!",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string DeleteStoreProcedure;
                if (Properties.Settings.Default.Mode == "Test")
                {
                    DeleteStoreProcedure = "[DeleteTestTranslationDetail2]";
                }
                else
                {
                    DeleteStoreProcedure = "[DeleteTranslationDetail2]";
                }


                try
                {

                    string connString = Properties.Settings.Default.ConnectionString;
                    SqlCommand Command = new SqlCommand();
                    SqlParameter ParamDetailsID;  //Parameter to pass DetailsID to DeleteTranslationDetail sp
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
                    conn.Open();

                    Command.Connection = conn;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.CommandText = DeleteStoreProcedure;   // Stored procedure to delete selected record
                    ParamDetailsID = new SqlParameter("@DetailRowID", SelectedRowIDInView);
                    ParamDetailsID.Direction = ParameterDirection.Input;
                    ParamDetailsID.DbType = DbType.String;
                    Command.Parameters.Add(ParamDetailsID);
                    Command.ExecuteNonQuery();
                    conn.Close();

                    lDetailsID.Text = ""; // the test mode details id label


                }

                catch (Exception exp)
                {
                    MessageBox.Show("There was an error while trying to delete details record.  \n" +
                     " Note what happened and contact administrator for help or see error log.  \n");
                    Error_Logging el = new Error_Logging("There was an error while trying to delete details record. \n" + exp);
                    return;
                }
                RefreshDataGridView();

            }
            else
            {
                return;
            }

        }

        private void dgvTranslations_DoubleClick(object sender, EventArgs e)  //row was double clicked
        {
            EditTranslation();
        }

        private void bEdit_Click(object sender, EventArgs e)  //edit button pressed
        {
            EditTranslation();
        }

        private void EditTranslation()
        {
            if (dgvTranslations.SelectedRows.Count == 1)
            {

                int selectedrowindex = dgvTranslations.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvTranslations.Rows[selectedrowindex];

                //set all the variable with the selected row data
                cboCommodity.SelectedValue = selectedRow.Cells[2].Value.ToString();
                CommodityCode = selectedRow.Cells[2].Value.ToString();
                tbGrowerCommodityCode.Text = UppercaseWords.Uppercase(selectedRow.Cells[1].Value.ToString());
                GrowerCommodityCode = UppercaseWords.Uppercase(selectedRow.Cells[1].Value.ToString());
                cboVariety.SelectedValue = selectedRow.Cells[5].Value.ToString();
                VarietyCode = selectedRow.Cells[5].Value.ToString();
                tbGrowerVarietyCode.Text = UppercaseWords.Uppercase(selectedRow.Cells[4].Value.ToString());
                GrowerVarietyCode = UppercaseWords.Uppercase(selectedRow.Cells[4].Value.ToString());
                StoneFruit = selectedRow.Cells[20].Value.ToString();
                lStoneFruit.Text = "Stone Fruit? " + StoneFruit;  //if it is stone fruit when in test mode
                cboStyle.SelectedValue = selectedRow.Cells[8].Value.ToString();
                StyleCode = selectedRow.Cells[8].Value.ToString();
                tbStyle.Text = selectedRow.Cells[7].Value.ToString();
                GrowerStyle = selectedRow.Cells[7].Value.ToString();
                cboSize.SelectedValue = selectedRow.Cells[10].Value.ToString();
                SizeCode = selectedRow.Cells[10].Value.ToString();
                tbSize.Text = selectedRow.Cells[9].Value.ToString();
                GrowerSize = selectedRow.Cells[9].Value.ToString();
                cboPackCode.SelectedValue = selectedRow.Cells[12].Value.ToString();
                Packcode = selectedRow.Cells[12].Value.ToString();
                tbPackCode.Text = selectedRow.Cells[11].Value.ToString();
                GrowerPackcode = selectedRow.Cells[11].Value.ToString();
                cboLabel.SelectedValue = selectedRow.Cells[14].Value.ToString();
                LabelCode = selectedRow.Cells[14].Value.ToString();
                tbLabel.Text = selectedRow.Cells[13].Value.ToString();
                GrowerLabel = UppercaseWords.Uppercase(selectedRow.Cells[13].Value.ToString());
                cboGrade.SelectedValue = selectedRow.Cells[16].Value.ToString();
                Grade = selectedRow.Cells[16].Value.ToString();
                tbGrade.Text = selectedRow.Cells[15].Value.ToString();
                GrowerGrade = selectedRow.Cells[15].Value.ToString();
                cboPalletType.SelectedValue = selectedRow.Cells[18].Value.ToString();
                PalletType = selectedRow.Cells[18].Value.ToString();
                tbPalletType.Text = selectedRow.Cells[17].Value.ToString();
                GrowerPalletType = selectedRow.Cells[17].Value.ToString();
         


                lblGCVCode.Text = selectedRow.Cells[21].Value.ToString();
                if (lblGCVCode.Text.Length > 5)
                {
                    lblGCVCode.BackColor = Color.LightGreen;
                }

                // enable the lower controls for editing
                cboGrade.Enabled = true;
                cboLabel.Enabled = true;
                cboPackCode.Enabled = true;
                cboPalletType.Enabled = true;
                cboSize.Enabled = true;
                cboStyle.Enabled = true;
                tbGrade.Enabled = true;
                tbLabel.Enabled = true;
                tbPackCode.Enabled = true;
                tbPalletType.Enabled = true;
                tbSize.Enabled = true;
                tbStyle.Enabled = true;
            }

            return;
        }

       

       
       

    }
}
