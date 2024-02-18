using CoreBusiness;

namespace UseCases
{
    public interface IGetVehicleByIdUseCase
    {
        Vehicle Execute(int vehicleId);
    }
}