namespace TWJOBS.Core.Repositories;

public interface IPagedRepository<Model>{
    PagedResult<Model> FindAll(PaginationOptions options);
}