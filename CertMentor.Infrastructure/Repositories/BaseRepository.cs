using CertMentor.Infrastructure.Persistence;

namespace CertMentor.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly CertMentorDbContext _certMentorDbContext;

        protected BaseRepository(CertMentorDbContext certMentorDbContext)
        {
            _certMentorDbContext = certMentorDbContext;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entityEntry = await _certMentorDbContext.AddAsync(entity, cancellationToken);
            return entityEntry.Entity;
        }

        public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _certMentorDbContext.Update(entity);
            return Task.CompletedTask;
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _certMentorDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
