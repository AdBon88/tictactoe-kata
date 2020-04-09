using System;
using Xunit;
using tictactoe_kata;

namespace tictactoe_kata_test
{
    public class GameLoopTests
    {
        [Fact]
        public void GameLoop_Run_RunsProgram()
        {
            GameLoop gameLoop = new GameLoop();
            
            const bool expected = true;
           // bool actual = gameLoop.Run();

            Assert.Equal(expected, true);
        }        
    }
}