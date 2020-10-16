using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static ConsoleKey GetNextKey()
        {
            //If the user hasn't pressed a key return.
            if (!Console.KeyAvailable)
            {
                return 0;
            }
            //Return the key that was pressed.
            return Console.ReadKey(true).Key;
        }

        public void Walls()
        {
            Actor wall1 = new Actor(0, 2, '|', ConsoleColor.Blue);
            Actor wall2 = new Actor(0, 3, '|', ConsoleColor.Blue);
            Actor wall3 = new Actor(0, 4, '|', ConsoleColor.Blue);
            Actor flatWall1 = new Actor(1, 1, '-', ConsoleColor.Blue);
            Actor flatWall2 = new Actor(2, 1, '-', ConsoleColor.Blue);
            Actor flatWall3 = new Actor(3, 1, '-', ConsoleColor.Blue);
            Actor flatWall4 = new Actor(4, 1, '-', ConsoleColor.Blue);
            Actor flatWall5 = new Actor(5, 1, '-', ConsoleColor.Blue);
            Actor flatWall6 = new Actor(6, 1, '-', ConsoleColor.Blue);
            Actor flatWall7 = new Actor(7, 1, '-', ConsoleColor.Blue);
            Actor flatWall8 = new Actor(8, 1, '-', ConsoleColor.Blue);
            Actor flatWall9 = new Actor(9, 1, '-', ConsoleColor.Blue);
            Actor flatWall10 = new Actor(10, 1, '-', ConsoleColor.Blue);
            Actor flatWall11 = new Actor(11, 1, '-', ConsoleColor.Blue);
            Actor flatWall12 = new Actor(12, 1, '-', ConsoleColor.Blue);
            Actor flatWall13 = new Actor(13, 1, '-', ConsoleColor.Blue);
            Actor flatWall14 = new Actor(14, 1, '-', ConsoleColor.Blue);
            Actor flatWall15 = new Actor(15, 1, '-', ConsoleColor.Blue);
            Actor flatWall16 = new Actor(16, 1, '-', ConsoleColor.Blue);

            _scene.AddActor(wall1);
            _scene.AddActor(wall2);
            _scene.AddActor(wall3);
            _scene.AddActor(flatWall1);
            _scene.AddActor(flatWall2);
            _scene.AddActor(flatWall3);
            _scene.AddActor(flatWall4);
            _scene.AddActor(flatWall5);
            _scene.AddActor(flatWall6);
            _scene.AddActor(flatWall7);
            _scene.AddActor(flatWall8);
            _scene.AddActor(flatWall9);
            _scene.AddActor(flatWall10);
            _scene.AddActor(flatWall11);
            _scene.AddActor(flatWall12);
            _scene.AddActor(flatWall13);
            _scene.AddActor(flatWall14);
            _scene.AddActor(flatWall15);
            _scene.AddActor(flatWall16);


        }

        public void BuildWalls()
        {
            for (int i = 0; i < 24; i++)
            {
                Actor flatWall = new Actor(1, 1, '-', ConsoleColor.Blue);
                Actor flatWall2 = new Actor(1, 5, '-', ConsoleColor.Blue);
                _scene.AddActor(flatWall2);
                _scene.AddActor(flatWall);
            }
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Console.CursorVisible = false;
            _scene = new Scene();
            //Actor actor = new Actor(0,0, '■', ConsoleColor.Green);
            //actor.Velocity.X = 1;
            Player player = new Player(1, 3, '@', ConsoleColor.Red);
            //_scene.AddActor(actor);
            _scene.AddActor(player);
            BuildWalls();
        }


        //Called every frame.
        public void Update()
        {
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                Thread.Sleep(100);
            }

            End();
        }
    }
}
