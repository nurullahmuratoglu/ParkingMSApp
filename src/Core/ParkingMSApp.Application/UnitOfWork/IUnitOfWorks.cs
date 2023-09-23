namespace ParkingMSApp.Application.UnitOfWork
{
    public interface IUnitOfWorks
    {
        void Commit();
        Task CommitAsync();
    }
}
