﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    class ConcreteCard : Card
    {
        override protected void OnDraw()
        {
            // ActionMove(Zone.Hand, Zone.Battlefield, 0); // <--- Do activate onPlay()
            // ActionPut(Zone.Hand, Zone.Battlefield, 0) <--- Do not activate onPlay()
        }

        override protected void OnPlay()
        {
            // Console.WriteLine("OnPlay in derived");
        }
    }
}
