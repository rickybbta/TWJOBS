using TWJOBS.API.Jobs.DTOS;
using TWJOBS.Core.Models;

namespace TWJOBS.API.Jobs.Mappers;

public interface IJobMapper{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailResponse ToDetailResponse(Job job);
    Job ToModel(JobRequest jobRequest);
}