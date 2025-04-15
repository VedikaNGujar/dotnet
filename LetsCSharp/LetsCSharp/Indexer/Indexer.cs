using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Indexer
{
    public class EmpIndexer
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    internal class Indexer
    {
        private List<EmpIndexer> Emp = new List<EmpIndexer>();

        public void Add(int EmpId, string Name, string Address)
        {
            Emp.Add(new EmpIndexer { EmpId = EmpId, Name = Name, Address = Address });
        }

        public string this[int i]
        {
            get { return Emp.FirstOrDefault(x => x.EmpId == i)?.Name!; }
            set { Emp.FirstOrDefault(x => x.EmpId == i).Name = value; }
        }
        public int this[string i] // multiple indexers
        {
            get { return Emp.FirstOrDefault(x => x.Name.Equals(i)).EmpId!; }
            set { Emp.FirstOrDefault(x => x.Name.Equals(i)).EmpId = value; }
        }

        public string this[string name, int empId] // multiple indexers
        {
            get
            {
                return Emp.FirstOrDefault(x => x.Name.Equals(name)
                                            && x.EmpId.Equals(empId))?.Address!;
            }
            set
            {
                Emp.FirstOrDefault(x => x.Name.Equals(name)
                                            && x.EmpId.Equals(empId)).Address = value;
            }
        }
    }

    public class IndexerTest
    {
        public void Test()
        {
            Indexer i = new Indexer();
            i.Add(10, "vedika", "Raviwar Peth");
            i.Add(20, "nidhi", "Raviwar Peth");
            i.Add(30, "aditya", "Raviwar Peth");

            Console.WriteLine(i[30]);
            i[20] = "nidhi gujar";
            Console.WriteLine(i[20]);

            Console.WriteLine(i["nidhi gujar"]);
            //i[20] = "nidhi gujar";
            //Console.WriteLine(i[20]);


            // i[40] = "nidhi gujar";

        }
    }
}
