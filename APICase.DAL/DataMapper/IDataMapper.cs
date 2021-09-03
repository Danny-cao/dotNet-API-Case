using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICase.DAL.DataMapper
{
    public interface IDataMapper<T, Key>
    {
        Task<List<T>> FindAll();
        Task<T> Find(Key key);
        Task Insert(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<bool> Exists(T item);
    }
}
