using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class JumperCard : Card
    {
        public override void LcStart()
        {
            state.SubscribeTrigger(this, ETrigger.onDraw);
        }

        public override void OnOtherDraw(BaseCard card)
        {
            if(currentZone == Zone.Battlefield)
            {
                state.SendEvent(new MoveCardEvent(card, Zone.Hand, Zone.Battlefield));
            }
        } 
    }
}
