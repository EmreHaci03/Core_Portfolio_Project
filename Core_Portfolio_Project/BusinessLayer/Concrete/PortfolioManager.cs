using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDal _IPortfolioDal;

        public PortfolioManager(IPortfolioDal ıPortfolioDal)
        {
            _IPortfolioDal = ıPortfolioDal;
        }

        public Portfolio GetByID(int id)
        {
            return _IPortfolioDal.GetByID(id);
        }

        public List<Portfolio> TGetList()
        {
            return _IPortfolioDal.GetList();
        }

        public void Tadd(Portfolio t)
        {
            _IPortfolioDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _IPortfolioDal.Delete(t);
        }

        public void TUpdate(Portfolio t)
        {
            _IPortfolioDal.Update(t);
        }

    }
}
