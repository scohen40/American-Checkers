using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanCheckers
{
    class CheckersGame
    {

        Board Game { get; set; }

        public CheckersGame()
        {
            BoardBuilder Builder = new BoardBuilder();
            Game = Builder.GameBoard;

        }


        public List<Board> PossibleBoards(Board InitialBoard)
        {
            List<Board> PotentialMoves = new List<Board>();
            Player.Color OurColor = Game.ComputerPlayer.PlayerColor;
            Cell.CellStatus OurStatus;
            Cell.CellStatus OponentStatus;
            if (OurColor.Equals(Player.Color.Red))
            {
                OurStatus = Cell.CellStatus.OccupiedRed;
                OponentStatus = Cell.CellStatus.OccupiedBlack;
            }
            else
            {
                OurStatus = Cell.CellStatus.OccupiedBlack;
                OponentStatus = Cell.CellStatus.OccupiedRed;
            }


            for (int row = 0; row < InitialBoard.BoardGame.Length; row++)
            {
                for (int col = 0; col < InitialBoard.BoardGame.Length; col++)
                {
                    Cell currentCell = InitialBoard.BoardGame[row, col];
                    if (currentCell.Status.Equals(OurStatus))
                    {
                        if (row != InitialBoard.BoardGame.Length - 1)
                        {
                            if (col != InitialBoard.BoardGame.Length - 1)
                            {
                                if (InitialBoard.BoardGame[row + 1, col + 1].Status.Equals(Cell.CellStatus.Unoccupied))
                                {
                                    Board Potential = InitialBoard;
                                    Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                    Potential.BoardGame[row + 1, col + 1] = new Cell(row + 1, col + 1, currentCell.Queen, OurStatus);
                                    PotentialMoves.Add(Potential);
                                }
                                if (col != InitialBoard.BoardGame.Length - 2)
                                {
                                    if (InitialBoard.BoardGame[row + 1, col + 1].Status.Equals(OponentStatus) &&
                           InitialBoard.BoardGame[row + 2, col + 2].Status.Equals(Cell.CellStatus.Unoccupied))
                                    {
                                        Board Potential = InitialBoard;
                                        Potential.BoardGame[row + 2, col + 2] = new Cell(row + 2, col + 2, currentCell.Queen, OurStatus);
                                        Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                        Potential.BoardGame[row + 1, col + 1] = new Cell(row + 1, col + 1, false, Cell.CellStatus.Unoccupied);
                                        PotentialMoves.Add(Potential);
                                    }
                                }

                            }
                            if (col != 0)
                            {
                                if (InitialBoard.BoardGame[row + 1, col - 1].Status.Equals(Cell.CellStatus.Unoccupied))
                                {
                                    Board Potential = InitialBoard;
                                    Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                    Potential.BoardGame[row + 1, col - 1] = new Cell(row + 1, col - 1, currentCell.Queen, OurStatus);
                                    PotentialMoves.Add(Potential);
                                }
                                if (col != 1)
                                {
                                    if (InitialBoard.BoardGame[row + 1, col - 1].Status.Equals(OponentStatus) &&
                               InitialBoard.BoardGame[row + 2, col - 2].Status.Equals(Cell.CellStatus.Unoccupied))
                                    {
                                        Board Potential = InitialBoard;
                                        Potential.BoardGame[row + 2, col - 2] = new Cell(row + 2, col - 2, currentCell.Queen, OurStatus);
                                        Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                        Potential.BoardGame[row + 1, col - 1] = new Cell(row + 1, col - 1, false, Cell.CellStatus.Unoccupied);
                                        PotentialMoves.Add(Potential);
                                    }
                                }
                            }


                        }
                        if (currentCell.Queen)
                        {
                            if (row != 0)
                            {
                                if (col != InitialBoard.BoardGame.Length - 1)
                                {
                                    if (InitialBoard.BoardGame[row - 1, col + 1].Status.Equals(Cell.CellStatus.Unoccupied))
                                    {
                                        Board Potential = InitialBoard;
                                        Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                        Potential.BoardGame[row - 1, col + 1] = new Cell(row - 1, col + 1, true, OurStatus);
                                        PotentialMoves.Add(Potential);
                                    }
                                    if (col != InitialBoard.BoardGame.Length - 2)
                                    {
                                        if (InitialBoard.BoardGame[row - 1, col + 1].Status.Equals(OponentStatus) &&
                                InitialBoard.BoardGame[row - 2, col + 2].Status.Equals(Cell.CellStatus.Unoccupied))
                                        {
                                            Board Potential = InitialBoard;
                                            Potential.BoardGame[row - 2, col + 2] = new Cell(row - 2, col + 2, currentCell.Queen, OurStatus);
                                            Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                            Potential.BoardGame[row - 1, col + 1] = new Cell(row - 1, col + 1, false, Cell.CellStatus.Unoccupied);
                                            PotentialMoves.Add(Potential);
                                        }
                                    }
                                }
                                if (col != 0)
                                {
                                    if (InitialBoard.BoardGame[row - 1, col - 1].Status.Equals(Cell.CellStatus.Unoccupied))
                                    {
                                        Board Potential = InitialBoard;
                                        Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                        Potential.BoardGame[row - 1, col - 1] = new Cell(row - 1, col - 1, true, OurStatus);
                                        PotentialMoves.Add(Potential);
                                    }

                                    if (col != 1)
                                    {
                                        if (InitialBoard.BoardGame[row - 1, col - 1].Status.Equals(OponentStatus) &&
                                            InitialBoard.BoardGame[row - 2, col - 2].Status.Equals(Cell.CellStatus.Unoccupied))
                                        {
                                            Board Potential = InitialBoard;
                                            Potential.BoardGame[row - 2, col - 2] = new Cell(row - 2, col - 2, currentCell.Queen, OurStatus);
                                            Potential.BoardGame[row, col] = new Cell(row, col, false, Cell.CellStatus.Unoccupied);
                                            Potential.BoardGame[row - 1, col - 1] = new Cell(row - 1, col - 1, false, Cell.CellStatus.Unoccupied);
                                            PotentialMoves.Add(Potential);
                                        }
                                    }
                                }

                            }
                        }






                    }
                }
            }



            return PotentialMoves;
        }

    }
}
