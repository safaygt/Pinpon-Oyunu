// ADI SOYADI: SAFA YİĞİT
// NUMARA: B201200001
// BÖLÜM: BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpÖdevPinpon
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            pong pong = new pong(60, 20);
            pong.calistir();
            Console.ReadKey();


        }
    }
}
