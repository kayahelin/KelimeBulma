using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamAsmaca
{
    public class AdamAsmaMotor
    {
        IList<string> sesliler = new List<string>();
        List<string> tumkelimeler = new List<string>();
         List<string> harfler = new List<string>();
         string anaKelime;
         int tekrarSayisi;
         string bulunanSatir;
         string kullaniciKelime;
         int kalankullanım;
         int sesliKalan;
        public string boslukluKullaniciKelime
        {
            get
            {
               return HarflerArasiBoslukBirak(kullaniciKelime);
            }

        }
        //public string Firstname
        //{
        //    get { return Firstname; }
        //    set { Firstname = value; }

        //}

        public string Oyna (string giris)
        {

        }

        public void AyarlariYukle()
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

        public void YeniOyun()
        {
            harfler.Clear();
            anaKelime = "";
            tekrarSayisi = 0;
            kullaniciKelime = "";
            kalankullanım = 5;
            sesliKalan = 2;

            Random rast = new Random();
            int rastgeleIndex = rast.Next(tumkelimeler.Count());
            bulunanSatir = tumkelimeler[rastgeleIndex];
            string[] ayrılan = bulunanSatir.Split(' ');
            anaKelime = ayrılan[0];
            if (ayrılan.Count() > 1)
            {
                tekrarSayisi = Convert.ToInt32(ayrılan[1]);
            }

            for (int i = 0; i < anaKelime.Length; i++)
            {
                kullaniciKelime = kullaniciKelime + "_";
            }


        }

        string HarflerArasiBoslukBirak(string kelime)
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
