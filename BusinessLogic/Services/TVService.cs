using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TVService : ITVService
    {
        private readonly TVShopDbContext context;
        private readonly IMapper mapper;

        public TVService(TVShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<TVDto> GetAll()
        {
            var tvs = context.TVs.Include(x => x.Color).ToList();
            return mapper.Map<IEnumerable<TVDto>>(tvs);
        }

        public TVDto? GetById(int id)
        {
            var tvs = context.TVs.Find(id);
            
            if (tvs == null) return null;

            return mapper.Map<TVDto>(tvs);
        }

        public void Create(TVDto tv)
        {
            context.TVs.Add(mapper.Map<TV>(tv));
            context.SaveChanges();
        }
        public void Edit(TVDto tv)
        {
            var data = context.TVs.AsNoTracking().FirstOrDefault(l => l.Id  == tv.Id);
            
            if(data == null) return;

            context.TVs.Update(mapper.Map<TV>(tv));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tv = context.TVs.Find(id);

            if(tv == null) return;

            context.TVs.Remove(tv);
            context.SaveChanges();
        }



    }
}
