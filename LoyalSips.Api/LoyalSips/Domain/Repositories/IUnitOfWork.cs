namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface IUnitOfWork//contrato para una unidad de trabajo 
{
    //agrupa una serie de operaciones de base de datos en una transacción 
    Task CompleteAsync(); // confirma cualquier trabajo pendiente y se guarda en la base de datos
}