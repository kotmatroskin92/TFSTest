using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Objects
{
    public class VINWalkTabular
    {
        public string VIN { get; set; }
        public int YEAR { get; set; }

        public VINWalkTabular(string vin, int year)
        {
            VIN = vin;
            YEAR = year;
        }

    }
}
