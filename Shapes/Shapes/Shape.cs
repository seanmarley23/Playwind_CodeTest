using System;
namespace Shapes
{
    //superclass: both rectangles and circles will have x and y coordinates
    public class Shape
    {
        private int _X;
        private int _Y;

        public int X
        {
            get { return this._X; }
            set { this._X = value; }
        }


        public int Y
        {
            get { return this._Y; }
            set { this._Y = value; }
        }
        //constructor
        public Shape(int x, int y)
        {
            this._X = x;
            this._Y = y;
        }

    }


    //Rectangle subclass will need additional data of width and height
    public class Rectangle : Shape
    {
        public int _width;
        public int _height;

        public int width
        {
            get { return this._width; }
            set { this.width = value; }
        }

        public int height
        {
            get { return this._height; }
            set { this._height = value; }
        }
        //constructor
        public Rectangle(int x, int y, int width, int height)
            : base(x, y)
        {
            this._width = width;
            this._height = height;
        }
    }




    //Circle subclass will need additional data of radius
    public class Circle : Shape
    {
        public double _radius;

        public double radius
        {
            get { return this._radius; }
            set { this._radius = value; }
        }
        //constructor
        public Circle(int x, int y, double radius)
            : base(x, y)
        {
            this.radius = radius;
        }
    }
}


