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

        private void buttonNewTable_Click(object sender, EventArgs e)
        {
            //Create new DataTable
            DataTable dataTable = new DataTable();

            //Add Columns To Data Table
            dataTable.Columns.Add("Nb");
            dataTable.Columns.Add("Device");
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
            dataTable.Columns.Add("Ack Req");
            for (int i = 1; i <= Int32.Parse(textBoxSMNumber.Text); i++)
            {
                dataTable.Columns.Add("Msg Reaction SM " + i.ToString());
            }
            dataTable.Columns.Add("Msg Store For All");

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
                        worksheet.Cells[1, 1] = "Message Text it";
                        worksheet.Cells[1, 2] = "Message Text en";
                        worksheet.Cells[1, 3] = "Message Text fr";
                        worksheet.Cells[1, 4] = "Message Text td";
                        worksheet.Cells[1, 5] = "Message Text sp";
                        worksheet.Cells[1, 6] = "Info Text it";
                        worksheet.Cells[1, 7] = "Info  Text en";
                        worksheet.Cells[1, 8] = "Info  Text fr";
                        worksheet.Cells[1, 9] = "Info  Text td";
                        worksheet.Cells[1, 10] = "Info  Text sp";
                        worksheet.Cells[1, 11] = "Message Class";

                        for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
                        {
                            worksheet.Cells[i + 2, 1] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " / " + "Device" + " : " + dataTable.Rows[i]["Device"] + " -> " + dataTable.Rows[i]["Msg Text it"];
                            worksheet.Cells[i + 2, 2] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " / " + "Device" + " : " + dataTable.Rows[i]["Device"] + " -> " + dataTable.Rows[i]["Msg Text en"]; ;
                            worksheet.Cells[i + 2, 3] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " / " + "Device" + " : " + dataTable.Rows[i]["Device"] + " -> " + dataTable.Rows[i]["Msg Text fr"]; ;
                            worksheet.Cells[i + 2, 4] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " / " + "Device" + " : " + dataTable.Rows[i]["Device"] + " -> " + dataTable.Rows[i]["Msg Text td"]; ;
                            worksheet.Cells[i + 2, 5] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " / " + "Device" + " : " + dataTable.Rows[i]["Device"] + " -> " + dataTable.Rows[i]["Msg Text sp"]; ;
                            worksheet.Cells[i + 2, 6] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " Info : " + dataTable.Rows[i]["Info Text it"];
                            worksheet.Cells[i + 2, 7] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " Info : " + dataTable.Rows[i]["Info Text en"]; ;
                            worksheet.Cells[i + 2, 8] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " Info : " + dataTable.Rows[i]["Info Text fr"]; ;
                            worksheet.Cells[i + 2, 9] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " Info : " + dataTable.Rows[i]["Info Text td"]; ;
                            worksheet.Cells[i + 2, 10] = "Msg Nb" + " : " + dataTable.Rows[i]["Nb"] + " Info : " + dataTable.Rows[i]["Info Text sp"]; ;
                            worksheet.Cells[i + 2, 11] = "Message Class";
                            if (dataTable.Rows[i]["Ack Req"].ToString() == "True")
                            {
                                worksheet.Cells[i + 2, 11] = "Acknowledgement";
                            }
                            else
                            {
                                worksheet.Cells[i + 2, 11] = "No Acknowledgement";
                            }
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
                    StreamWriter FB_Msg_Handler = new StreamWriter(filePath + @"\FB_Msg_Handler.scl", false);

                    //Body
                    FB_Msg_Handler.WriteLine(@"FUNCTION_BLOCK ""FB_Msg_Handler""
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1
   VAR_INPUT
      ""Msg_ACK"" : Bool;
   END_VAR

   VAR_IN_OUT
      Msg : ""Msg"";
   END_VAR

   VAR ");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        FB_Msg_Handler.WriteLine("      Msg_" + row["Nb"] + " " + "{InstructionName := 'Program_Alarm'; LibVersion := '1.0'} : Program_Alarm;");
                    }
                    FB_Msg_Handler.WriteLine("      ACK_ALARMS_ERROR { ExternalAccessible := 'False'; ExternalVisible := 'False'; ExternalWritable := 'False'} : Bool;");
                    FB_Msg_Handler.WriteLine("      ACK_ALARM_STATUS { ExternalAccessible:= 'False'; ExternalVisible:= 'False'; ExternalWritable:= 'False'} : Word;");
                    FB_Msg_Handler.WriteLine("   END_VAR");
                    FB_Msg_Handler.Write("\n");
                    FB_Msg_Handler.Write("\n");
                    FB_Msg_Handler.WriteLine("BEGIN");
                    FB_Msg_Handler.WriteLine("//********************************************************************//");
                    FB_Msg_Handler.WriteLine("//Name: FB_Msg_Handler");
                    FB_Msg_Handler.WriteLine("//Version: x.x");
                    FB_Msg_Handler.WriteLine("//Description: xxx");
                    FB_Msg_Handler.WriteLine("//Developer: Topcast");
                    FB_Msg_Handler.WriteLine("//********************************************************************//");
                    FB_Msg_Handler.Write("\n");
                    FB_Msg_Handler.Write("\n");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        FB_Msg_Handler.WriteLine("// Msg " + row["Nb"]);
                        FB_Msg_Handler.WriteLine("//********************************************************************//");
                        FB_Msg_Handler.WriteLine("#Msg_" + row["Nb"] + "(SIG := #Msg.msg[" + row["Nb"] + "].Trigger,");
                        FB_Msg_Handler.WriteLine("\t" + "SD_1 := #Msg.msg[" + row["Nb"] + "].Config.Nb);");
                        FB_Msg_Handler.Write("\n");
                        FB_Msg_Handler.WriteLine("\"" + "FC_Msg_Get_Status" + "\"" + "(MsgInstance := #Msg_" + row["Nb"] + ",");
                        FB_Msg_Handler.WriteLine("\t" + "\t" + "\t" + "MsgMaxSM:= #Msg.MsgMaxSM,");
                        FB_Msg_Handler.WriteLine("\t" + "\t" + "\t" + "MsgBase:= #Msg.Msg["+ row["Nb"] + "]);");
                        FB_Msg_Handler.Write("\n");
                    }
                    FB_Msg_Handler.WriteLine("//Message Reaction");
                    FB_Msg_Handler.WriteLine("//********************************************************************//");
                    FB_Msg_Handler.WriteLine("\"" + "FC_Msg_Reaction" + "\"" + "(#Msg);");
                    FB_Msg_Handler.Write("\n");
                    FB_Msg_Handler.WriteLine("//Message ACK");
                    FB_Msg_Handler.WriteLine("//********************************************************************//");
                    FB_Msg_Handler.WriteLine("Ack_Alarms(MODE := BOOL_TO_UINT(#Msg_ACK AND #ACK_ALARM_STATUS = 0),");
                    FB_Msg_Handler.WriteLine("\t" + "ERROR => #ACK_ALARMS_ERROR,");
                    FB_Msg_Handler.WriteLine("\t" + "STATUS => #ACK_ALARM_STATUS);");
                    FB_Msg_Handler.Write("\n");
                    FB_Msg_Handler.Write("\n");
                    FB_Msg_Handler.WriteLine("END_FUNCTION_BLOCK");

                    FB_Msg_Handler.Close();
                }
                #endregion

                #region FC_Msg_Config
                if (checkBoxFCMsgConfig.Checked)
                {
                    //New Stream For FC_Msg_Trigger
                    StreamWriter FC_Msg_Config = new StreamWriter(filePath + @"\FC_Msg_Config.scl", false);

                    //Body
                    FC_Msg_Config.WriteLine(@"FUNCTION ""FC_Msg_Config"" : Void
{ S7_Optimized_Access := 'TRUE' }
VERSION : 0.1
   VAR CONSTANT
      NONE : Usint:= 0;
      PAUSE : Usint:= 1;
      HALT : Usint:= 2;
   END_VAR


BEGIN");
                    FC_Msg_Config.WriteLine("//********************************************************************//");
                    FC_Msg_Config.WriteLine("//Name: FC_Msg_Config");
                    FC_Msg_Config.WriteLine("//Version: x.x");
                    FC_Msg_Config.WriteLine("//Description: xxx");
                    FC_Msg_Config.WriteLine("//Developer: Topcast");
                    FC_Msg_Config.WriteLine("//********************************************************************//");
                    FC_Msg_Config.Write("\n");
                    FC_Msg_Config.Write("\n");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        FC_Msg_Config.WriteLine("// Msg " + row["Nb"]);
                        FC_Msg_Config.WriteLine("//********************************************************************//");
                        FC_Msg_Config.WriteLine(@"""DB_Msg"".Msg.Msg[" + row["Nb"] + "].Config.Nb := " + row["Nb"] + ";");
                        if (row["Msg Store For All"].ToString() == "True")
                        {
                            FC_Msg_Config.WriteLine(@"""DB_Msg"".Msg.Msg[" + row["Nb"] + "].Config.StoreForAll := 1;");
                        } else
                        {
                            FC_Msg_Config.WriteLine(@"""DB_Msg"".Msg.Msg[" + row["Nb"] + "].Config.StoreForAll := 0;");
                        }
                        for (int i = 1; i <= 6; i++)
                        {
                            FC_Msg_Config.WriteLine(@"""DB_Msg"".Msg.Msg[" + row["Nb"] + "].Config.Reaction[" + i + "] := " + row["Msg Reaction SM " + i] + ";");
                        }
                        FC_Msg_Config.Write("\n");
                    }
                    FC_Msg_Config.WriteLine("//Gen Config");
                    FC_Msg_Config.WriteLine("//********************************************************************//");
                    FC_Msg_Config.WriteLine(@"""DB_Msg"".Msg.MsgMaxNb := 300;");
                    FC_Msg_Config.WriteLine(@"""DB_Msg"".Msg.MsgMaxSM := 6;");
                    FC_Msg_Config.Write("\n");
                    FC_Msg_Config.WriteLine("END_FUNCTION");

                    FC_Msg_Config.Close();
                }
                #endregion

                #region FC_Msg_Trigger
                if (checkBoxFCMsgTrigger.Checked)
                {
                    //New Stream For FC_Msg_Trigger
                    StreamWriter FC_Msg_Trigger = new StreamWriter(filePath + @"\FC_Msg_Trigger.scl", false);

                    //Body
                    FC_Msg_Trigger.WriteLine(@"FUNCTION ""FC_Msg_Trigger"" : Void
{ S7_Optimized_Access:= 'TRUE' }
VERSION: 0.1

BEGIN");
                    FC_Msg_Trigger.WriteLine("//********************************************************************//");
                    FC_Msg_Trigger.WriteLine("//Name: FC_Msg_Trigger");
                    FC_Msg_Trigger.WriteLine("//Version: x.x");
                    FC_Msg_Trigger.WriteLine("//Description: xxx");
                    FC_Msg_Trigger.WriteLine("//Developer: Topcast");
                    FC_Msg_Trigger.WriteLine("//********************************************************************//");
                    FC_Msg_Trigger.Write("\n");
                    FC_Msg_Trigger.Write("\n");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        FC_Msg_Trigger.WriteLine("// Msg " + row["Nb"]);
                        FC_Msg_Trigger.WriteLine("//********************************************************************//");
                        FC_Msg_Trigger.WriteLine(@"""DB_Msg"".Msg.Msg[" + row["Nb"] + "].Trigger := FALSE;");
                        FC_Msg_Trigger.Write("\n");
                    }
                    FC_Msg_Trigger.WriteLine("END_FUNCTION");

                    FC_Msg_Trigger.Close();
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
            dataGridView.Columns.Add("Device", "Device");
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
            columnAckReq.Name = "Ack Req";
            columnAckReq.HeaderText = "Ack Req";
            columnAckReq.Items.Add("True");
            columnAckReq.Items.Add("False");
            dataGridView.Columns.Add(columnAckReq);

            for (int i = 1; i <= SMColNb; i++)
            {
                string colName = "Msg Reaction SM " + i.ToString();
                DataGridViewComboBoxColumn columnReaction = new DataGridViewComboBoxColumn();
                columnReaction.Name = colName;
                columnReaction.HeaderText = colName;
                columnReaction.Items.Add("NONE");
                columnReaction.Items.Add("PAUSE");
                columnReaction.Items.Add("HALT");
                dataGridView.Columns.Add(columnReaction);
            }

            DataGridViewComboBoxColumn columnStoreAll = new DataGridViewComboBoxColumn();
            columnStoreAll.Name = "Msg Store For All";
            columnStoreAll.HeaderText = "Msg Store For All";
            columnStoreAll.Items.Add("True");
            columnStoreAll.Items.Add("False");
            dataGridView.Columns.Add(columnStoreAll);

            //Bind new Coloums To DataTable Coloumns
            dataGridView.Columns["Nb"].DataPropertyName = dataTable.Columns["Nb"].ToString();
            dataGridView.Columns["Device"].DataPropertyName = dataTable.Columns["Device"].ToString();
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
            dataGridView.Columns["Ack Req"].DataPropertyName = dataTable.Columns["Ack Req"].ToString();
            for (int i = 1; i <= SMColNb; i++)
            {
                dataGridView.Columns["Msg Reaction SM " + i.ToString()].DataPropertyName = dataTable.Columns["Msg Reaction SM " + i.ToString()].ToString();
            }
            dataGridView.Columns["Msg Store For All"].DataPropertyName = dataTable.Columns["Msg Store For All"].ToString();

            dataGridView.Update();
        }

        #endregion

    }
}
