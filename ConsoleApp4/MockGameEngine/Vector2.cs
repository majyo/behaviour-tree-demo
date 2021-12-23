using System;

namespace ConsoleApp2
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("({0} {1})", x, y);
        }

        public float Norm()
        {
            return MathF.Sqrt(x * x + y * y);
        }

        public Vector2 Normalized()
        {
            float norm = Norm();
            x /= norm;
            y /= norm;
            return this;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator *(float s, Vector2 v)
        {
            return new Vector2(v.x * s, v.y * s);
        }
        
        public static Vector2 operator *(Vector2 v, float s)
        {
            return new Vector2(v.x * s, v.y * s);
        }
    }
}