using FluentValidation;
using TWJOBS.API.Common.DTOS;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.API.Jobs.Mappers;
using TWJOBS.API.Jobs.Validators;
using TWJOBS.Core.Exceptions;
using TWJOBS.Core.Models;
using TWJOBS.Core.Repositories;
using TWJOBS.Core.Repositories.Jobs;

namespace TWJOBS.API.Jobs.Services;

public class JobService : IJobService{
    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;
    private readonly IValidator<JobRequest> _jobRequestValidator;
    public JobService(IJobRepository jobRepository,
                      IJobMapper jobMapper,
                      IValidator<JobRequest> jobRequestValidator){
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
        _jobRequestValidator = jobRequestValidator;
    }

    public ICollection<JobSummaryResponse> FindAll(){
        return _jobRepository.FindAll()
            .Select(job => _jobMapper.ToSummaryResponse(job))
            .ToList();
    }

    public JobDetailResponse FindById(int id){
        var job = _jobRepository.FindById(id);
        if (job is null){
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        return _jobMapper.ToDetailResponse(job);
    }

    public JobDetailResponse Create(JobRequest jobRequest){
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        var jobToCreate =  _jobMapper.ToModel(jobRequest);
        var createdJob = _jobRepository.Create(jobToCreate);
        return _jobMapper.ToDetailResponse(createdJob);
    }
    
    public JobDetailResponse UpdateById(int id, JobRequest jobRequest){
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        if(!_jobRepository.ExistsById(id)){
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        var jobToUpdate = _jobMapper.ToModel(jobRequest);
        jobToUpdate.id = id;
        var updatedJob = _jobRepository.Update(jobToUpdate);
        return _jobMapper.ToDetailResponse(updatedJob);
    }

    public void DeleteById(int id){
        if(!_jobRepository.ExistsById(id)){
            throw new ModelNotFoundException($"Job with id {id} not found");
        }
        _jobRepository.DeleteById(id);
    }

    public PagedResponse<JobSummaryResponse> FindAll(int page, int size)
    {
        var paginationoptions = new PaginationOptions(page, size);
        var pagedResult = _jobRepository.FindAll(paginationoptions);
        return _jobMapper.ToPagedSummaryResponse(pagedResult);
    }
}