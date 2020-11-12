using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static Scene GetScene(int index)
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene; 
            _scenes = tempArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if (scene == null)
            {
                return false;
            }

            bool sceneRemoved = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[i] = _scenes[j];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if (sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            _currentSceneIndex = index;
        }

        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }
        public Game()
        {
            _scenes = new Scene[0];
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

            //_scene.AddActor(wall1);
            //_scene.AddActor(wall2);
            //_scene.AddActor(wall3);
            //_scene.AddActor(flatWall1);
            //_scene.AddActor(flatWall2);
            //_scene.AddActor(flatWall3);
            //_scene.AddActor(flatWall4);
            //_scene.AddActor(flatWall5);
            //_scene.AddActor(flatWall6);
            //_scene.AddActor(flatWall7);
            //_scene.AddActor(flatWall8);
            //_scene.AddActor(flatWall9);
            //_scene.AddActor(flatWall10);
            //_scene.AddActor(flatWall11);
            //_scene.AddActor(flatWall12);
            //_scene.AddActor(flatWall13);
            //_scene.AddActor(flatWall14);
            //_scene.AddActor(flatWall15);
            //_scene.AddActor(flatWall16);


        }

        public void BuildPark()
        {
            for (int i = 0; i < 62; i++)
            {
                Actor flatWall = new Actor(i, 1, '-', ConsoleColor.Blue);
                Actor flatWall2 = new Actor(i, 24, '-', ConsoleColor.Blue);
                Actor wall1 = new Actor(1, i - 35, '|', ConsoleColor.Blue);
                Actor wall2 = new Actor(62, i - 35, '|', ConsoleColor.Blue);
                //_scene.AddActor(flatWall2);
                //_scene.AddActor(flatWall);
               //_scene.AddActor(wall1);
                //_scene.AddActor(wall2);
            }
        }

        public void BuildSolarSystem()
        {
            
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1024, 760, "Math For Games");
            Raylib.SetTargetFPS(60);

            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Math for Games";

            //Create a new scene for our actors to exist in
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            //Creates two actors to add to our scene
            Actor actor = new Actor(0,0,Color.GREEN, '■', ConsoleColor.Green);
            actor.Velocity.X = 1;
            Enemy enemy = new Enemy(10, 10, Color.GREEN, '.', ConsoleColor.Green);

            Player player = new Player(1,3,Color.RED, '.', ConsoleColor.Red);
            player.SetTranslation(new Vector2(10, 10));
            player.SetRotation(1);
            player.SetScale(3, 3);

            enemy.SetTranslation(new Vector2(2, 0));
            player.AddChild(enemy);

            enemy.Target = player;

            //scene1.AddActor(actor);
            scene1.AddActor(player);
            scene1.AddActor(enemy);

            //BuildPark();

            scene2.AddActor(player);
            player.Speed = 5;

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            SetCurrentScene(startingSceneIndex);
        }


        //Called every frame.
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
                _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
