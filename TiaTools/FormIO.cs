using System;
using CustomUtility_NET_F;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace TiaTools
{
    public partial class FormIO : Form
    {
        #region Constructor

        public FormIO()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Workbook|*.xls; *xlsx";
            openFileDialog.Title = "Select An Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                comboBoxSheetList.Items.Clear();
                textBoxFilePath.Text = openFileDialog.FileName;
            }

            //Fill combobox
            foreach (string str in ExcelDataTable.GetSheetsCollection(textBoxFilePath.Text))
            {
                comboBoxSheetList.Items.Add(str);
            }

            //Set default Sheet
            comboBoxSheetList.Text = comboBoxSheetList.Items[0].ToString();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            dataGridViewInput.DataSource = ExcelDataTable.ImportExcelToDataTable(textBoxFilePath.Text, comboBoxSheetList.SelectedIndex);
            dataGridViewInput.Update();
        }

        private void buttonCreateFiles_Click(object sender, EventArgs e)
        {
            //Select Folder To save File
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            //New String To Save Filepath
            string filePath;
            string filePathDIN;
            string filePathDOUT;
            string filePathAIN;
            string filePathAOUT;
            string filePathTypes;
            string filePathFB;

            //New DataTable To Store DataGridView Paramaters
            DataTable dataTable = new DataTable();
            dataTable = (DataTable)dataGridViewInput.DataSource;

            //Create Source Files
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                //Create a New Directory To store New Files
                filePath = folderBrowserDialog.SelectedPath + @"\TIA_SourceFile_IO_" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                filePathDIN = filePath + @"\D_IN";
                filePathAIN = filePath + @"\A_IN";
                filePathDOUT = filePath + @"\D_OUT";
                filePathAOUT = filePath + @"\A_OUT";
                filePathTypes = filePath + @"\IO_Types";
                filePathFB = filePath + @"\IO_FB";
                Directory.CreateDirectory(filePath);

                #region DI
                //Input Files
                if (checkBoxD_IN.Checked)
                {
                    //Create Directory
                    Directory.CreateDirectory(filePathDIN);

                    #region FC_Digital_IN
                    //New Stream For FC_Digital_IN
                    StreamWriter FC_Digital_IN = new StreamWriter(filePathDIN + @"\FC_Digital_IN.scl", false);

                    //FC_Digital_IN Body
                    FC_Digital_IN.Write(TiaTools.Properties.Resources.FC_Digital_IN);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Digital_IN.Write(TiaTools.Properties.Resources.FC_Digital_IN_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Digital_IN.Write("\n");
                        }
                    }
                    FC_Digital_IN.Write("END_FUNCTION");
                    FC_Digital_IN.Close();
                    FC_Digital_IN.Dispose();
                    #endregion

                    #region DB_DIN
                    //New Stream For DB_DIN
                    StreamWriter DB_DIN = new StreamWriter(filePathDIN + @"\DB_DIN.db", false);

                    //DB_IN Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            DB_DIN.Write(TiaTools.Properties.Resources.DB_DI.Replace("$VAR_NAME$", row["Name"].ToString()));
                        }
                    }
                    DB_DIN.Close();
                    DB_DIN.Dispose();
                    #endregion

                    #region FC_Digital_IN_Config
                    //New Stream For FC_Digital_IN_Config
                    StreamWriter FC_Digital_IN_Config = new StreamWriter(filePathDIN + @"\FC_Digital_IN_Config.scl", false);

                    //FC_Digital_IN_Config Body
                    FC_Digital_IN_Config.Write(TiaTools.Properties.Resources.FC_Digital_IN_Config);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Digital_IN_Config.Write(TiaTools.Properties.Resources.FC_Digital_IN_Config_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Digital_IN_Config.Write("\n");
                        }
                    }
                    FC_Digital_IN_Config.Write("END_FUNCTION");
                    FC_Digital_IN_Config.Close();
                    FC_Digital_IN_Config.Dispose();
                    #endregion
                }
                #endregion

                #region AI
                //Input Files
                if (checkBoxA_IN.Checked)
                {
                    //Create Directory
                    Directory.CreateDirectory(filePathAIN);

                    #region FC_Analog_IN
                    //New Stream For FC_Analog_IN
                    StreamWriter FC_Analog_IN = new StreamWriter(filePathAIN + @"\FC_Analog_IN.scl", false);

                    //FC_Analog_IN Body
                    FC_Analog_IN.Write(TiaTools.Properties.Resources.FC_Analog_IN);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Analog_IN.Write(TiaTools.Properties.Resources.FC_Analog_IN_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Analog_IN.Write("\n");
                        }
                    }
                    FC_Analog_IN.Write("END_FUNCTION");
                    FC_Analog_IN.Close();
                    FC_Analog_IN.Dispose();
                    #endregion

                    #region DB_AIN
                    //New Stream For DB_AIN
                    StreamWriter DB_AIN = new StreamWriter(filePathAIN + @"\DB_AIN.db", false);

                    //DB_AIN Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && row["Logical Address"].ToString().Contains("W"))
                        {
                            DB_AIN.Write(TiaTools.Properties.Resources.DB_AI.Replace("$VAR_NAME$", row["Name"].ToString()));
                        }
                    }
                    DB_AIN.Close();
                    DB_AIN.Dispose();
                    #endregion

                    #region FC_Analog_IN_Config
                    //New Stream For FC_Analog_IN_Config
                    StreamWriter FC_Analog_IN_Config = new StreamWriter(filePathAIN + @"\FC_Analog_IN_Config.scl", false);

                    //FC_Digital_IN_Config Body
                    FC_Analog_IN_Config.Write(TiaTools.Properties.Resources.FC_Analog_IN_Config);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Analog_IN_Config.Write(TiaTools.Properties.Resources.FC_Analog_IN_Config_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Analog_IN_Config.Write("\n");
                        }
                    }
                    FC_Analog_IN_Config.Write("END_FUNCTION");
                    FC_Analog_IN_Config.Close();
                    FC_Analog_IN_Config.Dispose();
                    #endregion
                }
                #endregion

                #region DO
                //Input Files
                if (checkBoxD_OUT.Checked)
                {
                    //Create Directory
                    Directory.CreateDirectory(filePathDOUT);

                    #region FC_Digital_OUT
                    //New Stream For FC_Digital_OUT
                    StreamWriter FC_Digital_OUT = new StreamWriter(filePathDOUT + @"\FC_Digital_OUT.scl", false);

                    //FC_Digital_OUT Body
                    FC_Digital_OUT.Write(TiaTools.Properties.Resources.FC_Digital_OUT);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Digital_OUT.Write(TiaTools.Properties.Resources.FC_Digital_OUT_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Digital_OUT.Write("\n");
                        }
                    }
                    FC_Digital_OUT.Write("END_FUNCTION");
                    FC_Digital_OUT.Close();
                    FC_Digital_OUT.Dispose();
                    #endregion

                    #region DB_DOUT
                    //New Stream For DB_DOUT
                    StreamWriter DB_DOUT = new StreamWriter(filePathDOUT + @"\DB_DOUT.db", false);

                    //DB_DOUT Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            DB_DOUT.Write(TiaTools.Properties.Resources.DB_DO.Replace("$VAR_NAME$", row["Name"].ToString()));
                        }
                    }
                    DB_DOUT.Close();
                    DB_DOUT.Dispose();
                    #endregion

                    #region FC_Digital_OUT_Config
                    //New Stream For FC_Digital_OUT_Config
                    StreamWriter FC_Digital_OUT_Config = new StreamWriter(filePathDOUT + @"\FC_Digital_OUT_Config.scl", false);

                    //FC_Digital_OUT_Config Body
                    FC_Digital_OUT_Config.Write(TiaTools.Properties.Resources.FC_Digital_OUT_Config);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Digital_OUT_Config.Write(TiaTools.Properties.Resources.FC_Digital_OUT_Config_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Digital_OUT_Config.Write("\n");
                        }
                    }
                    FC_Digital_OUT_Config.Write("END_FUNCTION");
                    FC_Digital_OUT_Config.Close();
                    FC_Digital_OUT_Config.Dispose();
                    #endregion
                }
                #endregion

                #region AO
                //Input Files
                if (checkBoxA_OUT.Checked)
                {
                    //Create Directory
                    Directory.CreateDirectory(filePathAOUT);

                    #region FC_Analog_OUT
                    //New Stream For FC_Analog_OUT
                    StreamWriter FC_Analog_OUT = new StreamWriter(filePathAOUT + @"\FC_Analog_OUT.scl", false);

                    //FC_Digital_OUT Body
                    FC_Analog_OUT.Write(TiaTools.Properties.Resources.FC_Analog_OUT);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Analog_OUT.Write(TiaTools.Properties.Resources.FC_Analog_OUT_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Analog_OUT.Write("\n");
                        }
                    }
                    FC_Analog_OUT.Write("END_FUNCTION");
                    FC_Analog_OUT.Close();
                    FC_Analog_OUT.Dispose();
                    #endregion

                    #region DB_AOUT
                    //New Stream For DB_AOUT
                    StreamWriter DB_AOUT = new StreamWriter(filePathAOUT + @"\DB_AOUT.db", false);

                    //DB_AOUT Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && row["Logical Address"].ToString().Contains("W"))
                        {
                            DB_AOUT.Write(TiaTools.Properties.Resources.DB_AO.Replace("$VAR_NAME$", row["Name"].ToString()));
                        }
                    }
                    DB_AOUT.Close();
                    DB_AOUT.Dispose();
                    #endregion

                    #region FC_Analog_OUT_Config
                    //New Stream For FC_Analog_OUT_Config
                    StreamWriter FC_Analog_OUT_Config = new StreamWriter(filePathAOUT + @"\FC_Analog_OUT_Config.scl", false);

                    //FC_Analog_OUT_Config Body
                    FC_Analog_OUT_Config.Write(TiaTools.Properties.Resources.FC_Analog_OUT_Config);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && row["Logical Address"].ToString().Contains("W"))
                        {
                            FC_Analog_OUT_Config.Write(TiaTools.Properties.Resources.FC_Analog_OUT_Config_Part.Replace("$VAR_NAME$", row["Name"].ToString()));
                            FC_Analog_OUT_Config.Write("\n");
                        }
                    }
                    FC_Analog_OUT_Config.Write("END_FUNCTION");
                    FC_Analog_OUT_Config.Close();
                    FC_Analog_OUT_Config.Dispose();
                    #endregion
                }
                #endregion

                #region Types
                if (checkBoxTypes.Checked)
                {
                    //Create Directory
                    Directory.CreateDirectory(filePathTypes);

                    //New Stream For FC_Analog_OUT
                    StreamWriter IO_Types = new StreamWriter(filePathTypes + @"\IO_Types.udt", false);


                    //Write From Source
                    IO_Types.Write(TiaTools.Properties.Resources.IO_Types);

                    //Close Stream
                    IO_Types.Close();
                    IO_Types.Dispose();
                }
                #endregion

                #region IO_FB
                if (checkBoxFB.Checked)
                {
                    //Create Directory
                    Directory.CreateDirectory(filePathFB);

                    //New Stream For FC_Analog_OUT
                    StreamWriter FB_Analog_IN = new StreamWriter(filePathFB + @"\FB_Analog_IN.scl", false);
                    StreamWriter FB_Digital_IN = new StreamWriter(filePathFB + @"\FB_Digital_IN.scl", false);
                    StreamWriter FB_Analog_OUT = new StreamWriter(filePathFB + @"\FB_Analog_OUT.scl", false);
                    StreamWriter FB_Digital_OUT = new StreamWriter(filePathFB + @"\FB_Digital_OUT.scl", false);

                    //Write From Source
                    FB_Analog_IN.Write(TiaTools.Properties.Resources.FB_Analog_IN);
                    FB_Digital_IN.Write(TiaTools.Properties.Resources.FB_Digital_IN);
                    FB_Analog_OUT.Write(TiaTools.Properties.Resources.FB_Analog_OUT);
                    FB_Digital_OUT.Write(TiaTools.Properties.Resources.FB_Digital_OUT);

                    //Close Stream
                    FB_Analog_IN.Close();
                    FB_Analog_IN.Dispose();
                    FB_Analog_OUT.Close();
                    FB_Analog_OUT.Dispose();
                    FB_Digital_IN.Close();
                    FB_Digital_IN.Dispose();
                    FB_Digital_OUT.Close();
                    FB_Digital_OUT.Dispose();
                }
                #endregion
            }
            #endregion
        }
    }
}