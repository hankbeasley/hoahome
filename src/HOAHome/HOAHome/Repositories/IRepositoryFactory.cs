namespace HOAHome.Repositories
{
    public interface IRepositoryFactory
    {
        INeighborhoodRepository Neighborhood { get; }
    }
}