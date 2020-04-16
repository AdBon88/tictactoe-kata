using Xunit;
using tictactoe_kata;
namespace tictactoe_kata_test
{
    public class CoordsTests
    {
        [Fact]
        public void Coords_ParseRow_ParsesRowAsIntegerFromCoordinatesString()
        {
            int expected = 0;
            int actual = Coords.ParseRow("1,2");

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Coords_ParseCol_ParsesColAsIntegerFromCoordinatesString()
        {
            int expected = 1;
            int actual = Coords.ParseCol("1,2");

            Assert.Equal(expected,actual);
        }
    }
}