using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace SixtyNineDegrees.MiteDesk.WinForms
{
    public static class Helper
    {

        public static string CurrentVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
                       Assembly.GetExecutingAssembly().GetName().Version.Minor;
            }
        }

        public static string CurrentBuild
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.Build.ToString(); }
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
            }
        }

        public static void ValidateTextEnteredInComboBox(object sender, EventArgs e)
        {

            var comboBox = (ComboBox)sender;

            string text = comboBox.Text;

            if (string.IsNullOrEmpty(text) || text.Length == 0)
                return;

            foreach (ListItem item in comboBox.Items)
            {
                if (item.Text.ToLower().StartsWith(text.ToLower()))
                    return;
            }

            comboBox.Text = text.Substring(0, text.Length - 1);
            comboBox.Select(comboBox.Text.Length, 0);

        }

        public static string GetFormattedTimeText(int minutes)
        {
            return (minutes / 60).ToString().PadLeft(2, '0') + ":" + (minutes % 60).ToString().PadLeft(2, '0');
        }

        public static void StartBackgroundWorker(BackgroundWorker worker, object argument)
        {

            if(worker.IsBusy)
            {
                worker.CancelAsync();
                while (worker.IsBusy) 
                    Application.DoEvents();
            }

            if (argument != null)
                worker.RunWorkerAsync(argument);
            else
                worker.RunWorkerAsync();

        }

        public static void SetCulture(string culture)
        {
            var ci = new System.Globalization.CultureInfo(culture, false);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

    }

}
