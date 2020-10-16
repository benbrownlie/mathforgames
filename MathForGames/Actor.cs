using MathLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    
    /// <summary>
    /// Create a new subclass for actor that builds upon the functionality already given.
    /// Examples:
    /// - Create simple collision detection between players and other actors.
    /// - Give NPCs simple AI
    /// - Create a simple golf game.Players would need to move an actor representing a
    ///  ball to an actor to that would represent the hole.The player wins if those two actors collide.
    /// For an added challenge, give the player the ability to switch clubs.Each club will change
    /// the magnitude of the vector applied to the ball's position.
    /// </summary>
    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;


        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public Actor()
        {
            _position = new Vector2();
            _velocity = new Vector2();
        }

        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _icon = icon;
            _position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth-1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight-1);
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {

        }
    }
}
