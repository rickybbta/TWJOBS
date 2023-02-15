using FluentValidation;
using TWJOBS.API.Jobs.DTOS;

namespace TWJOBS.API.Jobs.Validators;

public class JobRequestValidator: AbstractValidator<JobRequest>{
    public JobRequestValidator(){
        RuleFor(j => j.titulo).NotEmpty().OverridePropertyName("titulo");
        RuleFor(j => j.salario).GreaterThan(0).OverridePropertyName("salario");
        RuleFor(j => j.requerimentos).NotEmpty().OverridePropertyName("requerimentos");
    }
}