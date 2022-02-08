using AutoMapper;
using DemoERC.Data;
using DemoERC.Dto;
using DemoERC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoERC.Infraestructura
{
    public class ClienteRepository
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;
        public ClienteRepository(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClienteResponse>> FindAll()
        {
            var result = await context.ToDoItems.ToListAsync();
            var mapped = mapper.Map<List<ClienteResponse>>(result);
            return mapped;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClienteResponse> Find(int id)
        {
            var result = await context.ToDoItems.FindAsync(id);
            if (result == null) 
            {
                throw new Exception("not existe");
            }
                

            var mapped = mapper.Map<ClienteResponse>(result);

            return mapped;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task Insert(ClienteRequest request)
        {
            var mapped = mapper.Map<Cliente>(request);

            context.ToDoItems.Add(mapped);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task Update(int id, ClienteRequest request)
        {
            var mapped = mapper.Map<Cliente>(request);

            context.Entry(mapped).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var result = await context.ToDoItems.FindAsync(id);

            if (result == null)
                throw new Exception("not existe");

            context.ToDoItems.Remove(result);
            await context.SaveChangesAsync();
        }

    }
}
