using System;
namespace AmericanCheckers
{
    public class Cell
    {
        public int RowLocation { get; set; }
        public int ColumnLocation { get; set; }

        public enum CellStatus
        {
            OccupiedRed,
            OccupiedBlack,
            Unoccupied
        }

        public CellStatus Status { get; set; }

        public Boolean Queen { get; set; }

        public Cell(int rowLocation, int columnLocation)
        {
            RowLocation = rowLocation;
            ColumnLocation = columnLocation;
            Queen = false;
        }



      

      
    }
}
