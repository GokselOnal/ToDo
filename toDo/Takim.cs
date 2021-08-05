using System.Collections.Generic;

namespace toDo
{
    public class Takim{
        private int id;
        private string isim;
        public static List<Takim> takimListesi = new List<Takim>();

        public Takim(int id, string isim){
            this.id = id;
            this.isim = isim;
        }
        
        public Takim(){
            VarsayilanTakim();
        }

        public int Id {get => id; set => id = value;}
        public string Isim {get => isim; set => isim = value;}

        public static List<Takim> VarsayilanTakim(){
            takimListesi.Add(new Takim(1,"Goksel"));
            takimListesi.Add(new Takim(2,"denek2"));
            takimListesi.Add(new Takim(3,"denek3"));
            return takimListesi;
        }
    }
}