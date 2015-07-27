using System;

namespace SnakeGame
{
    public class Point : ICloneable
    {
        public int x { get; set; }
        public int y { get; set; }

        public object Clone()
        {
            return new Point() { x = this.x, y = this.y };
        }

        public override bool Equals(object obj)
        {
            bool areEqual = false;

            if (obj is Point)
            {
                Point point2 = (Point)obj;

                if (point2.x == this.x && point2.y == this.y)
                    areEqual = true;
            }

            return areEqual;
        }

        public override int GetHashCode()
        {
            string str = String.Format("{0},{1}", x, y);
            return str.GetHashCode();
        }
    }
}
