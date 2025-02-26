using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.ContraAndCovariance
{
    class Mammals { }
    class Dogs : Mammals { }

    internal class Covariance
    {
        public delegate Mammals HandlerMethod();

        public Mammals MammalsHandler()
        {
            Console.WriteLine("In MammalsHandler");
            return null;
        }

        public Dogs DogsHandler()
        {
            Console.WriteLine("In DogsHandler");
            return null;
        }

        public void Test()
        {
            HandlerMethod handlerMammals = MammalsHandler;
            handlerMammals.Invoke();

            // Covariance enables this assignment.  
            HandlerMethod handlerDogs = DogsHandler;
            handlerDogs.Invoke();

            handlerDogs += MammalsHandler;
            handlerDogs.Invoke();
        }
    }
}
