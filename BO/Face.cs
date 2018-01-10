using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubik.BO
{
    public class Face
    {
        public Cube Cube { get; set; }

        public Cell CellTop1 { get; set; }
        public Cell T2 { get; set; }
        public Cell T3 { get; set; }

        public Cell B1 { get; set; }
        public Cell B2 { get; set; }
        public Cell B3 { get; set; }

        public Cell R1 { get; set; }
        public Cell R2 { get; set; }
        public Cell R3 { get; set; }

        public Cell L1 { get; set; }
        public Cell L2 { get; set; }
        public Cell L3 { get; set; }

        public Cell[,] Cells = new Cell[4, 4];

        public Cell GetCell(int i){

            switch(i){
                case 1: return Cells[1, 1];
                case 2: return Cells[1, 2];
                case 3: return Cells[1, 3];
                case 4: return Cells[2, 1];
                case 5: return Cells[2, 2];
                case 6: return Cells[2, 3];
                case 7: return Cells[3, 1];
                case 8: return Cells[3, 2];
                case 9: return Cells[3, 3];
                default: return null;
            }
        }

        public void RotateInverse()
        {
            var firstColor = Cells[1, 1].Color;
            Cells[1, 1].Color = Cells[1, 3].Color;
            Cells[1, 3].Color = Cells[3, 3].Color;
            Cells[3, 3].Color = Cells[3, 1].Color;
            Cells[3, 1].Color = firstColor;

            firstColor = Cells[1, 2].Color;
            Cells[1, 2].Color = Cells[2, 3].Color;
            Cells[2, 3].Color = Cells[3, 2].Color;
            Cells[3, 2].Color = Cells[2, 1].Color;
            Cells[2, 1].Color = firstColor;

            firstColor = CellTop1.Color;
            CellTop1.Color = R1.Color;
            R1.Color = B1.Color;
            B1.Color = L1.Color;
            L1.Color = firstColor;

            firstColor = T2.Color;
            T2.Color = R2.Color;
            R2.Color = B2.Color;
            B2.Color = L2.Color;
            L2.Color = firstColor;

            firstColor = T3.Color;
            T3.Color = R3.Color;
            R3.Color = B3.Color;
            B3.Color = L3.Color;
            L3.Color = firstColor;
        }

        public void Rotate(){

            var firstColor = Cells[1, 1].Color;
            Cells[1, 1].Color = Cells[3, 1].Color;
            Cells[3, 1].Color = Cells[3, 3].Color;
            Cells[3, 3].Color = Cells[1, 3].Color;
            Cells[1, 3].Color = firstColor;

            firstColor = Cells[1, 2].Color;
            Cells[1, 2].Color = Cells[2, 1].Color;
            Cells[2, 1].Color = Cells[3, 2].Color;
            Cells[3, 2].Color = Cells[2, 3].Color;
            Cells[2, 3].Color = firstColor;

            firstColor = CellTop1.Color;
            CellTop1.Color = L1.Color;
            L1.Color = B1.Color;
            B1.Color = R1.Color;
            R1.Color = firstColor;

            firstColor = T2.Color;
            T2.Color = L2.Color;
            L2.Color = B2.Color;
            B2.Color = R2.Color;
            R2.Color = firstColor;

            firstColor = T3.Color;
            T3.Color = L3.Color;
            L3.Color = B3.Color;
            B3.Color = R3.Color;
            R3.Color = firstColor;
        }

        public int SolvedCount{
            get{
                int count = 1;

                if (Cells[1, 1].Color == Color && CellTop1.Color == CellTop1.Face.Color && L3.Color == L3.Face.Color)
                    count++;

                if (Cells[1, 2].Color == Color && T2.Color == T2.Face.Color)
                    count++;

                if (Cells[1, 3].Color == Color && T3.Color == T3.Face.Color && R1.Color == R1.Face.Color)
                    count++;

                if (Cells[2, 1].Color == Color && L2.Color == L2.Face.Color)
                    count++;
                
                if (Cells[2, 3].Color == Color && R2.Color == R2.Face.Color)
                    count++;
                
                if (Cells[3, 1].Color == Color && B3.Color == B3.Face.Color && L1.Color == L1.Face.Color)
                    count++;

                if (Cells[3, 2].Color == Color && B2.Color == B2.Face.Color)
                    count++;

                if (Cells[3, 3].Color == Color && B1.Color == B1.Face.Color && R3.Color == R3.Face.Color)
                    count++;

                return count;
            }
        }

        public Cell.CellColors Color { get; set; }

        private List<Cell> ListOfCells = new List<Cell>();

        public Face(Cell.CellColors color, Cube cube)
        {
            this.Cube = cube;
            this.Color = color;
            for (int row = 1; row <= 3; row++){
                for (int col = 1; col <= 3; col++){
                    Cells[row,col] = new Cell(this);
                    ListOfCells.Add(Cells[row, col]); 
                    Cells[row, col].Color = color;
                } 
            }
        }

        public override string ToString()
        {
            return String.Format("{1}{2}{3}{0}{4}{5}{6}{0}{7}{8}{9}", Environment.NewLine, Cells[1, 1], Cells[1, 2], Cells[1, 3],
                                Cells[2, 1], Cells[2, 2], Cells[2, 3],
                                 Cells[3, 1], Cells[3, 2], Cells[3, 3]); 
        }
    }
}
