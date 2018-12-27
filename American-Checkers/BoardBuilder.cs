using System;

namespace AmericanCheckers
{
    public class BoardBuilder
    {
        public Board GameBoard { get; }

        public const int ROWS = 8;
        public const int COLUMNS = 8;

        public Cell.CellStatus computerColor;
        public Cell.CellStatus userColor;


        public BoardBuilder()
        {
            GameBoard = new Board(ROWS, COLUMNS);

            setUpPlayers();
            setUpColors();
            setUpBoard();
        }

        public void setUpPlayers()
        {
            Random rand = new Random();
            int randNum = rand.Next(1);
            switch (randNum)
            {
                case 0:
                    GameBoard.UserPlayer.PlayerColor = Player.Color.Red;
                    GameBoard.ComputerPlayer.PlayerColor = Player.Color.Black;
                    break;
                case 1:
                    GameBoard.UserPlayer.PlayerColor = Player.Color.Black;                
                    GameBoard.ComputerPlayer.PlayerColor = Player.Color.Red;
                    break;
            }
        }

        private void setUpColors() {
            if(GameBoard.UserPlayer.PlayerColor == Player.Color.Red) {
                userColor = Cell.CellStatus.OccupiedRed;
                computerColor = Cell.CellStatus.OccupiedBlack;
            } else {
                userColor = Cell.CellStatus.OccupiedBlack;
                computerColor = Cell.CellStatus.OccupiedRed;
            }
        }

        public void setUpBoard()
        {

            //fill up the whole board and set status of each
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Cell currentCell = new Cell(row, col);
                    GameBoard.BoardGame[row, col] = currentCell;

                    if (row < 2)
                    {
                        currentCell.Status = computerColor;
                    }
                    else if (row >= ROWS - 2)
                    {
                        currentCell.Status = userColor;
                    }
                    else
                    {
                        currentCell.Status = Cell.CellStatus.Unoccupied;
                    }
                }
            }

        }
    }
}