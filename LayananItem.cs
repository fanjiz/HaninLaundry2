using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaninLaundry
{
    class LayananItem
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }

        public override string ToString()
        {
            return Nama;
        }
    }
}
