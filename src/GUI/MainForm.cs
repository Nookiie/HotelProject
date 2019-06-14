using Draw.src.Entities;
using Draw.src.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Върху главната форма е поставен потребителски контрол,
    /// в който се осъществява визуализацията
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            labelOperation.Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;

        }

        private void viewPort_Load(object sender, EventArgs e)
        {

        }

        private void ViewPortPaint(object sender, PaintEventArgs e)
        {

        }

        private void ViewPortMouseDown(object sender, MouseEventArgs e)
        {

        }

        private void ViewPortMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ViewPortMouseUp(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void viewPort_Load_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// От тук се импортират текстовите данни
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents|*.txt", Multiselect = false, ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader sr = new StreamReader(ofd.FileName);
                        textFile.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("No text file chosen");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string[] GetInputData()
        {
            string output = textFile.Text;

            output = output.Replace(";\r\n", ", ");
            string[] splits = Regex.Split(output, ", ", RegexOptions.Singleline);

            return splits;
        }

        /// <summary>
        /// От тук започва алгоритъма, ако има въведени данни
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            labelOperation.Visible = true;
            string from = textFrom.Text;
            string to = textTo.Text;
            string[] fileData = GetInputData();

            #region ErrorCheck
            if (textFile.Text.Length <= 3)
            {
                Error("TextFile Is Invalid");
                return;
            }

            if (radioExcept.Checked)
            {
                Error("Please Include One Of The Exceptions Below");
                return;
            }

            if (!radioSpecial.Checked && !radioOptimal.Checked && !radioExceptClimb.Checked && !radioExceptElevator.Checked && !radioExceptWalk.Checked)
            {
                Error("Please Select an Algorithm");
                return;
            }

            if (from == "" || to == "")
            {
                Error("Please Input Rooms (From, To)");
                return;
            }

            if (fileData.Length % 5 != 0)
            {
                Error("Invalid TextFile Format!");
                return;
            }

            #endregion

            // Console.WriteLine(GetInputData());

            Hotel hotel = new Hotel();

            for (int i = 0; i < fileData.Length; i += 5)
            {
                #region ErrorCheck
                if (!fileData[i + 4].Contains("room") && !fileData[i + 4].Contains("transit") && !fileData[i + 4].Contains("yes") && !fileData[i + 4].Contains("no"))
                {
                    Error("Invalid TextFile Format!");
                    return; // По-бърза проверка от един try-catch блок
                }
                #endregion

                if (fileData[i + 4].Contains("room") || fileData[i + 4].Contains("transit"))
                    hotel.AddRoomToHotel(new Room(fileData[i], fileData[i + 1], fileData[i + 2], fileData[i + 3], fileData[i + 4]));
                else if (fileData[i + 4].Contains("yes") || fileData[i + 4].Contains("no"))
                    hotel.CreateLink(fileData[i], fileData[i + 1], fileData[i + 2], fileData[i + 3], fileData[i + 4]);
                else
                    continue;
            }
            CoordinateSearch search = new CoordinateSearch(hotel);

            if (radioOptimal.Checked)
            {
                if (search.CheckForPathOptimal(from, to))
                    PathSuccess();
                else
                    PathFail();
            }

            else if (radioExceptClimb.Checked)
            {
                if (search.CheckForPathExceptType(from, to, ConnectionType.Climb))
                    PathSuccess();
                else
                    PathFail();
            }

            else if (radioExceptElevator.Checked)
            {
                if (search.CheckForPathExceptType(from, to, ConnectionType.Elevator))
                    PathSuccess();
                else
                    PathFail();
            }

            else if (radioExceptWalk.Checked)
            {
                if (search.CheckForPathExceptType(from, to, ConnectionType.Walk))
                    PathSuccess();
                else
                    PathFail();
            }

            else if (radioSpecial.Checked)
            {
                if (search.CheckForPathLiftOrClimbSpecial(from, to))
                    PathSuccess();
                else
                    PathFail();
            }
            else
            {
                Console.WriteLine("No Search Algorithm Selected!");
            }
        }

        private void radioExcept_CheckedChanged(object sender, EventArgs e)
        {
            if (radioExcept.Checked || radioExceptClimb.Checked || radioExceptElevator.Checked || radioExceptWalk.Checked)
            {
                radioExceptClimb.Visible = true;
                radioExceptElevator.Visible = true;
                radioExceptWalk.Visible = true;
            }
            else
            {
                radioExceptClimb.Visible = false;
                radioExceptElevator.Visible = false;
                radioExceptWalk.Visible = false;
            }
        }

        private void radioExceptElevator_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioExcept.Checked && !radioExceptClimb.Checked && !radioExceptElevator.Checked && !radioExceptWalk.Checked)
            {
                radioExceptClimb.Visible = false;
                radioExceptElevator.Visible = false;
                radioExceptWalk.Visible = false;
            }
        }

        private void radioExceptClimb_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioExcept.Checked && !radioExceptClimb.Checked && !radioExceptElevator.Checked && !radioExceptWalk.Checked)
            {
                radioExceptClimb.Visible = false;
                radioExceptElevator.Visible = false;
                radioExceptWalk.Visible = false;
            }
        }

        private void radioExceptWalk_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioExcept.Checked && !radioExceptClimb.Checked && !radioExceptElevator.Checked && !radioExceptWalk.Checked)
            {
                radioExceptClimb.Visible = false;
                radioExceptElevator.Visible = false;
                radioExceptWalk.Visible = false;
            }
        }

        private void PathSuccess()
        {
            string labelText = "Path Found!";

            labelOperation.Text = labelText;
            labelOperation.ForeColor = Color.DarkGreen;
            Console.WriteLine(labelText);
        }

        private void PathFail()
        {
            string labelText = "Path Not Found!";

            labelOperation.Text = labelText;
            labelOperation.ForeColor = Color.DarkOrange;
            Console.WriteLine(labelText);
        }

        private void Error(string labelText)
        {
            labelOperation.Text = labelText;
            labelOperation.ForeColor = Color.Red;
            Console.WriteLine(labelText);
        }

        private void labelTo_Click(object sender, EventArgs e)
        {

        }
    }
}
