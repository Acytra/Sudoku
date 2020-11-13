using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sudoku {
    public partial class Form1 : Form {
        private const Keys CopyKeys = Keys.Control | Keys.C;
        private const Keys PasteKeys = Keys.Control | Keys.V;

        public Dictionary<(int, int), TextBox> formGrid = new Dictionary<(int, int), TextBox>();
        public static event Action<Number, Number, Number> MatrixChangedEvent;

        public Form1() {
            InitializeComponent();

            #region Add textBox's to Dictionary

            formGrid.Add((1, 1), textBox1);
            formGrid.Add((1, 2), textBox2);
            formGrid.Add((1, 3), textBox3);
            formGrid.Add((1, 4), textBox4);
            formGrid.Add((1, 5), textBox5);
            formGrid.Add((1, 6), textBox6);
            formGrid.Add((1, 7), textBox7);
            formGrid.Add((1, 8), textBox8);
            formGrid.Add((1, 9), textBox9);
            formGrid.Add((2, 1), textBox10);
            formGrid.Add((2, 2), textBox11);
            formGrid.Add((2, 3), textBox12);
            formGrid.Add((2, 4), textBox13);
            formGrid.Add((2, 5), textBox14);
            formGrid.Add((2, 6), textBox15);
            formGrid.Add((2, 7), textBox16);
            formGrid.Add((2, 8), textBox17);
            formGrid.Add((2, 9), textBox18);
            formGrid.Add((3, 1), textBox19);
            formGrid.Add((3, 2), textBox20);
            formGrid.Add((3, 3), textBox21);
            formGrid.Add((3, 4), textBox22);
            formGrid.Add((3, 5), textBox23);
            formGrid.Add((3, 6), textBox24);
            formGrid.Add((3, 7), textBox25);
            formGrid.Add((3, 8), textBox26);
            formGrid.Add((3, 9), textBox27);
            formGrid.Add((4, 1), textBox28);
            formGrid.Add((4, 2), textBox29);
            formGrid.Add((4, 3), textBox30);
            formGrid.Add((4, 4), textBox31);
            formGrid.Add((4, 5), textBox32);
            formGrid.Add((4, 6), textBox33);
            formGrid.Add((4, 7), textBox34);
            formGrid.Add((4, 8), textBox35);
            formGrid.Add((4, 9), textBox36);
            formGrid.Add((5, 1), textBox37);
            formGrid.Add((5, 2), textBox38);
            formGrid.Add((5, 3), textBox39);
            formGrid.Add((5, 4), textBox40);
            formGrid.Add((5, 5), textBox41);
            formGrid.Add((5, 6), textBox42);
            formGrid.Add((5, 7), textBox43);
            formGrid.Add((5, 8), textBox44);
            formGrid.Add((5, 9), textBox45);
            formGrid.Add((6, 1), textBox46);
            formGrid.Add((6, 2), textBox47);
            formGrid.Add((6, 3), textBox48);
            formGrid.Add((6, 4), textBox49);
            formGrid.Add((6, 5), textBox50);
            formGrid.Add((6, 6), textBox51);
            formGrid.Add((6, 7), textBox52);
            formGrid.Add((6, 8), textBox53);
            formGrid.Add((6, 9), textBox54);
            formGrid.Add((7, 1), textBox55);
            formGrid.Add((7, 2), textBox56);
            formGrid.Add((7, 3), textBox57);
            formGrid.Add((7, 4), textBox58);
            formGrid.Add((7, 5), textBox59);
            formGrid.Add((7, 6), textBox60);
            formGrid.Add((7, 7), textBox61);
            formGrid.Add((7, 8), textBox62);
            formGrid.Add((7, 9), textBox63);
            formGrid.Add((8, 1), textBox64);
            formGrid.Add((8, 2), textBox65);
            formGrid.Add((8, 3), textBox66);
            formGrid.Add((8, 4), textBox67);
            formGrid.Add((8, 5), textBox68);
            formGrid.Add((8, 6), textBox69);
            formGrid.Add((8, 7), textBox70);
            formGrid.Add((8, 8), textBox71);
            formGrid.Add((8, 9), textBox72);
            formGrid.Add((9, 1), textBox73);
            formGrid.Add((9, 2), textBox74);
            formGrid.Add((9, 3), textBox75);
            formGrid.Add((9, 4), textBox76);
            formGrid.Add((9, 5), textBox77);
            formGrid.Add((9, 6), textBox78);
            formGrid.Add((9, 7), textBox79);
            formGrid.Add((9, 8), textBox80);
            formGrid.Add((9, 9), textBox81);

            #endregion
            
            foreach (KeyValuePair<(int, int), TextBox> textBox in formGrid) {
                textBox.Value.KeyPress += TextBox_KeyPress;
                textBox.Value.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) || int.Parse(e.KeyChar.ToString()) == 0)) {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;

            if (formGrid.ContainsValue(textBox)) {
                var (row, column) = formGrid.FirstOrDefault(x => x.Value == textBox).Key;
                Number newValue = 0;

                if (textBox.TextLength == 1) {
                    newValue = (Number)int.Parse(textBox.Text);
                }
                MatrixChangedEvent((Number)row, (Number)column, newValue);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {

            if ((keyData == CopyKeys) || (keyData == PasteKeys)) {
                return true;
            } else {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}