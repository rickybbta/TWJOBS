using TWJOBS.API.Common.DTOS;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.Core.Models;

namespace TWJOBS.API.Jobs.Services;

public interface IJobService{
    ICollection<JobSummaryResponse> FindAll();
    PagedResponse<JobSummaryResponse> FindAll(int page, int size);
    JobDetailResponse FindById(int id);
    JobDetailResponse Create(JobRequest jobRequest);
    JobDetailResponse UpdateById(int id, JobRequest jobRequest);
    void DeleteById(int id);
}