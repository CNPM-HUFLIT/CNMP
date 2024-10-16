using CNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPMNC.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult DangKy()
        {
            return View();
        }
        //POST: Ham Dangky(post) nhan du lieu tu trang Dangky và thuc hien viec thuc hien tao moi du lieu
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KHACHHANG kh)
        {
            //Gan cac gia tri nguoi dung nhap nhap du lieu cho cac bien
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var email = collection["Email"];
            var diachi = collection["Diachi"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống!";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không thể để trống!";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không thể để trống!";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại không thể để trống!";
            }
            else if (matkhaunhaplai != matkhau)
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại khác mật khẩu";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không thể để trống!";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi6"] = "Địa chỉ không thể để trống!";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "Số điện thoại không thể để trống!";
            }
            else
            {
                dbdangkyEntities db = new dbdangkyEntities();
                //Gan gia tri cho doi tuong duoc tao moi (kh)
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.Add(kh); //thêm 1 thành phần
                db.SaveChanges(); // lưu vào database
                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }
    }
}