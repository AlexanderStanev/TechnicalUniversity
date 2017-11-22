using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IShape
    {
        private double height;
        private double length;

        public Rectangle(double height, double length)
        {
            this.height = height;
            this.length = length;
        }

        public double CalculatePerimeter()
        {
            return 2 * (height + length);
        }

        public double CalculateArea()
        {
            return height * length;
        }

        public override string ToString()
        {
            return "Rectangle";
        }

        public byte[] Serialize()
        {
            var typeBytes = BitConverter.GetBytes(0);
            var heightBytes = BitConverter.GetBytes(height);
            var lengthBytes = BitConverter.GetBytes(length);

            var rectangleBytes = typeBytes.Concat(heightBytes).Concat(lengthBytes).ToArray();

            return rectangleBytes;
        }

        public Rectangle Deserializer()
        {
            return new Rectangle(0,0);
        }
    }
}
