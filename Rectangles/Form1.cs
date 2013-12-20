using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Rectangles
{
    public partial class Rectangles : Form
    {
        #region Variables
        // list of type Rectangle to hold all rectangle data
        List<Rectangle> myrectangles = new List<Rectangle>();
        // string to hold file path and name
        private const string File_Rectangle = "c:\\rectangles.csv";
        #endregion

        #region Constructor
        public Rectangles()
        {
            InitializeComponent();
            // load combo box
            LoadNumberRectanglesComboBox();
        }
        #endregion

        /// <summary>
        /// Load combo box with values 3-30 only
        /// </summary>
        private void LoadNumberRectanglesComboBox()
        {
            // load only numbers 3-30 into combo box for selection
            for (int i = 3; i <= 30; i++)
            {
                this.cbNumRectangles.Items.Add(i);
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            GenerateRandomRectangles();
            SaveRandomRectanglesToFile();
        }

        /// <summary>
        /// Create csv file with rectangle data
        /// </summary>
        private void SaveRandomRectanglesToFile()
        {
            // initialise string builder
            StringBuilder csvRectangle = new StringBuilder();
            // add header to string
            csvRectangle.AppendLine("\"ID\",\"WIDTH\",\"HEIGHT\"");
            // add rectangle data
            foreach (Rectangle rect in myrectangles)
            {
                csvRectangle.AppendLine(
                    string.Format("\"{0}\",\"{1}\",\"{2}\"",
                    rect.Id, rect.Width, rect.Height));
            }

            // save to csv file
            StreamWriter sw = new StreamWriter(File_Rectangle, false);
            sw.Write(csvRectangle.ToString());
            sw.Close();
        }

        /// <summary>
        /// Generate random rectangles and add to object of type list
        /// </summary>
        private void GenerateRandomRectangles()
        {
            if (cbNumRectangles.SelectedIndex > -1)
            {
                //clear all items from list before generating new rectangles
                myrectangles.Clear();
                // get number of rectangles to generate
                int NoRectanglesToGenerate = int.Parse(cbNumRectangles.Text);
                // initialise random number generator class
                Random rnd = new Random();
                // loop through and generate selected number of rectangles
                for (int i = 0; i < NoRectanglesToGenerate; i++)
                {
                    // initialise rectangle class
                    Rectangle rectangle = new Rectangle();
                    // set properties
                    rectangle.Id = Guid.NewGuid();
                    // random number with a maximum of 100
                    rectangle.Width = rnd.Next(100);
                    rectangle.Height = rnd.Next(100);
                    // add rectangle to list of type Rectangle
                    myrectangles.Add(rectangle);
                }
            }
            else
            {
                MessageBox.Show("Please select number of rectangles", "Alert", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Method uses Visual Basic TextFieldParser class to retrieve data from the csv file.
        /// </summary>
        /// <param name="csv_file_path">The path to the csv file</param>
        /// <returns></returns>
        private static DataTable GetDataFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        datacolumn.AllowDBNull = true;
                        csvData.Columns.Add(datacolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception)
            {
            }
            return csvData;
        }

        private void btnDrawFromFile_Click(object sender, EventArgs e)
        {
            // call pnlDisplay_Paint method
            pnlDisplay.Invalidate();
        }

        /// <summary>
        /// Panel draw event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDisplay_Paint(object sender, PaintEventArgs e)
        {
            // datatable to hold rectangle data
            DataTable dtRectangleData = new DataTable();
            dtRectangleData.TableName = "TableRectangles";

            // get data from file into datatable type
            dtRectangleData = GetDataFromCSVFile(File_Rectangle);

            // calculate and add area column to datatable then sort by area column asc
            dtRectangleData = SortByArea(dtRectangleData);

            int XCoOrdinate = 0;
           
            foreach (DataRow dr in dtRectangleData.Rows)
            {
                int Width = int.Parse(dr["WIDTH"].ToString());
                int Height = int.Parse(dr["HEIGHT"].ToString());

                System.Drawing.Point location = new System.Drawing.Point(XCoOrdinate, 0);
                System.Drawing.Size size = new System.Drawing.Size(Width, Height);

                e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(location, size));

                XCoOrdinate += Width;
            }
        }

        /// <summary>
        /// Add area column onto datatable, calculate and store area into column, sort by column, return sorted datatable
        /// </summary>
        /// <param name="dt">Datatable to be sorted by area</param>
        /// <returns></returns>
        private DataTable SortByArea(DataTable dt)
        {
            dt.TableName = "TableRectangles";

            // create new data column for area
            DataColumn dc = new DataColumn();
            dc.ColumnName = "AREA";
            dc.DataType = typeof(System.Int32);
            dt.Columns.Add(dc);
            dt.AcceptChanges();

            // loop through rows to add data for area column
            foreach (DataRow dr in dt.Rows)
            {
               int Width = int.Parse(dr["WIDTH"].ToString());
               int Height = int.Parse(dr["HEIGHT"].ToString());
               dr["AREA"] = (Width * Height).ToString();
               dr.AcceptChanges();
            }

            dt.AcceptChanges();
            
            // create dataview to sort datatable by area column
            DataView _dv = new DataView();
            _dv.Table = dt;
            _dv.Sort = "AREA";
            return _dv.ToTable();
        }
    }
}
