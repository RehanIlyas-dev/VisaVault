using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using visavault_g43.BLL;
namespace visavault_g43
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AuthService.PopulateStaticData();
            Application.Run(new Form1());
        }
    }
}

