﻿namespace UnitConv
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UnitConverter : IUnitConverter
    {
        public Length ConvertLength(float value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            return new Length(value, fromUnit).ConvertValue(toUnit);
        }
    }
}
