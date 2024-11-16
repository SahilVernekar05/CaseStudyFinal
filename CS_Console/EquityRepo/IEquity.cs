using CS_Console.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Console.EquityRepo
{
    public interface IEquity
    {
        public void ImportDataFromCsv(Stream csvStream);

        public string UpdateSecurityData(EditEquityModel esm);

        public void DeleteSecurityData(int securityId);

        public List<EditEquityModel> GetSecurityData();
    }
}
