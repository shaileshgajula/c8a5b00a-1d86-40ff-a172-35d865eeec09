using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongerOrg.BL.Entities
{
    public class TournamentOrganisation
    {
        public Guid TournamentId { get; set; }
        public Guid OrganisationId { get; set; }
    }
}
