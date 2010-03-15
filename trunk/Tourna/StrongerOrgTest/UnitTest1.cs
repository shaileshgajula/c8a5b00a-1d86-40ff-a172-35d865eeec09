using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrongerOrg.Backoffice.DataLayer;
using PDFDrawer;

namespace StrongerOrgTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DefaultHolidaysUS()
        {
            //
            // TODO: Add test logic	here
            //

            //using (TournaDataContext db = new TournaDataContext())
            //{
               // var holidays = db.DefaultHolidays;

            try
            {
                int test = 3;
                String enumVal = Enum.GetName(typeof(Test), test);
            }
            catch (Exception ex)
            {

            }
            //}
        }

        [TestMethod]
        public void TestPdfExport()
        {
            PDFGridExport export = new PDFGridExport();
            

        }

        [TestMethod]
        public void TestGetTournamentForMatchups()
        {
           var c= StrongerOrg.BL.Jobs.TournamentMatchupManager.GetTournamentForMatchups();


        }
        [TestMethod]
        public void TestNotifiModerator()
        {
            StrongerOrg.BL.Jobs.TournamentMatchupManager.NotifiModerator(Guid.Empty, new Guid("57baf8c4-3524-4273-a12b-c6cea946e920"),"test1", DateTime.Now); 
            

        }
    }


    public enum Test
    {
        Hello = 0,
        World = 1
    }
}
