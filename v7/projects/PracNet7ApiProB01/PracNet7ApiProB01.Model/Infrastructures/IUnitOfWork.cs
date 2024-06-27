using PracNet7ApiProB01.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        IGeneralRoleRepository GeneralRoleRepository { get; }

        int Save();
    }
}
