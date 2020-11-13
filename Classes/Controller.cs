namespace Sudoku.Classes {
    class Controller {
        Form1 form;
        Grid grid;

        public Controller(Form1 form, Grid grid) {
            this.form = form;
            this.grid = grid;

            Form1.MatrixChangedEvent += UpdateModelGrid;
        }

        private void UpdateModelGrid(Number row, Number column, Number newValue) {
            grid.UpdateCell(row, column, newValue);
        }
    }
}