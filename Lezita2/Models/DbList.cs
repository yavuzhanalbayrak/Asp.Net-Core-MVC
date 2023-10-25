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
                new Product(){Name="Kola",CategoryId=1,Description="Bu ürün leziz soğuk bir koladır.",Image=""  }
            };
            categories = new List<Category>
            {
                new Category(){Name="SOĞUK İÇECEKLER",Image="/images/Sogukicecek.jpg"  },
                new Category(){Name="SICAK İÇECEKLER",Image="/images/Coffee.jpg"  },
                new Category(){Name="BURGERLER",Image="/images/Burger.jpg"  }
            };
        }
    }
}
