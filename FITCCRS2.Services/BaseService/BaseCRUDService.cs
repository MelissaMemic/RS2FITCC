using AutoMapper;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.BaseService
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch>, IBaseCRUDService<T, TSearch, TInsert, TUpdate> where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(RS2SeminarskiContext context, IMapper mapper):base(context,mapper)
        {

        }
        public T Insert(TInsert insert)
        {
            var set = _context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(insert);

            set.Add(entity);

            BeforeInsert(insert, entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);

        }

        public virtual void BeforeInsert(TInsert insert, TDb entity)
        {

        }
        public T Update(int id, TUpdate update)
        {
            var set = _context.Set<TDb>();

            var entity = set.Find(id);

            if (entity != null)
            {
                _mapper.Map(update, entity);
            }
            else
            {
                return null;
            }

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public T Delete(int id)
        {
           
                var set = _context.Set<TDb>();

                var entity = set.Find(id);

                if (entity != null)
                {
                    set.Remove(entity);
                }
                else
                {
                    return null;
                }

                _context.SaveChanges();

                return _mapper.Map<T>(entity);
        }
        
    }
}
