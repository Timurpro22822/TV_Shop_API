using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITVService
    {
        IEnumerable<TVDto> GetAll();
        TVDto? GetById(int id);
        void Create(TVDto tv);
        void Edit(TVDto tv);
        void Delete(int id);
    }
}
