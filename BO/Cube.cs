using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubik.BO
{
    public class Cube
    {
        public Face FaceFront { get; set; } 
        public Face FaceTop { get; set; }
        public Face FaceLeft { get; set; }
        public Face FaceBack { get; set; }
        public Face FaceRight { get; set; }
        public Face FaceBottom { get; set; }

        public List<Face> Faces = new List<Face>();

        public int SolvedCount{
            get{
                return Faces.Sum(o => o.SolvedCount);
            }
        }

        public Cube()
        { 
            FaceFront = new Face(Cell.CellColors.O, this);
            FaceTop   = new Face(Cell.CellColors.W, this);
            FaceLeft  = new Face(Cell.CellColors.B, this);
            FaceBack = new Face(Cell.CellColors.R, this);
            FaceRight = new Face(Cell.CellColors.G, this);
            FaceBottom = new Face(Cell.CellColors.Y, this);
            
            Faces.Add(FaceFront);
            Faces.Add(FaceBack);
            Faces.Add(FaceTop);
            Faces.Add(FaceBottom);
            Faces.Add(FaceLeft);
            Faces.Add(FaceRight); 

            FaceLeft.CellTop1 = FaceTop.GetCell(1);
            FaceLeft.T2 = FaceTop.GetCell(4);
            FaceLeft.T3 = FaceTop.GetCell(7);
            FaceLeft.R1 = FaceFront.GetCell(1);
            FaceLeft.R2 = FaceFront.GetCell(4);
            FaceLeft.R3 = FaceFront.GetCell(7);
            FaceLeft.B1 = FaceBottom.GetCell(1);
            FaceLeft.B2 = FaceBottom.GetCell(4);
            FaceLeft.B3 = FaceBottom.GetCell(7);
            FaceLeft.L1 = FaceBack.GetCell(9);
            FaceLeft.L2 = FaceBack.GetCell(6);
            FaceLeft.L3 = FaceBack.GetCell(3);

            FaceBottom.CellTop1 = FaceFront.GetCell(7);
            FaceBottom.T2 = FaceFront.GetCell(8);
            FaceBottom.T3 = FaceFront.GetCell(9);
            FaceBottom.R1 = FaceRight.GetCell(7);
            FaceBottom.R2 = FaceRight.GetCell(8);
            FaceBottom.R3 = FaceRight.GetCell(9);
            FaceBottom.B1 = FaceBack.GetCell(7);
            FaceBottom.B2 = FaceBack.GetCell(8);
            FaceBottom.B3 = FaceBack.GetCell(9);
            FaceBottom.L1 = FaceLeft.GetCell(7);
            FaceBottom.L2 = FaceLeft.GetCell(8);
            FaceBottom.L3 = FaceLeft.GetCell(9);

            FaceFront.CellTop1 = FaceTop.GetCell(7);
            FaceFront.T2 = FaceTop.GetCell(8);
            FaceFront.T3 = FaceTop.GetCell(9);
            FaceFront.R1 = FaceRight.GetCell(1);
            FaceFront.R2 = FaceRight.GetCell(4);
            FaceFront.R3 = FaceRight.GetCell(7);
            FaceFront.B1 = FaceBottom.GetCell(3);
            FaceFront.B2 = FaceBottom.GetCell(2);
            FaceFront.B3 = FaceBottom.GetCell(1);
            FaceFront.L1 = FaceLeft.GetCell(9);
            FaceFront.L2 = FaceLeft.GetCell(6);
            FaceFront.L3 = FaceLeft.GetCell(3);

            FaceRight.CellTop1 = FaceTop.GetCell(9);
            FaceRight.T2 = FaceTop.GetCell(6);
            FaceRight.T3 = FaceTop.GetCell(3);
            FaceRight.R1 = FaceBack.GetCell(1);
            FaceRight.R2 = FaceBack.GetCell(4);
            FaceRight.R3 = FaceBack.GetCell(7);
            FaceRight.B1 = FaceBottom.GetCell(9);
            FaceRight.B2 = FaceBottom.GetCell(6);
            FaceRight.B3 = FaceBottom.GetCell(3);
            FaceRight.L1 = FaceFront.GetCell(9);
            FaceRight.L2 = FaceFront.GetCell(6);
            FaceRight.L3 = FaceFront.GetCell(3);

            FaceTop.CellTop1 = FaceBack.GetCell(3);
            FaceTop.T2 = FaceBack.GetCell(2);
            FaceTop.T3 = FaceBack.GetCell(1);
            FaceTop.R1 = FaceRight.GetCell(3);
            FaceTop.R2 = FaceRight.GetCell(2);
            FaceTop.R3 = FaceRight.GetCell(1);
            FaceTop.B1 = FaceFront.GetCell(3);
            FaceTop.B2 = FaceFront.GetCell(2);
            FaceTop.B3 = FaceFront.GetCell(1);
            FaceTop.L1 = FaceLeft.GetCell(3);
            FaceTop.L2 = FaceLeft.GetCell(2);
            FaceTop.L3 = FaceLeft.GetCell(1);

            FaceBack.CellTop1 = FaceTop.GetCell(3);
            FaceBack.T2 = FaceTop.GetCell(2);
            FaceBack.T3 = FaceTop.GetCell(1);
            FaceBack.R1 = FaceLeft.GetCell(1);
            FaceBack.R2 = FaceLeft.GetCell(4);
            FaceBack.R3 = FaceLeft.GetCell(7);
            FaceBack.B1 = FaceBottom.GetCell(7);
            FaceBack.B2 = FaceBottom.GetCell(8);
            FaceBack.B3 = FaceBottom.GetCell(9);
            FaceBack.L1 = FaceRight.GetCell(9);
            FaceBack.L2 = FaceRight.GetCell(6);
            FaceBack.L3 = FaceRight.GetCell(3);
        }

    }
}
