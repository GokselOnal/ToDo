namespace toDo
{
    public class Kart{
        private string baslik;
        private string icerik;
        private int atananKisi;
        private string buyukluk;

        public Kart(string baslik, string icerik, int atananKisi, string buyukluk){
            this.baslik = baslik;
            this.icerik = icerik;
            this.atananKisi = atananKisi;
            this.buyukluk = buyukluk;
        }

        public string Baslik {get => baslik; set => baslik = value;}
        public string Icerik {get => icerik; set => icerik = value;}
        public int AtananKisi {get => atananKisi; set => atananKisi = value;}
        public string Buyukluk {get => buyukluk; set => buyukluk = value;}
    }

    enum BuyuklukEnum
    {
        XS = 1,
        S,
        M,
        L,
        XL
    }
}