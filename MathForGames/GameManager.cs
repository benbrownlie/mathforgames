using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    delegate void GameEvent();
    class GameManager
    {
        private static bool _gameOver;
        public static bool GameOver { get => _gameOver; set => _gameOver = value; }
        public static int enemyCount;
        public static GameEvent onWin;
        public static void CheckWin()
        {
            if (enemyCount <= 0)
            {
                onWin.Invoke();
            }
        }
    }
}
