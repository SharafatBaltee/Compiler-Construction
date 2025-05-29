using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WordMatcher
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

            // Define regex to match words starting with 't' or 'm'
            Regex regex = new Regex(@"\b[tTmM][a-zA-Z0-9]*\b");

            // Clear DataGridView before adding new entries
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Matched Word";

            // Find matches in the input text
            MatchCollection matches = regex.Matches(input);

            // Add matched words to DataGridView
            foreach (Match match in matches)
            {
                dataGridView1.Rows.Add(match.Value);
            }

            // If no matches found, display a message
            if (matches.Count == 0)
            {
                MessageBox.Show("No matching words found!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
