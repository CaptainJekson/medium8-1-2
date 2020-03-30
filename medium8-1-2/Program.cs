using System;
using System.Collections.Generic;

namespace Task
{
    class GameObject
    {
        private int _pointX;
        private int _pointY;

        private Random random;

        public int PointX { get { if (_pointX > 0) return _pointX; else return 0; } }
        public int PointY { get { if (_pointY > 0) return _pointY; else return 0; } }

        public bool Isalive { get; set; }

        public GameObject(int pointX, int pointY)
        {
            _pointX = pointX;
            _pointY = pointY;
            Isalive = true;
            random = new Random();
        }

        public void СhangePosition()
        {
            _pointX += random.Next(-1, 1);
            _pointY += random.Next(-1, 1);
        }
    }

    class Comparer
    {
        public void Compare(GameObject objectPosition1, GameObject objectPosition2)
        {
            if (objectPosition1.PointX == objectPosition2.PointX && objectPosition1.PointY == objectPosition2.PointY)
            {
                objectPosition1.Isalive = false;
                objectPosition2.Isalive = false;
            }
        }
    }

    class Drawer
    {
        public void DrawPoint(GameObject objectPosition, char symbol)
        {
            if (objectPosition.Isalive)
            {
                Console.SetCursorPosition(objectPosition.PointX, objectPosition.PointY);
                Console.Write(symbol);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            GameObject gameObject1 = new GameObject(5, 5);
            GameObject gameObject2 = new GameObject(10, 10);
            GameObject gameObject3 = new GameObject(15, 15);

            Comparer comparer = new Comparer();
            Drawer drawer = new Drawer();

            while (true)
            {
                comparer.Compare(gameObject1, gameObject2);
                comparer.Compare(gameObject1, gameObject3);
                comparer.Compare(gameObject2, gameObject3);

                gameObject1.СhangePosition();
                gameObject2.СhangePosition();
                gameObject3.СhangePosition();

                drawer.DrawPoint(gameObject1, '1');
                drawer.DrawPoint(gameObject2, '2');
                drawer.DrawPoint(gameObject3, '3');
            }
        }
    }
}