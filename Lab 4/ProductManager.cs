using System;
using System.Collections.Generic;

namespace Lab_04
{
    // Interface ràng buộc
    public interface IEntity
    {
        string Id { get; }
    }

    // Class sản phẩm
    public class Product : IEntity
    {
        private double price;
        private int quantity;

        public string MaSP { get; set; }
        public string TenSP { get; set; }

        public string Id => MaSP;

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Đơn giá không được âm.");
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng không được âm.");
                quantity = value;
            }
        }

        public Product() { }

        public Product(string maSP, string tenSP, double price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã sản phẩm không được để trống.");

            MaSP = maSP.Trim();
            TenSP = tenSP?.Trim() ?? "";
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Mã: {MaSP,-8} | Tên: {TenSP,-20} | Giá: {Price,10:N0} VNĐ | SL: {Quantity,5}";
        }
    }

    // Các Exception tự tạo
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message) : base(message) { }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }

    // Generic Repository
    public class Repository<T> where T : IEntity
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public bool Remove(string id)
        {
            T item = FindById(id);
            if (item != null)
            {
                return items.Remove(item);
            }
            return false;
        }

        public T FindById(string id)
        {
            foreach (var item in items)
            {
                if (item.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    return item;
            }
            return default;
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<T> GetAll()
        {
            return new List<T>(items);
        }
    }

    // Xử lý nghiệp vụ & phát sự kiện
    public class ProductService
    {
        private Repository<Product> repo = new Repository<Product>();

        // Sự kiện thông báo khi thêm/xóa
        public event Action<string> OnProductAdded;
        public event Action<string> OnProductRemoved;

        public void AddProduct(Product p)
        {
            if (p == null) return;

            Product existing = repo.FindById(p.MaSP);
            if (existing != null)
            {
                throw new DuplicateProductException($"Lỗi: Mã sản phẩm '{p.MaSP}' đã tồn tại!");
            }

            repo.Add(p);
            OnProductAdded?.Invoke($"Đã thêm sản phẩm [{p.MaSP} - {p.TenSP}] thành công.");
        }

        public void RemoveProduct(string maSP)
        {
            Product p = repo.FindById(maSP);
            if (p == null)
            {
                throw new ProductNotFoundException($"Lỗi: Không tìm thấy sản phẩm có mã '{maSP}' để xóa!");
            }

            repo.Remove(maSP);
            OnProductRemoved?.Invoke($"Đã xóa sản phẩm mã '{maSP}' thành công.");
        }

        public Product FindById(string maSP)
        {
            return repo.FindById(maSP);
        }

        public List<Product> SearchByName(string keyword)
        {
            Func<Product, bool> condition = p => p.TenSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
            return repo.Find(condition);
        }

        public List<Product> FilterByPrice(double minPrice, double maxPrice)
        {
            Func<Product, bool> filterCondition = p => p.Price >= minPrice && p.Price <= maxPrice;
            return repo.Find(filterCondition);
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAll();
        }

        public double CalculateTotalInventoryValue()
        {
            double total = 0;
            foreach (var p in repo.GetAll())
            {
                total += p.Price * p.Quantity;
            }
            return total;
        }
    }
}