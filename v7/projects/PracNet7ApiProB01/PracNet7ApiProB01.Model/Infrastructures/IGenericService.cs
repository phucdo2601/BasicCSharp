using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Infrastructures
{
    public interface IGenericService<T>
    {
        #region Find All
        List<T> FindAll();
        #endregion

        #region Find by id
        T FindById(Guid id);
        #endregion

        
    }
}
