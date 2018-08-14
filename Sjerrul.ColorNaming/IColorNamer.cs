using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.ColorNaming
{
    /// <summary>
    /// Interfaces for classes that can convert a color into a readable name
    /// </summary>
    public interface IColorNamer
    {
        /// <summary>
        /// Gets the human-readably name of the color for the passed in hexvalue.
        /// </summary>
        /// <param name="hexValue">The hexadecimal value.</param>
        /// <returns>The human-readble name of the color when found, NULL otherwise</returns>
        string GetColorName(string hexValue);

        /// <summary>
        /// Gets the human-readably name of the color for the passed in hexvalue.
        /// </summary>
        /// <param name="r">The red component of the color.</param>
        /// <param name="g">The green component of the color.</param>
        /// <param name="b">The blue component of the color.</param>
        /// <returns>The human-readble name of the color when found, NULL otherwise</returns>
        string GetColorName(int r, int g, int b);
    }
}
