using TWJOBS.Core.Models;

namespace TWJOBS.Core.Repositories.Jobs;

public interface IJobRepository : ICrudRepository<Job, int>, IPagedRepository<Job>{ }