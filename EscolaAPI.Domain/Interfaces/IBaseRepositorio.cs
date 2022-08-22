using EscolaAPI.Domain.Models;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IBaseRepositorio<T> where T : EntidadeBase
    {
        public List<T> GetAll();

        public T GetById(int id);

        public void Post(T entity);

        public void Put(T entity);
        
        public void Delete(T entity);
       
        
    }
}