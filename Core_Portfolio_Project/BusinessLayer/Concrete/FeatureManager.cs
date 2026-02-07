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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _IFeatureDal;

        public FeatureManager(IFeatureDal ıFeatureDal)
        {
            _IFeatureDal = ıFeatureDal;
        }
        public Feature GetByID(int id)
        {
            return _IFeatureDal.GetByID(id);
        }

        public List<Feature> TGetList()
        {
            return _IFeatureDal.GetList();
        }

        public void Tadd(Feature t)
        {
            _IFeatureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _IFeatureDal.Delete(t);
        }

        public void TUpdate(Feature t)
        {
            _IFeatureDal.Update(t);
        }

    }
}
