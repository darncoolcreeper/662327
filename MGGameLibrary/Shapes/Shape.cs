using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary.Shapes
{
    public abstract class Shape
    {
        public Vector2 Position { get; set; }

        public Shape(Vector2 position)
        {
            Position = position;
        }

        public abstract bool IsInside(Point point);

        public abstract bool Intersects(Shape other);
        public abstract bool IntersectsCircle(Circle circle);

        public static bool Intersects(Circle c1, Circle c2)
        {
            float distance = Vector2.Distance(c1.Position, c2.Position);
            return distance < c1.radius + c2.radius;
        }

        public abstract bool Intersects(Shape other, ref Vector2 collisionNormal);
        public abstract bool IntersectsCircle(Circle other, ref Vector2 collisionNormal);

        public static bool Intersects(Circle c, Square s, ref Vector2 collisionNormal)
        {
            // Find the closest point on the square to the circle's center
            float closestX = Math.Clamp(c.Centre.X, s.Position.X, s.Position.X + s.size);
            float closestY = Math.Clamp(c.Centre.Y, s.Position.Y, s.Position.Y + s.size);
            Vector2 closestPoint = new Vector2(closestX, closestY);

            // Vector from closest point to circle center
            Vector2 diff = c.Centre - closestPoint;
            float distanceSquared = diff.LengthSquared();

            if (distanceSquared <= c.radius * c.radius)
            {
                collisionNormal = diff != Vector2.Zero ? Vector2.Normalize(diff) : Vector2.UnitY;
                return true;
            }
            collisionNormal = Vector2.Zero;
            return false;
        }

        //public static bool Intersects(Circle c, Triangle s, ref Vector2 collisionNormal)
        //{
        //    //change to be triangle not square
        //    float closestX = Math.Clamp(c.Centre.X, s.Position.X, s.Position.X + s.size);
        //    float closestY = Math.Clamp(c.Centre.Y, s.Position.Y, s.Position.Y + s.size);
        //    Vector2 closestPoint = new Vector2(closestX, closestY);

        //    // Vector from closest point to circle center
        //    Vector2 diff = c.Centre - closestPoint;
        //    float distanceSquared = diff.LengthSquared();

        //    if (distanceSquared <= c.radius * c.radius)
        //    {
        //        collisionNormal = diff != Vector2.Zero ? Vector2.Normalize(diff) : Vector2.UnitY;
        //        return true;
        //    }
        //    collisionNormal = Vector2.Zero;
        //    return false;


        //}

        public static bool Intersects(Circle c, Triangle t, ref Vector2 collisionNormal)
        {
            Vector2 center = c.Centre;
            float r = c.radius;

            // Triangle vertices based on your Triangle class
            Vector2 A = new Vector2(t.Position.X + t.size / 2f, t.Position.Y);
            Vector2 B = new Vector2(t.Position.X, t.Position.Y + t.size);
            Vector2 C = new Vector2(t.Position.X + t.size, t.Position.Y + t.size);

            bool hit = false;
            float bestDistSq = float.MaxValue;
            Vector2 bestNormal = Vector2.Zero;

            //Edge AB
            {
                Vector2 ab = B - A;
                float tVal = Vector2.Dot(center - A, ab) / Vector2.Dot(ab, ab);
                tVal = Math.Clamp(tVal, 0f, 1f);

                Vector2 closest = A + tVal * ab;
                Vector2 diff = center - closest;
                float distSq = diff.LengthSquared();

                if (distSq <= r * r && distSq < bestDistSq)
                {
                    bestDistSq = distSq;
                    bestNormal = diff != Vector2.Zero ? Vector2.Normalize(diff) : Vector2.UnitY;
                    hit = true;
                }
            }

            //Edge BC
            {
                Vector2 bc = C - B;
                float tVal = Vector2.Dot(center - B, bc) / Vector2.Dot(bc, bc);
                tVal = Math.Clamp(tVal, 0f, 1f);

                Vector2 closest = B + tVal * bc;
                Vector2 diff = center - closest;
                float distSq = diff.LengthSquared();

                if (distSq <= r * r && distSq < bestDistSq)
                {
                    bestDistSq = distSq;
                    bestNormal = diff != Vector2.Zero ? Vector2.Normalize(diff) : Vector2.UnitY;
                    hit = true;
                }
            }

            //Edge CA
            {
                Vector2 ca = A - C;
                float tVal = Vector2.Dot(center - C, ca) / Vector2.Dot(ca, ca);
                tVal = Math.Clamp(tVal, 0f, 1f);

                Vector2 closest = C + tVal * ca;
                Vector2 diff = center - closest;
                float distSq = diff.LengthSquared();

                if (distSq <= r * r && distSq < bestDistSq)
                {
                    bestDistSq = distSq;
                    bestNormal = diff != Vector2.Zero ? Vector2.Normalize(diff) : Vector2.UnitY;
                    hit = true;
                }
            }

            if (hit)
            {
                collisionNormal = bestNormal;
                return true;
            }

            collisionNormal = Vector2.Zero;
            return false;
        }


    }
}
