using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StrongerOrg.BL.DL;
using System.Configuration;


namespace StrongerOrg.BL
{
    internal class CultureEnvironment
    {
        private static CultureEnvironment _instance;

        //cache--id - list of invalid dates
        private Dictionary<Guid, IEnumerable<DateTime>> _holidayCache;

        //i just though of this type of singleton, i think its nice and clean
        public static CultureEnvironment Instance
        {
            get
            {
                _instance = _instance ?? new CultureEnvironment();

                return _instance;
            }

        }
        //constructor
        private CultureEnvironment()
        {
            this._holidayCache = new Dictionary<Guid, IEnumerable<DateTime>>();
        }

        public IEnumerable<DateTime> GetInvalidDates(Guid orgId)
        {
            if (this._holidayCache.ContainsKey(orgId))
                return this._holidayCache[orgId];

            //cache and return
            IEnumerable<DateTime> holidays;
            using (TournamentsDataContext db = new TournamentsDataContext(ConfigurationManager.ConnectionStrings["StrongerOrgString"].ConnectionString))
            {
                 holidays = db.OrganisationHolidays.Where(x => x.OrganisationId == orgId)
                                                      .Select(y => y.Date).ToList();
            }

            this._holidayCache.Add(orgId, holidays);

            return holidays;
        }

        public bool ClearCache(Guid orgId)
        {
            return this._holidayCache.Remove(orgId);
        }
      



    }
}
