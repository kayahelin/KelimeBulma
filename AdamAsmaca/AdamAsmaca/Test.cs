using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamAsmaca
{
    public class Test
    {
        static public void Main()
        {
            Insan insan1 = new Insan();
            insan1.Adi = "helin";
            insan1.GozRengi = "Kahverengi";

        }

    }

    class Insan
    {
        public string GozRengi;
        public string Adi { get; set; }

        public string Soyadi
        {
            get
            {
                return "ilker";
            }
            set { }
        }


    }
}
