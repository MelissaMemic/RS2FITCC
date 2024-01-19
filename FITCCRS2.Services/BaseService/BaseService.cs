﻿using AutoMapper;
using FITCCRS2.Model.SearchObjects;
using FITCCRS2.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.BaseService
{
    public class BaseService<T, TDb, TSearch>:IBaseService<T, TSearch> where T:class where TDb : class where TSearch : BaseSearchObject 
    {
        public RS2SeminarskiContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public BaseService(RS2SeminarskiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<T> GetAll(TSearch search = null)
        {
            var entity = _context.Set<TDb>().AsQueryable();

            entity = AddFilter(entity, search);

            entity = AddInclude(entity, search);

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = entity.ToList();
            //NOTE: elaborate IEnumerable vs IList
            return _mapper.Map<IList<T>>(list);
        }
        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public T GetById(int id)
        {
            var set = _context.Set<TDb>();

            var entity = set.Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
