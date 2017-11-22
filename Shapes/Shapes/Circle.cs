using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return "Circle";
        }

        public byte[] Serialize()
        {
            var typeBytes = BitConverter.GetBytes(1);
            var radiusBytes = BitConverter.GetBytes(radius);

            var circleBytes = typeBytes.Concat(radiusBytes).ToArray();

            return circleBytes;
        }

        public Circle Deserialize()
        {
            return new Circle(0);
        }
    }
}
