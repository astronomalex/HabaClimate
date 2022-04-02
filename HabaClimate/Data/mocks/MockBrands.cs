using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.mocks
{
    public class MockBrands : IBrands
    {
        public IEnumerable<Brand> AllBrands
        {
            get
            {
                return new List<Brand>
                {
                    new Brand
                    {
                        Name = "Ballu", ShortDesc = "Промышленный концерн Ballu",
                        LongDesc = 
                            "Промышленный концерн Ballu специализируется на разработке и производстве климатической и инженерной техники."
                    },
                    new Brand
                    {
                        Name = "Electrolux", ShortDesc = "Для комфортной жизни. Разработано в Швеции",
                        LongDesc = 
                            "Опираясь на наши шведские ценности и прочную связь с природой, мы создаем продукты с очевидной целью." +
                            " Мы делаем все, что можем, чтобы заботиться о здоровье нашей планеты ради будущих поколений." +
                            " Мы не только создаем вкусовые впечатления, заботимся об одежде и поддерживаем комфорт дома. " +
                            "Мы также помогаем людям жить лучше, чтобы они могли открывать для себя больше."
                    },
                };
            }
        }
    }
}