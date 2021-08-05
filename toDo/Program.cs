using System;
using System.Threading;

namespace toDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Board lines = new Board();
            Metodlar metod = new Metodlar();
            
            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)\n*******************************************");
                Console.WriteLine(" (1) Board Listelemek\n (2) Board'a Kart Eklemek\n (3) Board'dan Kart Silmek\n (4) Kart Taşımak\n (5) Çıkış Yap");
                int islem = int.Parse(Console.ReadLine());
                switch (islem)
                {
                    case 1:
                        metod.BoardListele();
                        break;
                    case 2:
                        metod.KartEkle();
                        break;
                    case 3:
                        metod.KartSil();
                        break;
                    case 4:
                        metod.KartTasi();
                        break;
                    case 5:
                        Console.WriteLine("Çıkış yapılıyor..");
                        Thread.Sleep(3000);
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
