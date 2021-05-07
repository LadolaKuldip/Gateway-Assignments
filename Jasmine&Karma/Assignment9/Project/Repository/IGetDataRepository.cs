namespace Project.Repository
{
    public interface IGetDataRepository
    {
        string GetNameById(int id);
        string[] GetAll();
    }
}
