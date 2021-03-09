using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    abstract class BaseCard : TriggerObserver
    {
        public PlayerIds OwnerId { get; set; } = PlayerIds.None ;
        public PlayerIds ControllerId { get; set; } = PlayerIds.None;
        public Zone CurrentZone { get; set; }

        public IMatch State {
            get => _state;
            set {
                _state = value;
                LcStart(); 
            } 
        }

        private IMatch _state;

        public virtual void LcStart() { }

        public virtual void LcEnd()
        {
            State.UnSubsribeTrigger(this);
        }

        public void ActionMove(Zone src, Zone dest, int position = 0)
        {
            ActionPut(src, dest, position);
            if(src == Zone.Hand && dest == Zone.Battlefield)
            {
                ControllerId = OwnerId;
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
                State.SignalTrigger(this, ETrigger.onDraw);
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
