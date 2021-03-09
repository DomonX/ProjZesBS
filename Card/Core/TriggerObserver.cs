using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class TriggerObserver
    {
        public virtual void OnOtherPlay(BaseCard triggerSource) { }
        public virtual void OnOtherDie(BaseCard triggerSource) { }

        public virtual void OnOtherDraw(BaseCard triggerSource) { }

        public virtual void OnOtherBounce(BaseCard triggerSource) { }
    }
}
