using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.BL
{
    public class CultureManager
    {
        private Guid _organistaionId;
        private IEnumerable<DateTime> _invalidDates;
        private CultureEnvironment env;
        public CultureManager(Guid orgId)
        {
            this._organistaionId = orgId;

            env = CultureEnvironment.Instance;
            this._invalidDates = env.GetInvalidDates(orgId);
        }

        public IEnumerable<DateTime> GetNextBusinessDay(DateTime startDate)
        {
            for (DateTime strtDt = startDate; ; strtDt = strtDt.AddDays(1))
            {
                if (strtDt.DayOfWeek == DayOfWeek.Saturday)
                    continue;

                if (strtDt.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                if (this._invalidDates.FirstOrDefault(d => d.Date == strtDt.Date) != DateTime.MinValue)
                    continue;

                yield return strtDt;
            }
        }

        public void ClearCache() 
        {
            env.ClearCache(this._organistaionId);
        }
    }
}
