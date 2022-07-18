using System;

namespace Shapes
{
    internal class Program
    {
        /*method template as defined in coding challenge question.
         * nested for loop: take first shape, check for intersections with following shapes,
         * move to next shape, check for intersections, repeat until all shapes are checked
         */

        public static Dictionary<int, List<int>> FindIntersections(List<Shape> shapes)
        {
            int count = shapes.Count;
            Dictionary<int, List<int>> intersections = new Dictionary<int, List<int>>();


            for (int shape1Index = 0; shape1Index < count; shape1Index++)
            {
                Shape shape1 = shapes[shape1Index];

                for (int shape2Index = shape1Index + 1; shape2Index < count; shape2Index++)
                {
                    Shape shape2 = shapes[shape2Index];
                    if (didTheyCollide(shape1, shape2))
                    {
                        output(shape1Index, shape2Index, intersections);
                    }
                }
            }

            return intersections;
        }

        /* creating dictionary output to include ID of shape currently being checked for intersections (dictionary key)
         * followed by ID (in this case the List's count value) of the shape it intersects with (dictionary value).
         */
        static private void output(int id_1, int id_2, Dictionary<int, List<int>> collidedShapes)
        {
            if (!collidedShapes.TryGetValue(id_1, out List<int> collidedIdsForA))
            {
                collidedIdsForA = new List<int>();
                collidedShapes[id_1] = collidedIdsForA;
            }

            if (!collidedShapes.TryGetValue(id_2, out List<int> collidedIdsForB))
            {
                collidedIdsForB = new List<int>();
                collidedShapes[id_2] = collidedIdsForB;
            }


            collidedIdsForA.Add(id_1);
            collidedIdsForB.Add(id_2);

            if (id_1 == collidedShapes[id_1].Count || id_2 == collidedShapes[id_2].Count)
            {
                //do nothing
            }
            else
            {
                Console.WriteLine(id_1 + " -> " + "(" + collidedShapes[id_1].Count + ")");
                Console.WriteLine(id_2 + " -> " + "(" + collidedShapes[id_2].Count + ")");
            }
        }



        /*if statements to define whether the comparing shapes are:
         * - 2 rectangles
         * - 2 circles
         * - a rectangle and a circle
         * used by casting the shape to either a rectangle or circle
         * NOTE: could be futher improved to a switch statement?
         */
          
        public static bool didTheyCollide(Shape a, Shape b)
        {
            if(a is Rectangle && b is Rectangle)
            {
                return didTheyCollide((Rectangle)a, (Rectangle)b);
            };
            if(a is Circle && b is Circle)
            {
                return didTheyCollide((Circle)a, (Circle)b);
            };

            return false;

        }
        /* Rectangle/Rectangle comparison to check for intersections
         */
        private static bool didTheyCollide(Rectangle a, Rectangle b)
        {
            bool xIntersection = false;
            bool yIntersection = false;

           
            if(a.X + a.width > b.X && a.X < b.X + b.width){
                xIntersection = true;
            };
            if(a.Y + a.height > b.Y && a.Y < b.Y + b.height)
            {
                yIntersection = true;
            };

            if (xIntersection == true && yIntersection == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /* Circle/Circle comparison to check for intersections
         */
        private static bool didTheyCollide(Circle a, Circle b)
        {
            double xCircle = a.X - b.X; 
            double yCircle = a.Y - b.Y;
            //x squared plus y squared equals radius squared
            double result = Math.Sqrt(xCircle * xCircle + yCircle * yCircle);

            if (result < a.radius + b.radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //main method, initalising shapes, running FindIntersections method
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            //Code-block to test Rectangle V Rectangle intersections
            
            shapes.Add(new Rectangle(25, 25, 25, 25));
            shapes.Add(new Rectangle(75, 75, 50, 50));
            shapes.Add(new Rectangle(0, 0, 100, 100));
            shapes.Add(new Rectangle(30, 30, 100, 100));
            shapes.Add(new Rectangle(31, 31, 100, 100));
            

            //Uncomment code-block to test Circle V Circle intersections
            /*
            shapes.Add(new Circle(15, 15, 100.0));
            shapes.Add(new Circle(15, 15, 100.0));
            shapes.Add(new Circle(15, 15, 100.0));
            shapes.Add(new Circle(15, 15, 100.0));
            */

            //Find intersections method!
            FindIntersections(shapes);
            

        }
    }
}