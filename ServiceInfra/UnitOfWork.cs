using Domain;
using Domain.Entity;
using ServiceInfra.WIRepository;
using ServiceInfra.WIRepository.Interface;
using System.Threading.Tasks;


namespace ServiceInfra
{
    //[ServiceBehavior(
    //  ConcurrencyMode = ConcurrencyMode.Single,
    //  InstanceContextMode = InstanceContextMode.PerCall,
    //  ReleaseServiceInstanceOnTransactionComplete = true
    //)]

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string nameOrConnectionString)
        {

            _context = new ApplicationDbContext(nameOrConnectionString);
            _context.Configuration.ProxyCreationEnabled = false;
        }


        private readonly ApplicationDbContext _context;
        private IAspNetUserLoginRepository _AspNetUserLoginRepository;
        private IAspNetRoleRepository _AspNetroleRepository;
        private IAspNetUserRepository _AspNetUserRepository;


        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public IAspNetUserLoginRepository AspNetUserLoginRepository
        {
            get { return _AspNetUserLoginRepository ?? (_AspNetUserLoginRepository = new AspNetUserLoginRepository(_context)); }
        }

        public IAspNetRoleRepository AspNetRoleRepository
        {
            get { return _AspNetroleRepository ?? (_AspNetroleRepository = new AspNetRoleRepository(_context)); }
        }

        public IAspNetUserRepository AspNetUserRepository
        {
            get { return _AspNetUserRepository ?? (_AspNetUserRepository = new AspNetUserRepository(_context)); }
        }

        private IRepository<Test1> _Test1Repository;

        public IRepository<Test1> Test1Repository { get { return _Test1Repository ?? (_Test1Repository = new Repository<Test1>(_context)); } }



        public Test1 test(Test1 test)
        {

            test.Id = 5;
            test.Name = "ali";
            return test;
        }


       
        //[OperationBehavior(TransactionAutoComplete = true,  TransactionScopeRequired = true )]
        //[TransactionFlow(TransactionFlowOption.Mandatory)]

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        //[TransactionFlow(TransactionFlowOption.Mandatory)]
        public void Dispose()
        {


            _context.Dispose();
        }


        public void Add(Test1 test)
        {
            var vv = new Repository<Test1>(_context);
            vv.Add(test);
        }
    }
}
