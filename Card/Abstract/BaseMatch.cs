using System.Collections.Generic;

enum PlayerIds { None, Player, Opponent };

namespace Card
{
    abstract class BaseMatch : IMatch
    {

        private readonly Player player;
        private readonly Player opponent;

        public BaseMatch()
        {
            player = new Player((int)PlayerIds.Player);
            opponent = new Player((int)PlayerIds.Opponent);
        }

        public Player GetPlayer(PlayerIds id)
        {
            return player.GetId() == (int)id ? player : opponent;
        }

        public Player GetOpponent(PlayerIds id)
        {
            return player.GetId() == (int)id ? opponent : player;
        }

        public void LoadDeck(PlayerIds playerId, List<BaseCard> deck)
        {
            foreach(BaseCard card in deck)
            {
                card.ownerId = playerId;
                card.ConnectState(this);
            }

            GetPlayer(playerId).deck = deck;
        }

        public void DrawCard(PlayerIds id)
        {
            GetPlayer(id).deck[0].ActionMove(Zone.Deck, Zone.Hand);
        }

        public abstract T SendEvent<T>(IEvent<T> e);
        public abstract void SubscribeTrigger(TriggerObserver observer, ETrigger trigger);
        public abstract void UnSubsribeTrigger(TriggerObserver observer);
        public abstract void SignalTrigger(BaseCard card, ETrigger trigger);
    }
}
