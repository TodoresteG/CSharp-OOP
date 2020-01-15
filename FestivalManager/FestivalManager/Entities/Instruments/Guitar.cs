using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        protected override int RepairAmount => 60;
    }
}
