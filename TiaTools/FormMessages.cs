using System;
using CustomUtility_NET_F;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;

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
            //Create new DataTable
            DataTable dataTable = new DataTable();

            //Add Columns To Data Table
            dataTable.Columns.Add("Nb");
            dataTable.Columns.Add("Device");
            dataTable.Columns.Add("Msg Text");
            dataTable.Columns.Add("Info Text");
            dataTable.Columns.Add("Ack Req");
            dataTable.Columns.Add("Msg Reaction SM 1");
            dataTable.Columns.Add("Msg Reaction SM 2");
            dataTable.Columns.Add("Msg Reaction SM 3");
            dataTable.Columns.Add("Msg Reaction SM 4");
            dataTable.Columns.Add("Msg Reaction SM 5");
            dataTable.Columns.Add("Msg Reaction SM 6");
            dataTable.Columns.Add("Msg Store For All");

            //Set DataTable As DataGridView Source
            dataGridViewMsg.DataSource = dataTable;

            //Clear Coloumn On DatagridView
            dataGridViewMsg.Columns.Clear();

            //Add Same Coloumns To DataGridView but of a different Type
            dataGridViewMsg.Columns.Add("Nb", "Nb");

            dataGridViewMsg.Columns.Add("Device", "Device");

            dataGridViewMsg.Columns.Add("Msg Text","Msg Text");

            dataGridViewMsg.Columns.Add("Info Text", "Info Text");

            DataGridViewComboBoxColumn columnAckReq = new DataGridViewComboBoxColumn();
            columnAckReq.Name = "Ack Req";
            columnAckReq.HeaderText = "Ack Req";
            columnAckReq.Items.Add("True");
            columnAckReq.Items.Add("False");
            dataGridViewMsg.Columns.Add(columnAckReq);

            DataGridViewComboBoxColumn columnReactionSM1 = new DataGridViewComboBoxColumn();
            columnReactionSM1.Name = "Msg Reaction SM 1";
            columnReactionSM1.HeaderText = "Msg Reaction SM 1";
            columnReactionSM1.Items.Add("NONE");
            columnReactionSM1.Items.Add("PAUSE");
            columnReactionSM1.Items.Add("HALT");
            dataGridViewMsg.Columns.Add(columnReactionSM1);

            DataGridViewComboBoxColumn columnReactionSM2 = new DataGridViewComboBoxColumn();
            columnReactionSM2.Name = "Msg Reaction SM 2";
            columnReactionSM2.HeaderText = "Msg Reaction SM 2";
            columnReactionSM2.Items.Add("NONE");
            columnReactionSM2.Items.Add("PAUSE");
            columnReactionSM2.Items.Add("HALT");
            dataGridViewMsg.Columns.Add(columnReactionSM2);

            DataGridViewComboBoxColumn columnReactionSM3 = new DataGridViewComboBoxColumn();
            columnReactionSM3.Name = "Msg Reaction SM 3";
            columnReactionSM3.HeaderText = "Msg Reaction SM 3";
            columnReactionSM3.Items.Add("NONE");
            columnReactionSM3.Items.Add("PAUSE");
            columnReactionSM3.Items.Add("HALT");
            dataGridViewMsg.Columns.Add(columnReactionSM3);

            DataGridViewComboBoxColumn columnReactionSM4 = new DataGridViewComboBoxColumn();
            columnReactionSM4.Name = "Msg Reaction SM 4";
            columnReactionSM4.HeaderText = "Msg Reaction SM 4";
            columnReactionSM4.Items.Add("NONE");
            columnReactionSM4.Items.Add("PAUSE");
            columnReactionSM4.Items.Add("HALT");
            dataGridViewMsg.Columns.Add(columnReactionSM4);

            DataGridViewComboBoxColumn columnReactionSM5 = new DataGridViewComboBoxColumn();
            columnReactionSM5.Name = "Msg Reaction SM 5";
            columnReactionSM5.HeaderText = "Msg Reaction SM 5";
            columnReactionSM5.Items.Add("NONE");
            columnReactionSM5.Items.Add("PAUSE");
            columnReactionSM5.Items.Add("HALT");
            dataGridViewMsg.Columns.Add(columnReactionSM5);

            DataGridViewComboBoxColumn columnReactionSM6 = new DataGridViewComboBoxColumn();
            columnReactionSM6.Name = "Msg Reaction SM 6";
            columnReactionSM6.HeaderText = "Msg Reaction SM 6";
            columnReactionSM6.Items.Add("NONE");
            columnReactionSM6.Items.Add("PAUSE");
            columnReactionSM6.Items.Add("HALT");
            dataGridViewMsg.Columns.Add(columnReactionSM6);

            DataGridViewComboBoxColumn columnStoreAll = new DataGridViewComboBoxColumn();
            columnStoreAll.Name = "Msg Store For All";
            columnStoreAll.HeaderText = "Msg Store For All";
            columnStoreAll.Items.Add("True");
            columnStoreAll.Items.Add("False");
            dataGridViewMsg.Columns.Add(columnStoreAll);

            //Bind new Coloums To DataTable Coloumns
            dataGridViewMsg.Columns["Nb"].DataPropertyName = dataTable.Columns["Nb"].ToString();
            dataGridViewMsg.Columns["Device"].DataPropertyName = dataTable.Columns["Device"].ToString();
            dataGridViewMsg.Columns["Msg Text"].DataPropertyName = dataTable.Columns["Msg Text"].ToString();
            dataGridViewMsg.Columns["Info Text"].DataPropertyName = dataTable.Columns["Info Text"].ToString();
            dataGridViewMsg.Columns["Ack Req"].DataPropertyName = dataTable.Columns["Ack Req"].ToString();
            dataGridViewMsg.Columns["Msg Reaction SM 1"].DataPropertyName = dataTable.Columns["Msg Reaction SM 1"].ToString();
            dataGridViewMsg.Columns["Msg Reaction SM 2"].DataPropertyName = dataTable.Columns["Msg Reaction SM 2"].ToString();
            dataGridViewMsg.Columns["Msg Reaction SM 3"].DataPropertyName = dataTable.Columns["Msg Reaction SM 3"].ToString();
            dataGridViewMsg.Columns["Msg Reaction SM 4"].DataPropertyName = dataTable.Columns["Msg Reaction SM 4"].ToString();
            dataGridViewMsg.Columns["Msg Reaction SM 5"].DataPropertyName = dataTable.Columns["Msg Reaction SM 5"].ToString();
            dataGridViewMsg.Columns["Msg Reaction SM 6"].DataPropertyName = dataTable.Columns["Msg Reaction SM 6"].ToString();
            dataGridViewMsg.Columns["Msg Store For All"].DataPropertyName = dataTable.Columns["Msg Store For All"].ToString();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
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
            dataGridViewMsg.DataSource = ExcelDataTable.ImportExcelToDataTable(textBoxImportFilePath.Text, comboBoxSheetList.SelectedIndex);
            dataGridViewMsg.Update();
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
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
                    DataTable dataTable = new DataTable();
                    dataGridViewMsg.EndEdit();
                    dataTable = (DataTable)dataGridViewMsg.DataSource;
                    ExcelDataTable.ExportDataTableToExcel(dataTable, Path.GetFullPath(saveFileDialog.FileName), "Messages");
                }
            }
        }

        #endregion

    }
}
