using Microsoft.EntityFrameworkCore;
using TWJOBS.Core.Data.Contexts;
using TWJOBS.Core.Models;

namespace TWJOBS.Core.Repositories.Jobs;


public class JobRepository : IJobRepository{
    private readonly TwJobsDbContext _context;
    public JobRepository(TwJobsDbContext context){
        _context = context;
    }

    public Job Create(Job model){
        _context.Jobs.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id){
        var job = _context.Jobs.Find(id);
        if (job is not null) { 
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id){
        return _context.Jobs.Any(j=> j.id == id);
    }

    public ICollection<Job> FindAll(){
        return _context.Jobs.AsNoTracking().ToList();
    }

    public PagedResult<Job> FindAll(PaginationOptions options)
    {
        var totalelements = _context.Jobs.Count();
        var items = _context.Jobs
            .Skip((options.pagenumber - 1) * options.pagesize)
            .Take(options.pagesize)
            .ToList();
        return new PagedResult<Job>(items, options.pagenumber, options.pagesize, totalelements);
    }

    public Job? FindById(int id){
        return _context.Jobs.AsNoTracking().FirstOrDefault(j => j.id == id);
    }

    public Job Update(Job model){
        _context.Jobs.Update(model);
        _context.SaveChanges();
        return model;
    }
}