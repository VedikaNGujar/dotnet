using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Throw
{
    internal class Throw
    {
        public void TestThrow()
        {
            try
            {
                Console.WriteLine("---TestThrow---");

                ThrowTest t = new ThrowTest();
                t.Throw();
            }
            catch (Exception ex)
            {
                Console.WriteLine("---Stack---");
                Console.WriteLine(ex.StackTrace.ToString());

                Console.WriteLine("---Target---");
                Console.WriteLine(ex.TargetSite);
            }
        }

        public void TestThrowEx()
        {
            try
            {
                Console.WriteLine("---TestThrowEx---");

                ThrowTest t = new ThrowTest();
                t.ThrowEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine("---Stack---");
                Console.WriteLine(ex.StackTrace.ToString());

                Console.WriteLine("---Target---");
                Console.WriteLine(ex.TargetSite);
            }
        }
    }

    internal class ThrowTest
    {
        public void Throw()
        {
            try
            {
                FaultyMethod();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void ThrowEx()
        {
            try
            {
                FaultyMethod();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FaultyMethod()
        {
            throw new TimeoutException();
        }

    }
}
