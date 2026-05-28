namespace CertMentor.Application.Interfaces
{
    public interface IRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
