using System.Runtime.CompilerServices;

namespace Lezita2.Models
{
    public static class DbList
    {
        public static List<Product> products;
        public static List<Category> categories;
        static DbList()
        {
            products = new List<Product>
            {
                new Product(){Name="Kola",CategoryId=1,Description="Bu ürün leziz soğuk bir koladır.",Image="/images/kola.jpg"  },
                new Product(){Name="Fanta",CategoryId=1,Description="Bu ürün leziz soğuk bir Fantadır.",Image="/images/fanta.jpg"  },
                new Product(){Name="Kahve",CategoryId=2,Description="Bu ürün leziz sıcacık bir kahvedir.",Image="/images/kahve.jpg"  },
            };
            categories = new List<Category>
            {
                new Category(){Name="SOĞUK İÇECEKLER",Image="/images/Sogukicecek.jpg"  },
                new Category(){Name="SICAK İÇECEKLER",Image="/images/Coffee.jpg"  },
                new Category(){Name="BURGERLER",Image="/images/Burger.jpg"  },
                new Category(){Name="KURABİYELER",Image="/images/Burger.jpg"  },
                new Category(){Name="BURGERLER",Image="/images/Burger.jpg"  },
                new Category(){Name="BURGERLER",Image="/images/Burger.jpg"  },
            };
        }
    }
}
