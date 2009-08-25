using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongerOrg.Backoffice.Entities
{
    public class CultureManager
    {
        private Guid _organistaionId;
        private IEnumerable<DateTime> _invalidDates;
        public CultureManager(Guid orgId)
        {
            this._organistaionId = orgId;

            CultureEnvironment env = CultureEnvironment.Instance;
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

                if (this._invalidDates.Contains(strtDt))
                    continue;

                yield return strtDt;
            }
        }
    }
}
