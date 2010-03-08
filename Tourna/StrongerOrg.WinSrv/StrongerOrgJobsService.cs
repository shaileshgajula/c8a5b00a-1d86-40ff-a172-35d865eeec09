using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using StrongerOrg.BL.Jobs;
using StrongerOrg.BL.Entities;

namespace StrongerOrg.WinSrv
{
    public partial class StrongerOrgJobsService : ServiceBase
    {
        private Timer timer;
        private DateTime lastRun = DateTime.Now;

        public StrongerOrgJobsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Debugger.Launch();
            Debug.Listeners["logging"].WriteLine("service started");
            timer = new Timer(8 * 60 * 60 * 1000); // every 12H
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            this.BuildNewTournaments();
            Debug.Flush();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            BuildNewTournaments();
        }

        private void BuildNewTournaments()
        {
            
            List<TournamentOrganisation> tournamentsToRun = TournamentMatchup.GetTournamentForMatchups();
            Debug.Listeners["logging"].WriteLine(string.Format("{0} Found {1} tournaments to build ", DateTime.Now.ToString(), tournamentsToRun.Count.ToString()));
            if(tournamentsToRun.Count>0)
            {
                foreach (TournamentOrganisation to in tournamentsToRun)
                {
                    TournamentMatchup.Build(to.TournamentId, to.OrganisationId);
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
