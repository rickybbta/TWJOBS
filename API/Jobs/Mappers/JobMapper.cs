using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.Core.Models;

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

    public JobSummaryResponse ToSummaryResponse(Job job){
        return new JobSummaryResponse{
            id = job.id,
            titulo = job.titulo
        };
    }
}