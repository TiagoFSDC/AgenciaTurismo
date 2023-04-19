namespace Repositories
{
    public interface ITourAgencyRepository
    {
        bool Insert1(City city);

        List<City> GetAll();
    }
}