using DAL.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL
{
    public class MagnetronDAO
    {
        private readonly IMongoCollection<Prep> _prepCollection;
        private readonly IMongoCollection<Dish> _dishCollection;
        private readonly IMongoCollection<MagnetronBrand> _magnetronCollection;


        public MagnetronDAO(IOptions<ProjectDatabaseSettings> projectDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            projectDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectDatabaseSettings.Value.DatabaseName);

            //TODO add this in env varibles
            _prepCollection = mongoDatabase.GetCollection<Prep>("preps");

            _dishCollection = mongoDatabase.GetCollection<Dish>("dishes");

            _magnetronCollection = mongoDatabase.GetCollection<MagnetronBrand>("magnetrons");
        }

        public async Task<List<Dish>> GetAllDishesAsync()
        {
            return await _dishCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Dish> GetDishAsync(string dishId)
        {
            Dish dish = await _dishCollection.Find(x => x.DishId == dishId).FirstOrDefaultAsync();
            if (dish == null || dish.DishId == null) return new();

            List<Prep> preps = await _prepCollection.Find(x => x.DishId == dishId).ToListAsync();
            dish.Preps = preps;

            return dish;
        }

        public async Task<List<MagnetronBrand>> GetAllMagnetronsAsync()
        {
            return await _magnetronCollection.Find(_ => true).ToListAsync();
        }

        public Task AddDishAsync(Dish dish)
        {
            return _dishCollection.InsertOneAsync(dish);
        }

        public Task AddPrepAsync(Prep prep)
        {
            return _prepCollection.InsertOneAsync(prep);
        }

        public Task AddMagnetron(MagnetronBrand magnetronBrand)
        {
            return _magnetronCollection.InsertOneAsync(magnetronBrand);
        }

        public Task DeletePrepAsync(string prepId)
        {
            return _prepCollection.DeleteOneAsync(x => x.PrepId == prepId);
        }
    }
}
