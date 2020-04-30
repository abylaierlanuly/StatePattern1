using System;

namespace StatePattern1
{

    enum Light { Green, Yellow, Red }

    class TrafficLight
    {
        interface IState
        {
            IState Next(TrafficLight t);

        }

        class ToRedState : IState
        {

            private static ToRedState _trsInstance;
            private ToRedState() { }

            public static ToRedState GetInstance()
            {
                if (_trsInstance == null)
                    _trsInstance = new ToRedState();
                return _trsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Red;
                return RedState.GetInstance();
            }

        }

        class GreenState : IState
        {

            private static GreenState _gsInstance;
            private GreenState() { }

            public static GreenState GetInstance()
            {
                if (_gsInstance == null)
                    _gsInstance = new GreenState();
                return _gsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Yellow;
                return ToRedState.GetInstance();
            }
        }

        class RedState : IState
        {
            private static RedState _rsInstance;
            private RedState() { }
            public static RedState GetInstance()
            {
                if (_rsInstance == null)
                    _rsInstance = new RedState();
                return _rsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Yellow;
                return ToGreenState.GetInstance();
            }
        }

        class ToGreenState : IState
        {
            private static ToGreenState _tgsInstance;
            private ToGreenState() { }
            public static ToGreenState GetInstance()
            {
                if (_tgsInstance == null)
                    _tgsInstance = new ToGreenState();
                return _tgsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Green;
                return GreenState.GetInstance();
            }
        }

        public Light CurrentLight { get; private set; } = Light.Green;

        private IState state = GreenState.GetInstance();

        public void Next()
        {
            state = state.Next(this);
        }


        public void Manuals(string str)
        {

            switch (str)
            {
                case "Green":
                    CurrentLight = Light.Green;
                    break;
                case "Red":
                    CurrentLight = Light.Red;
                    break;
                case "Yellow":
                    CurrentLight = Light.Yellow;
                    break;
            }


        }

        class Program
        {
            static void Main(string[] args)
            {
                TrafficLight tl = new TrafficLight();
                Console.WriteLine("Automatical Mode");
                Console.WriteLine(tl.CurrentLight);
                tl.Next();
                Console.WriteLine(tl.CurrentLight);
                tl.Next();
                Console.WriteLine(tl.CurrentLight);
                tl.Next();
                Console.WriteLine(tl.CurrentLight);
                tl.Next();

                Console.WriteLine("Manual Mode");

                Console.WriteLine(tl.CurrentLight);
                tl.Manuals("Green");
                Console.WriteLine(tl.CurrentLight);
                tl.Next();
                Console.WriteLine(tl.CurrentLight);
                tl.Manuals("Yellow");
                Console.WriteLine(tl.CurrentLight);
                tl.Next();
                Console.WriteLine(tl.CurrentLight);
                tl.Next();
                Console.WriteLine(tl.CurrentLight);
                tl.Manuals("Green");
                Console.WriteLine(tl.CurrentLight);
                tl.Manuals("Yellow");
                Console.WriteLine(tl.CurrentLight);

            }
        }
    }
}
