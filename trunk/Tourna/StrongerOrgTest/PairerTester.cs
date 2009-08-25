using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrongerOrg.BackOffice.PairsAlgorithm;

namespace StrongerOrgTest
{
    [TestClass]
    public class PairerTester
    {
        [TestMethod]
        public void PairTest()
        {
            //
            // TODO: Add test logic	here
            //

            List<PlayersEntity> playersPairs = PairsAlgo.BuildPairs(new Guid("9A2CC2A6-625F-480A-81E2-32135AB445E8"));

        }
    }
}
