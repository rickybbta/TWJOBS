using Microsoft.AspNetCore.Mvc;
using TWJOBS.API.Common.DTOS;
using TWJOBS.API.Jobs.DTOS;
using TWJOBS.API.Jobs.Services;

namespace TWJOBS.API.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController: ControllerBase{
    private readonly IJobService _jobService;
    public JobController(IJobService jobService){
        _jobService = jobService;
    }

    [HttpGet]
    public IActionResult FindAll(){
        var body = _jobService.FindAll();
        foreach (var resource in body){
            var selflink = new LinkResponse($"/api/jobs/{resource.id}", "GET", "self");
            var updatelink = new LinkResponse($"/api/jobs/{resource.id}", "PUT", "update");
            var deletelink = new LinkResponse($"/api/jobs/{resource.id}", "DELETE", "delete");
            resource.AddLinks(selflink, updatelink, deletelink);
        }
        return Ok(body);
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id){
        var body = _jobService.FindById(id);
        body.AddLink(new LinkResponse($"/api/jobs/{id}", "GET", "self"));
        body.AddLink(new LinkResponse($"/api/jobs/{id}", "PUT", "update"));
        body.AddLink(new LinkResponse($"/api/jobs/{id}", "DELETE", "delete"));
        return Ok(body);
    }

    [HttpPost]
    public IActionResult Create([FromBody] JobRequest jobRequest){
        var body = _jobService.Create(jobRequest);
        body.AddLink(new LinkResponse($"/api/jobs/{body.id}", "GET", "self"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.id}", "PUT", "update"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.id}", "DELETE", "delete"));
        return CreatedAtAction(nameof(FindById), new { id = body.id }, body);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] JobRequest jobRequest){
        var body = _jobService.UpdateById(id, jobRequest);
        body.AddLink(new LinkResponse($"/api/jobs/{body.id}", "GET", "self"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.id}", "PUT", "update"));
        body.AddLink(new LinkResponse($"/api/jobs/{body.id}", "DELETE", "delete"));
        return Ok(body);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteByid([FromRoute] int id){
        _jobService.DeleteById(id);
        return NoContent();
    }

}