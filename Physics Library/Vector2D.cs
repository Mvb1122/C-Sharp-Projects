namespace Vector
{
    public class Vector2D
    {
        private float _Vx;
        public float Vx
        {
            get
            {
                if (_Vx != float.NegativeInfinity)
                {
                    return _Vx;
                }
                else
                {
                    CalculateComponents();
                    return _Vx;
                }
            }
        }

        private float _Vy;
        public float Vy
        {
            get
            {
                if (_Vy != float.NegativeInfinity)
                {
                    return _Vy;
                }
                else
                {
                    CalculateComponents();
                    return _Vy;
                }
            }
        }

        private float _Theta;
        public float Theta
        {
            get
            {
                if (_Theta != float.NegativeInfinity)
                    return _Theta;

                CalculateComponents();
                return _Theta;
            }
        }

        private float _Magnitude;
        public float Magnitude
        {
            get
            {
                if (_Magnitude != float.NegativeInfinity)
                    return _Magnitude;

                CalculateComponents();
                return _Magnitude;
            }
        }

        private void CalculateComponents()
        {
            // Look at what we have and decide which way to go. 
                // If we have Theta and Magnitude, calculate Vx and Vy from that.
                // If we have Vx and Vy, calculate Magnitude and Theta from that.

            if (float.IsNegativeInfinity(_Theta) && float.IsNegativeInfinity(_Magnitude))
            {  
                // Magnitude = sqrt(Vx^2 + Vy^2)
                _Magnitude = MathF.Sqrt(MathF.Pow(Vx, 2) + MathF.Pow(Vy, 2));

                // Theta = arctan(Vy/Vx)
                _Theta = GeometryHelpers.InverseTanDegrees(Vy / Vx);

                return;
            }
            else if (float.IsNegativeInfinity(_Vx) && float.IsNegativeInfinity(_Vy))
            {
                // Vy = sin(Theta) * Magnitude, in Degrees
                _Vy = GeometryHelpers.SinDegrees(Theta) * _Magnitude;
                // Vx = cos(Theta) * Magnitude, in Degrees
                _Vx = GeometryHelpers.CosDegrees(Theta) * _Magnitude;

                return;
            }

            throw new Exception("ERROR: Variable misconfiguration.");
        }

        public Vector2D(float vx, float vy, float theta, float magnitude)
        {
            _Vx = vx;
            _Vy = vy;
            _Theta = theta;
            _Magnitude = magnitude;
        }

        public Vector2D(float theta, float magnitude)
        {
            _Theta = theta; _Magnitude = magnitude;

            _Vx = _Vy = float.NegativeInfinity;
        }

        public Vector2D(float vx, float vy, string type)
        {
            _Vx = vx; _Vy = vy;

            _Theta = _Magnitude = float.NegativeInfinity;

            // Discard type, since it only serves to tell the compiler that we're creating a vector from Vx and Vy.
            _ = type;
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.Vx + b.Vx, a.Vy + b.Vy, "Vx and Vy");
        }
        public static Vector2D operator -(Vector2D a, Vector2D b) 
        {
            return new Vector2D(a.Vx - b.Vx, a.Vy - b.Vy, "Vx and Vy");
        }

        public static Vector2D operator *(Vector2D a, float b) 
        {
            return new Vector2D(a.Vx * b, a.Vy * b, "Vx and Vy");
        }

        public override string ToString() => $"<{Vx},{Vy}>";

        /// <summary>
        /// Returns a string representing the object.
        /// </summary>
        /// <param name="x">The number of Sig.Figs to round to.</param>
        /// <returns>The component form rounded to x sig figs.</returns>
        public string ToString(int x) => $"<{MathF.Round(Vx, x)}, {MathF.Round(Vy, x)}>";
    }

    public class GeometryHelpers
    {
        private readonly static float DegreesToRadians = MathF.PI / 180;
        private readonly static float RadiansToDegrees = 180 / MathF.PI;
        
        public static float SinDegrees(float deg) =>
            MathF.Sin(deg * DegreesToRadians);
        
        public static float CosDegrees(float deg) =>
            MathF.Cos(deg * DegreesToRadians);

        public static float InverseSinDegrees(float deg) =>
            MathF.Asin(deg * DegreesToRadians);

        public static float InverseTanDegrees(float deg) =>
            MathF.Atan(deg * RadiansToDegrees);
    }
}

namespace Program
{
    using Vector;
    public class Program
    {
        public static int Main()
        {
            Console.Write("Enter theta for the first vector: ");
            string st1 = Console.ReadLine() + "";
            int SigFigs = st1.Length - 1;
            float t1 = float.Parse(st1);

            Console.Write("Enter the magnitude of the first vector: ");
            string sm1 = Console.ReadLine() + "";
            if (sm1.Length - 1 > SigFigs) SigFigs = sm1.Length - 1;
            float m1 = float.Parse(sm1);
            Vector2D v1 = new(t1, m1);

            Console.Write("Enter theta for the second vector: ");
            string st2 = Console.ReadLine() + "";
            if (st2.Length - 1 > SigFigs) SigFigs = st2.Length - 1;
            float t2 = float.Parse(st2);

            Console.Write("Enter the magnitude of the second vector: ");
            string sm2 = Console.ReadLine() + "";
            if (sm2.Length - 1 > SigFigs) SigFigs = sm2.Length - 1;
            float m2 = float.Parse(sm2);

            Vector2D v2 = new(t2, m2);
            Vector2D vf = v1 + v2;

            Console.WriteLine($"VFinal, in Component form: {vf.ToString(SigFigs)}\nVFinal, Theta: {vf.Theta} Magnitude: {vf.Magnitude}");
            
            return 0;         
        }
    }
}