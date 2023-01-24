using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Switch _switch = new Switch();

            _switch.Presionar();
            _switch.Presionar();
            _switch.Presionar();
            _switch.Presionar();
            _switch.Presionar();
            _switch.Presionar();


            Console.ReadKey();
        }
    }
}
