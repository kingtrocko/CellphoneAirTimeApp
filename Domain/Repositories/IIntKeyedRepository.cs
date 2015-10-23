namespace Domain.Repositories

{
    public interface IIntKeyedRepository : IRepository
    {
        T FindBy<T>(int id) where T : class;
    }
}
