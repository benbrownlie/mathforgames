﻿using MathLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    /// <summary>
    /// This is the base class for all objects that will
    /// be moved or interacted with in the game
    /// 
    /// Create new matrices to transform the actors matrix. The user should be able
    /// to translate, rotate, and scale the actor.
    /// </summary>
    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _velocity;
        protected Matrix3 _transform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_transform.m11, _transform.m21);
            }
            set
            {
                _transform.m11 = value.X;
                _transform.m21 = value.Y;
            }
        }

        public void SetTranslation(Vector2 position)
        {
           // _translation
        }

        public void SetRotation(float radians)
        {
           // _rotation
        }

        public void SetScale(float x, float y)
        {
            
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2 (_transform.m13, _transform.m23);
            }
            set
            {
                _transform.m13 = value.X;
                _transform.m23 = value.Y;
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
            Position = new Vector2();
            _velocity = new Vector2();
        }

        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _transform = new Matrix3();
            Position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            Forward = new Vector2(1, 0);
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;
            _transform = new Matrix3();
        }

        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            Forward = Velocity.Normalized;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateFacing();
            Position += _velocity * deltaTime;
            Position.X = Math.Clamp(Position.X, 0, Console.WindowWidth-1);
            Position.Y = Math.Clamp(Position.Y, 0, Console.WindowHeight-1);
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(Position.X * 32), (int)(Position.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
              (int)(Position.X * 32),
              (int)(Position.Y * 32),
              (int)((Position.X + Forward.X) * 32),
              (int)((Position.Y + Forward.Y) * 32),
              Color.WHITE
            );

            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {

        }
    }
}
