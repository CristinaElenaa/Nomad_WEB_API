using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nomad.DataAccess.Data;
using Nomad.DataAccess.Helpers;
using Nomad.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Implementations
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly Cloudinary? _cloudinary;
        protected readonly IOptions<CloudinarySettings>? _config;

        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public Repository(ApplicationDbContext context, IOptions<CloudinarySettings> config)
        {
            _dbContext = context;
            var acc = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
           );

             _cloudinary = new Cloudinary(acc);
            
          
        }

        public async Task<TEntity> Get(int id)
        {

            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Remove(TEntity entity)
        {
             _dbContext.Set<TEntity>().Remove(entity);
        }


    }
}
