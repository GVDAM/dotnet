using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gabriel.RentCar.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly MyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MyContext myContext)
        {
            Db = myContext;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();   
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<List<TEntity>> ObterAtivos(TEntity entity)
        {
            return await DbSet.FromSql($"select * from {entity} where ativo = 1").ToListAsync();
        }

        // -=-=-=-=-=-=- //
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        // -=-=-=-=-=-=- //
        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
