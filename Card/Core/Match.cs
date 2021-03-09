using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class Match : BaseMatch
    {
        protected Dictionary<ETrigger, List<TriggerObserver>> subscriptions = new Dictionary<ETrigger, List<TriggerObserver>>();
        override public T SendEvent<T>(IEvent<T> e)
        {
            return ((Event<T>)e).Activate(this);
        }

        public override void SignalTrigger(BaseCard card, ETrigger trigger)
        {
            foreach(TriggerObserver observer in GetSubscribers(trigger)) {
                SendSignal(card, trigger, observer);
            }
        }

        override public void SubscribeTrigger(TriggerObserver observer, ETrigger trigger)
        {
            List<TriggerObserver> subs = GetSubscribers(trigger);
            if (subs.Contains(observer))
            {
                System.Console.Error.WriteLine("Subsribtion already exists");
                return;
            }
            subs.Add(observer);
        }

        override public void UnSubsribeTrigger(TriggerObserver observer)
        {
            foreach (KeyValuePair<ETrigger, List<TriggerObserver>> observers in subscriptions)
            {
                observers.Value.Remove(observer);
            }
        }

        protected void SendSignal(BaseCard card, ETrigger trigger, TriggerObserver observer)
        {
            switch(trigger)
            {
                case ETrigger.onDraw:
                    observer.OnOtherDraw(card);
                    break;
                case ETrigger.onPlay:
                    observer.OnOtherPlay(card);
                    break;
                case ETrigger.onDie:
                    observer.OnOtherDie(card);
                    break;
                case ETrigger.onBounce:
                    observer.OnOtherBounce(card);
                    break;
                default:
                    return;
            }
        }

        private List<TriggerObserver> GetSubscribers(ETrigger trigger)
        {
            if (!subscriptions.ContainsKey(trigger))
            {
                subscriptions[trigger] = new List<TriggerObserver>();
            }
            return subscriptions[trigger];
        }

    }
}
