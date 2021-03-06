﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConv
{
    /// <summary>
    /// quantity type of volume
    /// </summary>
    public class Volume : Quantity<VolumeUnit, Volume>
    {
        public Volume(string quantity) : base(quantity)
        {
        }

        public Volume(decimal value, VolumeUnit unit) : base(value, unit)
        {
        }

        public Volume(string value, string unit) : base(value, unit)
        {
        }

        public Volume(decimal value, string unit) : base(value, unit)
        {
        }

        public Volume(string value, VolumeUnit unit) : base(value, unit)
        {
        }

        protected internal override Volume ConvertValue(VolumeUnit toUnit)
        {
            if (toUnit == this.Unit) return new Volume(this.Value, toUnit);
            var targetValue = this.CalculateConversion(this.Unit, toUnit);
            return new Volume(targetValue, toUnit);
        }
    }
}
