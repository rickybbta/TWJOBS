using TWJOBS.API.Common.DTOS;

namespace TWJOBS.API.Common.Assemblers;

public interface IPagedAssembler<R> where R: ResourceResponse{
    PagedResponse<R> ToPagedResource(PagedResponse<R> pagedResource, HttpContext context);
}