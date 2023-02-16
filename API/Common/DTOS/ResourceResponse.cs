namespace TWJOBS.API.Common.DTOS;

public class ResourceResponse{
    public ICollection<LinkResponse> Links { get; set; } = new List<LinkResponse>();
    public void AddLink(LinkResponse link){
        Links.Add(link);
    }
   
    public void AddLinks(params LinkResponse[] links){
        foreach (var link in links)
        {
            Links.Add(link);
        }
    }

    public void AddLinkIf(bool condition, LinkResponse link){
        if(condition)
        {
            Links.Add(link);
        }
    }
}