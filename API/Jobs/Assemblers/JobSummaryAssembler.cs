using TWJOBS.API.Common.Assemblers;
using TWJOBS.API.Common.DTOS;
using TWJOBS.API.Jobs.DTOS;

namespace TWJOBS.API.Jobs.Assemblers;

public class JobSummaryAssembler : IAssembler<JobSummaryResponse>{
    private readonly LinkGenerator _linkGenerator;
    public JobSummaryAssembler(LinkGenerator linkGenerator){
        _linkGenerator = linkGenerator;
    }

    public JobSummaryResponse ToResource(JobSummaryResponse resource, HttpContext context){
        var selflink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "FindJobById", new { id = resource.id}),
            "GET",
            "self"
        );
        var updatelink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "UpdateJobById", new { id = resource.id}),
            "PUT",
            "update"
        );
        var deletelink = new LinkResponse(
            _linkGenerator.GetUriByName(context, "DeleteJobById", new { id = resource.id}),
            "DELETE",
            "delete"
        );
        resource.AddLinks(selflink, updatelink, deletelink);
        return resource;
    }
}