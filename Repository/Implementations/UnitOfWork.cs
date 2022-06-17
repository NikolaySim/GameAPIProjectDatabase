using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private GameDBContext context = new GameDBContext();
        private GenericRepository<Player> studentRepository;
        private GenericRepository<Game> nationalityRepository;
        
        public GenericRepository<Player> PlayerRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Player>(context);
                }
                return studentRepository;
            }
        }
        
        public GenericRepository<Game> GameRepository
        {
            get
            {
                if (this.nationalityRepository == null)
                {
                    this.nationalityRepository = new GenericRepository<Game>(context);
                }
                return nationalityRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
