using TWJOBS.API.Common.DTOS;

namespace TWJOBS.API.Common.Assemblers;

public interface IAssembler<T> where T: ResourceResponse{
    T ToResource(T resource, HttpContext context);
    ICollection<T> ToResourceCollection(ICollection<T> resources, HttpContext context){
        return resources.Select(r => ToResource(r, context)).ToList();
    }
 }