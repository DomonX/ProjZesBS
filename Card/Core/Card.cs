using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    abstract class Card : BaseCard
    {
        override protected void ActionPut(Zone src, Zone dest, int position)
        {
            state.SendEvent(new MoveCardEvent(this, src, dest, position));
        }
    }
}
