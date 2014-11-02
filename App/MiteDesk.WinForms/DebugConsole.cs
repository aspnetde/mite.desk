using System;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.WinForms.Localization;

namespace SixtyNineDegrees.MiteDesk.WinForms
{
    public partial class DebugConsole : Form
    {
        public DebugConsole(Exception exception)
        {
            
            InitializeComponent();
            LocalizeForm();

            textBox1.Text = "================================================================" + Environment.NewLine;
            textBox1.Text += "Version:" + Environment.NewLine;
            textBox1.Text += Helper.CurrentVersion + " (Build " + Helper.CurrentBuild + ")" + Environment.NewLine;
            textBox1.Text += "================================================================";
            textBox1.Text += Environment.NewLine + Environment.NewLine;

            textBox1.Text += "================================================================"+ Environment.NewLine;
            textBox1.Text += "Message:" + Environment.NewLine;
            textBox1.Text += exception.Message + Environment.NewLine;
            textBox1.Text += "================================================================";
            textBox1.Text += Environment.NewLine + Environment.NewLine;

            textBox1.Text += "================================================================"+ Environment.NewLine;
            textBox1.Text += "StackTrace:" + Environment.NewLine;
            textBox1.Text += exception.StackTrace + Environment.NewLine;
            textBox1.Text += "================================================================";
            textBox1.Text += Environment.NewLine + Environment.NewLine;

            textBox1.Text += "================================================================"+ Environment.NewLine;
            textBox1.Text += "HelpLink:" + Environment.NewLine;
            textBox1.Text += exception.HelpLink + Environment.NewLine;
            textBox1.Text += "================================================================";
            textBox1.Text += Environment.NewLine + Environment.NewLine;

            textBox1.Text += "================================================================"+ Environment.NewLine;
            textBox1.Text += "Source:" + Environment.NewLine;
            textBox1.Text += exception.Source + Environment.NewLine;
            textBox1.Text += "================================================================";
            textBox1.Text += Environment.NewLine + Environment.NewLine;

            textBox1.Text += "================================================================"+ Environment.NewLine;
            textBox1.Text += "TargetSite:" + Environment.NewLine;
            textBox1.Text += exception.TargetSite.Name + Environment.NewLine;
            textBox1.Text += "================================================================";
            textBox1.Text += Environment.NewLine + Environment.NewLine;

        }

        private void LocalizeForm()
        {
            Text = DebugConsoleLabels.FormTitle;
            groupBox1.Text = DebugConsoleLabels.GroupBoxTitle;
            button3.Text = DebugConsoleLabels.CopyToClipboardButton;
            button1.Text = DebugConsoleLabels.RestartButton;
            button2.Text = DebugConsoleLabels.OKButton;
            label1.Text = DebugConsoleLabels.LabelTitle;
            label2.Text = DebugConsoleLabels.LabelText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

    }
}
