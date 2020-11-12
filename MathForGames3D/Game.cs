using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
namespace MathForGames3D
{
    class Game
    {
        private static bool _gameOver;
        private Camera3D _camera = new Camera3D();
        public static bool GameOver
        {
            get
            {
                return _gameOver;
            }
            set
            {
                _gameOver = value;
            }
        }

        private void Start()
        {
            Raylib.InitWindow(1024, 760, "Math for Games");
            Raylib.SetTargetFPS(60);
            //Camera position
            _camera.position = new System.Numerics.Vector3(0.0f, 10.0f, 10.0f);
            //Camera looking at point
            _camera.target = new System.Numerics.Vector3(0.0f, 0.0f, 0.0f);
            //Camera up vector (rotation towards target)
            _camera.up = new System.Numerics.Vector3(0.0f, 1.0f, 0.0f);
            //Camera field-of-view Y
            _camera.fovy = 45.0f;
            //Camera mode type
            _camera.type = CameraType.CAMERA_PERSPECTIVE;
        }

        private void Update()
        {

        }

        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode3D(_camera);

            Raylib.ClearBackground(Color.RAYWHITE);

            Raylib.DrawSphere(new System.Numerics.Vector3(), 1, Color.BLUE);
            Raylib.DrawGrid(20, 1.0f);

            Raylib.EndMode3D();
            Raylib.EndDrawing();
        }

        private void End()
        {

        }

        public void Run()
        {
            Start();

            while (!_gameOver && !Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            End();
        }
    }
}
