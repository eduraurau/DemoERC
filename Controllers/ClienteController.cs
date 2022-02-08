using DemoERC.Dto;
using DemoERC.Infraestructura;
using DemoERC.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoERC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteValidator _clienteValidator;
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository, ClienteValidator clienteValidator)
        {
            this._clienteValidator = clienteValidator;
            this._clienteRepository = clienteRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ClienteResponse>> all()
        {
            return await _clienteRepository.FindAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ClienteResponse> Find(int id)
        {
            return await _clienteRepository.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteRequest request)
        {
            var validation = _clienteValidator.Validate(request);
            if (request.CodCliente != id || !validation.IsValid) 
            {
                return BadRequest(validation.Errors);
            }
                

            await _clienteRepository.Update(id, request);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ClienteRequest request)
        {
            var validation = _clienteValidator.Validate(request);
            if (!validation.IsValid) 
            {
                return BadRequest(validation.Errors);
            }

            await _clienteRepository.Insert(request);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _clienteRepository.Delete(id);
        }
    }
}
