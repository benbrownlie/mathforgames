using MathLibrary;
using System;
using System.Text;
using Raylib_cs;
using System.Collections.Generic;

namespace MathForGames
{
    /// <summary>
    /// This is the base class for all objects that will
    /// be moved or interacted with in the game
    /// 
    /// Create a "solar system" using the matrix heirarchy.
    /// </summary>
    class Actor
    {
        protected char _icon = ' ';
        private Vector2 _velocity = new Vector2();
        private Vector2 acceleration = new Vector2();
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        private float _collisionRadius;
        private float _maxSpeed = 5;
        
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_globalTransform.m11, _globalTransform.m21);
            }
        }

        public void SetTranslation(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
            
        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        public void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;

            if (_parent != null)
                _globalTransform = _parent._globalTransform * _localTransform;
            else
                _globalTransform = Game.GetCurrentScene().World * _localTransform;
        }

        /// <summary>
        /// Check to see if this actor overlaps another
        /// </summary>
        /// <param name="other">The actor that this actor is checking against</param>
        /// <returns></returns>
        public bool CheckCollision(Actor other)
        {
            return false;
        }

        /// <summary>
        /// Called whenever a collision occurs between this actor and another.
        /// Use this to define game logic for this actor's collision.
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnCollision(Actor other)
        {
            //if (CheckCollision(other) == true)
            //{
            //    Scene.RemoveActor(other);
           // }
        }

        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2 (_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
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

        protected Vector2 Acceleration 
        { get => acceleration; 
          set => acceleration = value; }
        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
            }
        }

        public Actor()
        {
            LocalPosition = new Vector2();
            _velocity = new Vector2();
        }

        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;
            _localTransform = new Matrix3();
        }

        public bool AddChild(Actor child)
        {
            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
            return true;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            Velocity += Acceleration;

            if (Velocity.Magnitude > MaxSpeed)
                Velocity = Velocity.Normalized * MaxSpeed;


            LocalPosition += _velocity * deltaTime;
            //LocalPosition.X = Math.Clamp(LocalPosition.X, 0, Console.WindowWidth-1);
            //LocalPosition.Y = Math.Clamp(LocalPosition.Y, 0, Console.WindowHeight-1);
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
              (int)(WorldPosition.X * 32),
              (int)(WorldPosition.Y * 32),
              (int)((WorldPosition.X + Forward.X) * 32),
              (int)((WorldPosition.Y + Forward.Y) * 32),
              Color.WHITE
            );

            Console.ForegroundColor = _color;

            if (WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth
                && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
                Console.Write(_icon);
                Console.ForegroundColor = Game.DefaultColor;
            }
        }

        public virtual void End()
        {

        }
    }
}
