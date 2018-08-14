//----------------------------------------------------------------------
// Namespace Christo.GFX.Conversion
// Author: Christo Greeff
// Date: 24/June/2008
//----------------------------------------------------------------------
// 24/June/2008 : New: GFXConversionException, HSL
//----------------------------------------------------------------------

using System;
using System.Drawing;

namespace Christo.GFX.Conversion
{
    /// <summary>
    /// Color Util Exception
    /// </summary>
    public class GFXConversionException : Exception
    {
        public GFXConversionException(string message, Exception innerException)
            : base(message, innerException)
        {
            //ToDo: Implement if needed
        }
    }

    /// <summary>
    /// HSL (Hue/Saturation/Luminance) Class
    /// </summary>
    public class HSL
    {
        #region Private members

        /// <summary>
        /// private hue
        /// </summary>
        private double _h;

        /// <summary>
        /// private saturation
        /// </summary>
        private double _s;

        /// <summary>
        /// private luminance
        /// </summary>
        private double _l;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public HSL()
        {
            try
            {
                this.HSLHelper(0, 0, 0);
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL Constructor Error", ee);
            }
        }

        /// <summary>
        /// Constructor with ARGB color
        /// </summary>
        /// <param name="color">System.Drawing.Color value</param>
        public HSL(Color color)
        {
            try
            {
                this.HSLHelper(color.GetHue() / 360.0, color.GetSaturation(), color.GetBrightness());
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL Constructor Error", ee);
            }
        }

        /// <summary>
        /// Constructor with RGB color
        /// </summary>
        /// <param name="R">Red component with a value from 0 to 255</param>
        /// <param name="G">Green component with a value from 0 to 255</param>
        /// <param name="B">Blue component with a value from 0 to 255</param>
        public HSL(byte R, byte G, byte B)
        {
            try
            {
                Color temp = Color.FromArgb(R, G, B);
                this.HSLHelper(temp.GetHue() / 360.0, temp.GetSaturation(), temp.GetBrightness());
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL Constructor Error", ee);
            }
        }

        /// <summary>
        /// Constructor with HSL
        /// </summary>
        /// <param name="Hue">Varies from magenta - red - yellow - green - cyan - blue - magenta, described as an angle around a circle from 0.0 - 360.0 degrees</param>
        /// <param name="Saturation">Varies from 0.0 and 1.0 and describes how "grey" the colour is, with 0 being completely unsaturated (grey, white or black) and 1 being completely saturated</param>
        /// <param name="Luminance">Varies from 0.0 and 1.0 and ranges from black at 0.0, through the standard colour itself at 0.5 to white at 1.0</param>
        public HSL(double Hue, double Saturation, double Luminance)
        {
            try
            {
                this.HSLHelper(Hue, Saturation, Luminance);
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL Construcclasstor Error", ee);
            }
        }

        /// <summary>
        /// HSL Helper
        /// </summary>
        /// <param name="Hue">Varies from magenta - red - yellow - green - cyan - blue - magenta, described as an angle around a circle from 0.0 - 360.0 degrees</param>
        /// <param name="Saturation">Varies from 0.0 and 1.0 and describes how "grey" the colour is, with 0 being completely unsaturated (grey, white or black) and 1 being completely saturated</param>
        /// <param name="Luminance">Varies from 0.0 and 1.0 and ranges from black at 0.0, through the standard colour itself at 0.5 to white at 1.0</param>
        private void HSLHelper(double Hue, double Saturation, double Luminance)
        {
            try
            {
                this.H = Hue;
                this.S = Saturation;
                this.L = Luminance;
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL HSLHelper Error", ee);
            }
        }

        /// <summary>
        /// Set helper function
        /// </summary>
        /// <param name="value">value that must be between 0 and 1</param>
        /// <returns>double value</returns>
        private double SetHelper(double value)
        {
            try
            {
                return (value > 1) ? 1.0 : (value < 0) ? 0 : value;
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL SetHelper Error", ee);
            }
        }

        /// <summary>
        /// Gets or sets the Hue value
        /// </summary>
        public double H
        {
            get
            {
                return this._h;
            }
            set
            {
                this._h = this.SetHelper(value);
            }
        }

        /// <summary>
        /// Gets or sets the Saturation value
        /// </summary>
        public double S
        {
            get
            {
                return this._s;
            }
            set
            {
                this._s = this.SetHelper(value);
            }
        }

        /// <summary>
        /// Gets or sets the Luminance value
        /// </summary>
        public double L
        {
            get
            {
                return this._l;
            }
            set
            {
                this._l = this.SetHelper(value);
            }
        }

        /// <summary>
        /// <para>Convert from the current HSL to RGB</para>
        /// <para>http://en.wikipedia.org/wiki/HSV_color_space#Conversion_from_HSL_to_RGB</para>
        /// </summary>
        public Color Color
        {
            get
            {
                double[] t = new double[] { 0, 0, 0 };

                try
                {
                    double tH = this._h;
                    double tS = this._s;
                    double tL = this._l;

                    if (tS.Equals(0))
                    {
                        t[0] = t[1] = t[2] = tL;
                    }
                    else
                    {
                        double q, p;

                        q = tL < 0.5 ? tL * (1 + tS) : tL + tS - (tL * tS);
                        p = 2 * tL - q;

                        t[0] = tH + (1.0 / 3.0);
                        t[1] = tH;
                        t[2] = tH - (1.0 / 3.0);

                        for (byte i = 0; i < 3; i++)
                        {
                            t[i] = t[i] < 0 ? t[i] + 1.0 : t[i] > 1 ? t[i] - 1.0 : t[i];

                            if (t[i] * 6.0 < 1.0)
                                t[i] = p + ((q - p) * 6 * t[i]);
                            else
                                if (t[i] * 2.0 < 1.0)
                                    t[i] = q;
                                else
                                    if (t[i] * 3.0 < 2.0)
                                        t[i] = p + ((q - p) * 6 * ((2.0 / 3.0) - t[i]));
                                    else
                                        t[i] = p;
                        }
                    }
                }
                catch (Exception ee)
                {
                    throw new GFXConversionException("HSL Color Error", ee);
                }

                return Color.FromArgb((int)(t[0] * 255), (int)(t[1] * 255), (int)(t[2] * 255));
            }
        }

        /// <summary>
        /// Modify the current HSL brightness
        /// </summary>
        /// <param name="brightness">brightness value</param>
        /// <returns>HSL</returns>
        private HSL BrightnessHelper(double brightness)
        {
            try
            {
                this.L = this.L * brightness;
            }
            catch (Exception ee)
            {
                throw new GFXConversionException("HSL BrightnessHelper Error", ee);
            }

            return new HSL(H, S, L);
        }

        /// <summary>
        /// Modify the current HSL brightness
        /// </summary>
        /// <param name="brightness">brightness value</param>
        /// <returns>HSL</returns>
        public HSL Brightness(double brightness)
        {
            return this.BrightnessHelper(brightness);
        }

        /// <summary>
        /// Modify the current HSL brightness
        /// </summary>
        /// <param name="brightness">brightness value</param>
        /// <returns>Color</returns>
        public Color BrightnessC(double brightness)
        {
            return this.BrightnessHelper(brightness).Color;
        }
    }
}