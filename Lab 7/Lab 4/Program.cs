using System;

namespace Lab_04
{
    class Program
    {
        static ProductService service = new ProductService();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Đăng ký event
            service.OnProductAdded += ThongBaoThanhCong;
            service.OnProductRemoved += ThongBaoThanhCong;

            // Thêm dữ liệu mẫu
            InitSampleData();

            while (true)
            {
                HienThiMenu();
                Console.Write("Chon: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ThemSanPham();
                        break;
                    case "2":
                        XuatDanhSach();
                        break;
                    case "3":
                        TimTheoMa();
                        break;
                    case "4":
                        TimTheoTen();
                        break;
                    case "5":
                        LocTheoKhoangGia();
                        break;
                    case "6":
                        XoaSanPham();
                        break;
                    case "7":
                        TinhTongGiaTriKho();
                        break;
                    case "0":
                        Console.WriteLine("Thoát chương trình. Tạm biệt!");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại!");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }

        static void ThongBaoThanhCong(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[THÔNG BÁO]: {message}");
            Console.ResetColor();
        }

        static void InitSampleData()
        {
            try
            {
                service.AddProduct(new Product("SP01", "Bàn phím cơ", 650000, 10));
                service.AddProduct(new Product("SP02", "Chuột gaming", 450000, 20));
                service.AddProduct(new Product("SP03", "Tai nghe", 1200000, 5));
            }
            catch { }
        }

        static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("===== PRODUCT MANAGER =====");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
        }

        static void ThemSanPham()
        {
            Console.WriteLine("\n--- THÊM MỚI SẢN PHẨM ---");
            try
            {
                Console.Write("Nhập mã sản phẩm: ");
                string ma = Console.ReadLine();

                Console.Write("Nhập tên sản phẩm: ");
                string ten = Console.ReadLine();

                Console.Write("Nhập đơn giá: ");
                if (!double.TryParse(Console.ReadLine(), out double gia))
                {
                    Console.WriteLine("Lỗi: Đơn giá phải là số hợp lệ.");
                    return;
                }

                Console.Write("Nhập số lượng: ");
                if (!int.TryParse(Console.ReadLine(), out int sl))
                {
                    Console.WriteLine("Lỗi: Số lượng phải là số nguyên.");
                    return;
                }

                Product p = new Product(ma, ten, gia, sl);
                service.AddProduct(p);
            }
            catch (DuplicateProductException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dữ liệu không hợp lệ: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lỗi: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void XuatDanhSach()
        {
            Console.WriteLine("\n--- DANH SÁCH SẢN PHẨM ---");
            var list = service.GetAllProducts();
            if (list.Count == 0)
            {
                Console.WriteLine("Danh sách sản phẩm hiện đang trống!");
                return;
            }

            int stt = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"{stt++}. {item}");
            }
        }

        static void TimTheoMa()
        {
            Console.WriteLine("\n--- TÌM KIẾM THEO MÃ ---");
            Console.Write("Nhập mã sản phẩm cần tìm: ");
            string ma = Console.ReadLine();

            Product p = service.FindById(ma);
            if (p != null)
            {
                Console.WriteLine("Tìm thấy sản phẩm:");
                Console.WriteLine(p);
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sản phẩm có mã '{ma}'.");
            }
        }

        static void TimTheoTen()
        {
            Console.WriteLine("\n--- TÌM KIẾM THEO TÊN ---");
            Console.Write("Nhập từ khóa tên sản phẩm: ");
            string kw = Console.ReadLine();

            var list = service.SearchByName(kw);
            if (list.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sản phẩm nào khớp với từ khóa.");
                return;
            }

            Console.WriteLine($"Tìm thấy {list.Count} sản phẩm:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void LocTheoKhoangGia()
        {
            Console.WriteLine("\n--- LỌC THEO KHOẢNG GIÁ ---");
            Console.Write("Nhập giá tối thiểu (min): ");
            if (!double.TryParse(Console.ReadLine(), out double min))
            {
                Console.WriteLine("Lỗi: Giá nhập không hợp lệ.");
                return;
            }

            Console.Write("Nhập giá tối đa (max): ");
            if (!double.TryParse(Console.ReadLine(), out double max))
            {
                Console.WriteLine("Lỗi: Giá nhập không hợp lệ.");
                return;
            }

            if (min > max)
            {
                Console.WriteLine("Lỗi: Giá min không thể lớn hơn giá max.");
                return;
            }

            var list = service.FilterByPrice(min, max);
            if (list.Count == 0)
            {
                Console.WriteLine($"Không có sản phẩm nào trong khoảng giá từ {min:N0} đến {max:N0} VNĐ.");
                return;
            }

            Console.WriteLine($"Có {list.Count} sản phẩm:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void XoaSanPham()
        {
            Console.WriteLine("\n--- XÓA SẢN PHẨM ---");
            Console.Write("Nhập mã sản phẩm cần xóa: ");
            string ma = Console.ReadLine();

            try
            {
                service.RemoveProduct(ma);
            }
            catch (ProductNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lỗi: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void TinhTongGiaTriKho()
        {
            Console.WriteLine("\n--- TỔNG GIÁ TRỊ KHO HÀNG ---");
            double total = service.CalculateTotalInventoryValue();
            Console.WriteLine($"Tổng giá trị tồn kho: {total:N0} VNĐ");
        }
    }
}