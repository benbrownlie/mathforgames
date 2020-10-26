using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;
using System.Runtime.CompilerServices;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed = 1;
        private Color _detectedColor;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) 
            : base (x, y, icon, color)
        {
            _detectedColor = Color.YELLOW;
        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {

        }

        public void Detected()
        {
            if (Enemy.CheckTargetInSight(1.5f, 5))
            {
                _rayColor = Color.YELLOW;
            }
        }

        public override void Update(float deltaTime)
        {
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));

            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized * Speed;
            
            base.Update(deltaTime);
        }

    }
}
