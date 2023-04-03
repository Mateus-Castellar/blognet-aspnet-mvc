using BlogNet.Data.Context;
using BlogNet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogNet.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppBlogContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppBlogContext context, DbSet<T> dbSet)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Adicionar(T model)
    {
        _dbSet.Add(model);
        await SaveChanges();
    }

    public async Task Atualizar(T model)
    {
        _context.Entry(model).State = EntityState.Modified;
        _dbSet.Update(model);
        await SaveChanges();
    }

    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
    }

    public async Task<T?> ObterPorId(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> ObterTodos()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task Remover(Guid id)
    {
        _dbSet.Remove(await _dbSet.FindAsync(id) ?? throw new InvalidOperationException());
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
