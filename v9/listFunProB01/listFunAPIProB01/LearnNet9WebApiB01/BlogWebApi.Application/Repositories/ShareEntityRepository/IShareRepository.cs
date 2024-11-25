using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Repositories.ShareEntityRepository
{
    public interface IShareRepository : IGenericRepository<ShareEntity>
    {
    }
}
