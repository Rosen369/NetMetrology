﻿using System;
using System.Collections.Generic;
using System.Text;
using UnitConv.Units;
using UnitConv.Utils;

namespace UnitConv
{
    /// <summary>
    /// base class of quantity
    /// </summary>
    /// <typeparam name="TUnit">specific quantity unit</typeparam>
    /// <typeparam name="TChild">specific quantity type</typeparam>
    public abstract class Quantity<TUnit, TChild> where TUnit : Unit where TChild : Quantity<TUnit, TChild>
    {
        public Quantity(decimal value, TUnit unit)
        {
            this.Value = value;
            this.Unit = unit;
        }

        public Quantity(string quantity)
        {
            var result = Util.ConvertQuantity<TUnit>(quantity);
            this.Value = result.Number;
            this.Unit = result.Unit;
        }

        public Quantity(string value, string unit)
        {
            this.Value = Util.ConvertValue(value);
            this.Unit = Util.ConvertUnit<TUnit>(unit);
        }

        public Quantity(decimal value, string unit)
        {
            this.Value = value;
            this.Unit = Util.ConvertUnit<TUnit>(unit);
        }

        public Quantity(string value, TUnit unit)
        {
            this.Value = Util.ConvertValue(value);
            this.Unit = unit;
        }

        public decimal Value { get; protected set; }

        public TUnit Unit { get; protected set; }

        protected internal abstract TChild ConvertValue(TUnit toUnit);

        protected internal decimal CalculateConversion(TUnit from, TUnit to)
        {
            var fromRate = from.Rate;
            var toRate = to.Rate;
            var fromSub = from.Subtrahend;
            var toSub = to.Subtrahend;
            var targetValue = ((this.Value + fromSub) * fromRate - toSub) / toRate;
            return targetValue;
        }

        public TChild ConvertTo(TUnit toUnit)
        {
            return this.ConvertValue(toUnit);
        }

        public override string ToString()
        {
            return this.ToString(UnitConvSettings.DefaultLanguage, UnitConvSettings.DefaultDigits);
        }

        public virtual string ToString(int digits)
        {
            return this.ToString(UnitConvSettings.DefaultLanguage, digits);
        }

        public virtual string ToString(Languages language)
        {
            return this.ToString(language, UnitConvSettings.DefaultDigits);
        }

        public virtual string ToString(Languages language, int digits)
        {
            var value = Math.Round(this.Value, digits).ToString();
            return value + this.Unit.GetDisplay(language);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TChild)) return false;
            return this.Equals(obj as TChild);
        }

        public bool Equals(TChild quantity)
        {
            var value = quantity.ConvertValue(this.Unit).Value;
            return value == this.Value;
        }

        public override int GetHashCode()
        {
            var str = this.Value.ToString() + this.Unit.GetDisplay(Languages.Symbol);
            var hashCode = str.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Quantity<TUnit, TChild> lq, Quantity<TUnit, TChild> rq)
        {
            return lq.Equals(rq);
        }

        public static bool operator !=(Quantity<TUnit, TChild> lq, Quantity<TUnit, TChild> rq)
        {
            return !lq.Equals(rq);
        }

        public static bool operator >=(Quantity<TUnit, TChild> lq, Quantity<TUnit, TChild> rq)
        {
            if (!(lq is TChild)) return false;
            if (!(rq is TChild)) return false;
            var rqValue = rq.ConvertValue(lq.Unit).Value;
            return lq.Value >= rqValue;
        }

        public static bool operator <=(Quantity<TUnit, TChild> lq, Quantity<TUnit, TChild> rq)
        {
            if (!(lq is TChild)) return false;
            if (!(rq is TChild)) return false;
            var rqValue = rq.ConvertValue(lq.Unit).Value;
            return lq.Value <= rqValue;
        }

        public static bool operator >(Quantity<TUnit, TChild> lq, Quantity<TUnit, TChild> rq)
        {
            if (!(lq is TChild)) return false;
            if (!(rq is TChild)) return false;
            var rqValue = rq.ConvertValue(lq.Unit).Value;
            return lq.Value > rqValue;
        }

        public static bool operator <(Quantity<TUnit, TChild> lq, Quantity<TUnit, TChild> rq)
        {
            if (!(lq is TChild)) return false;
            if (!(rq is TChild)) return false;
            var rqValue = rq.ConvertValue(lq.Unit).Value;
            return lq.Value < rqValue;
        }
    }
}
