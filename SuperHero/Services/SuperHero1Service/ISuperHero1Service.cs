namespace SuperHero.Services.SuperHero1Service
{
    public interface ISuperHero1Service
    {
        Task<List<SuperHero1>> GetAllHeroes();
        Task<SuperHero1?> GetSingleHero(int id);
        Task<List<SuperHero1>> AddHero(SuperHero1 hero);
        Task<List<SuperHero1>?> UpdateHero(int id, SuperHero1 request);
        Task<List<SuperHero1>?> DeleteHero(int id);

    }
}
