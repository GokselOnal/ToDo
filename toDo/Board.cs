using System.Collections.Generic;

namespace toDo
{
    public class Board{
        public static List<Kart> toDoLine = new List<Kart>();
        public static List<Kart> inProgressLine = new List<Kart>();
        public static List<Kart> doneLine = new List<Kart>();

        public Board(){
            VarsayilanBoard();
        }

        public void VarsayilanBoard(){
            Takim takim = new Takim();
            int count = 1;
            foreach (var item in Takim.takimListesi)
            {
                Kart yeniKart = new Kart("varsayılan"+ count.ToString(), "icerik"+ count.ToString(), item.Id, BuyuklukEnum.S.ToString());
                Board.toDoLine.Add(yeniKart);
                count++; 
            }
        }
    }
}