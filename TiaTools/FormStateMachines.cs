using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CustomUtility_NET_F;

namespace TiaTools
{
    public partial class FormStateMachines : Form
    {
        #region Constructor

        public FormStateMachines()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormStateMachines_Load(object sender, EventArgs e)
        {
            //Create new DataTable
            DataTable dataTable = new DataTable();

            //Add Columns To Data Table
            dataTable.Columns.Add("Phase Name");
            dataTable.Columns.Add("Phase Nb");
            dataTable.Columns.Add("Create Phase FC");
            dataTable.Columns.Add("First Step");

            //Set DataTable As DataGridView Source
            dataGridViewSM.DataSource = dataTable;

            //Clear Coloumn On DatagridView
            dataGridViewSM.Columns.Clear();

            //Add Same Coloumns To DataGridView but of a different Type
            dataGridViewSM.Columns.Add("Phase Name", "Phase Name");

            dataGridViewSM.Columns.Add("Phase Nb", "Phase Nb");

            DataGridViewComboBoxColumn coloumncreateFC = new DataGridViewComboBoxColumn();
            coloumncreateFC.Name = "Create Phase FC";
            coloumncreateFC.HeaderText = "Create Phase FC";
            coloumncreateFC.Items.Add("True");
            coloumncreateFC.Items.Add("False");
            dataGridViewSM.Columns.Add(coloumncreateFC);

            DataGridViewComboBoxColumn columnFstep = new DataGridViewComboBoxColumn();
            columnFstep.Name = "First Step";
            columnFstep.HeaderText = "First Step";
            columnFstep.Items.Add("True");
            columnFstep.Items.Add("False");
            dataGridViewSM.Columns.Add(columnFstep);

            //Bind new Coloums To DataTable Coloumns
            dataGridViewSM.Columns["Phase Name"].DataPropertyName = dataTable.Columns["Phase Name"].ToString();
            dataGridViewSM.Columns["Phase Nb"].DataPropertyName = dataTable.Columns["Phase Nb"].ToString();
            dataGridViewSM.Columns["Create Phase FC"].DataPropertyName = dataTable.Columns["Create Phase FC"].ToString();
            dataGridViewSM.Columns["First Step"].DataPropertyName = dataTable.Columns["First Step"].ToString();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            //ClearList
            comboBoxSheetList.Items.Clear();

            //Open file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Workbook|*.xls; *xlsx";
            openFileDialog.Title = "Select An Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxImportFilePath.Text = openFileDialog.FileName;
            }

            //Fill combobox
            foreach (string str in ExcelDataTable.GetSheetsCollection(textBoxImportFilePath.Text))
            {
                comboBoxSheetList.Items.Add(str);
            }

            //Set default Sheet
            comboBoxSheetList.Text = comboBoxSheetList.Items[0].ToString();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        { 
            //Set DatagridView source As DataTable From Excel File
            dataGridViewSM.DataSource = ExcelDataTable.ImportExcelToDataTable(textBoxImportFilePath.Text, comboBoxSheetList.SelectedIndex);
            dataGridViewSM.Update();

            //Update State Machine Nunmber Tot Number And Name
            textBoxSMName.Text = comboBoxSheetList.Text;
            textBoxSMNb.Text = (comboBoxSheetList.SelectedIndex + 1).ToString();
            textBoxSMTotNb.Text = comboBoxSheetList.Items.Count.ToString();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            {
                //Prompt Savefiledialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook|*xlsx";
                saveFileDialog.Title = "Export";
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.FileName = @"SM_" + textBoxSMNb.Text + "_" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");

                textBoxExportFilePath.Text = Path.GetFullPath(saveFileDialog.FileName);
                textBoxExportFilePath.Update();

                if (saveFileDialog.FileName != "" && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //New DataTable
                    DataTable dataTable = new DataTable();

                    //Fill DataTable With Datasource To Datatable Casting
                    dataTable = (DataTable)dataGridViewSM.DataSource;

                    //Export DataTable To Excel
                    ExcelDataTable.ExportDataTableToExcel(dataTable, Path.GetFullPath(saveFileDialog.FileName), "SM " + textBoxSMNb.Text);
                }
            }
        }

        private void buttonSelectALL_Click(object sender, EventArgs e)
        {
            //New DataTable
            DataTable dataTable = new DataTable();

            //Fill DataTable With Datasource To Datatable Casting
            dataTable = (DataTable)dataGridViewSM.DataSource;

            foreach (DataRow row in dataTable.Rows)
            {
                row["Create Phase FC"] = "True";
            }
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            //New DataTable
            DataTable dataTable = new DataTable();

            //Fill DataTable With Datasource To Datatable Casting
            dataTable = (DataTable)dataGridViewSM.DataSource;

            foreach (DataRow row in dataTable.Rows)
            {
                row["Create Phase FC"] = "False";
            }
        }

        private void buttonCreateTIAFiles_Click(object sender, EventArgs e)
        {
            //Select Folder To save File
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            //some Falgs
            bool OkToCreateFile;

            //String To Save First Step
            string firstPhase;
            
            //String To Save Autostart
            string autostart;

            //New String To Save Filepath
            string filePath;
            string filePathCommon;
            string filePathDB;
            string filePathSM;
            string filePhatePhaseFC;
            string filepathTypes;
            string filepathHmi;

            //New DataTable To Store DataGridView Paramaters
            DataTable dataTable = new DataTable();
            dataTable = (DataTable)dataGridViewSM.DataSource;

            //Create Source Files
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                //Create a New Directory To store New Files
                filePath = folderBrowserDialog.SelectedPath + @"\TIA_SourceFile_SM" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                Directory.CreateDirectory(filePath);

                #region Common Files
                if (checkBoxCommon.Checked)
                {

                    if (textBoxSMTotNb.Text == null || textBoxSMTotNb.Text == "" || textBoxSMTotNb.Text == "0")
                    {
                        MessageBox.Show("SM Tot Nb must be > 0");
                    }
                    else
                    {
                        //Create a New Directory To store New Files
                        filePathCommon = filePath + @"\CommonFiles";
                        Directory.CreateDirectory(filePathCommon);

                        #region FC_SM_Common.scl
                        //Write File With StreamWriter
                        StreamWriter FC_SM_Common = new StreamWriter(filePathCommon + @"\FC_SM_Common.scl", false);

                        try
                        {
                            //Write File Begin From Source
                            FC_SM_Common.Write(TiaTools.Properties.Resources.FC_SM_Common);

                            //Close Stream
                            FC_SM_Common.Close();
                            FC_SM_Common.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //display error message
                            MessageBox.Show("Exception: " + ex.Message);
                        }
                        #endregion

                        #region FC_SM_Pause_Seq.scl
                        //Write File With StreamWriter
                        StreamWriter FC_SM_Pause_Seq = new StreamWriter(filePathCommon + @"\FC_SM_Pause_Seq.scl", false);

                        try
                        {
                            //Write File Begin From Source
                            FC_SM_Pause_Seq.Write(TiaTools.Properties.Resources.FC_SM_Pause_Seq);

                            //Write File End
                            for (int i = 1; i <= Int32.Parse(textBoxSMTotNb.Text); i++)
                            {
                                FC_SM_Pause_Seq.WriteLine("\t" + "\t" + "\t" + "//PAUSE SEQUENCE SM " + i);
                                FC_SM_Pause_Seq.WriteLine("\t" + "\t" + "\t" + "//********************************************************************//");
                                FC_SM_Pause_Seq.WriteLine("\t" + "\t" + i + ":");
                                FC_SM_Pause_Seq.WriteLine("\t" + "\t" + "\t" + ";");
                                FC_SM_Pause_Seq.Write("\n");
                            }
                            FC_SM_Pause_Seq.WriteLine("END_CASE;");
                            FC_SM_Pause_Seq.WriteLine("END_FUNCTION");

                            //Close Stream
                            FC_SM_Pause_Seq.Close();
                            FC_SM_Pause_Seq.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //display error message
                            MessageBox.Show("Exception: " + ex.Message);
                        }
                        #endregion

                        #region FC_SM_Stop_Seq.scl
                        //Write File With StreamWriter
                        StreamWriter FC_SM_Stop_Seq = new StreamWriter(filePathCommon + @"\FC_SM_Stop_Seq.scl", false);

                        try
                        {
                            //Write File Begin From Source
                            FC_SM_Stop_Seq.Write(TiaTools.Properties.Resources.FC_SM_Stop_Seq);

                            //Write File End
                            for (int i = 1; i <= Int32.Parse(textBoxSMTotNb.Text); i++)
                            {
                                FC_SM_Stop_Seq.WriteLine("\t" + "\t" + "\t" + "//STOP SEQUENCE SM " + i);
                                FC_SM_Stop_Seq.WriteLine("\t" + "\t" + "\t" + "//********************************************************************//");
                                FC_SM_Stop_Seq.WriteLine("\t" + "\t" + i + ":");
                                FC_SM_Stop_Seq.WriteLine("\t" + "\t" + "\t" + ";");
                                FC_SM_Stop_Seq.Write("\n");
                            }
                            FC_SM_Stop_Seq.WriteLine("END_CASE;");
                            FC_SM_Stop_Seq.WriteLine("END_FUNCTION");

                            //Close Stream
                            FC_SM_Stop_Seq.Close();
                            FC_SM_Stop_Seq.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //display error message
                            MessageBox.Show("Exception: " + ex.Message);
                        }
                        #endregion

                        #region FC_SM_Reset_Seq.scl
                        //Write File With StreamWriter
                        StreamWriter FC_SM_Reset_Seq = new StreamWriter(filePathCommon + @"\FC_SM_Reset_Seq.scl", false);

                        try
                        {
                            //Write File Begin From Source
                            FC_SM_Reset_Seq.Write(TiaTools.Properties.Resources.FC_SM_Reset_Seq);

                            //Write File End
                            for (int i = 1; i <= Int32.Parse(textBoxSMTotNb.Text); i++)
                            {
                                FC_SM_Reset_Seq.WriteLine("\t" + "\t" + "\t" + "//RESET SEQUENCE SM " + i);
                                FC_SM_Reset_Seq.WriteLine("\t" + "\t" + "\t" + "//********************************************************************//");
                                FC_SM_Reset_Seq.WriteLine("\t" + "\t" + i + ":");
                                FC_SM_Reset_Seq.WriteLine("\t" + "\t" + "\t" + "\"" + "DB_SM" + "\"" + ".Sm[#SMN] := " + "\"" + "DB_SM" + "\"" + ".Sm[0];");
                                FC_SM_Reset_Seq.Write("\n");
                            }
                            FC_SM_Reset_Seq.WriteLine("END_CASE;");
                            FC_SM_Reset_Seq.WriteLine("END_FUNCTION");

                            //Close Stream
                            FC_SM_Reset_Seq.Close();
                            FC_SM_Reset_Seq.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //display error message
                            MessageBox.Show("Exception: " + ex.Message);
                        }
                        #endregion

                        #region FC_SM_Call.scl
                        //Write File With StreamWriter
                        StreamWriter FC_SM_Call = new StreamWriter(filePathCommon + @"\FC_SM_Call.scl", false);

                        try
                        {
                            //Write File Begin From Source
                            FC_SM_Call.Write(TiaTools.Properties.Resources.FC_SM_Call);

                            //Write File End
                            for (int i = 1; i <= Int32.Parse(textBoxSMTotNb.Text); i++)
                            {
                                FC_SM_Call.WriteLine("\t" + "//CALL SM " + i);
                                FC_SM_Call.WriteLine("\t" + "//********************************************************************//");
                                FC_SM_Call.WriteLine("\t" + "\"" + "FC_SM_" + i + "\"" + "()" + ";");
                                FC_SM_Call.Write("\n");
                            }
                            FC_SM_Call.WriteLine("END_FUNCTION");

                            //Close Stream
                            FC_SM_Call.Close();
                            FC_SM_Call.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //display error message
                            MessageBox.Show("Exception: " + ex.Message);
                        }
                        #endregion
                    }
                }
                #endregion

                #region DB
                if (checkBoxDB.Checked)
                {
                    if (textBoxSMTotNb.Text == null || textBoxSMTotNb.Text == "" || textBoxSMTotNb.Text == "0")
                    {
                        MessageBox.Show("SM Tot Nb must be > 0");
                    }
                    else
                    {

                        //Create a New Directory To store New Files
                        filePathDB = filePath + @"\DB";
                        Directory.CreateDirectory(filePathDB);

                        #region DB_SM.db
                        //Write File With StreamWriter
                        StreamWriter DB_SM = new StreamWriter(filePathDB + @"\DB_SM.db", false);

                        try
                        {
                            //Write File Begin From Source
                            DB_SM.Write(TiaTools.Properties.Resources.DB_SM.Replace("$SM_TOT_NB$", textBoxSMTotNb.Text));

                            //Close Stream
                            DB_SM.Close();
                            DB_SM.Dispose();
                        }
                        catch (Exception ex)
                        {
                            //display error message
                            MessageBox.Show("Exception: " + ex.Message);
                        }
                        #endregion
                    }
                }
                #endregion

                #region FC_SM
                if (checkBoxSMFiles.Checked)
                {
                    if (textBoxSMNb.Text == null || textBoxSMNb.Text == "" || textBoxSMNb.Text == "0")
                    {
                        MessageBox.Show("SM Nb bust be > 0");
                    }
                    else
                    {
                        if (textBoxSMName.Text == null || textBoxSMName.Text == "")
                        {
                            MessageBox.Show("SM Name must not be empty");
                        }
                        else
                        {
                            //Null firstStep
                            firstPhase = null;
                            OkToCreateFile = true;

                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (firstPhase != null)
                                {
                                    if (row["First Step"].ToString() == "True")
                                    {
                                        MessageBox.Show("More than one First Step Selected");
                                        OkToCreateFile = false;
                                    }
                                }
                                else
                                {
                                    if (row["First Step"].ToString() == "True")
                                    {
                                        firstPhase = row["Phase Name"].ToString();
                                    }
                                }
                            }

                            if (firstPhase == null)
                            {
                                MessageBox.Show("No First Step Selected");
                                OkToCreateFile = false;
                            }

                            if (OkToCreateFile)
                            {
                                //Create a New Directory To store New Files
                                filePathSM = filePath + @"\FC_SM";
                                Directory.CreateDirectory(filePathSM);

                                //Write File With StreamWriter
                                StreamWriter FC_SM = new StreamWriter(filePathSM + @"\FC_SM_" + textBoxSMNb.Text + ".scl", false);

                                //Check if Autostart
                                if (checkBoxAutoStart.Checked)
                                {
                                    autostart = "1";
                                }
                                else
                                {
                                    autostart = "0";
                                }

                                try
                                {
                                    //Write File Begin From Source
                                    FC_SM.Write(TiaTools.Properties.Resources.FC_SM.Replace("$SM_NAME$", textBoxSMName.Text).Replace("$SM_NB$", textBoxSMNb.Text).Replace("$START_PHASE$", firstPhase).Replace("$AUTOSTART$", autostart));

                                    //Write Steps From Source
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        FC_SM.Write(TiaTools.Properties.Resources.FC_SM_Step.Replace("$PHASE_NAME$", row["Phase Name"].ToString()));
                                        FC_SM.Write("\n");
                                        FC_SM.Write("\n");
                                    }
                                    FC_SM.WriteLine("\t" + "END_CASE;");
                                    FC_SM.Write("\n");
                                    FC_SM.WriteLine("END_FUNCTION");

                                    //Close Stream
                                    FC_SM.Close();
                                    FC_SM.Dispose();
                                }
                                catch (Exception ex)
                                {
                                    //display error message
                                    MessageBox.Show("Exception: " + ex.Message);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region FC_SM_X_Phase
                if (checkBoxPhaseFC.Checked)
                {
                    //Create a New Directory To store New Files
                    filePhatePhaseFC = filePath + @"\FC_Phases";
                    Directory.CreateDirectory(filePhatePhaseFC);

                    //Write File With StreamWriter
                    StreamWriter FC_Phases = new StreamWriter(filePhatePhaseFC + @"\FC_Phases" + ".scl", false);

                    //Write Steps From Source
                    foreach (DataRow row in dataTable.Rows)
                    { 
                        if (row["Create Phase FC"].ToString() == "True")
                        {
                            FC_Phases.Write(TiaTools.Properties.Resources.FC_SM_Phase.Replace("$SM_NB$", textBoxSMNb.Text).Replace("$PHASE_NAME$", row["Phase Name"].ToString()));
                            FC_Phases.Write("\n");
                            FC_Phases.Write("\n");
                        }
                    }

                    //Close Stream
                    FC_Phases.Close();
                    FC_Phases.Dispose();
                }
                #endregion

                #region Types
                if (checkBoxTypes.Checked)
                {
                    //Create a New Directory To store New Files
                    filepathTypes = filePath + @"\SM_Types";
                    Directory.CreateDirectory(filepathTypes);

                    //Write File With StreamWriter
                    StreamWriter SM_types = new StreamWriter(filepathTypes + @"\SM_Types.udt", false);

                    //Write From Source
                    SM_types.Write(TiaTools.Properties.Resources.SM_Types);

                    //Close Stream
                    SM_types.Close();
                    SM_types.Dispose();
                }
                #endregion

                #region FC_HMI_SM
                if (checkBoxHmi.Checked)
                {
                    if (textBoxSMNb.Text == null || textBoxSMNb.Text == "" || textBoxSMNb.Text == "0")
                    {
                        MessageBox.Show("SM Nb bust be > 0");
                    }
                    else
                    {
                        if (textBoxSMName.Text == null || textBoxSMName.Text == "")
                        {
                            MessageBox.Show("SM Name must not be empty");
                        }
                        else
                        {
                            //Create a New Directory To store New Files
                            filepathHmi = filePath + @"\Hmi";
                            Directory.CreateDirectory(filepathHmi);

                            //Write File With StreamWriter
                            StreamWriter FC_Hmi = new StreamWriter(filepathHmi + @"\FC_Hmi_SM_" + textBoxSMName.Text + ".scl", false);

                            //Write File Begin From Source
                            FC_Hmi.Write(TiaTools.Properties.Resources.FC_SM_Hmi.Replace("$SM_NAME$", textBoxSMName.Text).Replace("$SM_NB$", textBoxSMNb.Text));

                            //Write Steps From Source
                            foreach (DataRow row in dataTable.Rows)
                            {
                                FC_Hmi.Write(TiaTools.Properties.Resources.FC_SM_Hmi_Step.Replace("$PHASE_NAME$", row["Phase Name"].ToString()));
                                FC_Hmi.Write("\n");
                                FC_Hmi.Write("\n");
                            }

                            FC_Hmi.WriteLine("\t" + "END_CASE;");
                            FC_Hmi.Write("\n");
                            FC_Hmi.WriteLine("END_FUNCTION");

                            //Close Stream
                            FC_Hmi.Close();
                            FC_Hmi.Dispose();
                        }
                    }
                }
                #endregion
            }
        }
        #endregion
    }
}