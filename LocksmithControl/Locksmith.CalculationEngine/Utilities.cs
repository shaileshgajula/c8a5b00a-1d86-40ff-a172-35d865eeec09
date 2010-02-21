using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locksmith.CalculationEngine
{
    [Serializable]
    public static class Utilities
    {
        public static string ClearWhiteSpaces(string stringItem)
        {
            while (stringItem.Contains(' '))
            {
                stringItem = stringItem.Replace(" ", string.Empty);
            }

            return stringItem;
        }
    }
}
