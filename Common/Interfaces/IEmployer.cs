using Common.DTO;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IEmployer
    {
        EmployerFiltersResponse GetByFilters(EmployerFiltersRequest employerFiltersRequest);
        EmployerDTO GetById(int id);
        List<EmployerDTO> Pagination(EmployerDTO filters);
        EmployerDTO Save(EmployerDTO employerDTO);
        EmployerDTO Update(EmployerDTO employerDTO);
        EmployerDTO Delete(int id);
    }
}
