using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseMatch m = new Match();
            List<BaseCard> cards = new List<BaseCard>();
            Card crd = new JumperCard();
            Card crd2 = new SummonerCard();
            cards.Add(crd2);
            cards.Add(crd);
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            cards.Add(new SummonerCard());
            m.LoadDeck(PlayerIds.Player, cards);
            m.DrawCard(PlayerIds.Player);
            crd2.ActionMove(Zone.Hand, Zone.Battlefield);
            m.DrawCard(PlayerIds.Player);
            crd.ActionMove(Zone.Hand, Zone.Battlefield);
            m.DrawCard(PlayerIds.Player);
        }
    }
}
