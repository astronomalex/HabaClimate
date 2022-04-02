using System.Collections.Generic;
using System.Linq;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.mocks
{
    public class MockAirConditioners : IAllAirConditioners
    {
        private readonly IGoodsCategory _category = new MockCategory();
        private readonly IBrands _brands = new MockBrands();
        
        public IEnumerable<AirConditioner> AirConditioners
        {
            get
            {
                return new List<AirConditioner>()
                {
                    new AirConditioner
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
                        Category = _category.AllCategories.First(),
                        Brand = _brands.AllBrands.First(),
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
                        Category = _category.AllCategories.First(),
                        Brand = _brands.AllBrands.Last(),
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
                        Category = _category.AllCategories.First(),
                        Brand = _brands.AllBrands.Last(),
                        Img = "/img/air_gate_2_eacs_07_09_12_18_24_hg_b2_n3_830x620.webp"
                    }
                };
            }
        }

        public IEnumerable<AirConditioner> GetFavAirConditioners { get; set; }
        public AirConditioner GetObjectAirConditioner(int goodId)
        {
            throw new System.NotImplementedException();
        }

    }
}