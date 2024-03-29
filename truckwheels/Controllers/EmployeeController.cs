﻿using Microsoft.AspNetCore.Mvc;
using truckwheels.Model;
using truckwheels.ViewModel;

using Microsoft.AspNetCore.Authorization;

using System;
using System.IO;

namespace truckwheels.Controllers
{

    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        [Authorize]
        [HttpPost("add")] // Defina uma rota específica para a ação Add
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {

            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            employeeView.Photo.CopyTo(fileStream);


            var employee = new Employee(employeeView.Nome, employeeView.Email, employeeView.Telefone, employeeView.Detalhes, filePath);
           
            _employeeRepository.Add(employee);
            return Ok();
        }
        [Authorize]//proteje as rotas
        [HttpPost]
        [Route("{id}/download")]

        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/png");
        }
        [Authorize]
        [HttpGet("get")] // Defina uma rota específica para a ação Get
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();
            return Ok(employees);
        }




    }

}
