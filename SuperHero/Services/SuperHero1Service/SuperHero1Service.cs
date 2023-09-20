using Microsoft.EntityFrameworkCore;

namespace SuperHero.Services.SuperHero1Service
{
    public class SuperHero1Service : ISuperHero1Service
    {

        private readonly DataContext _context;

        public SuperHero1Service(DataContext context)
        {
            _context = context;
        }


        public async Task<List<SuperHero1>> AddHero(SuperHero1 hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero1>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        //public List<SuperHero1> GetAllHeroes()
        //{
        //    return heros;
        //}

        public async Task<List<SuperHero1>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }
        public async Task<SuperHero1?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            return hero;
        }

        public async Task<List<SuperHero1>?> UpdateHero(int id, SuperHero1 request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
