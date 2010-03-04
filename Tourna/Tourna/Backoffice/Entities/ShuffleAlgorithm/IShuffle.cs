using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongerOrg.Backoffice.Entities.ShuffleAlgorithm
{
    interface IShuffle<T>
    {
        List<T> Execute(List<T> list);
    }
}
