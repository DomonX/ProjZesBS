using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Player
    {
        public List<BaseCard> hand = new List<BaseCard>();
        public List<BaseCard> deck = new List<BaseCard>();
        public List<BaseCard> graveyard = new List<BaseCard>();
        public List<BaseCard> battlefield = new List<BaseCard>();
        private int id;
        public Player(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }
    }
}
