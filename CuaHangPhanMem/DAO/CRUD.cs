using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public interface CRUD
    {
        List<Object> GetList();
        bool Create(Object obj);
        bool Update(Object obj);
        bool Delete(int id);
    }
}
