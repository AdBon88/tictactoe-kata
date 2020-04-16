using System;
namespace tictactoe_kata
{
    public class Board
    {
        const int NumberOfRows = 3;
        const int NumberOfCols = 3;
        public char[,] SpaceContents {get;} = new char[NumberOfRows, NumberOfCols];

        public Board(){
            for (int i = 0; i < NumberOfRows; i++)
                for (int j = 0; j < NumberOfCols; j++)
                    SpaceContents[i,j] = '.';
        }

        public void PlaceMarkerAt(string coordsInput, PlayerMarker activePlayerMarker)
        {
            // string[] coordsArray = coordsInput.Split(',');
            // int row = Int32.Parse(coordsArray[0]) - 1;
            // int col = Int32.Parse(coordsArray[1]) - 1;
            
            SpaceContents[Coords.ParseRow(coordsInput), Coords.ParseCol(coordsInput)] = (char)activePlayerMarker; 
        }

        public bool SpaceIsTakenAt(string coordsInput)
        {
            // string[] coordsArray = coordsInput.Split(',');
            // int row = Int32.Parse(coordsArray[0]) - 1;
            // int col = Int32.Parse(coordsArray[1]) - 1;   

            if(SpaceContents[Coords.ParseRow(coordsInput),Coords.ParseCol(coordsInput)] != (char)PlayerMarker.None)      
                return true;
            else
                return false; 
        }

        public override string ToString()
        {
            string currentBoard = "\n";
            string[] rows = new string[NumberOfRows];
            
            for (int currentRow = 0; currentRow < NumberOfRows; currentRow++){
                string[] cols = new string[NumberOfCols];
                for (int currentCol = 0; currentCol < NumberOfCols; currentCol++){
                    cols[currentCol] = SpaceContents[currentRow,currentCol].ToString();
                }
            
                rows[currentRow] = string.Join(" ", cols);
            }
            currentBoard += string.Join("\n", rows);
            return currentBoard;
        }
    }
}