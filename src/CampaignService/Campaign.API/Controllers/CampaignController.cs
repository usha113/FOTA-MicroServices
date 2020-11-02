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


namespace Campaign.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

       
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<CampaignResponse>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CampaignResponse>>> InitiateCampaign([FromBody] InitiateCampaignCommand initiateCampaignCommand)
        {
            
            var campaign =await _mediator.Send(initiateCampaignCommand);
            return Ok(campaign);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> StopCampaign(int id,StopCampaignCommand stopCampaign)
        {
            
            var stopCamp =await _mediator.Send(stopCampaign);
            return Ok(stopCamp);
        }

        [Route("[action]/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApproveCampaign(int id,ApproveCampaignCommand approveCampaign)
        {
            
            var approveCamp =await _mediator.Send(approveCampaign);
            return Ok(approveCamp);
        }

        [Route("[action]/{id}")] 
        [HttpPut]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> RejectCampaign(int id,RejectCampaignCommand rejectCampaign)
        {
            
            var rejectCamp =await _mediator.Send(rejectCampaign);
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
        [ProducesResponseType(typeof(IEnumerable<CampaignResponse>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CampaignResponse>>> GetCampaigns()
        {
            var getCampaignsQuery=new GetCampaignsQuery();
            var campaigns =await _mediator.Send(getCampaignsQuery);
            return Ok(campaigns);
        }

    }
}