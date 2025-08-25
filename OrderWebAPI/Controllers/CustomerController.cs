using AutoMapper;
using BudgetWebAPI.DTOs;
using BudgetWebAPI.Services.Exceptions;
using BudgetWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService cutomerService, IMapper mapper)
        {
            _mapper = mapper;
            _customerService = cutomerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCutomers()
        {
            try
            {
                var customers = await _customerService.GetCustomersAsync();
                var customersResults = _mapper.Map<ICollection<CustomerDto>>(customers);
                return Ok(customersResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                var customerResults = _mapper.Map<CustomerDto>(customer);
                return Ok(customerResults);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); //para retornar o 404
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto createDto)
        {
            var newCustomer = _mapper.Map<Customer>(createDto);

            try
            {
                var createdCustomer = await _customerService.CreateCustomerAsync(newCustomer);

                var resultDto = _mapper.Map<CustomerDto>(createdCustomer);

                return CreatedAtAction(nameof(GetCustomerById), new { id = resultDto.Id }, resultDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCostumer(int id, [FromBody] CustomerCreateDto updateDto)
        {
            try
            {
                var customerEntity = _mapper.Map<Customer>(updateDto);
                await _customerService.UpdateCustomerAsync(customerEntity);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                await _customerService.DeleteCustomerAsync(customer.Id);
                return NoContent();

            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
