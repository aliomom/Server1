using Domain.Entity;
using Service.Interface;
using ServiceInfra;

namespace Service
{
    public class Test1Service : ITest1Service
    {
        IUnitOfWork _unitOfWork;
        public Test1Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public int Add(Test1 test1)
        {

            _unitOfWork.Add(test1);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
            return test1.Id;
                
        }

       

    }
}
