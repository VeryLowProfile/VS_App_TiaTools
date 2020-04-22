using System;
using CustomUtility_NET_F;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace TiaTools
{
    public partial class FormInput : Form
    {
        #region Constructor

        public FormInput()
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

            //New DataTable To Store DataGridView Paramaters
            DataTable dataTable = new DataTable();
            dataTable = (DataTable)dataGridViewInput.DataSource;

            //Create Source Files
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                //Create a New Directory To store New Files
                filePath = folderBrowserDialog.SelectedPath + @"\TIA_SourceFile_" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                filePathDIN = filePath + @"\D_IN";
                filePathAIN = filePath + @"\A_IN";
                filePathDOUT = filePath + @"\D_OUT";
                filePathAOUT = filePath + @"\A_OUT";
                Directory.CreateDirectory(filePath);
                Directory.CreateDirectory(filePathAIN);
                Directory.CreateDirectory(filePathDOUT);
                Directory.CreateDirectory(filePathAOUT);

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
                    FC_Digital_IN.WriteLine(@"FUNCTION ""FC_Digital_IN"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Digital_IN
//Version: x.x
//Description: Instances OF FB_Digital_In
//Developer: Topcast
//********************************************************************//
");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "DI_" + row["Name"];
                            FC_Digital_IN.WriteLine("//" + completeName);
                            FC_Digital_IN.WriteLine(@"//********************************************************************//");
                            FC_Digital_IN.WriteLine("\"" + completeName + "\"" + " " + "(\"" + row["Name"] + "\");");
                            FC_Digital_IN.Write("\n");
                        }
                    }
                    FC_Digital_IN.Write("END_FUNCTION");
                    FC_Digital_IN.Close();
                    #endregion

                    #region DB_DIN
                    //New Stream For DB_DIN
                    StreamWriter DB_DIN = new StreamWriter(filePathDIN + @"\DB_DIN.db", false);

                    //DB_IN Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "DI_" + row["Name"];
                            DB_DIN.WriteLine("DATA_BLOCK \"" + completeName + "\"");
                            DB_DIN.WriteLine("{ S7_Optimized_Access := 'TRUE' }");
                            DB_DIN.WriteLine("VERSION : 0.1");
                            DB_DIN.WriteLine("NON_RETAIN");
                            DB_DIN.WriteLine("\"FB_Digital_IN\"");
                            DB_DIN.WriteLine();
                            DB_DIN.WriteLine("BEGIN");
                            DB_DIN.WriteLine();
                            DB_DIN.WriteLine("END_DATA_BLOCK");
                            DB_DIN.WriteLine();
                        }
                    }
                    DB_DIN.Close();
                    #endregion

                    #region FC_Digital_IN_Config
                    //New Stream For FC_Digital_IN_Config
                    StreamWriter FC_Digital_IN_Config = new StreamWriter(filePathDIN + @"\FC_Digital_IN_Config.scl", false);

                    //FC_Digital_IN_Config Body
                    FC_Digital_IN_Config.WriteLine(@"FUNCTION ""FC_Digital_IN_Config"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Digital_IN_Config
//Version: x.x
//Description: Configuration Digital IN
//Developer: Topcast
//********************************************************************//
");


                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "DI_" + row["Name"];
                            FC_Digital_IN_Config.WriteLine("//" + completeName);
                            FC_Digital_IN_Config.WriteLine(@"//********************************************************************//");
                            FC_Digital_IN_Config.WriteLine("\"" + completeName + "\"" + ".DigitalIN.Config.Name := '" + row["Logical Address"].ToString().Replace("%","") + "_" + completeName + "\';");
                            FC_Digital_IN_Config.WriteLine("\"" + completeName + "\"" + ".DigitalIN.Config.DebounceTime := T#0MS;");
                            FC_Digital_IN_Config.WriteLine();
                        }
                    }
                    FC_Digital_IN_Config.Write("END_FUNCTION");
                    FC_Digital_IN_Config.Close();
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
                    FC_Analog_IN.WriteLine(@"FUNCTION ""FC_Analog_IN"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Analog_IN
//Version: x.x
//Description: Instances OF FB_Analog_IN
//Developer: Topcast
//********************************************************************//
");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "AI_" + row["Name"];
                            FC_Analog_IN.WriteLine("//" + completeName);
                            FC_Analog_IN.WriteLine(@"//********************************************************************//");
                            FC_Analog_IN.WriteLine("\"" + completeName + "\"" + " " + "(\"" + row["Name"] + "\");");
                            FC_Analog_IN.Write("\n");
                        }
                    }
                    FC_Analog_IN.Write("END_FUNCTION");
                    FC_Analog_IN.Close();
                    #endregion

                    #region DB_AIN
                    //New Stream For DB_AIN
                    StreamWriter DB_AIN = new StreamWriter(filePathAIN + @"\DB_AIN.db", false);

                    //DB_AIN Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "AI_" + row["Name"];
                            DB_AIN.WriteLine("DATA_BLOCK \"" + completeName + "\"");
                            DB_AIN.WriteLine("{ S7_Optimized_Access := 'TRUE' }");
                            DB_AIN.WriteLine("VERSION : 0.1");
                            DB_AIN.WriteLine("NON_RETAIN");
                            DB_AIN.WriteLine("\"FB_Analog_IN\"");
                            DB_AIN.WriteLine();
                            DB_AIN.WriteLine("BEGIN");
                            DB_AIN.WriteLine();
                            DB_AIN.WriteLine("END_DATA_BLOCK");
                            DB_AIN.WriteLine();
                        }
                    }
                    DB_AIN.Close();
                    #endregion

                    #region FC_Analog_IN_Config
                    //New Stream For FC_Analog_IN_Config
                    StreamWriter FC_Analog_IN_Config = new StreamWriter(filePathAIN + @"\FC_Analog_IN_Config.scl", false);

                    //FC_Digital_IN_Config Body
                    FC_Analog_IN_Config.WriteLine(@"FUNCTION ""FC_Analog_IN_Config"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Analog_IN_Config
//Version: x.x
//Description: Configuration Analog IN
//Developer: Topcast
//********************************************************************//
");


                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("I") && row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "AI_" + row["Name"];
                            FC_Analog_IN_Config.WriteLine("//" + completeName);
                            FC_Analog_IN_Config.WriteLine(@"//********************************************************************//");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.Name := '" + row["Logical Address"].ToString().Replace("%", "") + "_" + completeName + "\';");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.HighScaleValue := 0;");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.LowScaleValue := 0;");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.HighLimit := 0;");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.LowLimit := 0;");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.LimitDelay := T#5S;");
                            FC_Analog_IN_Config.WriteLine("\"" + completeName + "\"" + ".AnalogIN.Config.IsBipolar := 0;");
                            FC_Analog_IN_Config.WriteLine();
                        }
                    }
                    FC_Analog_IN_Config.Write("END_FUNCTION");
                    FC_Analog_IN_Config.Close();
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
                    FC_Digital_OUT.WriteLine(@"FUNCTION ""FC_Digital_OUT"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Digital_OUT
//Version: x.x
//Description: Instances OF FB_Digital_OUT
//Developer: Topcast
//********************************************************************//
");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "DO_" + row["Name"];
                            FC_Digital_OUT.WriteLine("//" + completeName);
                            FC_Digital_OUT.WriteLine(@"//********************************************************************//");
                            FC_Digital_OUT.WriteLine("\"" + completeName + "\"" + " " + "(\"" + row["Name"] + "\");");
                            FC_Digital_OUT.Write("\n");
                        }
                    }
                    FC_Digital_OUT.Write("END_FUNCTION");
                    FC_Digital_OUT.Close();
                    #endregion

                    #region DB_DOUT
                    //New Stream For DB_DOUT
                    StreamWriter DB_DOUT = new StreamWriter(filePathDOUT + @"\DB_DOUT.db", false);

                    //DB_DOUT Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "DO_" + row["Name"];
                            DB_DOUT.WriteLine("DATA_BLOCK \"" + completeName + "\"");
                            DB_DOUT.WriteLine("{ S7_Optimized_Access := 'TRUE' }");
                            DB_DOUT.WriteLine("VERSION : 0.1");
                            DB_DOUT.WriteLine("NON_RETAIN");
                            DB_DOUT.WriteLine("\"FB_Digital_OUT\"");
                            DB_DOUT.WriteLine();
                            DB_DOUT.WriteLine("BEGIN");
                            DB_DOUT.WriteLine();
                            DB_DOUT.WriteLine("END_DATA_BLOCK");
                            DB_DOUT.WriteLine();
                        }
                    }
                    DB_DOUT.Close();
                    #endregion

                    #region FC_Digital_OUT_Config
                    //New Stream For FC_Digital_OUT_Config
                    StreamWriter FC_Digital_OUT_Config = new StreamWriter(filePathDOUT + @"\FC_Digital_OUT_Config.scl", false);

                    //FC_Digital_OUT_Config Body
                    FC_Digital_OUT_Config.WriteLine(@"FUNCTION ""FC_Digital_OUT_Config"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Digital_OUT_Config
//Version: x.x
//Description: Configuration Digital OUT
//Developer: Topcast
//********************************************************************//
");


                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && !row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "DO_" + row["Name"];
                            FC_Digital_OUT_Config.WriteLine("//" + completeName);
                            FC_Digital_OUT_Config.WriteLine(@"//********************************************************************//");
                            FC_Digital_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.Name := '" + row["Logical Address"].ToString().Replace("%", "") + "_" + completeName + "\';");
                            FC_Digital_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.OFFDelay:= T#0MS;");
                            FC_Digital_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.ONDelay:= T#0MS;");
                            FC_Digital_OUT_Config.WriteLine();
                        }
                    }
                    FC_Digital_OUT_Config.Write("END_FUNCTION");
                    FC_Digital_OUT_Config.Close();
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
                    FC_Analog_OUT.WriteLine(@"FUNCTION ""FC_Analog_OUT"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Analog_OUT
//Version: x.x
//Description: Instances OF FB_Analog_OUT
//Developer: Topcast
//********************************************************************//
");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "AO_" + row["Name"];
                            FC_Analog_OUT.WriteLine("//" + completeName);
                            FC_Analog_OUT.WriteLine(@"//********************************************************************//");
                            FC_Analog_OUT.WriteLine("\"" + completeName + "\"" + " " + "(\"" + row["Name"] + "\");");
                            FC_Analog_OUT.Write("\n");
                        }
                    }
                    FC_Analog_OUT.Write("END_FUNCTION");
                    FC_Analog_OUT.Close();
                    #endregion

                    #region DB_AOUT
                    //New Stream For DB_AOUT
                    StreamWriter DB_AOUT = new StreamWriter(filePathAOUT + @"\DB_AOUT.db", false);

                    //DB_AOUT Body
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "AO_" + row["Name"];
                            DB_AOUT.WriteLine("DATA_BLOCK \"" + completeName + "\"");
                            DB_AOUT.WriteLine("{ S7_Optimized_Access := 'TRUE' }");
                            DB_AOUT.WriteLine("VERSION : 0.1");
                            DB_AOUT.WriteLine("NON_RETAIN");
                            DB_AOUT.WriteLine("\"FB_Analog_OUT\"");
                            DB_AOUT.WriteLine();
                            DB_AOUT.WriteLine("BEGIN");
                            DB_AOUT.WriteLine();
                            DB_AOUT.WriteLine("END_DATA_BLOCK");
                            DB_AOUT.WriteLine();
                        }
                    }
                    DB_AOUT.Close();
                    #endregion

                    #region FC_Analog_OUT_Config
                    //New Stream For FC_Analog_OUT_Config
                    StreamWriter FC_Analog_OUT_Config = new StreamWriter(filePathAOUT + @"\FC_Analog_OUT_Config.scl", false);

                    //FC_Analog_OUT_Config Body
                    FC_Analog_OUT_Config.WriteLine(@"FUNCTION ""FC_Analog_OUT_Config"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1

BEGIN
//********************************************************************//
//Name: FC_Analog_OUT_Config
//Version: x.x
//Description: Configuration Analog OUT
//Developer: Topcast
//********************************************************************//
");


                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Logical Address"].ToString().Contains("Q") && row["Logical Address"].ToString().Contains("W"))
                        {
                            string completeName = "AO_" + row["Name"];
                            FC_Analog_OUT_Config.WriteLine("//" + completeName);
                            FC_Analog_OUT_Config.WriteLine(@"//********************************************************************//");
                            FC_Analog_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.Name := '" + row["Logical Address"].ToString().Replace("%", "") + "_" + completeName + "\';");
                            FC_Analog_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.HighUnscaleLimit:= 0;");
                            FC_Analog_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.LowUnscaleLimit:= 0;");
                            FC_Analog_OUT_Config.WriteLine("\"" + completeName + "\"" + ".DigitalOUT.Config.IsBipolar:= 0;");
                            FC_Analog_OUT_Config.WriteLine();
                        }
                    }
                    FC_Analog_OUT_Config.Write("END_FUNCTION");
                    FC_Analog_OUT_Config.Close();
                    #endregion
                }
                #endregion
            }
        }

        #endregion

    }
}