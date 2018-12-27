using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanCheckers
{
    class MoveHeuristic
    {
        public Cell Beginnning { get; set; }
        public Cell End { get; set; }
        public Board CurrentBoard { get; set; }

        double PieceValue = 5;
        double Hueristic;
        Boolean Attack;
        Cell.CellStatus myStatus;
        public MoveHeuristic(Cell Beginning, Cell End, Board CurrentBoard, Boolean Attack)
        {
            this.Beginnning = Beginnning;
            this.End = End;
            this.CurrentBoard = CurrentBoard;
            this.Attack = Attack;
            this.myStatus = Beginning.Status;
            if(Beginnning.Queen)
            {
                PieceValue += 2;
            }
            else
            {
                PieceValue += Beginnning.RowLocation;
            }
        
        }

        public double CalculateHeuristic()
        {
            if (Attack) {Hueristic = 1; }
            if(End.ColumnLocation == 0 || End.ColumnLocation == 7) { Hueristic += 0.3; }
            if(CurrentBoard.BoardGame[End.RowLocation + 1,End.ColumnLocation + 1 ].Status == myStatus) { Hueristic += 0.25; }
            if (CurrentBoard.BoardGame[End.RowLocation + 1, End.ColumnLocation - 1].Status == myStatus) { Hueristic += 0.25; }
            if (Beginnning.Queen && End.RowLocation == Beginnning.RowLocation - 1)
            {
                if (CurrentBoard.BoardGame[End.RowLocation - 1, End.ColumnLocation + 1].Status == myStatus) { Hueristic += 0.25; }
                if (CurrentBoard.BoardGame[End.RowLocation - 1, End.ColumnLocation - 1].Status == myStatus) { Hueristic += 0.25; }
            }


            return Hueristic;
        }
            



    }
}
