using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Application.Interfaces.Repositories;

namespace Application.Interfaces.Services;
public interface IUnitOfWork
{
    //IDictionaryRepo DictRepo { get; }
    //IDoctorRepo DoctorRepo { get; }
    //IMaterialRepo MaterialRepo { get; }
    //ILocalisationRepo LocalisationRepo { get; }
    //IDepartmentRepo DepartmentRepo { get; }
    //IInstitutionRepo InstitutionRepo { get; }
    //IDepartmentProfileRepo DepartmentProfileRepo { get; }
    //IDoctorInstitutionRepo DoctorInstitutionRepo { get; }

    //IPatientRepo PatientRepo { get; }
    //ISampleRepo SampleRepo { get; }

    Task<bool> SaveChangesAsync();
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
