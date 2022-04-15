using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    //https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
    //https://www.geeksforgeeks.org/program-for-point-of-intersection-of-two-lines/
    struct Point
    {
        public double X;
        public double Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    enum IntersectionStatus
    {
        None = 0,
        SKEW_CROSS = 1,
        SKEW_NO_CROSS = 2,
        COLLINEAR = 3,
        PARALLEL = 4
    }

    struct LineSegment
    {
        public Point From;
        public Point To;

        public LineSegment(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public LineSegment(double p1, double q1, double p2, double q2)
        {
            From.X = p1;
            From.Y = q1;
            To.X = p2;
            To.Y = q2;
        }

        // Given three collinear points p, q, r, the function checks if
        // point q lies on line segment 'pr'
        bool OnSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;

            return false;
        }

        // To find Orientation of ordered triplet (p, q, r).
        // The function returns following values
        // 0 --> p, q and r are collinear
        // 1 --> Clockwise
        // 2 --> Counterclockwise
        int Orientation(Point p, Point q, Point r)
        {
            // See https://www.geeksforgeeks.org/Orientation-3-ordered-points/
            // for details of below formula.
            double val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0; // collinear

            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        // The main function that returns true if line segment 'p1q1'
        // and 'p2q2' intersect.
        bool DoIntersect(Point p1, Point q1, Point p2, Point q2, ref Point point, ref IntersectionStatus status)
        {
            // Find the four Orientations needed for general and
            // special cases
            int o1 = Orientation(p1, q1, p2);
            int o2 = Orientation(p1, q1, q2);
            int o3 = Orientation(p2, q2, p1);
            int o4 = Orientation(p2, q2, q1);

            // Line AB represented as a1x + b1y = c1
            double a1 = q1.Y - p1.Y;
            double b1 = p1.X - q1.X;
            double c1 = a1 * (p1.X) + b1 * (p1.Y);

            // Line CD represented as a2x + b2y = c2
            double a2 = q2.Y - p2.Y;
            double b2 = p2.X - q2.X;
            double c2 = a2 * (p2.X) + b2 * (p2.Y);

            double determinant = a1 * b2 - a2 * b1;
            // General case
            if (o1 != o2 && o3 != o4 && determinant != 0)
            {
                point.X = (b2 * c1 - b1 * c2) / determinant;
                point.Y = (a1 * c2 - a2 * c1) / determinant;
                status = IntersectionStatus.SKEW_CROSS;
                return true;
            }

            // Special Cases
            // p1, q1 and p2 are collinear and p2 lies on segment p1q1
            if (o1 == 0 && OnSegment(p1, p2, q1))
            {
                point = p2;
                status = IntersectionStatus.COLLINEAR;
                return true;
            }

            // p1, q1 and q2 are collinear and q2 lies on segment p1q1
            if (o2 == 0 && OnSegment(p1, q2, q1))
            {
                point = q2;
                status = IntersectionStatus.COLLINEAR;
                return true;
            }

            // p2, q2 and p1 are collinear and p1 lies on segment p2q2
            if (o3 == 0 && OnSegment(p2, p1, q2))
            {
                point = p1;
                status = IntersectionStatus.COLLINEAR;
                return true;
            }

            // p2, q2 and q1 are collinear and q1 lies on segment p2q2
            if (o4 == 0 && OnSegment(p2, q1, q2))
            {
                point = q1;
                status = IntersectionStatus.COLLINEAR;
                return true;
            }

            if (o1 == 0 && o2 == 0 && o3 == 0 && o4 == 0)
            {
                status = IntersectionStatus.COLLINEAR;
            }
            else if (determinant == 0)
            {
                // The lines are parallel. This is simplified
                status = IntersectionStatus.PARALLEL;
            }
            else
            {
                status = IntersectionStatus.SKEW_NO_CROSS;
            }

            return false; // Doesn't fall in any of the above cases
        }

        public bool IsIntersect(LineSegment target, ref Point point, ref IntersectionStatus status)
        {
            return DoIntersect(From, To, target.From, target.To, ref point, ref status);
        }

    }
}
