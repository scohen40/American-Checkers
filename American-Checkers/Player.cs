using System;
namespace AmericanCheckers
{
    public class Player {

        public enum Color
        {
            Red,
            Black
        }

        public Color PlayerColor { get; set; }
        
        public Player(){}
    }
}
