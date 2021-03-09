using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    abstract class BaseCard : TriggerObserver
    {
        public PlayerIds ownerId = PlayerIds.None;
        public PlayerIds controllerId = PlayerIds.None;
        public Zone currentZone;
        protected IMatch state;

        public void ConnectState(IMatch state)
        {
            this.state = state;
            LcStart();
        }

        public virtual void LcStart()
        {

        }

        public virtual void LcEnd()
        {
            state.UnSubsribeTrigger(this);
        }

        public void ActionMove(Zone src, Zone dest, int position = 0)
        {
            ActionPut(src, dest, position);
            if(src == Zone.Hand && dest == Zone.Battlefield)
            {
                controllerId = ownerId;
                OnPlay();
            }

            if(src == Zone.Battlefield && dest == Zone.Graveyard)
            {
                OnDie();
            }

            if(src == Zone.Battlefield && dest == Zone.Hand)
            {
                OnBounce();
            }

            if(src == Zone.Deck && dest == Zone.Hand)
            {
                OnDraw();
                state.SignalTrigger(this, ETrigger.onDraw);
            }
        }

        public void ActionAttack() 
        { 
        
        }

        public void ActionUse()
        {

        }

        protected abstract void ActionPut(Zone src, Zone dest, int position);

        protected virtual void OnPlay()
        {
            Console.WriteLine("onPlay()");
        }

        protected virtual void OnDie()
        {
            Console.WriteLine("onDie()");
        }

        protected virtual void OnBounce()
        {
            Console.WriteLine("onBounce()");
        }

        protected virtual void OnDraw()
        {
            Console.WriteLine("onDraw()");
        }
    }
}
