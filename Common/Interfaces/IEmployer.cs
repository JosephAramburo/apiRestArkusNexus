using Common.DTO;

namespace Common.Interfaces
{
    public interface IEmployer
    {
        EmployerDTO GetById(int id);
    }
}
