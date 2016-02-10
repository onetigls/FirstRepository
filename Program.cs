using System;

namespace Сomputing_process
{


    class Program
    {
        static void Main()
        {
            Triangle TestTriangle = new Triangle(new PointXY(-1.0, 0.0), new PointXY(0.0, 1.0), new PointXY(1.0, 0.0));
            Console.WriteLine("A = " + TestTriangle.A.ShowPoint());
            Console.WriteLine("B = " + TestTriangle.B.ShowPoint());
            Console.WriteLine("C = " + TestTriangle.C.ShowPoint());

            Console.WriteLine();
            TestTriangle.Turn(90.0);

            Console.WriteLine("A = " + TestTriangle.A.ShowPoint());
            Console.WriteLine("B = " + TestTriangle.B.ShowPoint());
            Console.WriteLine("C = " + TestTriangle.C.ShowPoint());


            Console.WriteLine();
            TestTriangle.Increas(3.0);

            Console.WriteLine("A = " + TestTriangle.A.ShowPoint());
            Console.WriteLine("B = " + TestTriangle.B.ShowPoint());
            Console.WriteLine("C = " + TestTriangle.C.ShowPoint());

            Console.WriteLine();
            TestTriangle.MovingCentre(new PointXY(1.0, 1.0));

           


            Console.ReadKey();
        }



    }

    struct PointXY
    {
        public PointXY(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double x
        {
            get;
            set;
        }
        public double y
        {
            get;
            set;
        }

        public string ShowPoint()
        {
            string str = "(";
            str = str + x.ToString() + "," + y.ToString() + ")";
            return str;

        }

        public static PointXY operator +(PointXY firstPoint, PointXY secondPoint)
        {
            PointXY resultPoint = default(PointXY);
            resultPoint.x = firstPoint.x + secondPoint.x;
            resultPoint.y = firstPoint.y + secondPoint.y;

            return resultPoint;
        }

        public static PointXY operator *(double multiplier, PointXY somePoint)
        {
            PointXY resultPoint = default(PointXY);
            resultPoint.x = (multiplier * somePoint.x);
            resultPoint.y = multiplier * somePoint.y;
            return resultPoint;
        }

        public static PointXY operator /(PointXY somePoint, double divider)
        {
            PointXY resultPoint = default(PointXY);
            resultPoint.x = somePoint.x / divider;
            resultPoint.y = somePoint.y / divider;
            return resultPoint;
        }

        public static PointXY operator -(PointXY firstPoint, PointXY secondPoint)
        {
            PointXY resultPoint = default(PointXY);
            resultPoint.x = firstPoint.x - secondPoint.x;
            resultPoint.y = firstPoint.y - secondPoint.y;
            return resultPoint;
        }

        public static PointXY operator *(PointXY somePoint, double multiplier)
        {
            PointXY resultPoint = default(PointXY);
            resultPoint.x = multiplier * somePoint.x;
            resultPoint.y = multiplier * somePoint.y;
            return resultPoint;
        }

    }

    class Triangle
    {
        public PointXY A
        {
            get;
            private set;
        }

        public PointXY B
        {
            get;
            private set;
        }

        public PointXY C
        {
            get;
            private set;
        }

        PointXY Centre;

        public PointXY CentrePoint
        {
            get
            {
                Centre = ((A + B + C) / 3);
                return Centre;
            }

        }


        public Triangle(PointXY A, PointXY B, PointXY C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public void Increas(double multiplier)
        {
            PointXY centrePoint = this.CentrePoint;
            A = (multiplier * (A - centrePoint)) + centrePoint;
            B = (multiplier * (B - centrePoint)) + centrePoint;
            C = (multiplier * (C - centrePoint)) + centrePoint;
        }

        public void MovingCentre(PointXY newCentre)
        {
            PointXY oldCentre = CentrePoint;

            A = A + (newCentre - CentrePoint);
            B = B + (newCentre - CentrePoint);
            C = C + (newCentre - CentrePoint);
        }

        public void Turn(double angleInDegrees)
        {                        
            double angleInRadian = (angleInDegrees * Math.PI) / 180;
            PointXY centrePoint = this.CentrePoint;
            A = TurnPoint(A, centrePoint, angleInRadian);
            B = TurnPoint(B, centrePoint, angleInRadian);
            C = TurnPoint(C, centrePoint, angleInRadian);
        }

       

        PointXY TurnPoint(PointXY somePoint, PointXY centrePoint, double angleInRadian)
        {
            PointXY temporaryPoint = somePoint;

            temporaryPoint.x = temporaryPoint.x - centrePoint.x;
            temporaryPoint.y = temporaryPoint.y - centrePoint.y;

            somePoint.x = (Math.Cos(angleInRadian) * temporaryPoint.x) - (Math.Sin(angleInRadian) * temporaryPoint.y);
            somePoint.y = (Math.Sin(angleInRadian) * temporaryPoint.x) + (Math.Cos(angleInRadian) * temporaryPoint.y);

            somePoint.x = somePoint.x + centrePoint.x;
            somePoint.y = somePoint.y + centrePoint.y;
            return somePoint;
        }
    }
}



