using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using TWJOBS.API.Common.DTOS;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.Core.Models;
using TWJOBS.Core.Repositories;

namespace TWJOBS.API.Jobs.Mappers;

public class JobMapper : IJobMapper{
    public JobDetailResponse ToDetailResponse(Job job){
        return new JobDetailResponse{
            id = job.id,
            titulo = job.titulo,
            salario = job.salario,
            requerimentos = job.requerimentos.Split(";")
        };
    }

    public Job ToModel(JobRequest jobRequest){
        return new Job{
            titulo = jobRequest.titulo,
            salario = jobRequest.salario,
            requerimentos = string.Join(";", jobRequest.requerimentos)
        };
    }

    public PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult)
    {
        return new PagedResponse<JobSummaryResponse>{
            Items = pagedResult.Items.Select(ToSummaryResponse).ToList(),
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            FirstPage = pagedResult.FirstPage,
            LastPage = pagedResult.LastPage,
            TotalPages = pagedResult.TotalPages,
            TotalElements = pagedResult.TotalElements,
            HasPreviousPage = pagedResult.HasPreviousPage,
            HasNextPage = pagedResult.HasNextPage
        };
    }

    public JobSummaryResponse ToSummaryResponse(Job job){
        return new JobSummaryResponse{
            id = job.id,
            titulo = job.titulo
        };
    }
}