using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaign.Application.Commands;
using Campaign.Application.Responses;
using Campaign.Core.Repositories;
using Campaign.Core.Entities;
using Campaign.Application.Mapper;
using Campaign.Application.Helper;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Campaign.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Campaign.Infrastructure.Repositories;
using System.Net;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace Campaign.Application.Handlers
{
     
    public class InitiateCampaignHandler : IRequestHandler<InitiateCampaignCommand,CampaignResponse>    {
        
//        private IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly SmtpClient _client;
        private readonly IEmailHelper _email;
        
        //private readonly IWebHostEnvironment _hostEnvironment;
        
        public InitiateCampaignHandler(ICampaignRepository campaignRepository,SmtpClient client, IEmailHelper emailHelper)
        {
            _campaignRepository=campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
            _client = client;
            _email = emailHelper;
        //    _hostEnvironment = hostEnvironment;
        }

    public async Task<CampaignResponse> Handle(InitiateCampaignCommand request,CancellationToken cancellationToken)
    {
        //var userList = await _userRepository.GetUsersByRole(request.RoleId);
    //     Firmware firmware1 = new Firmware
    //     {
    //     firmware_name=request.firmware.firmware_name;
    //     current_firmware_version = request.firmware.current_firmware_version;
    //     current_firmware_link=request.firmware.current_firmware_link;
    //     previous_firmware_version=request.firmware.previous_firmware_version;
    //     previous_firmware_link=request.firmware.previous_firmware_link;
    //     }

        var campaignEntity = CampaignMapper.Mapper.Map<Campaign.Core.Entities.Campaign>(request);
        if (campaignEntity == null)
        {
            throw new ApplicationException("Not Mapped");
        }

        campaignEntity.campaign_name=request.campaign_name;
        campaignEntity.campaign_desc=request.campaign_desc;
        campaignEntity.campaign_start_date = request.campaign_start_date;
        campaignEntity.campaign_end_date = request.campaign_end_date;
        campaignEntity.Approver = await _campaignRepository.GetApproverById(request.approver_id);
        campaignEntity.VehicleGroup= await _campaignRepository.GetVehiclegroupById(request.vehiclegroup_id);
        campaignEntity.Firmware =  new Firmware
        {
        firmware_name = request.firmware.firmware_name ,
       new_firmware_version = request.firmware.new_firmware_version,
        new_firmware_link=request.firmware.new_firmware_link,
        old_firmware_version=request.firmware.old_firmware_version,
        old_firmware_link=request.firmware.old_firmware_link
        //newFirmwareZipName = SaveNewFirmwareZipName(request.firmware.newFirmwareZipFile)
        };
        campaignEntity.ECU= await _campaignRepository.GetECUById(request.ecu_id);
        campaignEntity.approval_date=request.approval_date;
        campaignEntity.approval_status=1;
        campaignEntity.is_active= true;
        campaignEntity.status=1;
        
        var newCampaign = await _campaignRepository.AddAsync(campaignEntity);
         //Firmware firmware = await _campaignRepository.GetFirmwareById(request.firmware_id);
        // firmware.NewFirmwareFile=SaveNewFirmwareZipName(request.I)
        
        await _email.SendEmail(_client, "usha.krishnan@wabco-auto.com", EmailType.CampaignInitiated, campaignEntity);
        var campaignResponse = Campaign.Application.Mapper.CampaignMapper.Mapper.Map<CampaignResponse>(newCampaign);
        campaignResponse.approver_id =campaignEntity.Approver.approver_id;
        campaignResponse.vehiclegroup_id = campaignEntity.VehicleGroup.vehiclegroup_id;
        campaignResponse.firmware = campaignEntity.Firmware;
        campaignResponse.ecu_id =campaignEntity.ECU.ecu_id;
        return campaignResponse;
    }

        //  public string SaveNewFirmwareZipName(IFormFile newFirmwareZipFile)
        // {
        //     string newFirmwareZipName= new String(Path.GetFileNameWithoutExtension(newFirmwareZipFile.FileName).Take(10).ToArray()).Replace(' ','-');
        //     newFirmwareZipName=newFirmwareZipName+DateTime.Now.ToString("yymmssfff") + Path.GetExtension(newFirmwareZipFile.FileName);
        //     var newfirmwareFilePath=Path.Combine(_hostEnvironment.ContentRootPath,"FirmwareFiles",newFirmwareZipName);

        //     using (var fileStream = new FileStream(newfirmwareFilePath,FileMode.Create))
        //     {
        //         newFirmwareZipFile.CopyToAsync(fileStream);
        //     }
        //     return newFirmwareZipName;
        // }
      
        
    }
}