using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.Entities
{
    internal abstract class Bus
    {
        public int BusId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        

        public Bus(int busid,string name, int capacity)
        {
            BusId = busid;
            Name = name;
            Capacity = capacity;
          
        }
        public override string ToString()
        {
            return $"name:{Name} capacity :{Capacity} ";
        }
        public virtual void ShowSeats(int busId)
        {
            

        }
       
    }
}




