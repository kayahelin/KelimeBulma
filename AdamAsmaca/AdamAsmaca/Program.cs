using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamAsmaca
{
    class Program
    {
        static List<string> harfler = new List<string>();
        static string anaKelime;
        static string kullaniciKelime;
        static int kalankullanım;
        static int sesliKalan;
        static List<string> tumkelimeler = new List<string>();
        static IList<string> sesliler = new List<string>();

        static void Main(string[] args)
        {
            AyarlariYukle();
            YeniOyun();

            string harf = "";
            bool isfound = false;

            while (true)
            {
                isfound = false;
                Console.WriteLine(HarflerArasiBoslukBirak(kullaniciKelime));
                Console.WriteLine("Bir Harf Gir");
                harf = Console.ReadLine();

                int sesliIndex = sesliler.IndexOf(harf);

                if (sesliKalan == 0 && sesliIndex > -1)
                {
                    Console.WriteLine("Sesli harf kullanım hakkınız bitmiştir.");

                    continue;
                }
                int ara;

                ara = harfler.IndexOf(harf);

                if (ara != -1)
                {
                    Console.WriteLine("Aynı harfi girmiştiniz");
                }

                int siraNo;
                harfler.Add(harf);

                if (sesliIndex > -1)
                {
                    sesliKalan--;
                }

                for (int i = 0; i < anaKelime.Length; i++)
                {
                    siraNo = harfler.IndexOf(anaKelime[i].ToString());

                    if (siraNo != -1)
                    {
                        char[] parcalanmis = kullaniciKelime.ToCharArray();
                        parcalanmis[i] = anaKelime[i];

                        kullaniciKelime = new string(parcalanmis);
                    }
                }

                if (kullaniciKelime == anaKelime)
                {
                    isfound = true;
                }
                else
                {
                    kalankullanım--;
                    Console.WriteLine(HarflerArasiBoslukBirak(kullaniciKelime));
                    Console.WriteLine("Bir tahmininiz var mı varsa nedir?");

                    string tahmin = Console.ReadLine();

                    if (tahmin == anaKelime)
                    {
                        isfound = true;
                    }
                    else
                    {
                        Console.WriteLine("Kalan Hakkınız: " + kalankullanım);
                    }

                }

                if (isfound == true)
                {
                    Console.WriteLine("Tebrikler bildiniz");
                    Console.WriteLine("Tekrar oynamak istermisiniz?(e/h)");
                    string Tekrar = Console.ReadLine();

                    if (Tekrar == "e")
                    {
                        YeniOyun();
                    }
                    else
                    {
                        break;
                    }
                }


                if (kalankullanım == 0)
                {
                    Random rastgele = new Random();
                    char[] KelimeParcala = anaKelime.ToCharArray();
                    string yeni = "";
                    int kelimeBoyutu = KelimeParcala.Length;

                    for (int i = 0; i < kelimeBoyutu; i++)
                    {
                        int index = rastgele.Next(KelimeParcala.Length - 1);
                        yeni += KelimeParcala[index];
                        KelimeParcala = new string(KelimeParcala).Remove(index, 1).ToCharArray();
                    }
                    Console.WriteLine("Bütün haklarınız bitmiştir.");
                    Console.Write("Karışık verilen kelimeyi bilirseniz oyunu kazanabilirsiniz: ");
                    Console.WriteLine(yeni);
                    string sonSans = Console.ReadLine();

                    if (sonSans==anaKelime)
                    {
                        Console.WriteLine("Tebrikler bildiniz");
                      
                    }
                    else
                    {
                        Console.WriteLine("Bilemediniz:(");
                    }
                    Console.WriteLine("Tekrar oynamak istermisiniz?(e/h)");
                    string Tekrar = Console.ReadLine();

                    if (Tekrar == "e")
                    {
                        YeniOyun();
                    }
                    else
                    {
                        break;
                    }

                    YeniOyun();

                }

            }
        }

        static void YeniOyun()
        {
            harfler.Clear();
            anaKelime = "";
            kullaniciKelime = "";
            kalankullanım = 5;
            sesliKalan = 2;

            Random rast = new Random();
            int rastgeleIndex = rast.Next(tumkelimeler.Count());
            anaKelime = tumkelimeler[rastgeleIndex];

            for (int i = 0; i < anaKelime.Length; i++)
            {
                kullaniciKelime = kullaniciKelime + "_";
            }

            Console.Clear();
            Console.WriteLine("Yeni Oyun Başladı");

        }

        static void AyarlariYukle()
        {
            //Sesli harfleri yükle 
            sesliler.Add("a");
            sesliler.Add("e");
            sesliler.Add("ı");
            sesliler.Add("i");
            sesliler.Add("o");
            sesliler.Add("ö");
            sesliler.Add("u");
            sesliler.Add("ü");

            //kelimeler dosyasını oku ve yükle
            string dosya_yolu = @"C:\test\kelime.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs, System.Text.Encoding.GetEncoding("windows-1254"));
            tumkelimeler = sw.ReadToEnd().Replace("\n", "").Split('\r').ToList();
            sw.Dispose();
            fs.Close();
        }

        static string HarflerArasiBoslukBirak(string kelime)
        {
            string boslukluKelime = "";
            char[] parcalanmis = kelime.ToCharArray();
            for (int i = 0; i < parcalanmis.Length; i++)
            {
                boslukluKelime += parcalanmis[i].ToString();
                boslukluKelime += " ";
            }

            return boslukluKelime;
        }
    }
}
