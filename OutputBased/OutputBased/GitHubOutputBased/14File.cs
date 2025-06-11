using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased.GitHubOutputBased
{

    public struct S : IDisposable
    {
        private bool dispose;
        public void Dispose()
        {
            dispose = true;
        }
        public bool GetDispose()
        {
            return dispose;
        }
    }

    public class SC : IDisposable
    {
        private bool dispose;
        public void Dispose()
        {
            dispose = true;
        }
        public bool GetDispose()
        {
            return dispose;
        }
    }


    internal class _14File
    {
        public void Test()
        {
            var s = new S();

            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());

            var SC = new SC();

            using (SC)
            {
                Console.WriteLine(SC.GetDispose());
            }
            Console.WriteLine(SC.GetDispose());
        }

    }
}
