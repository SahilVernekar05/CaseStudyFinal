using BondConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BondConsoleApp.Repository
{
    public interface IBond
    {
        public void ImportDataFromCsv(Stream csvStream);

        public void UpdateBondData(EditBondModel ebm);

        public void DeleteBondData(int SecurityID);

        public List<EditBondModel> GetBondsData();
    }
}
