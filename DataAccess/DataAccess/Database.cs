using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Domain;

namespace DataAccess
{
    public class Database
    {
        private readonly List<IEntity> _db;
        private static Database _instance;

        public static Database Instance
        {
            get { return _instance ?? (_instance = new Database()); }
        }

        public Database()
        {
            _db = new List<IEntity>
            {
                new ProductDto(Guid.NewGuid(),10, 0, "Ducks"),
                new ProductDto(Guid.NewGuid(), 3, 10, "Milk"),
                new ProductDto(Guid.NewGuid(), 6, 0, "Cheese"),
                new ProductDto(Guid.NewGuid(), 1000, 13, "HiFi"),
                new ProductDto(Guid.NewGuid(), 2, 0, "Dallas"),
                new ProductDto(Guid.NewGuid(), 3, 1, "Food"),
                new ProductDto(Guid.NewGuid(),10, 0, "Duck"),
                new ProductDto(Guid.NewGuid(), 3, 10, "MilkShake"),
                new ProductDto(Guid.NewGuid(), 6, 0, "Cheese"),
                new ProductDto(Guid.NewGuid(), 1000, 13, "TV"),
                new ProductDto(Guid.NewGuid(), 2, 0, "Dallas Cowboys"),
                new ProductDto(Guid.NewGuid(), 3, 1, "Food vegan"),
                new CustomerDto(Guid.NewGuid(), 0),
                new CustomerDto(Guid.NewGuid(), 1),
                new CustomerDto(Guid.NewGuid(), 2)
            };
        }
        public void Write(IEntity entity)
        {
            _db.Add(entity);
        }

        public IEnumerable<T> ReadAll<T>() where T : class
        {
            return _db.ConvertAll(entity => entity as T).Where(entity => entity != null);
        }

        public T Read<T>(Guid id) where T : class
        {
            return (T)_db.Find(entity => entity.Id == id);
        }
    }
}
