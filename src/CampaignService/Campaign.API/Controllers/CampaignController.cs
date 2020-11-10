using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Campaign.Application.Responses;
using Campaign.Application.Commands;
using Campaign.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Campaign.Infrastructure.Repositories;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace Campaign.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment hostEnvironment;

        public CampaignController(IMediator mediator,IWebHostEnvironment hostEnvironment)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.hostEnvironment = hostEnvironment;
        }

       
        [HttpPost]
        [ProducesResponseType(typeof(CampaignResponse),(int)HttpStatusCode.OK)]
        public async Task<ActionResult> InitiateCampaign([FromForm]InitiateCampaignCommand initiateCampaignCommand)
        {
            //Console.WriteLine(initiateCampaignCommand.campaign_desc);
     // if(ModelState.IsValid)
           //initiateCampaignCommand.firmware.newFirmwareZipName= await SaveNewFirmwareZipName(initiateCampaignCommand.firmware.newFirmwareZipFile);
            if (initiateCampaignCommand != null)
            {
            var campaign =await _mediator.Send(initiateCampaignCommand);
            return Ok(campaign);
            }
            return BadRequest();
        }
        [Route("[action]/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> StopCampaign(int id,StopCampaignCommand stopCampaignCommand)
        {
            
            var stopCamp =await _mediator.Send(stopCampaignCommand);
            return Ok(stopCamp);
        }

        [Route("[action]/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApproveCampaign(int id,ApproveCampaignCommand approveCampaignCommand)
        {
            if (id != approveCampaignCommand.campaign_id)
            {
                return BadRequest();
            }
        
            var approveCamp =await _mediator.Send(approveCampaignCommand);
            return Ok(approveCamp);
        }

        [Route("[action]/{id}")] 
        [HttpPut]
        [ProducesResponseType(typeof(long),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> RejectCampaign(long id,RejectCampaignCommand rejectCampaignCommand)
        {
             if (id != rejectCampaignCommand.campaign_id)
            {
                return BadRequest();
            }
            
            var rejectCamp =await _mediator.Send(rejectCampaignCommand);
            return Ok(rejectCamp);
        }
        [Route("[action]/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(CampaignResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CampaignResponse>> GetCampaignById(int id)
        {
            var campaignbyIDQuery = new GetCampaignByIdQuery(id);
            var campaign = await _mediator.Send(campaignbyIDQuery);
            return Ok(campaign);
        }

        [HttpGet]
        [Route("[action]")] 
        [ProducesResponseType(typeof(IEnumerable<CampaignResponse>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CampaignResponse>>> GetCampaigns()
        {
            var getCampaignsQuery=new GetCampaignsQuery();
            var campaigns =await _mediator.Send(getCampaignsQuery);
            return Ok(campaigns);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<EmployeeResponse>> PostEmployeeModel([FromForm]EmployeeCommand employeeCommand)
        {
            employeeCommand.ImageName = await SaveImage(employeeCommand.ImageFile);
            // _context.Employees.Add(employeeModel);
            // await _context.SaveChangesAsync();

            // return StatusCode(201);

             //employeeCommand.imageName= await SaveNewFirmwareZipName(employeeCommand.firmware.newFirmwareZipFile);
            if (employeeCommand != null)
            {
            var employee =await _mediator.Send(employeeCommand);
            return Ok(employee);
            }
            return BadRequest();
        }

        // [NonAction]
        //  public async Task<string> SaveNewFirmwareZipName(IFormFile newFirmwareZipFile)
        // {
        //     string newFirmwareZipName= new String(Path.GetFileNameWithoutExtension(newFirmwareZipFile.FileName).Take(10).ToArray()).Replace(' ','-');
        //     newFirmwareZipName=newFirmwareZipName+DateTime.Now.ToString("yymmssfff") + Path.GetExtension(newFirmwareZipFile.FileName);
        //     var newfirmwareFilePath=Path.Combine(_hostEnvironment.ContentRootPath,"FirmwareFiles",newFirmwareZipName);

        //     using (var fileStream = new FileStream(newfirmwareFilePath,FileMode.Create))
        //     {
        //         await newFirmwareZipFile.CopyToAsync(fileStream);
        //     }
        //     return newFirmwareZipName;
        // }
        //    }

           [NonAction]
         public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName= new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName= imageName+DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
        
            var imagePath=Path.Combine(hostEnvironment.ContentRootPath,"Images",imageName);

            using (var fileStream = new FileStream(imagePath,FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
           }
}