﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConv
{
    public class Power : Quantity<PowerUnit, Power>
    {
        public Power(string quantity) : base(quantity)
        {
        }

        public Power(decimal value, PowerUnit unit) : base(value, unit)
        {
        }

        public Power(string value, string unit) : base(value, unit)
        {
        }

        public Power(decimal value, string unit) : base(value, unit)
        {
        }

        public Power(string value, PowerUnit unit) : base(value, unit)
        {
        }

        protected internal override Power ConvertValue(PowerUnit toUnit)
        {
            if (toUnit == this.Unit) new Power(this.Value, toUnit);
            var basicRate = this.Unit.GetRate();
            var rate = toUnit.GetRate();
            var targetValue = this.Value * basicRate / rate;
            return new Power(targetValue, toUnit);
        }
    }
}
