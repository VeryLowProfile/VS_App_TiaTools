using System;
using CustomUtility_NET_F;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace TiaTools
{
    public partial class FormMessages : Form
    {
        #region Constructor

        public FormMessages()
        {
            InitializeComponent();
        }

        #endregion

       #region Events

        private void FormMessages_Load(object sender, EventArgs e)
        {

            //SM Number Default Value
            textBoxSMNumber.Text = 6.ToString();
        }

        private void checkBoxDefStore_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxDefNone.Checked = false;
        }

        private void checkBoxDefNone_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxDefStore.Checked = false;
        }

        private void buttonNewTable_Click(object sender, EventArgs e)
        {
            //Create new DataTable
            DataTable dataTable = new DataTable();

            //Add Columns To Data Table
            dataTable.Columns.Add("Nb");
            dataTable.Columns.Add("Device it");
            dataTable.Columns.Add("Device en");
            dataTable.Columns.Add("Device fr");
            dataTable.Columns.Add("Device td");
            dataTable.Columns.Add("Device sp");
            dataTable.Columns.Add("Msg Text it");
            dataTable.Columns.Add("Msg Text en");
            dataTable.Columns.Add("Msg Text fr");
            dataTable.Columns.Add("Msg Text td");
            dataTable.Columns.Add("Msg Text sp");
            dataTable.Columns.Add("Info Text it");
            dataTable.Columns.Add("Info Text en");
            dataTable.Columns.Add("Info Text fr");
            dataTable.Columns.Add("Info Text td");
            dataTable.Columns.Add("Info Text sp");
            dataTable.Columns.Add("Msg Class");
            for (int i = 1; i <= Int32.Parse(textBoxSMNumber.Text); i++)
            {
                dataTable.Columns.Add("Msg Reaction SM " + i.ToString());
            }

            //Update DataGridView Structure
            SetDatGridViewSMCol(dataGridViewMsg, dataTable);

        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            //Clear comboBox
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
            //hide New Table Buttons and TextBox
            buttonNewTable.Hide();
            labelSMNumber.Hide();
            textBoxSMNumber.Hide();

            //Update DataGridView Structure
            SetDatGridViewSMCol(dataGridViewMsg, ExcelDataTable.ImportExcelToDataTable(textBoxImportFilePath.Text, comboBoxSheetList.SelectedIndex));
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            //Prompt Savefiledialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*xlsx";
            saveFileDialog.Title = "Export";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.FileName = @"Messages" + "_" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");

            textBoxExportFilePath.Text = Path.GetFullPath(saveFileDialog.FileName);
            textBoxExportFilePath.Update();

            if (saveFileDialog.FileName != "" && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //New DataTable
                DataTable dataTable = new DataTable();

                //Fill DataTable With Datasource To Datatable Casting
                dataTable = (DataTable)dataGridViewMsg.DataSource;

                //Export DataTable To Excel
                ExcelDataTable.ExportDataTableToExcel(dataTable, Path.GetFullPath(saveFileDialog.FileName), "Messages");
            }

            //show New Table Buttons and TextBox
            buttonNewTable.Show();
            labelSMNumber.Show();
            textBoxSMNumber.Show();
        }

        private void buttonCreateFiles_Click(object sender, EventArgs e)
        {
            //Select Folder To save File
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            //New String To Save Filepath
            string filePath;

            //New DataTable To Store DataGridView Paramaters
            DataTable dataTable = new DataTable();
            dataTable = (DataTable)dataGridViewMsg.DataSource;

            //Some Data
            int MsgNb = 0;
            int WordNb = 0;
            int SMNb = 0;

            //Calculate Tot Alarm Number Hmi word Number SM Number
            MsgNb = dataTable.Rows.Count;
            WordNb = (MsgNb / 16) - 1;
            if ((MsgNb % 16) > 0)
            {
                WordNb++;
            }

            //Number of SM Coloumns in DataTable
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.Contains("Msg Reaction SM "))
                {
                    SMNb++;
                }
            }

            //Create Source Files
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                //Create a New Directory To store New Files
                filePath = folderBrowserDialog.SelectedPath + @"\TIA_SourceFile_Messages" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_");
                Directory.CreateDirectory(filePath);

                #region MsgConfig
                if (checkBoxMsgConfig.Checked)
                {
                    try
                    {
                        //Open Excel and create new sheet
                        Excel.Application excel = new Excel.Application();
                        Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
                        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                        worksheet.Name = "MsgConfig";
                        excel.DisplayAlerts = false;

                        //Set Coloumn Header
                        worksheet.Cells[1, 1] = "ID";
                        worksheet.Cells[1, 2] = "Message Text it";
                        worksheet.Cells[1, 3] = "Message Text en";
                        worksheet.Cells[1, 4] = "Message Text fr";
                        worksheet.Cells[1, 5] = "Message Text td";
                        worksheet.Cells[1, 6] = "Message Text sp";
                        worksheet.Cells[1, 7] = "Info Text it";
                        worksheet.Cells[1, 8] = "Info  Text en";
                        worksheet.Cells[1, 9] = "Info  Text fr";
                        worksheet.Cells[1, 10] = "Info  Text td";
                        worksheet.Cells[1, 11] = "Info  Text sp";
                        worksheet.Cells[1, 12] = "Message Class";

                        for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
                        {
                            worksheet.Cells[i + 2, 1] = dataTable.Rows[i]["Nb"];
                            worksheet.Cells[i + 2, 2] =  dataTable.Rows[i]["Device it"] + " -> " + dataTable.Rows[i]["Msg Text it"];
                            worksheet.Cells[i + 2, 3] =  dataTable.Rows[i]["Device en"] + " -> " + dataTable.Rows[i]["Msg Text en"]; 
                            worksheet.Cells[i + 2, 4] =  dataTable.Rows[i]["Device fr"] + " -> " + dataTable.Rows[i]["Msg Text fr"]; 
                            worksheet.Cells[i + 2, 5] =  dataTable.Rows[i]["Device td"] + " -> " + dataTable.Rows[i]["Msg Text td"]; 
                            worksheet.Cells[i + 2, 6] =  dataTable.Rows[i]["Device sp"] + " -> " + dataTable.Rows[i]["Msg Text sp"]; 
                            worksheet.Cells[i + 2, 7] = "Info : " + dataTable.Rows[i]["Info Text it"];
                            worksheet.Cells[i + 2, 8] = "Info : " + dataTable.Rows[i]["Info Text en"]; 
                            worksheet.Cells[i + 2, 9] = "Info : " + dataTable.Rows[i]["Info Text fr"]; 
                            worksheet.Cells[i + 2, 10] = "Info : " + dataTable.Rows[i]["Info Text td"]; 
                            worksheet.Cells[i + 2, 11] = "Info : " + dataTable.Rows[i]["Info Text sp"]; 
                            worksheet.Cells[i + 2, 12] = dataTable.Rows[i]["Msg Class"];
                        }

                        //Saving
                        workbook.SaveAs(filePath + @"\Msg_Config.xlsx");

                        //close Excel
                        workbook.Close();
                        excel.Quit();

                    }
                    catch (Exception ex)
                    {
                        //display error message
                        MessageBox.Show("Exception: " + ex.Message);
                    }
                }
                #endregion

                #region FB_Msg_Handler
                if (checkBoxFBMsgHandler.Checked)
                {
                    //New Stream For MsgConfig
                    StreamWriter FC_Msg_Handler = new StreamWriter(filePath + @"\FC_Msg_Handler.scl", false);

                    //Body
                    FC_Msg_Handler.Write(TiaTools.Properties.Resources.FC_Msg_Handler_Begin);
                    FC_Msg_Handler.Write("\n");
                    if (checkBoxDefStore.Checked)
                    {
                        FC_Msg_Handler.Write(TiaTools.Properties.Resources.FC_Msg_Handler_Body_Store);
                    }
                    if (checkBoxDefNone.Checked)
                    {
                        FC_Msg_Handler.Write(TiaTools.Properties.Resources.FC_Msg_Handler_Body_None);
                    }
                    FC_Msg_Handler.Write("\n");
                    FC_Msg_Handler.Write(TiaTools.Properties.Resources.FC_Msg_Handler_End);

                    FC_Msg_Handler.Close();
                    FC_Msg_Handler.Dispose();
                }
                #endregion

                #region FC_Msg_Config
                if (checkBoxFCMsgConfig.Checked)
                {
                    //New Stream For FC_Msg_Trigger
                    StreamWriter FC_Msg_Config = new StreamWriter(filePath + @"\FC_Msg_Config.scl", false);

                    //Body
                    FC_Msg_Config.Write(TiaTools.Properties.Resources.FC_Msg_Config_Begin.Replace("$WORD_NUMBER$", WordNb.ToString()).Replace("$MSG_TOT_NUMBER$", MsgNb.ToString()).Replace("$SM_TOT$", SMNb.ToString()));
                    FC_Msg_Config.Write("\n");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (!row["Device it"].ToString().Contains("SPARE"))
                        {
                            FC_Msg_Config.Write("\n");
                            for (int i = 1; i <= SMNb; i++)
                            {
                                if ((checkBoxDefStore.Checked & row["Msg Reaction SM " + i].ToString() != "STORE") || (checkBoxDefNone.Checked & row["Msg Reaction SM " + i].ToString() != "NONE"))
                                {
                                    FC_Msg_Config.Write("\n");
                                    FC_Msg_Config.Write(TiaTools.Properties.Resources.FC_Msg_Config_Body.Replace("$MSG_TEXT$", row["Msg Text it"].ToString()).Replace("$MSG_DEVICE$", row["Device it"].ToString()).Replace("$MSG_NUMBER$", row["Nb"].ToString()).Replace("$MSG_REACTION$", row["Msg Reaction SM " + i].ToString()).Replace("$SM_NUMBER$", i.ToString()));                                  
                                }
                            }
                        }
                    }

                    FC_Msg_Config.Write("\n");
                    FC_Msg_Config.Write(TiaTools.Properties.Resources.FC_Msg_Config_End);

                    FC_Msg_Config.Close();
                    FC_Msg_Config.Dispose();
                }
                #endregion

                #region FC_Msg_Trigger
                if (checkBoxFCMsgTrigger.Checked)
                {
                    //New Stream For FC_Msg_Trigger
                    StreamWriter FC_Msg_Trigger = new StreamWriter(filePath + @"\FC_Msg_Trigger.scl", false);

                    //Body
                    FC_Msg_Trigger.Write(TiaTools.Properties.Resources.FC_Msg_Trigger_Begin);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (!row["Device it"].ToString().Contains("SPARE"))
                        {
                            FC_Msg_Trigger.Write(TiaTools.Properties.Resources.FC_Msg_Trigger_Body.Replace("$MSG_TEXT$", row["Msg Text it"].ToString()).Replace("$MSG_DEVICE$", row["Device it"].ToString()).Replace("$MSG_NUMBER$", row["Nb"].ToString()));
                            FC_Msg_Trigger.Write("\n");
                        }
                    }
                    FC_Msg_Trigger.WriteLine("END_FUNCTION");

                    FC_Msg_Trigger.Close();
                    FC_Msg_Trigger.Dispose();
                }
                #endregion

                #region DB_Msg
                if (checkBoxDBMsg.Checked)
                {
                    //New Stream For DB_Msg
                    StreamWriter DB_Msg = new StreamWriter(filePath + @"\DB_Msg.db", false);

                    //Body
                    DB_Msg.Write(TiaTools.Properties.Resources.DB_Msg);

                    DB_Msg.Close();
                    DB_Msg.Dispose();
                }
                #endregion

                #region Msg_Types
                if (checkBoxMsgTypes.Checked)
                {
                    //New Stream For Msg_Types
                    StreamWriter Msg_Types = new StreamWriter(filePath + @"\Msg_Types.udt", false);

                    //Body
                    if (checkBoxDefNone.Checked)
                    {
                        Msg_Types.Write(TiaTools.Properties.Resources.Msg_Types.Replace("$DEFAULT_REACTION$", 0.ToString()).Replace("$ARRAY_LENGHT$", (SMNb + 1).ToString()).Replace("$SM_TOT$", SMNb.ToString()).Replace("$MSG_NUMBER$", MsgNb.ToString()).Replace("$WORD_NUMBER$", WordNb.ToString()));

                    }
                    if (checkBoxDefStore.Checked)
                    {
                        Msg_Types.Write(TiaTools.Properties.Resources.Msg_Types.Replace("$DEFAULT_REACTION$", 1.ToString()).Replace("$ARRAY_LENGHT$", (SMNb + 1).ToString()).Replace("$SM_TOT$", SMNb.ToString()).Replace("$MSG_NUMBER$", MsgNb.ToString()).Replace("$WORD_NUMBER$", WordNb.ToString()));
                    }

                    Msg_Types.Close();
                    Msg_Types.Dispose();
                }
                #endregion

                #region FC_Msg_Store_Sql
                if (checkBoxSql.Checked)
                {
                    //New Stream For Msg_Types
                    StreamWriter FC_Msg_Store_Sql = new StreamWriter(filePath + @"\FC_Msg_Store_Sql.scl", false);

                    //Body
                    FC_Msg_Store_Sql.Write(TiaTools.Properties.Resources.FC_Msg_Store_Sql);

                    FC_Msg_Store_Sql.Close();
                    FC_Msg_Store_Sql.Dispose();
                }
                #endregion

                #region FC_Msg_Reaction
                if (checkBoxSql.Checked)
                {
                    //New Stream For Msg_Types
                    StreamWriter FC_Msg_Reaction = new StreamWriter(filePath + @"\FC_Msg_Reaction.scl", false);

                    //Body
                    FC_Msg_Reaction.Write(TiaTools.Properties.Resources.FC_Msg_Reaction);

                    FC_Msg_Reaction.Close();
                    FC_Msg_Reaction.Dispose();
                }
                #endregion
            }
        }

        private void dataGridViewMsg_Click(object sender, EventArgs e)
        {
            //hide New Table Buttons and TextBox
            buttonNewTable.Hide();
            labelSMNumber.Hide();
            textBoxSMNumber.Hide();
        }

        #endregion

        #region Metods

        public static void SetDatGridViewSMCol(DataGridView dataGridView, DataTable dataTable)
        {
            int SMColNb = 0;

            //Number of SM Coloumns in DataTable
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.Contains("Msg Reaction SM "))
                {
                    SMColNb++;
                }
            }

            //Set DataTable As DataGridView Source
            dataGridView.DataSource = dataTable;

            //Clear Coloumn On DatagridView
            dataGridView.Columns.Clear();

            //Add Same Coloumns To DataGridView but of a different Type
            dataGridView.Columns.Add("Nb", "Nb");
            dataGridView.Columns.Add("Device it", "Device it");
            dataGridView.Columns.Add("Device en", "Device en");
            dataGridView.Columns.Add("Device fr", "Device fr");
            dataGridView.Columns.Add("Device td", "Device td");
            dataGridView.Columns.Add("Device sp", "Device sp");
            dataGridView.Columns.Add("Msg Text it", "Msg Text it");
            dataGridView.Columns.Add("Msg Text en", "Msg Text en");
            dataGridView.Columns.Add("Msg Text fr", "Msg Text fr");
            dataGridView.Columns.Add("Msg Text td", "Msg Text td");
            dataGridView.Columns.Add("Msg Text sp", "Msg Text sp");
            dataGridView.Columns.Add("Info Text it", "Info Text it");
            dataGridView.Columns.Add("Info Text en", "Info Text en");
            dataGridView.Columns.Add("Info Text fr", "Info Text fr");
            dataGridView.Columns.Add("Info Text td", "Info Text td");
            dataGridView.Columns.Add("Info Text sp", "Info Text sp");

            DataGridViewComboBoxColumn columnAckReq = new DataGridViewComboBoxColumn();
            columnAckReq.Name = "Msg Class";
            columnAckReq.HeaderText = "Msg Class";
            columnAckReq.Items.Add("ACK");
            columnAckReq.Items.Add("NO_ACK");
            dataGridView.Columns.Add(columnAckReq);

            for (int i = 1; i <= SMColNb; i++)
            {
                string colName = "Msg Reaction SM " + i.ToString();
                DataGridViewComboBoxColumn columnReaction = new DataGridViewComboBoxColumn();
                columnReaction.Name = colName;
                columnReaction.HeaderText = colName;
                columnReaction.Items.Add("NONE");
                columnReaction.Items.Add("STORE");
                columnReaction.Items.Add("PAUSE");
                columnReaction.Items.Add("HALT");
                dataGridView.Columns.Add(columnReaction);
            }

            //Bind new Coloums To DataTable Coloumns
            dataGridView.Columns["Nb"].DataPropertyName = dataTable.Columns["Nb"].ToString();
            dataGridView.Columns["Device it"].DataPropertyName = dataTable.Columns["Device it"].ToString();
            dataGridView.Columns["Device en"].DataPropertyName = dataTable.Columns["Device en"].ToString();
            dataGridView.Columns["Device fr"].DataPropertyName = dataTable.Columns["Device fr"].ToString();
            dataGridView.Columns["Device td"].DataPropertyName = dataTable.Columns["Device td"].ToString();
            dataGridView.Columns["Device sp"].DataPropertyName = dataTable.Columns["Device sp"].ToString();
            dataGridView.Columns["Msg Text it"].DataPropertyName = dataTable.Columns["Msg Text it"].ToString();
            dataGridView.Columns["Msg Text en"].DataPropertyName = dataTable.Columns["Msg Text en"].ToString();
            dataGridView.Columns["Msg Text fr"].DataPropertyName = dataTable.Columns["Msg Text fr"].ToString();
            dataGridView.Columns["Msg Text td"].DataPropertyName = dataTable.Columns["Msg Text td"].ToString();
            dataGridView.Columns["Msg Text sp"].DataPropertyName = dataTable.Columns["Msg Text sp"].ToString();
            dataGridView.Columns["Info Text it"].DataPropertyName = dataTable.Columns["Info Text it"].ToString();
            dataGridView.Columns["Info Text en"].DataPropertyName = dataTable.Columns["Info Text en"].ToString();
            dataGridView.Columns["Info Text fr"].DataPropertyName = dataTable.Columns["Info Text fr"].ToString();
            dataGridView.Columns["Info Text td"].DataPropertyName = dataTable.Columns["Info Text td"].ToString();
            dataGridView.Columns["Info Text sp"].DataPropertyName = dataTable.Columns["Info Text sp"].ToString();
            dataGridView.Columns["Msg Class"].DataPropertyName = dataTable.Columns["Msg Class"].ToString();
            for (int i = 1; i <= SMColNb; i++)
            {
                dataGridView.Columns["Msg Reaction SM " + i.ToString()].DataPropertyName = dataTable.Columns["Msg Reaction SM " + i.ToString()].ToString();
            }

            dataGridView.Update();
        }

        #endregion

    }
}
