namespace TWJOBS.Core.Repositories;

public class PagedResult<Model>{
    public ICollection<Model> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int FirstPage { get; set; }
    public int LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalElements { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }

    public PagedResult(ICollection<Model> items, int pagenumber, int pagesize, int totalelements){
        Items = items;
        PageNumber = pagenumber;
        PageSize = pagesize;
        TotalElements = totalelements;
        TotalPages = (int)Math.Ceiling(totalelements/ (double)pagesize);
        FirstPage = 1;
        LastPage = TotalPages;
        HasPreviousPage = PageNumber > 1;
        HasNextPage = PageNumber < TotalPages;
    }


}