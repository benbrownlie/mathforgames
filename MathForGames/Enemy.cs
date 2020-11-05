﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;
namespace MathForGames
{
    class Enemy : Actor
    {
        private Actor _target;
        private Color _alertColor;
        private Sprite _sprite;

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _alertColor = Color.RED;
            _sprite = new Sprite("Images/Images/enemy.png");
        }

        /// <summary>
        /// Modify this function so that it takes in a max viewing angle and max viewing distance.
        /// It should only return true if the target is within the viewing angle
        /// and the viewing distance.
        /// The angle should be in radians.
        /// </summary>
        /// <returns></returns>
        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;
            //Find the vector representing the actor and its target.
            Vector2 direction = Target.LocalPosition - LocalPosition;
            //Get the magnitude of the distance vector.
            float distance = direction.Magnitude;
            //Use the inverse cosine to find the angle of the dot product in radians.
            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));

            if (angle < maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        public override void Update(float deltaTime)
        {
            if (CheckTargetInSight(1.5f, 5))
            {
                _rayColor = Color.RED;
            }
            else
            {
                _rayColor = Color.BLUE;
            }
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_localTransform);
            base.Draw();
        }
    }
}
