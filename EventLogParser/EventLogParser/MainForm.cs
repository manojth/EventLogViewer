using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EventLogParser
{
    public partial class MainForm : Form
    {
        private delegate void ShowMessageHandler(string msg);
        private delegate void ShowProgressHandler(int val, int max);

        ShowMessageHandler msgHandler;
        ShowProgressHandler pbHandler;

        private String filterString;

        DataSet ds;
        BindingSource bs;
        

        public MainForm()
        {
            InitializeComponent();
            filterString = txtFilter.Text;
            msgHandler = new ShowMessageHandler(ShowMsg);
            pbHandler = new ShowProgressHandler(UpdatePb);

            
        }

        // Exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void menuOpenLogFolder_Click(object sender, EventArgs e)
        {
            OpenLogFolder();
        }

        private void exportEventsToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                ExportEventsToCSV();
            }
        }


        // Open the log file
        private void OpenLogFolder()
        {
            
            // Show file open dialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Create a dataset for binding the data to the grid.
                ds = new DataSet("EventLog Entries");
                ds.Tables.Add("Events");
                ds.Tables["Events"].Columns.Add("Type");
                ds.Tables["Events"].Columns.Add("Date");
                ds.Tables["Events"].Columns.Add("Time");
                ds.Tables["Events"].Columns.Add("Source");
                ds.Tables["Events"].Columns.Add("Description");
                ds.Tables["Events"].Columns.Add("Category");
                ds.Tables["Events"].Columns.Add("EventID");
                ds.Tables["Events"].Columns.Add("User");
                ds.Tables["Events"].Columns.Add("System");
                // Start the processing as a background process
                worker.RunWorkerAsync(folderBrowserDialog1.SelectedPath);

            }
        }

        private void ExportEventsToCSV()
        {
            // Show file open dialog
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Create a dataset for binding the data to the grid.
                Console.WriteLine(saveFileDialog1.FileName);
                if ((dataGridView1 != null)&& (ds!=null))
                {
                    StreamWriter strWri = new StreamWriter(saveFileDialog1.FileName);

                    string strRowVal = "";
                    for (int i = 0; i < ds.Tables["Events"].Columns.Count; i++)
                    {
                        
                            if (strRowVal == "")
                            {
                                strRowVal = ds.Tables["Events"].Columns[i].ToString();
                            }
                            else
                            {
                                strRowVal = strRowVal + "," + ds.Tables["Events"].Columns[i].ToString();
                            }
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        
                        for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                        {
                            if (strRowVal == "")
                            {
                                strRowVal = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                strRowVal = strRowVal + "," + dataGridView1.Rows[i].Cells[j].Value;
                            }
                        }
                        strWri.WriteLine(strRowVal);
                    }
                    strWri.Close();
                }
                else
                    MessageBox.Show("Please load events from an evt file or folder");
               
            }
        }

        // Open the log file
        private void OpenFile()
        {
            // Show file open dialog
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a dataset for binding the data to the grid.
                ds = new DataSet("EventLog Entries");
                ds.Tables.Add("Events");
                ds.Tables["Events"].Columns.Add("Type");
                ds.Tables["Events"].Columns.Add("Date");
                ds.Tables["Events"].Columns.Add("Time");
                ds.Tables["Events"].Columns.Add("Source");
                ds.Tables["Events"].Columns.Add("Description");
                ds.Tables["Events"].Columns.Add("Category");
                ds.Tables["Events"].Columns.Add("EventID");
                ds.Tables["Events"].Columns.Add("User");
                ds.Tables["Events"].Columns.Add("System");
                // Start the processing as a background process
                worker.RunWorkerAsync(fileDialog.FileName);
            }
        }

        // Update the value of the progress bar.
        void UpdatePb(int val, int max)
        {
            this.pb.Value = (val * 100) / max;
        }

        // Event: A new event log record is parsed.
        void parser_OnFoundRecord(object[] items)
        {
            if (items[0].ToString().Equals(filterString))
            {
                ds.Tables[0].Rows.Add(items);
            }
        }

        // Event: Showing the progress 
        void parser_OnProgress(int val, int max)
        {
            this.Invoke(pbHandler, new object[] { val, max });
        }

        // Update the status bar message
        private void ShowMsg(string msg)
        {
            this.toolStripStatusLabel1.Text = msg;
        }

        // Event: Show the status bar message
        void parser_OnAction(string msg)
        {
            this.Invoke(msgHandler, new object[] { msg });
        }

        // Start the parsing of the file
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var parser = new CompositeParser();
            parser.OnAction += parser_OnAction;
            parser.OnProgress += parser_OnProgress;
            parser.OnFoundRecord += parser_OnFoundRecord;
            parser.Parse(e.Argument.ToString());
        }


        // Finished the parsing of the file.
        // Bind the dataset to the grid.
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bs = new BindingSource(ds, "Events");
            dataGridView1.DataSource = bs;
            this.Invoke(pbHandler, new object[] { 100, 100 });
        }



        // Finished the parsing of the file.
        // Bind the dataset to the grid.
       
        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        

        // Exit the application
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Show the description in a message box.
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dv = this.dataGridView1.SelectedRows[0];
                if (dv != null)
                {
                    MessageBox.Show(this, dv.Cells["Description"].Value.ToString().Replace('\0', '\n'), "Description", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            catch (Exception)
            {
            }
        }

        // Select the row when a cell is clicked
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            filterString = txtFilter.Text;
        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

       
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}