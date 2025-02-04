
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Infrastructure.Data;

namespace CLIMFinders.Repositories
{
    public class UnitOfWorkBase : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        private Dictionary<Type, object> _repos;
     
        public UnitOfWorkBase(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext = this.applicationDbContext;
        } 
        #region Repository Manager
        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            if (_repos == null)
            {
                _repos = new Dictionary<Type, object>();
            }
            var type = typeof(T);
            if (!_repos.ContainsKey(type))
            {
                _repos[type] = new RepositoryBase<T>(applicationDbContext);
            }
            return (IRepositoryBase<T>)_repos[type];
        }
        #endregion      

    }
}
