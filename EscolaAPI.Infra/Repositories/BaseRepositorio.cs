using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;

namespace EscolaAPI.Infra.Repositories
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : EntidadeBase
    {   
        public readonly EscolaContext BancoDeDados;

        public BaseRepositorio(EscolaContext bancoDeDados)
        {
            BancoDeDados = bancoDeDados;
        }
        
        public List<T> GetAll() => BancoDeDados.Set<T>().ToList();

        public T GetById(int id) => BancoDeDados.Set<T>().Where(t => t.Id == id).FirstOrDefault();

        public void Post(T entity)
        {
            BancoDeDados.Set<T>().Add(entity);
            BancoDeDados.SaveChanges();
        }      

        public void Put(T entity)
        {
            BancoDeDados.Set<T>().Update(entity);
            BancoDeDados.SaveChanges();
        }
        public void Delete(T entity) 
        {
            BancoDeDados.Set<T>().Remove(entity);
            BancoDeDados.SaveChanges();
        }
    }

}