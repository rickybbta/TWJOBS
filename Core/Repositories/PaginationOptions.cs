namespace TWJOBS.Core.Repositories;

public class PaginationOptions{
    public int pagenumber { get; set; }
    public int pagesize { get; set; }

    public PaginationOptions(int pagenumber, int pagesize){
        this.pagenumber = pagenumber < 1 ? 1 : pagenumber;
        this.pagesize = pagesize < 1 ? 10 : pagesize;
    }
}