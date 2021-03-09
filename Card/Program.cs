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
            cards.Add(crd);
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            cards.Add(new ConcreteCard());
            m.LoadDeck(PlayerIds.Player, cards);
            m.DrawCard(PlayerIds.Player);
            crd.ActionMove(Zone.Hand, Zone.Battlefield);
            m.DrawCard(PlayerIds.Player);
            BaseCard c = m.GetPlayer(PlayerIds.Player).battlefield[0];
        }
    }
}
