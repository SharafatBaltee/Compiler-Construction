using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScientificNotationChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get input from RichTextBox
            string input = richTextBox1.Text;
            string[] words = input.Split(' '); // Split input by spaces

            // Define regular expression for scientific notation
            Regex scientificRegex = new Regex(@"^\d+e[-]?\d+$");

            // Clear DataGridView before adding new entries
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Number";
            dataGridView1.Columns[1].Name = "Status";

            foreach (string word in words)
            {
                if (scientificRegex.IsMatch(word))
                {
                    dataGridView1.Rows.Add(word, "Valid");
                }
                else
                {
                    dataGridView1.Rows.Add(word, "Invalid");
                }
            }
        }
    }
}
