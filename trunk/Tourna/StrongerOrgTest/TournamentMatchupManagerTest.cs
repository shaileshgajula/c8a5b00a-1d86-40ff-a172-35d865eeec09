using StrongerOrg.BL.Jobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StrongerOrg.BL.DL;
using System.Collections.Generic;
using StrongerOrg.BL.TournamentAlgorithm;

namespace StrongerOrgTest
{


    /// <summary>
    ///This is a test class for TournamentMatchupManagerTest and is intended
    ///to contain all TournamentMatchupManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TournamentMatchupManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        /// <summary>
        ///A test for GetMatchupsToNotify
        ///</summary>
        [TestMethod()]
        public void GetMatchupsToNotifyTest()
        {

            var actual = TournamentMatchupManager.GetMatchupsToNotify();
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NotifyPlayers
        ///</summary>
        [TestMethod()]
        public void NotifyPlayersTest()
        {
            MatchupsToNotifyGetResult tm = new MatchupsToNotifyGetResult()
            {
                Id = 12,
                PlayerAEmail = "piniusha@gmail.com",
                PlayerAId = new Guid("B306EEFB-8B00-44D5-BE41-18829CC0A131"),
                PlayerAName = "Pini Usha",
                PlayerBId = new Guid("2509148F-C595-4A7E-9800-ECBB371DB857"),
                PlayerBEmail = "A1@strongerorg.com",
                PlayerBName = "Daniel Usha",
                TournamentId = new Guid("FFFE4BFF-871C-410B-8190-39954A77CDFA"), 
                Round = 1,
                Start = DateTime.Now.AddDays(8),
                TournamentName = "Ping Pong",
                Locations = "Aquarium",
                OrganisationId = new Guid("57baf8c4-3524-4273-a12b-c6cea946e920") // visa cal
            };
            TournamentMatchupManager.NotifyPlayers(tm);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
