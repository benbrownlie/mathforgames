﻿using System;

namespace MathLibrary
{
    public class Vector2
    {
        private float _x;
        private float _y;

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }

        public Vector2 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        /// <summary>
        /// Returns the normalized version of the vector passed in.
        /// </summary>
        /// <param name="vector">The vector that will be normalized</param>
        /// <returns></returns>
        public static Vector2 Normalize (Vector2 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector2();

            return vector / vector.Magnitude;
        }

        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public Vector2()
        {
            _x = 0;
            _y = 0;
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            float x = lhs.X + rhs.X;
            float y = lhs.Y + rhs.Y;

            return new Vector2(x, y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X * scalar, lhs.Y * scalar);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X / scalar, lhs.Y / scalar);
        }
    }
}
