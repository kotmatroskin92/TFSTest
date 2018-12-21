﻿using System;

namespace ToyotaSpec.Enums
{
    public sealed class ReportName
    {
        private readonly String _name;
        public static readonly ReportName VinWalk = new ReportName("VIN Walk");

        private ReportName(String name)
        {
            _name = name;
        }

        public override String ToString()
        {
            return _name;
        }
    }
}
