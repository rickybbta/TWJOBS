using System.Threading.Tasks.Dataflow;
using TWJOBS.API.Common.DTOS;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.Core.Models;
using TWJOBS.Core.Repositories;

namespace TWJOBS.API.Jobs.Mappers;

public interface IJobMapper{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult);
    Job ToModel(JobRequest jobRequest);
}