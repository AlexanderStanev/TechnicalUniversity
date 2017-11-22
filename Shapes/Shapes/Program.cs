using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "shapes.bin";
            var listOfShapes = new List<IShape>();

            Console.WriteLine("Hello welcome to my app that calculates shapes area and volume");

            do
            {
                ShowMenu();
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the height");
                    double height;
                    if (!double.TryParse(Console.ReadLine(), out height))
                    {
                        Console.WriteLine("You must enter a number");
                        continue;
                    }

                    Console.WriteLine("Please enter the length");
                    double length;

                    if (!double.TryParse(Console.ReadLine(), out length))
                    {
                        Console.WriteLine("You must enter a number");
                        continue;
                    }

                    listOfShapes.Add(new Rectangle(height, length));
                    Console.WriteLine("The rectangle was added succesfully");
                }
                else if (keyPressed.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the radius");
                    var radius = double.Parse(Console.ReadLine());

                    listOfShapes.Add(new Circle(radius));
                    Console.WriteLine("The circle was added succesfully");
                }
                else if (keyPressed.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("The results are the following:");

                    foreach (var shape in listOfShapes)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"The {shape.ToString()} has:");
                        Console.WriteLine($"-Area: {shape.CalculatePerimeter()}");
                        Console.WriteLine($"-Volume: {shape.CalculateArea()}");
                    }
                }
                else if (keyPressed.Key == ConsoleKey.D4)
                {
                    Console.Clear();

                    using (var fs = new FileStream(fileName, FileMode.Create))
                    {
                        foreach (var shape in listOfShapes)
                        {
                            var shapeBytes = shape.Serialize();
                            fs.Write(shapeBytes, 0, shapeBytes.Length);
                        }
                    }

                    Console.WriteLine("The information has been successfully written to the file" +
                        Environment.NewLine + Environment.CurrentDirectory + "\\" + fileName);
                }
                // TODO
                //else if (keyPressed.Key == ConsoleKey.D5)
                //{
                //    Console.Clear();
                //    Console.WriteLine("Read from a file");

                //    var ds = new TypeDeserializer();
                //    ds.RegisterDeserializer(new Circle.Deserializer());
                //    ds.RegisterDeserializer(new Rectangle.Deserializer());

                //    var sr = new StreamReader("shapes.bin");
                //    var shape = BitConverter.ToBoolean(sr.Read, )
                //}
                else if (keyPressed.Key == ConsoleKey.Escape)
                {
                    break;
                }

                keyPressed = Console.ReadKey();

            } while (true);
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add a rectangle");
            Console.WriteLine("2. Add a circle");
            Console.WriteLine("3. Print the results");
            Console.WriteLine("4. Write to a file");
            //Console.WriteLine("5. Read from a file");
            Console.WriteLine("Press escape to exit");
        }
    }
}
