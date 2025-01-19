using App.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace App.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// SaveChanges işlemini transaction ile yönetir.
    /// Başarılıysa kaydeder, başarısız olursa rollback yapar.
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {

        // Transaction yoksa bir tane başlat
        if (_transaction == null)
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        try
        {
            var result = await _context.SaveChangesAsync(); // Değişiklikleri kaydet
            await _transaction.CommitAsync();              // Commit işlemini gerçekleştir
            return result;
        }
        catch
        {
            await RollbackTransactionAsync(); // Hata durumunda rollback yap
            throw; // Hatanın üst katmana iletilmesini sağla
        }
        finally
        {
            await DisposeTransactionAsync(); // Kaynakları temizle
        }

    }

    /// <summary>
    /// Transaction işlemlerini geri alır (rollback).
    /// </summary>
    private async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
        }
    }

    /// <summary>
    /// Transaction'ı serbest bırakır.
    /// </summary>
    private async Task DisposeTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null; // Transaction'u sıfırla
        }
    }
}