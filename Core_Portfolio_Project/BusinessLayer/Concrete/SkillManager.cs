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
    public class SkillManager:ISkillService
    {
        private readonly ISkillDal _ISkillDal;

        public SkillManager(ISkillDal ıSkillDal)
        {
            _ISkillDal = ıSkillDal;
        }

        public Skill GetByID(int id)
        {
            return _ISkillDal.GetByID(id);
        }

        public List<Skill> TGetList()
        {
            return _ISkillDal.GetList();
        }

        public void Tadd(Skill t)
        {
            _ISkillDal.Insert(t);
        }

        public void TDelete(Skill t)
        {
            _ISkillDal.Delete(t);
        }

        public void TUpdate(Skill t)
        {
            _ISkillDal.Update(t);
        }

    }
}
