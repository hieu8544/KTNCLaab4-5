using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNCLaab4_5
{
    public class SanPhamService
    {
        private List<SanPham> danhSachSanPham;
        public SanPhamService()
        {
            danhSachSanPham = new List<SanPham>();
        }
        public List<SanPham> GetDanhSachSanPham()
        {
            return danhSachSanPham;
        }

        public void ThemSanPham(SanPham sanPham)
        {
            if (sanPham == null)
            {
                throw new ArgumentNullException(nameof(sanPham), "Sản phẩm không được null.");
            }
            else if (sanPham.SoLuong <= 0 || sanPham.SoLuong >= 100)
            {
                throw new ArgumentException("Số lượng phải là số nguyên dương và nhỏ hơn 100.");
            }
            danhSachSanPham.Add(sanPham);
            Console.WriteLine("Thêm sản phẩm thành công!");
        }

        public void SuaSanPham(string id, SanPham sanPhamMoi)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID không được null hoặc rỗng.");

            if (sanPhamMoi == null)
                throw new ArgumentNullException(nameof(sanPhamMoi), "Thông tin sản phẩm không được null.");

            if (string.IsNullOrWhiteSpace(sanPhamMoi.MaSanPham))
                throw new ArgumentException("Mã sản phẩm không được null hoặc rỗng.");

            if (!sanPhamMoi.MaSanPham.StartsWith("SP"))
                throw new ArgumentException("Mã sản phẩm phải bắt đầu bằng 'SP'.");

            if (danhSachSanPham.Any(sp => sp.MaSanPham == sanPhamMoi.MaSanPham && sp.Id != id))
                throw new InvalidOperationException("Mã sản phẩm đã tồn tại.");

            var sanPhamHienTai = danhSachSanPham.Find(sp => sp.Id == id);

            if (sanPhamHienTai == null)
                throw new KeyNotFoundException("Không tìm thấy sản phẩm với ID được cung cấp.");

            sanPhamHienTai.MaSanPham = sanPhamMoi.MaSanPham;
            sanPhamHienTai.TenSanPham = sanPhamMoi.TenSanPham;
            sanPhamHienTai.Gia = sanPhamMoi.Gia;
            sanPhamHienTai.MauSac = sanPhamMoi.MauSac;
            sanPhamHienTai.KichThuoc = sanPhamMoi.KichThuoc;
            sanPhamHienTai.SoLuong = sanPhamMoi.SoLuong;

            Console.WriteLine("Sửa sản phẩm thành công!");
        }
        public void XoaSanPham(string id)
        {
            var sanPham = danhSachSanPham.Find(sp => sp.Id == id);

            if (sanPham == null)
            {
                throw new KeyNotFoundException("Không tìm thấy sản phẩm với ID được cung cấp.");
            }

            danhSachSanPham.Remove(sanPham);
            Console.WriteLine("Xóa sản phẩm thành công!");
        }
    }
}
