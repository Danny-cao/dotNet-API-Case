using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICase.DAL.DataMapper
{
    public abstract class DataMapperBase<T, Key> : IDataMapper<T, Key> where T : class
    {
        protected readonly AdresContext adresContext;

        protected DataMapperBase(AdresContext context) 
        {
            adresContext = context;
        }

        public abstract Task<List<T>> FindAll();
        public abstract Task<List<T>> FindAll(T item);
        public abstract Task<T> Find(Key key);
        public abstract Task Insert(T item);
        public abstract Task Update(T item);
        public abstract Task Delete(T item);
        public abstract Task<bool> Exists(T item);
    }
}
