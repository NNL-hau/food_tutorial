using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    /// <summary>
    /// Seed data cho nhà hàng - Thay thế toàn bộ dữ liệu quần áo bằng món ăn Việt Nam
    /// </summary>
    public static class CatalogSeedData
    {
        public static void Seed(CatalogDbContext context)
        {
            if (context.Categories.Any())
            {
                Console.WriteLine("[CatalogSeedData] Database already has data. Skipping seed.");
                return;
            }

            Console.WriteLine("[CatalogSeedData] Seeding food menu data...");

            // ── CATEGORIES ────────────────────────────────────────────────
            var catKhaiVi    = new Category { Id = Guid.NewGuid(), Name = "Khai Vị",    Description = "Các món ăn khai vị nhẹ nhàng, kích thích vị giác" };
            var catMonChinh  = new Category { Id = Guid.NewGuid(), Name = "Món Chính",  Description = "Các món chính đậm đà, no bụng" };
            var catTrangMieng= new Category { Id = Guid.NewGuid(), Name = "Tráng Miệng",Description = "Các món tráng miệng ngọt ngào" };
            var catDoUong    = new Category { Id = Guid.NewGuid(), Name = "Đồ Uống",    Description = "Nước giải khát, trà, cà phê" };
            var catSetMeal   = new Category { Id = Guid.NewGuid(), Name = "Set Meal",   Description = "Combo tiết kiệm, đầy đủ món" };

            context.Categories.AddRange(catKhaiVi, catMonChinh, catTrangMieng, catDoUong, catSetMeal);

            // ── BANNERS ───────────────────────────────────────────────────
            var banners = new List<Banner>
            {
                new Banner
                {
                    Id = Guid.NewGuid(),
                    Title = "Thực Đơn Hôm Nay",
                    SubTitle = "Món ăn tươi ngon, giao hàng nhanh trong 30 phút",
                    ImageUrl = "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?auto=format&fit=crop&q=80&w=1400",
                    LinkUrl = "/products",
                    IsActive = true,
                    DisplayOrder = 1
                },
                new Banner
                {
                    Id = Guid.NewGuid(),
                    Title = "Ưu Đãi Cuối Tuần",
                    SubTitle = "Giảm 20% tất cả combo - Chỉ Thứ 7 & Chủ Nhật",
                    ImageUrl = "https://images.unsplash.com/photo-1567620905732-2d1ec7ab7445?auto=format&fit=crop&q=80&w=1400",
                    LinkUrl = "/products",
                    IsActive = true,
                    DisplayOrder = 2
                },
                new Banner
                {
                    Id = Guid.NewGuid(),
                    Title = "Trà Sữa Cao Cấp",
                    SubTitle = "Hơn 20 loại trà sữa thơm ngon, nhiều topping",
                    ImageUrl = "https://images.unsplash.com/photo-1558857563-b371033873b8?auto=format&fit=crop&q=80&w=1400",
                    LinkUrl = "/products",
                    IsActive = true,
                    DisplayOrder = 3
                }
            };
            context.Banners.AddRange(banners);

            // ── PRODUCTS ──────────────────────────────────────────────────
            var foodImages = new Dictionary<string, string>
            {
                ["pho-bo"] = "https://images.unsplash.com/photo-1557499305-0af888c3d8ec?auto=format&fit=crop&q=80&w=800",
                ["bun-bo"] = "https://images.unsplash.com/photo-1582878826629-29b7ad1cdc43?auto=format&fit=crop&q=80&w=800",
                ["com-tam"] = "https://images.unsplash.com/photo-1512058564366-18510be2db19?auto=format&fit=crop&q=80&w=800",
                ["banh-mi"] = "https://images.unsplash.com/photo-1600326145308-d0cc3d64e1ad?auto=format&fit=crop&q=80&w=800",
                ["hu-tieu"] = "https://images.unsplash.com/photo-1569562211093-4ed0d0758f12?auto=format&fit=crop&q=80&w=800",
                ["goi-cuon"] = "https://images.unsplash.com/photo-1562802378-063ec186a863?auto=format&fit=crop&q=80&w=800",
                ["che"] = "https://images.unsplash.com/photo-1546793665-c74683f339c1?auto=format&fit=crop&q=80&w=800",
                ["tra-sua"] = "https://images.unsplash.com/photo-1558857563-b371033873b8?auto=format&fit=crop&q=80&w=800",
                ["ca-phe"] = "https://images.unsplash.com/photo-1509042239860-f550ce710b93?auto=format&fit=crop&q=80&w=800",
                ["sinh-to"] = "https://images.unsplash.com/photo-1553530666-ba11a90bb518?auto=format&fit=crop&q=80&w=800",
                ["kem"] = "https://images.unsplash.com/photo-1488900128323-21503983a07e?auto=format&fit=crop&q=80&w=800",
                ["banh-ngot"] = "https://images.unsplash.com/photo-1488477181946-6428a0291777?auto=format&fit=crop&q=80&w=800",
                ["lau"] = "https://images.unsplash.com/photo-1569050467447-ce54b3bbc37d?auto=format&fit=crop&q=80&w=800",
                ["set-combo"] = "https://images.unsplash.com/photo-1547592166-23ac45744acd?auto=format&fit=crop&q=80&w=800",
                ["bun-thit"] = "https://images.unsplash.com/photo-1565299507177-b0ac66763828?auto=format&fit=crop&q=80&w=800",
            };

            var products = new List<Product>
            {
                // ── KHai Vị ──
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catKhaiVi.Id,
                    Name = "Gỏi Cuốn Tôm Thịt",
                    Description = "Gỏi cuốn tươi với tôm, thịt heo, rau sống, bún tươi, chấm tương hoisin",
                    Price = 35000, StockQuantity = 50, SoldQuantity = 120,
                    ImageUrl = foodImages["goi-cuon"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catKhaiVi.Id,
                    Name = "Chả Giò Chiên Giòn",
                    Description = "Chả giò nhân thịt heo, mộc nhĩ, miến, chiên vàng giòn, ăn kèm rau sống",
                    Price = 45000, StockQuantity = 40, SoldQuantity = 89,
                    ImageUrl = "https://images.unsplash.com/photo-1600684388213-b6a4a3c0e5ab?auto=format&fit=crop&q=80&w=800",
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catKhaiVi.Id,
                    Name = "Nem Nướng Nha Trang",
                    Description = "Nem nướng đặc sản Nha Trang, ăn kèm bánh tráng, rau và nước chấm đặc biệt",
                    Price = 55000, StockQuantity = 35, SoldQuantity = 67,
                    ImageUrl = "https://images.unsplash.com/photo-1494390248081-4e521a5940db?auto=format&fit=crop&q=80&w=800",
                    Colors = "", Sizes = ""
                },

                // ── Món Chính ──
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Phở Bò Đặc Biệt",
                    Description = "Phở bò với nước dùng ninh xương từ 8 tiếng, thịt bò tươi, hành, ngò, giá đỗ",
                    Price = 75000, StockQuantity = 100, SoldQuantity = 342,
                    ImageUrl = foodImages["pho-bo"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Bún Bò Huế",
                    Description = "Bún bò Huế chính gốc với chả Huế, giò heo, sả, mắm ruốc, sợi bún to đặc trưng",
                    Price = 70000, StockQuantity = 80, SoldQuantity = 215,
                    ImageUrl = foodImages["bun-bo"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Cơm Tấm Sườn Nướng",
                    Description = "Cơm tấm với sườn nướng tẩm ướp đặc biệt, bì, chả, trứng ốp la, nước mắm chua ngọt",
                    Price = 65000, StockQuantity = 90, SoldQuantity = 289,
                    ImageUrl = foodImages["com-tam"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Bánh Mì Thịt Nướng",
                    Description = "Bánh mì giòn cốt, nhân thịt nướng, pate, dưa leo, đồ chua, sốt tương đặc biệt",
                    Price = 35000, StockQuantity = 120, SoldQuantity = 456,
                    ImageUrl = foodImages["banh-mi"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Hủ Tiếu Nam Vang",
                    Description = "Hủ tiếu dai với nước dùng trong, thịt heo bằm, tôm, gan, hẹ tươi",
                    Price = 60000, StockQuantity = 70, SoldQuantity = 178,
                    ImageUrl = foodImages["hu-tieu"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Bún Thịt Nướng",
                    Description = "Bún với thịt heo nướng than, chả giò, rau sống, đậu phộng rang, nước mắm",
                    Price = 58000, StockQuantity = 85, SoldQuantity = 203,
                    ImageUrl = foodImages["bun-thit"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catMonChinh.Id,
                    Name = "Lẩu Thái Hải Sản",
                    Description = "Lẩu Thái cay chua với tôm, mực, cá, nấm kim châm, nước dùng Tom Yum đậm vị",
                    Price = 299000, StockQuantity = 30, SoldQuantity = 89,
                    ImageUrl = foodImages["lau"],
                    Colors = "", Sizes = ""
                },

                // ── Tráng Miệng ──
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catTrangMieng.Id,
                    Name = "Chè Khúc Bạch",
                    Description = "Chè với thạch lá dứa, hạt lựu, trân châu trắng, nước cốt dừa thơm ngát",
                    Price = 45000, StockQuantity = 50, SoldQuantity = 134,
                    ImageUrl = foodImages["che"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catTrangMieng.Id,
                    Name = "Kem Dừa Đặc Biệt",
                    Description = "Kem dừa béo ngậy múc trong trái dừa tươi, thêm thạch màu và đậu xanh",
                    Price = 55000, StockQuantity = 40, SoldQuantity = 98,
                    ImageUrl = foodImages["kem"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catTrangMieng.Id,
                    Name = "Bánh Bông Lan",
                    Description = "Bánh bông lan mềm mịn với hương vani, phủ kem tươi và trái cây tươi",
                    Price = 65000, StockQuantity = 25, SoldQuantity = 67,
                    ImageUrl = foodImages["banh-ngot"],
                    Colors = "", Sizes = ""
                },

                // ── Đồ Uống ──
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catDoUong.Id,
                    Name = "Trà Sữa Trân Châu",
                    Description = "Trà sữa oolong thơm, trân châu đen dẻo, có thể chọn mức ngọt và đá",
                    Price = 45000, StockQuantity = 200, SoldQuantity = 567,
                    ImageUrl = foodImages["tra-sua"],
                    Colors = "Size M,Size L,Size XL", Sizes = "ít ngọt,vừa,nhiều đường"
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catDoUong.Id,
                    Name = "Cà Phê Sữa Đá",
                    Description = "Cà phê Robusta pha phin truyền thống, sữa đặc Ông Thọ, đá viên mát lạnh",
                    Price = 35000, StockQuantity = 150, SoldQuantity = 423,
                    ImageUrl = foodImages["ca-phe"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catDoUong.Id,
                    Name = "Sinh Tố Xoài",
                    Description = "Sinh tố xoài Cát Hòa tươi ngọt, thêm kem tươi và trân châu",
                    Price = 50000, StockQuantity = 80, SoldQuantity = 198,
                    ImageUrl = foodImages["sinh-to"],
                    Colors = "", Sizes = ""
                },

                // ── Set Meal ──
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catSetMeal.Id,
                    Name = "Combo Gia Đình 4 người",
                    Description = "2 tô phở + 2 phần cơm tấm + 4 ly nước + 1 đĩa chả giò. Tiết kiệm 15%",
                    Price = 280000, StockQuantity = 20, SoldQuantity = 56,
                    ImageUrl = foodImages["set-combo"],
                    Colors = "", Sizes = ""
                },
                new Product
                {
                    Id = Guid.NewGuid(), CategoryId = catSetMeal.Id,
                    Name = "Combo Đôi Lãng Mạn",
                    Description = "2 phần cơm tấm sườn + 2 ly nước + 1 tráng miệng. Hoàn hảo cho 2 người",
                    Price = 175000, StockQuantity = 30, SoldQuantity = 87,
                    ImageUrl = "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?auto=format&fit=crop&q=80&w=800",
                    Colors = "", Sizes = ""
                },
            };

            context.Products.AddRange(products);
            context.SaveChanges();
            Console.WriteLine($"[CatalogSeedData] Seeded {products.Count} food items in {5} categories.");
        }
    }
}
