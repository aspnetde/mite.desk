using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.WinForms
{

    static class Program
    {

        private static Main MainForm;

        [STAThread]
        static void Main()
        {

            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrapper.Initialize();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.ApplicationExit += Application_ApplicationExit;
            MainForm = new Main();
			try
			{
				MainForm.Initialize();	
			}
            catch(MiteConnectorException e)
            {
            	HandleException(e);
            }
            Application.Run(MainForm);
            
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            SingleInstance.Stop();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        static void Application_ThreadException(object sender,ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void HandleException(Exception e)
        {
            if (e is MiteConnectorException)
            {
                MainForm.NotifyAboutNetworkErrorAndDisableForm(e as MiteConnectorException);
            }
            else
            {
                new DebugConsole(e).ShowDialog();
            }
        }

    }

    static public class WinApi
    {
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string message = String.Format(format, args);
            return RegisterWindowMessage(message);
        }

        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("User32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, int swCommand);

    }

    static public class ProgramInfo
    {
        static public string AssemblyGuid
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((GuidAttribute)attributes[0]).Value;
            }
        }
    } 

    static public class SingleInstance
    {

        public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramInfo.AssemblyGuid);
        static Mutex mutex;

        static public bool Start()
        {
            bool onlyInstance;
            string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);
            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }

        static public void ShowFirstInstance()
        {
            WinApi.PostMessage((IntPtr)WinApi.HWND_BROADCAST, WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);
        }

        static public void Stop()
        {
            mutex.ReleaseMutex();
        }

    }

}
