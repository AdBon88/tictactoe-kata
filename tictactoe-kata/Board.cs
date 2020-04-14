namespace tictactoe_kata
{
    public class Board
    {
        const int NumberOfRows = 3;
        const int NumberOfCols = 3;
        public char[,] Spaces {get;} = new char[NumberOfRows, NumberOfCols];

        public Board(){
            for (int i = 0; i < NumberOfRows; i++)
                for (int j = 0; j < NumberOfCols; j++)
                    Spaces[i,j] = '.';
        }

        public void PlaceMarkerAt(int[] coords)
        {
            int row = coords[0] - 1;
            int col = coords[1] - 1;

            Spaces[row, col] = 'X'; 
        }
    }
}