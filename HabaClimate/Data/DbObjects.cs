using System.Collections.Generic;
using System.Linq;
using HabaClimate.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HabaClimate.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            
            if (!context.Brands.Any())
                context.Brands.AddRange(Brands.Select(b => b.Value));
            
            if (!context.AirConditioners.Any())
                context.AirConditioners.AddRange(new AirConditioner
                    {
                        Name = "BSW-07HN1/OL/15Y",
                        LongDesc =
                            "Безупречность линий в сочетании с уникальными технологиями позволяет по-новому взглянуть " +
                            "на традиционные сплит-системы. Тихая работа, А класс энергоэффективности, 4 скорости потока воздуха" +
                            " и I FEEL климат контроль подарят Вам истинное наслаждение от использования новой сплит-системы Olympio.",
                        ShortDesc = "Сплит-система Ballu BSW-07HN1/OL/15Y",
                        Price = 39990,
                        Available = true,
                        IsInverter = false,
                        IsFavorite = true,
                        SquareRoom = 21,
                        EnergyEfficiencyClass = "A",
                        Category = Categories["Сплит системы"],
                        Brand = Brands["Ballu"],
                        Img = "/img/24457_29961_a.webp"
                    },
                    new AirConditioner
                    {
                        Name = "EACS-18HF/N3_21Y",
                        LongDesc =
                            "тип кондиционера: сплит-система, площадь помещения: 31 – 54 м², Мощность кондиционера (BTU): 18," +
                            " режим работы: охлаждение / обогрев, дополнительные режимы: осушение, ночной," +
                            " класс энергопотребления: A, особенности: пульт ДУ, дисплей, таймер включения/выключения",
                        ShortDesc = "Сплит-система Electrolux EACS-18HF/N3_21Y",
                        Price = 108000,
                        Available = true,
                        IsInverter = false,
                        IsFavorite = false,
                        SquareRoom = 35,
                        EnergyEfficiencyClass = "A",
                        Category = Categories["Сплит системы"],
                        Brand = Brands["Electrolux"],
                        Img = "/img/orig.webp"
                    },
                    new AirConditioner
                    {
                        Name = "EACS-09HG-B2/N3 ",
                        LongDesc ="Мин. рабочая температура воздуха для внешнего блока: -7" +
                                  " Бренд: ELECTROLUX Гарантийный срок: 3 года Серия: Air Gate 2",
                        ShortDesc = "Сплит-система Electrolux EACS-18HF/N3_21Y",
                        Price = 64000,
                        Available = true,
                        IsInverter = false,
                        IsFavorite = false,
                        SquareRoom = 27,
                        EnergyEfficiencyClass = "A",
                        Category = Categories["Сплит системы"],
                        Brand = Brands["Electrolux"],
                        Img = "/img/air_gate_2_eacs_07_09_12_18_24_hg_b2_n3_830x620.webp"
                    });

            context.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Сплит системы", Desc = "Системы кондиционирования воздуха" },
                        new Category
                            { CategoryName = "Мобильные кондиционеры", Desc = "Мобильные системы кондиционирвания" }
                    };

                    _categories = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        _categories.Add(el.CategoryName, el);
                }

                return _categories;
            }
        }
        
        private static Dictionary<string, Brand> _brands;
        public static Dictionary<string, Brand> Brands
        {
            get
            {
                if (_brands == null)
                {
                    var list = new Brand[]
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
                        }
                    };

                    _brands = new Dictionary<string, Brand>();
                    foreach (Brand el in list)
                        _brands.Add(el.Name, el);
                }

                return _brands;
            }
        }
    }
}