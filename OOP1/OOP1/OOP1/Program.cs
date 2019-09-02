using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Insan insan1 = new Insan();
            insan1.Adi = "helin";
            insan1.Soyadi= "kaya";
            insan1.GozRengi = "Kahverengi";

            Araba araba1 = new Araba();

            Insan insan2 = new Insan();
            insan2.Soyadi = "jackson";
            insan2.GozRengi = "siyah";

            insan1.Arabasi = araba1;
            insan2.Arabasi = araba1;

            araba1.Marka = "Mercedes";
            araba1.Yil = 2015;
            araba1.Model = "CLK";

            Console.WriteLine(insan1.Adi);
            Console.WriteLine(insan1.Soyadi);
            Console.WriteLine(insan1.GozRengi);
            Console.ReadLine();

            Console.WriteLine(insan2.Adi);
            Console.WriteLine(insan2.Soyadi);
            Console.WriteLine(insan2.GozRengi);
            
            Console.ReadLine();

            bool yemekYedinmi = insan2.YemekYe("Ekmek");

            Console.ReadLine();

            List<Insan> ogrenciler = new List<Insan>();
            Insan secili_ogrenci = ogrenciler[2];
            Insan ogrenci = new Insan();
            ogrenciler.Add(ogrenci);
        }
    }

    class Insan
    {

        private string _adi;
        public string Adi
        {
            get
            {
                return _adi;
            }

            set
            {
                if (value == "ahmet" )
                {
                    _adi = "X";
                }
                else
                {
                    _adi = value;
                }
            }
        }


        public string Soyadi { get; set; }
        public string GozRengi { get; set; }
        public Araba Arabasi { get; set; }

        public Insan()
        {

        }

        public Insan(string adi)
        {
            _adi = adi;
        }
        //aşırı yükleme, method overloading

        public bool YemekYe()
        {
            Console.WriteLine("Yemek yemeye başladım");
            return true;
        }

        public bool YemekYe(string NeYenecek)
        {
            return true;
        }

    }

    class Araba
    {
        public int Yil { get; set; } = 1999;
        public string Marka { get; set; } = "RENAULT";
        public string Model{ get; set; }
    }

}
