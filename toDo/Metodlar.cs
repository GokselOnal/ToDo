using System;
using System.Collections.Generic;
using System.Threading;

namespace toDo
{
    public class Metodlar{
        public void BoardListele(){
            Console.WriteLine("Bilgiler taranıyor..");
            Thread.Sleep(3000);
            Console.WriteLine("TODO Line\n ************************");
            if(Board.toDoLine.Count == 0)
                Console.WriteLine("~ BOŞ ~");
            else{
                foreach (var item in Board.toDoLine)
                {
                    BilgileriGoster(item);
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("IN PROGRESS Line\n ************************");
            if(Board.inProgressLine.Count == 0)
                Console.WriteLine("~ BOŞ ~");
            else{
                foreach (var item in Board.inProgressLine)
                {
                    BilgileriGoster(item);
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("DONE Line\n ************************");
            if(Board.doneLine.Count == 0)
                Console.WriteLine("~ BOŞ ~");
            else{
                foreach (var item in Board.doneLine)
                {
                    BilgileriGoster(item);
                }
            }
        }

        public void BilgileriGoster(Kart item){
            Thread.Sleep(500);
            Console.WriteLine("Başlık      :{0}", item.Baslik);
            Console.WriteLine("İçerik      :{0}", item.Icerik);
            Console.WriteLine("Atanan Kişi :{0}", item.AtananKisi);
            Console.WriteLine("Büyüklük    :{0}", item.Buyukluk);
            Console.WriteLine("-");
        }

        public void KartEkle(){
            Console.Write("\nBaşlık Giriniz                               : ");
            string baslik = Console.ReadLine();
            Console.Write("İçerik Giriniz                                 : ");
            string icerik = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) : ");
            int buyukluk = int.Parse(Console.ReadLine());
            Console.Write("Kişi Seçiniz                                   : ");
            int kisi = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Kart oluşturuluyor..");
            Thread.Sleep(3000);
            Kart yeniKart = new Kart(baslik, icerik, kisi, ((BuyuklukEnum)buyukluk).ToString());
            Board.toDoLine.Add(yeniKart);
            Console.WriteLine("\nKart başarıyla eklendi.");
        }

        public void KartSil(){
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:");
            string baslik = Console.ReadLine();
            string line = Bulundu(baslik);

            if(String.Equals(line,"todo")){
                foreach (var item in Board.toDoLine)
                {
                    if(String.Equals(item.Baslik,baslik)){
                        KartSilHelper(Board.toDoLine,item);
                    }
                }   
            }else if(String.Equals(line,"inprogress")){
                foreach (var item in Board.inProgressLine)
                {
                    if(String.Equals(item.Baslik,baslik)){
                        KartSilHelper(Board.inProgressLine,item);
                    }
                }
            }
            else if(String.Equals(line,"done")){
                foreach (var item in Board.doneLine)
                {
                    if(String.Equals(item.Baslik,baslik)){
                        KartSilHelper(Board.doneLine,item);
                    }
                }
            }else if(String.Equals(line,"")){
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int secim = int.Parse(Console.ReadLine());
                if(secim == 1)
                    return;
                else if(secim == 2)
                    KartSil();
                else{
                    Console.WriteLine("Hatalı işlem, 1 veya 2 karakteri giriniz.");
                    KartSil();
                }
            }
        }

        public string Bulundu(string kartBaslik){
            string bulundu = "";
            foreach (var item in Board.toDoLine)
            {
                if(String.Equals(item.Baslik, kartBaslik))
                    bulundu += "todo";
            }

            foreach (var item in Board.inProgressLine)
            {
                if(String.Equals(item.Baslik, kartBaslik))
                    bulundu += "inprogress";
            }

            foreach (var item in Board.doneLine)
            {
                if(String.Equals(item.Baslik, kartBaslik))
                    bulundu += "done";
            }
            return bulundu;
        }

        public void KartSilHelper(List<Kart> kartlar, Kart item){
            Console.WriteLine("Kart siliniyor..");
            Thread.Sleep(3000);
            kartlar.Remove(item);
            Console.WriteLine("\nKart başarıyla kaldırıldı.");
        }

        public void KartTasi(){
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:  ");
            string baslik = Console.ReadLine();
            string bulundu = Bulundu(baslik);

            if(String.Equals(bulundu,"")){
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int secim = int.Parse(Console.ReadLine());
                if(secim == 1)
                    return;
                else if(secim == 2)
                    KartTasi();
                else{
                    Console.WriteLine("Hatalı işlem, 1 veya 2 karakteri giriniz.");
                    KartTasi();
                }
            }else{
                if(String.Equals(bulundu,"todo")){
                    foreach (var item in Board.toDoLine)
                    {
                        BulunanKartBilgileri(item,bulundu);
                        Tasima(item,bulundu);
                        BoardListele();
                    }      
                }

                else if(String.Equals(bulundu,"inprogress")){
                    foreach (var item in Board.inProgressLine)
                    {
                        BulunanKartBilgileri(item,bulundu);
                        Tasima(item,bulundu);
                        BoardListele();
                    }  
                }

                else if(String.Equals(bulundu,"done")){
                    foreach (var item in Board.doneLine)
                    {
                        BulunanKartBilgileri(item,bulundu);
                        Tasima(item,bulundu);
                        BoardListele();
                    }  
                }
            }
        }

        public void BulunanKartBilgileri(Kart item, string line){
            Console.WriteLine("Bulunan Kart Bilgileri:\n**************************************");
            Console.WriteLine("Başlık      : {0}", item.Baslik);
            Console.WriteLine("İçerik      : {0}", item.Icerik);
            Console.WriteLine("Atanan Kişi : {0}", item.AtananKisi);
            Console.WriteLine("Büyüklük    : {0}", item.Buyukluk);
            Console.WriteLine("Line        : {0}", line);
        }

        public void Tasima(Kart item, string line){
            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: \n(1) TODO\n(2) IN PROGRESS\n(3) DONE");
            int secim = int.Parse(Console.ReadLine());
            if(secim == 1 && !String.Equals(line,"todo")){
                Board.toDoLine.Add(item);
                Kaldir(item,line);
            }else if(secim == 2 && !String.Equals(line,"inprogress")){
                Board.inProgressLine.Add(item);
                Kaldir(item,line);
            }else if(secim == 3 && !String.Equals(line,"done")){
                Board.doneLine.Add(item);
                Kaldir(item,line);
            }else{
                Console.WriteLine("Hatalı işmel yaptınız,\n * 1, 2 veya 3 giriniz\n * Eski line, taşınmak istenilen line'a eşit olmamalı.");
                Tasima(item,line);
            }
        }
        public void Kaldir(Kart item, string eskiLine){
            if(String.Equals(eskiLine,"todo")){
                Board.toDoLine.Remove(item);
            }else if(String.Equals(eskiLine,"inprogress")){
                Board.inProgressLine.Remove(item);
            }else if(String.Equals(eskiLine,"done")){
                Board.doneLine.Remove(item);
            }
        }
    }
}