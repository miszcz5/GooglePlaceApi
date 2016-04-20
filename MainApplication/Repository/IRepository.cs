namespace MainApplication.Repository {
    public interface IRepository {
        LocationModel GetLocations();
        bool AddLocation(Location location);
        BarModel GetBars(Location location);
    }
}
