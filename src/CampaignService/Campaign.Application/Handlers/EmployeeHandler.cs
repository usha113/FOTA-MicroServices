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


namespace Campaign.Application.Handlers
{
     
    public class EmployeeHandler : IRequestHandler<EmployeeCommand,EmployeeResponse>    {
        
//        private IMapper _mapper;
        private readonly IEmployeeRepository _empRepository;
        private readonly SmtpClient _client;
        private readonly IEmailHelper _email;
        
        //private readonly IWebHostEnvironment _hostEnvironment;
        
        public EmployeeHandler(IEmployeeRepository empRepository,SmtpClient client, IEmailHelper emailHelper)
        {
            _empRepository=empRepository ?? throw new ArgumentNullException(nameof(empRepository));
            _client = client;
            _email = emailHelper;
        //    _hostEnvironment = hostEnvironment;
        }

    public async Task<EmployeeResponse> Handle(EmployeeCommand request,CancellationToken cancellationToken)
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

        var empEntity = EmployeeMapper.Mapper.Map<Campaign.Core.Entities.EmployeeModel>(request);
        if (empEntity == null)
        {
            throw new ApplicationException("Not Mapped");
        }

        empEntity.ImageName=request.ImageName;
        var newEmp = await _empRepository.AddAsync(empEntity);
         //Firmware firmware = await _campaignRepository.GetFirmwareById(request.firmware_id);
        // firmware.NewFirmwareFile=SaveNewFirmwareZipName(request.I)
        
        
        var employeeResponse = Campaign.Application.Mapper.EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmp);
        return employeeResponse;
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