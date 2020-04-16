using System;
namespace tictactoe_kata
{
    public class Coords
    {
        private static int indexOfRow = 0;
        private static int indexOfCol = 1;

        public static int ParseRow(string coordsInput){
            string[] coordsArray = coordsInput.Split(',');
            return Int32.Parse(coordsArray[indexOfRow]) - 1;
        }

        public static int ParseCol(string coordsInput){
            string[] coordsArray = coordsInput.Split(',');
            return Int32.Parse(coordsArray[indexOfCol]) - 1;
        }
    }
    
}