using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanCheckers
{
    class MoveHeuristic
    {

        public Board PotentialBoard { get; set; }
        public Cell.CellStatus MyStatus;
        public Cell.CellStatus OpponentStatus;
        double PIECE_VALUE = 5;
        double OpponentValues;
        double MyValues;
        double MySafePieces;
        double OpponentSafePieces;
        double MyAttackingPawns;
        double OpponentAttackingPawns;
        double Hueristic;
        public MoveHeuristic(Player.Color Me)
        {
            if (Me.Equals(Player.Color.Red))
            {
                MyStatus = Cell.CellStatus.OccupiedRed;
                OpponentStatus = Cell.CellStatus.OccupiedBlack;
            }
            else
            {
                MyStatus = Cell.CellStatus.OccupiedBlack;
                OpponentStatus = Cell.CellStatus.OccupiedRed;
            }
        }

        public double CalculateHeuristic(Board PotentialBoard)
        {
            this.PotentialBoard = PotentialBoard;

            for (int row = 0; row < PotentialBoard.BoardGame.Length; row++)
            {
                for (int col = 0; col < PotentialBoard.BoardGame.Length; col++)
                {
                    Cell CurrentCell = PotentialBoard.BoardGame[row, col];

                    if (CurrentCell.Status.Equals(MyStatus))
                    {
                        if (CurrentCell.Queen)
                        {
                            MyValues += row + PIECE_VALUE + 2;
                        }
                        else
                        {
                            MyValues += row + PIECE_VALUE;
                        }

                        if (col.Equals(0) || col.Equals(PotentialBoard.BoardGame.Length - 1))
                        {
                            MySafePieces++;
                        }
                        if (AttackPossible(CurrentCell))
                        {
                            MyAttackingPawns++;
                        }
                    }
                    else if (CurrentCell.Status.Equals(OpponentStatus))
                    {
                        if (CurrentCell.Queen)
                        {
                            OpponentValues += PIECE_VALUE + 2 - row;
                        }
                        else
                        {
                            OpponentValues += PIECE_VALUE - row;
                        }

                        if (col.Equals(0) || col.Equals(PotentialBoard.BoardGame.Length - 1))
                        {
                            OpponentSafePieces++;
                        }
                        if (AttackPossible(CurrentCell))
                        {
                            OpponentAttackingPawns++;
                        }
                    }
                }
            }

            Hueristic = (MyValues - OpponentValues) + ((MySafePieces - OpponentSafePieces) * 0.8) + ((MyAttackingPawns - OpponentAttackingPawns) * 1.5);

            return Hueristic;
        }

        private bool AttackPossible(Cell currentCell)
        {
            bool attack = false;

            if (currentCell.Status.Equals(MyStatus))
            {
                if (PotentialBoard.BoardGame[currentCell.RowLocation + 1, currentCell.ColumnLocation + 1]
                    .Status.Equals(OpponentStatus))
                {
                    if (PotentialBoard.BoardGame[currentCell.RowLocation + 2, currentCell.ColumnLocation + 2]
                    .Status.Equals(Cell.CellStatus.Unoccupied))
                    {
                        return true;
                    }
                }
                else if (PotentialBoard.BoardGame[currentCell.RowLocation + 1, currentCell.ColumnLocation - 1]
                   .Status.Equals(OpponentStatus))
                {
                    if (PotentialBoard.BoardGame[currentCell.RowLocation + 2, currentCell.ColumnLocation - 2]
                    .Status.Equals(Cell.CellStatus.Unoccupied))
                    {
                        return true;
                    }
                }

                if (currentCell.Queen)
                {
                    if (PotentialBoard.BoardGame[currentCell.RowLocation - 1, currentCell.ColumnLocation + 1]
                                        .Status.Equals(OpponentStatus))
                    {
                        if (PotentialBoard.BoardGame[currentCell.RowLocation - 2, currentCell.ColumnLocation + 2]
                        .Status.Equals(Cell.CellStatus.Unoccupied))
                        {
                            return true;
                        }
                    }
                    else if (PotentialBoard.BoardGame[currentCell.RowLocation - 1, currentCell.ColumnLocation - 1]
                       .Status.Equals(OpponentStatus))
                    {
                        if (PotentialBoard.BoardGame[currentCell.RowLocation - 2, currentCell.ColumnLocation - 2]
                        .Status.Equals(Cell.CellStatus.Unoccupied))
                        {
                            return true;
                        }
                    }
                }
            }

            if (currentCell.Status.Equals(OpponentStatus))
            {
                if (PotentialBoard.BoardGame[currentCell.RowLocation - 1, currentCell.ColumnLocation + 1]
                    .Status.Equals(MyStatus))
                {
                    if (PotentialBoard.BoardGame[currentCell.RowLocation - 2, currentCell.ColumnLocation + 2]
                    .Status.Equals(Cell.CellStatus.Unoccupied))
                    {
                        return true;
                    }
                }
                else if (PotentialBoard.BoardGame[currentCell.RowLocation - 1, currentCell.ColumnLocation - 1]
                   .Status.Equals(MyStatus))
                {
                    if (PotentialBoard.BoardGame[currentCell.RowLocation - 2, currentCell.ColumnLocation - 2]
                    .Status.Equals(Cell.CellStatus.Unoccupied))
                    {
                        return true;
                    }
                }

                if (currentCell.Queen)
                {
                    if (PotentialBoard.BoardGame[currentCell.RowLocation + 1, currentCell.ColumnLocation + 1]
                                        .Status.Equals(MyStatus))
                    {
                        if (PotentialBoard.BoardGame[currentCell.RowLocation + 2, currentCell.ColumnLocation + 2]
                        .Status.Equals(Cell.CellStatus.Unoccupied))
                        {
                            return true;
                        }
                    }
                    else if (PotentialBoard.BoardGame[currentCell.RowLocation + 1, currentCell.ColumnLocation - 1]
                       .Status.Equals(MyStatus))
                    {
                        if (PotentialBoard.BoardGame[currentCell.RowLocation + 2, currentCell.ColumnLocation - 2]
                        .Status.Equals(Cell.CellStatus.Unoccupied))
                        {
                            return true;
                        }
                    }
                }
            }
            return attack;

        }

    }
}
