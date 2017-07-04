﻿using System;
using System.Globalization;

namespace BuildTablesFromPdf.Engine
{
    public struct Point
    {
        #region ==

        public bool Equals(Point other)
        {
            return Math.Abs(X - other.X) < Line.Tolerance && Math.Abs(Y - other.Y) < Line.Tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point && Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !left.Equals(right);
        }

        #endregion

        #region >, >=, <, <=

        public static bool operator >(Point left, Point right)
        {
            if (Math.Abs(left.X - right.X) < Line.Tolerance)
            {
                if (Math.Abs(left.Y - right.Y) < Line.Tolerance)
                    // Equal point
                    return false;
                else
                    return left.Y > right.Y;
            }
            else
            {
                return left.X > right.X;
            }
        }

        public static bool operator >=(Point left, Point right)
        {
            if (Math.Abs(left.X - right.X) < Line.Tolerance)
            {
                if (Math.Abs(left.Y - right.Y) < Line.Tolerance)
                    // Equal point
                    return true;
                else
                    return left.Y > right.Y;
            }
            else
            {
                return left.X > right.X;
            }
        }

        public static bool operator <=(Point left, Point right)
        {
            if (Math.Abs(left.X - right.X) < Line.Tolerance)
            {
                if (Math.Abs(left.Y - right.Y) < Line.Tolerance)
                    // Equal point
                    return true;
                else
                    return left.Y < right.Y;
            }
            else
            {
                return left.X < right.X;
            }
        }


        public static bool operator <(Point left, Point right)
        {
            if (Math.Abs(left.X - right.X) < Line.Tolerance)
            {
                if (Math.Abs(left.Y - right.Y) < Line.Tolerance)
                    // Equal point
                    return false;
                else
                    return left.Y < right.Y;
            }
            else
            {
                return left.X < right.X;
            }
        }

        #endregion

        public readonly float X;
        public readonly float Y;

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Point Parse(string rawContent)
        {
            float x = float.Parse(rawContent.Split(' ')[0], NumberFormatInfo.InvariantInfo);
            float y = float.Parse(rawContent.Split(' ')[1], NumberFormatInfo.InvariantInfo);
            return new Point(x, y);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public float Distance(Point point)
        {
            return (float) Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
        }

        public bool IsValid()
        {
            if (X < 0 || Y < 0)
                return false;

            if (X > 10000 || Y > 10000)
                return false;

            return true;
        }
    }
}
