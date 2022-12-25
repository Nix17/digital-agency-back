using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    //private IDictionaryRepo _dictRepo;
    //private IDoctorRepo _doctorRepo;
    //private IMaterialRepo _materialRepo;
    //private ILocalisationRepo _localisationRepo;
    //private IDepartmentRepo _departmentRepo;
    //private IDepartmentProfileRepo _departmentProfileRepo;
    //private IInstitutionRepo _institutionRepo;
    //private IDoctorInstitutionRepo _doctorInstitutionRepo;
    //private IPatientRepo _patientRepo;
    //private ISampleRepo _sampleRepo;

    public UnitOfWork(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    //public IDictionaryRepo DictRepo => _dictRepo = _dictRepo ?? new DictionaryRepo(_context, _mapper);
    //public IDoctorRepo DoctorRepo => _doctorRepo ?? new DoctorRepo(_context);
    //public IMaterialRepo MaterialRepo => _materialRepo ?? new MaterialRepo(_context);
    //public ILocalisationRepo LocalisationRepo => _localisationRepo ?? new LocalisationRepo(_context);
    //public IDepartmentRepo DepartmentRepo => _departmentRepo ?? new DepartmentRepo(_context);
    //public IDepartmentProfileRepo DepartmentProfileRepo => _departmentProfileRepo ?? new DepartmentProfileRepo(_context);
    //public IInstitutionRepo InstitutionRepo => _institutionRepo ?? new InstitutionRepo(_context);
    //public IDoctorInstitutionRepo DoctorInstitutionRepo => _doctorInstitutionRepo ?? new DoctorInstitutionRepo(_context);
    //public IPatientRepo PatientRepo => _patientRepo ?? new PatientRepo(_context);
    //public ISampleRepo SampleRepo => _sampleRepo ?? new SampleRepo(_context);


    public async Task<bool> SaveChangesAsync() { return (await _context.SaveChangesAsync()) > 0; }

    public async Task BeginAsync() { await _context.BeginTranAsync(); }

    public async Task CommitAsync() { await _context.CommitTranAsync(); }

    public async Task RollbackAsync() { await _context.RollbackTranAsync(); }

    public void Dispose() { _context.Dispose(); }
}
