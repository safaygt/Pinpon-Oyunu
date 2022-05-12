// ADI SOYADI: SAFA YİĞİT
// NUMARA: B201200001
// BÖLÜM: BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ndpÖdevPinpon
{
    class pong
    {


        int en;
        int boy;
        Tahta tahta;
        çubuk çubuk1;
        çubuk çubuk2;
        top ball;


        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;


        public pong(int en, int boy)
        {
            this.en = en;
            this.boy = boy;
            tahta = new Tahta(en, boy);
            ball = new top(en / 2, boy / 2, boy, en);
        }
        public void kur()
        {


            çubuk1 = new çubuk(2, boy);
            çubuk2 = new çubuk(en - 2, boy);
            keyInfo = new ConsoleKeyInfo();

            consoleKey = new ConsoleKey();

            ball.X = en / 2;
            ball.Y = boy / 2;
            ball.yön = 0;
        }
        public void skor()
        {
            ball.skorHesapla();
            if (ball.skor1 == 3 || ball.skor2 == 3)
            {
                Console.Clear();
                Console.WriteLine(ball.skor1.ToString() + "\t\t\t : \t\t\t" + ball.skor2.ToString());
                devam();

            }


        }



        void input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }

        public void calistir()
        {


            while (true)
            {


                Console.Clear();
                skor();
                kur();
                tahta.ciz();
                çubuk1.ciz();
                çubuk2.ciz();
                ball.ciz();

                while (ball.X != 1 && ball.X != en - 1)
                {
                    input();
                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            çubuk1.yukarı();

                            break;
                        case ConsoleKey.UpArrow:
                            çubuk2.yukarı();
                            break;
                        case ConsoleKey.S:
                            çubuk1.asagi();
                            break;
                        case ConsoleKey.DownArrow:
                            çubuk2.asagi();
                            break;


                    }

                    consoleKey = ConsoleKey.A;
                    ball.mantik(çubuk1, çubuk2);
                    ball.ciz();

                    Thread.Sleep(50);


                }
            }


        }

        public void devam()
        {
            while (true)
            {
                Console.Write("Devam etmek istiyor musunuz: ");
                string cevap = Console.ReadLine();

                if (cevap == "E" || cevap == "e")
                {
                    calistir();
                    Console.Write("Devam etmek istiyor musunuz: ");
                    cevap = Console.ReadLine();

                }
                else if (cevap == "H" || cevap == "h")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Write("Devam etmek istiyor musunuz: ");
                    cevap = Console.ReadLine();
                }

            }
        }


        class top
        {

            public int X { get; set; }
            public int Y { get; set; }
            public int skor1 { get; set; }
            public int skor2 { get; set; }

            int yönX;

            int yönY;



            int tahtaBoy;
            int tahtaEn;


            public int yön { get; set; }

            public top(int x, int y, int tahtaboy, int tahtaen)
            {
                X = x;
                Y = y;
                tahtaBoy = tahtaboy;
                tahtaEn = tahtaen;
                yönX = -1;  // 1 sağa -1 sola gider
                yönY = 1;
            }
            public void ciz()
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.SetCursorPosition(X, Y);

                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.White;



            }
            public void mantik(çubuk çubuk1, çubuk çubuk2)
            {
                Console.SetCursorPosition(X, Y);


                Console.Write("\0");

                if (Y <= 1 || Y >= tahtaBoy)
                {
                    yönY *= -1;
                }
                if ((X == 3) && (çubuk1.Y - (çubuk1.uzunluk / 2)) <= Y && (çubuk1.Y + (çubuk1.uzunluk / 2)) > Y)
                {

                    yönX *= -1;
                    if (Y == çubuk1.Y)
                    {
                        yön = 0;

                    }
                    if ((Y >= (çubuk1.Y - (çubuk1.uzunluk / 2)) && Y < çubuk1.Y) || (Y > çubuk1.Y && Y < (çubuk1.Y + (çubuk1.uzunluk / 2))))
                    {
                        yön = 1;
                    }


                }

                if ((X == tahtaEn - 3) && (çubuk2.Y - (çubuk2.uzunluk / 2)) <= Y && (çubuk2.Y + (çubuk2.uzunluk / 2)) > Y)
                {
                    yönX *= -1;

                    if (Y == çubuk2.Y)
                    {
                        yön = 0;
                    }
                    if ((Y >= (çubuk2.Y - (çubuk2.uzunluk / 2)) && Y < çubuk2.Y) || (Y > çubuk2.Y && Y < (çubuk2.Y + (çubuk2.uzunluk / 2))))
                    {
                        yön = 1;
                    }

                }


                switch (yön)
                {
                    case 0:
                        X += yönX;

                        break;

                    case 1:
                        X += yönX;
                        Y += yönY;

                        break;

                }





            }


            public void skorHesapla()
            {
                if (X == tahtaEn - 1)
                {
                    skor1++;


                }
                if (X == 1)
                {
                    skor2++;
                }
            }



        }



        public class Tahta
        {
            int i;
            public int boy { get; set; }
            public int en { get; set; }

            public Tahta()
            {
                en = 20;
                boy = 60;


            }
            public Tahta(int en, int boy)
            {
                this.en = en;
                this.boy = boy;
            }

            public void ciz()
            {

                for (int i = 0; i <= en + 1; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("─");

                }
                for (int i = 0; i <= en + 1; i++)
                {
                    Console.SetCursorPosition(i, (boy + 1));
                    Console.Write("─");
                }

                for (int i = 0; i <= boy + 1; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("│");

                }
                for (int i = 0; i <= boy + 1; i++)
                {
                    Console.SetCursorPosition((en + 1), i);
                    Console.Write("│");
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("┌");
                Console.SetCursorPosition(en + 1, 0);
                Console.WriteLine("┐");
                Console.SetCursorPosition(0, boy + 1);
                Console.WriteLine("└");
                Console.SetCursorPosition(en + 1, boy + 1);
                Console.WriteLine("┘");

            }

        }

        class çubuk
        {
            public int X { get; set; }
            public int Y { get; set; }

            public int uzunluk { get; set; }

            public int tahtaBoy { get; set; }

            public çubuk(int x, int tahtaBoy)
            {
                this.tahtaBoy = tahtaBoy;
                X = x;
                Y = tahtaBoy / 2;

                uzunluk = tahtaBoy / 3;

            }

            public void yukarı()
            {

                if ((Y - 1 - (uzunluk / 2)) != 0)
                {
                    Console.SetCursorPosition(X, (Y + (uzunluk / 2)) - 1);

                    Console.Write("\0");
                    Y--;
                    ciz();
                }


            }

            public void asagi()
            {
                if ((Y + 1 + (uzunluk / 2)) != tahtaBoy + 2)
                {
                    Console.SetCursorPosition(X, (Y - (uzunluk / 2)));

                    Console.Write("\0");
                    Y++;
                    ciz();
                }
            }

            public void ciz()
            {
                Console.ForegroundColor = ConsoleColor.Red;


                for (int i = (Y - (uzunluk / 2)); i < (Y + (uzunluk / 2)); i++)
                {

                    Console.SetCursorPosition(X, i);
                    Console.Write("│");

                }

                Console.ForegroundColor = ConsoleColor.White;
            }

        }




    }
}

