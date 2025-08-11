using System;
using System.Linq;
using System.Windows.Forms;

namespace Calc
{
    public class A
    {
        public int x = 100500;
        public A()
        {

        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var a = new A[] { };
            var first = a.FirstOrDefault();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new Evaluator()));
        }
    }
}
