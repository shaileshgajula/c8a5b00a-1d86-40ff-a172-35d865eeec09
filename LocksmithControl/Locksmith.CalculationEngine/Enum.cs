using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locksmith.CalculationEngine
{
    [Serializable]
    public enum PaymentMethods
    {
        Cash = 0,
        CreditCard = 1,
        Check = 2
    }

    [Serializable]
    public enum JobPricing
    {
        Day = 0,
        Night = 1,
        FreeLance = 2
    }
}
