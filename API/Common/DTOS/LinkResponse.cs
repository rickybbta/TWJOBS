namespace TWJOBS.API.Common.DTOS;

public class LinkResponse{
    public string? href { get; set; }
    public string tipo { get; set; }
    public string rel { get; set; }

    public LinkResponse(string? href, string tipo, string rel){
        this.href = href;
        this.tipo = tipo;
        this.rel = rel;
    }
}