
using System;
namespace AmericanCheckers
{
    public class Board
    {
        public Cell[,] BoardGame { get; }

        public Player ComputerPlayer { get; set; }
        public Player UserPlayer { get; set; }

        public Board(int rows, int columns)
        {
            BoardGame = new Cell[rows, columns];

            ComputerPlayer = new Player();
            UserPlayer = new Player();

        }



       
    }
}
