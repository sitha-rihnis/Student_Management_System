using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace VTA_Interface.Forms
{
    public partial class Student_Enqueries : Form
    {
        public Student_Enqueries()
        {
            InitializeComponent();
            connect();
            dataGridView1.Visible = false;
        }

        MySqlConnection con;
        string db;
        void connect()
        {

            db = "server=localhost;user=root;pwd=;database=kasthury";
            con = new MySqlConnection(db);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   
            dataGridView1.Visible = true;
            if (txtsearch.Text == "") { dataGridView1.Visible = false; }

            if (cbatch.Text != "")
            {
                try
                {
                    con.Open();
                    string sql = "select  stdetail.stname as STUDENT_NAME,stdetail.mis as MIS_NO,stdetail.years as YEAR,stdetail.batch as BATCH,attand.totaldays as STUDENT_TOTAL_ATTANDANCE,attand.totalclassdays as TOTAL_CLASS_DAYS,attand.percentage as ATTANDANCE,payments.total as TOTAL_PAY,ojt.ojtplace as OJT_PLACE,final.theory as THEORY,final.practical as PRACTICAL,final.nvq as NVQ_LEVEL,final.indexno as INDEX_NO,stdetail.sts as DROPOUT from stdetail inner join attand on stdetail.stname=attand.stname inner join payments on stdetail.mis=payments.mis inner join ojt on stdetail.mis=ojt.mis inner join final on stdetail.mis=final.mis where (stdetail.batch ='" + cbatch.SelectedItem.ToString() + "' ) and (stdetail.stname like'%" + txtsearch.Text + "%' or stdetail.nic like'%" + txtsearch.Text + "%' or stdetail.mis like'%" + txtsearch.Text + "%'  or stdetail.years like'%" + txtsearch.Text + "%') ";
                    //MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //MySqlDataReader dr = cmd.ExecuteReader();

                    //while (dr.Read())
                    //{
                    //    lstname.Text = dr.GetString("stname");
                    //    lsttotdays.Text = dr.GetString("totaldays");
                    //    ltotclass.Text = dr.GetString("totalclassdays");


                    //}

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            else
            {
                try
                {
                    con.Open();
                    string sql = "select stdetail.stname as STUDENT_NAME,stdetail.mis as MIS_NO,stdetail.years as YEAR,stdetail.batch as BATCH,attand.totaldays as STUDENT_TOTAL_ATTANDANCE,attand.totalclassdays as TOTAL_CLASS_DAYS,attand.percentage as ATTANDANCE,payments.total as TOTAL_PAY,ojt.ojtplace as OJT_PLACE,final.theory as THEORY,final.practical as PRACTICAL,final.nvq as NVQ_LEVEL,final.indexno as INDEX_NO,stdetail.sts as DROPOUT from stdetail inner join attand on stdetail.mis=attand.mis inner join payments on stdetail.mis=payments.mis inner join ojt on stdetail.mis=ojt.mis inner join final on stdetail.mis=final.mis where  (stdetail.stname like'%" + txtsearch.Text + "%' or stdetail.nic like'%" + txtsearch.Text + "%' or stdetail.mis like'%" + txtsearch.Text + "%'  or stdetail.years like'%" + txtsearch.Text + "%') ";
                    //MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //MySqlDataReader dr = cmd.ExecuteReader();

                    //while (dr.Read())
                    //{
                    //    lstname.Text = dr.GetString("stname");
                    //    lsttotdays.Text = dr.GetString("totaldays");
                    //    ltotclass.Text = dr.GetString("totalclassdays");


                    //}

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }



            }

        }

        private void copytocb()
        {
            try
            {
                  
                dataGridView1.SelectAll();
                DataObject obj = dataGridView1.GetClipboardContent();

                if (obj != null)
                    Clipboard.SetDataObject(obj);
                else
                    MessageBox.Show("data is empty");

            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //DialogResult drSaveFile = sfd.ShowDialog();
            //try
            //{
            //    if (drSaveFile == System.Windows.Forms.DialogResult.OK)
            //    {
            //        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            //        ExcelApp.Application.Workbooks.Add(Type.Missing);

            //        //ExcelApp.ActiveWorkbook.FileFormat = XlFileFormat.xlExcel8;   
            //        // Change properties of the Workbook   
            //        ExcelApp.Columns.ColumnWidth = 20;

            //        // Storing header part in Excel   
            //        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            //        {
            //            ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            //        }

            //        // Storing Each row and column value to excel sheet   
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {
            //            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //            {
            //                if (j == 2 || j == 5)
            //                {
            //                    ExcelApp.Cells[i + 2, j + 1] = "'" + dataGridView1.Rows[i].Cells[j].Value.ToString();
            //                }
            //                else
            //                {
            //                    ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //                }
            //            }
            //        }

            //        //Save Copy by giving file Path   
            //        //ExcelApp.ActiveWorkbook.SaveCopyAs("C:\\" + FileName);   

            //        //OR using SaveFileDialog   
            //        ExcelApp.ActiveWorkbook.SaveCopyAs(sfd.FileName);

            //        //OR even you can use SaveAs function   
            //        //ExcelApp.ActiveWorkbook.SaveAs(sfd.FileName, XlFileFormat.xlExcel8, null, null, null,   
            //        // null, XlSaveAsAccessMode.xlShared, null, null, null, null, null);   
            //        ExcelApp.ActiveWorkbook.Saved = true;
            //        ExcelApp.Quit();
                        
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ERROR: " + ex.Message);
            //}


            //try{
            //    //if (dataGridView1.Rows.Count > 0)
            //    //{

            //try
            //{
               
            //    Microsoft.Office.Interop.Excel.Application xcelapp = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook workbook;
            //    Microsoft.Office.Interop.Excel.Worksheet worksheet;
            //    Microsoft.Office.Interop.Excel.Range xlrange;

            //    Object mv = System.Reflection.Missing.Value;
            //    xcelapp.Visible = true;
            //    workbook = xcelapp.Workbooks.Add(mv);
            //    worksheet = workbook.Worksheets.get_Item(1);

            //    xlrange = worksheet.Cells[1, 1];
            //    xlrange.Select();
            //    worksheet.PasteSpecial(xlrange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            //    {
            //        xcelapp.Cells[i, 1] = dataGridView1.Columns[1 - i].HeaderText;
            //    }

            //    // Storing Each row and column value to excel sheet   
            //    for (int i = 1; i < dataGridView1.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //        {
            //            if (j == 2 || j == 5)
            //            {
            //                xcelapp.Cells[i + 2, j + 1] = "'" + dataGridView1.Rows[i].Cells[j].Value.ToString();
            //            }
            //            else
            //            {
            //                xcelapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

            //            }


            //        }
            //        xcelapp.Columns.AutoFit();
            //        xcelapp.Visible = true;
            //        //return;
            //    }
            //}

            //catch (Exception ex)
            //{
            //    ////MessageBox.Show(ex.Message);

            //}
            //return;
            //SaveFileDialog sfd = new SaveFileDialog();

            //xcelapp.ActiveWorkbook.SaveCopyAs(sfd.FileName);
            ////xcelapp.Columns.AutoFit();
            //xcelapp.Visible = true;
            //var savefileDialoge = new SaveFileDialog();
            //savefileDialoge.FileName = "output";
            //savefileDialoge.DefaultExt = ".xlsx";
            //if (savefileDialoge.ShowDialog() == DialogResult.OK)
            //{
            //    workbook.SaveAs(savefileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //}
            //xcelapp.Quit();
            
            
           // xcelapp.Visible = true;

            // worksheet=workbook.Sheets["Sheet 1"];
            // worksheet = workbook.ActiveSheet;
            // worksheet.Name = "Student details";
            //// xcelapp.Application.Workbooks.Add(Type.Missing);

            // for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            // {
            //    worksheet.Cells[i, 1]=dataGridView1.Columns[i - 1].HeaderText;
            // }

            // for (int i = 0; i < dataGridView1.Rows.Count; i++)
            // {
            //     for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //     {
            //         worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //     }
            // }
            // xcelapp.Columns.AutoFit();
            // xcelapp.Visible = true;
            // var savefileDialoge = new SaveFileDialog();
            // savefileDialoge.FileName = "output";
            // savefileDialoge.DefaultExt = ".xlsx";
            // if (savefileDialoge.ShowDialog() == DialogResult.OK)
            // {
            //     workbook.SaveAs(savefileDialoge.FileName,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
            // }
            // xcelapp.Quit();

            //xcelapp.Columns.AutoFit();
            //xcelapp.Visible = true;
            //}

            //}

            //    catch(Exception ex){

            //        MessageBox.Show(ex.Message);
            //    }

            //}


            try
            {
                Microsoft.Office.Interop.Excel.Application xcelapp = new Microsoft.Office.Interop.Excel.Application();
                xcelapp.Application.Workbooks.Add(Type.Missing);

                //ExcelApp.ActiveWorkbook.FileFormat = XlFileFormat.xlExcel8;   
                // Change properties of the Workbook   
                xcelapp.Visible = true;
                // xcelapp.Columns.ColumnWidth = 20;
                xcelapp.Columns.AutoFit();

                // Storing header part in Excel   
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcelapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                // Storing Each row and column value to excel sheet   
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (j == 2 || j == 5)
                        {
                            xcelapp.Cells[i + 2, j + 1] = "'" + dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            xcelapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

            }

            catch (Exception ex)
            {
               // MessageBox.Show();

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

