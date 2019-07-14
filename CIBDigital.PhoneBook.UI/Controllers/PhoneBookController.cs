using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigital.PhoneBook.Model;
using CIBDigital.PhoneBook.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CIBDigital.PhoneBook.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [HttpGet]
        [Route("getEntries")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _phoneBookService.Get().ConfigureAwait(false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
         }

        [HttpPost]
        [Route("addEntry")]
        public async Task<IActionResult> Add(PhoneBookModel model)
        {
            try
            {
                var response = await _phoneBookService.Add(model).ConfigureAwait(false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}