using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Application.Contracts;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Logic.Services
{
    public class BaseRepositoryService<T> : IBaseRepositoryService<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BaseRepositoryService (DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(object id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(object id, T item)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _mapper.Map(item, entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetDetails(object id)
        {
            T placeholder = await _context.Set<T>().FindAsync(id);
            return placeholder;
        }

        public async Task<List<T>> List()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}