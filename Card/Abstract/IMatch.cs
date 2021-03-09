using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    interface IMatch
    {
        T SendEvent<T>(IEvent<T> e);
        void SubscribeTrigger(TriggerObserver observer, ETrigger trigger);
        void UnSubsribeTrigger(TriggerObserver observer);

        void SignalTrigger(BaseCard card, ETrigger trigger);
    }
}
