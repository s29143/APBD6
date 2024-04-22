namespace APBD6.Warehouse;

public interface IWarehouseService
{
    Task<int> CreateProduct(WarehouseDto dto);
}


public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<int> CreateProduct(WarehouseDto dto)
    {
        // Example Flow:
        // check if product exists else throw NotFoundException
        // check if warehouse exists else throw NotFoundException
        // get order if exists else throw NotFoundException
        const int idOrder = 1;
        // check if product is already in warehouse else throw ConflictException
        
        

        var idProductWarehouse = await _warehouseRepository.RegisterProduct(
            idWarehouse: dto.IdWarehouse!.Value,
            idProduct: dto.IdProduct!.Value,
            idOrder: idOrder,
            createdAt: DateTime.UtcNow);

        if (!idProductWarehouse.HasValue)
            throw new Exception("Failed to register product in warehouse");

        return idProductWarehouse.Value;
    }
}