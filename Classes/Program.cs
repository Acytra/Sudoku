using Sudoku.Classes;
using System;
using System.Windows.Forms;

public enum Number {
    Zero = 0,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine
}

namespace Sudoku {
    static class Program {
        [STAThread]
        static void Main() {
            ApplicationMethods();
            Form1 form1 = new Form1();
            Grid grid = new Grid();            
            Controller controller = new Controller(form1, grid);

            Application.Run(form1);
        }

        private static void ApplicationMethods() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
