using System;
using CustomUtility_NET_F;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Drawing;

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

        #endregion


    }
}