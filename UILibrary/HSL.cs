﻿namespace UILibrary
{
    using System;

    public class HSL
    {
        private int _hue;
        private double _luminance;
        private double _saturation;

        public HSL()
        {
        }

        public HSL(int hue, double saturation, double luminance)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminance = luminance;
        }

        public override string ToString()
        {
            return string.Format("HSL [H={0}, S={1}, L={2}]", this._hue, this._saturation, this._luminance);
        }

        public int Hue
        {
            get
            {
                return this._hue;
            }
            set
            {
                if (value < 0)
                {
                    this._hue = 0;
                }
                else if (value <= 360)
                {
                    this._hue = value;
                }
                else
                {
                    this._hue = value % 360;
                }
            }
        }

        public double Luminance
        {
            get
            {
                return this._luminance;
            }
            set
            {
                if (value < 0.0)
                {
                    this._luminance = 0.0;
                }
                else
                {
                    this._luminance = Math.Min(value, 1.0);
                }
            }
        }

        public double Saturation
        {
            get
            {
                return this._saturation;
            }
            set
            {
                if (value < 0.0)
                {
                    this._saturation = 0.0;
                }
                else
                {
                    this._saturation = Math.Min(value, 1.0);
                }
            }
        }
    }
}

