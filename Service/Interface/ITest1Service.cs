using Domain.Entity;
using System.ServiceModel;

namespace Service.Interface
{
    [ServiceContract]
    public interface ITest1Service
    {
        [OperationContract]
        int Add(Test1 test1);
    }
}