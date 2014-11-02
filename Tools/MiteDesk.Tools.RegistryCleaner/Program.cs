using System;
using Microsoft.Win32;

namespace MiteDesk.Tools.RegistryCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Registry.CurrentUser.OpenSubKey("Software\\69 Grad") != null)
            {
                Registry.CurrentUser.DeleteSubKeyTree("Software\\69 Grad");
                Console.WriteLine("Aktion erfolgreich. Du kannst die Anwendung jetzt schließen.");
            }
            else
            {
                Console.WriteLine("Nichts zum Aufräumen gefunden. Du kannst die Anwendung jetzt schließen.");
            }
            Console.ReadLine();
        }
    }
}
