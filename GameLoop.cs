using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    class GameLoop
    {
        //private Gam _myGame;
        private bool isRunning = true;
        DateTime _previousGameTime = DateTime.Now;
        private async void Loop(){
            while(isRunning)
            {
                // Calculate the time elapsed since the last game loop cycle
                TimeSpan GameTime = DateTime.Now - _previousGameTime;
                // Update the current previous game time
                _previousGameTime = _previousGameTime + GameTime;
                // Update the game
                    ///_myGame.Update(GameTime);
                // Update Game at 60fps
                await Task.Delay(8);

            }
        }
    }
}

