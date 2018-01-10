using System;
namespace Rubik.BO
{
    public class Cell
    {
        public enum CellColors { O, R, Y, W, G, B }

        public CellColors Color { get; set; }

        public Face Face { get; set; }

        public Cell(Face face)
        {
            this.Face = face;
        }

        public override string ToString()
        {
            return Color.ToString(); 
        }
    }
}
