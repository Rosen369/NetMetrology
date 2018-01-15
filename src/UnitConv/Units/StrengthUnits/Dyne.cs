﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConv.Units.StrengthUnits
{
    public class Dyne : StrengthUnit
    {
        private Dyne()
        {

        }

        private static readonly Dyne _instance = new Dyne();

        public static Dyne GetInstance()
        {
            return _instance;
        }

        protected override void InitDisplay()
        {
            _display = new Dictionary<Languages, string>
            {
                { Languages.Chinese, "达因" },
                { Languages.English, "dyn" }
            };
        }

        protected override void InitRate()
        {
            _rate = 100000m;
        }
    }
}
