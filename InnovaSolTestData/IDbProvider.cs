using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace InnovaSolTestData
{
    public interface IDbProvider
    {
        IDbConnection GetDbConnection();
    }
}
