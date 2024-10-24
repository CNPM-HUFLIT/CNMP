using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;
using PagedList;

namespace CNPMNC.Controllers
{
    public class SanPhamController : Controller
    {
        //// GET: SanPham
        private readonly DBQLQUANAOEntities3 db = new DBQLQUANAOEntities3(); // Giả sử bạn có DbContext
        private int? page;

        // GET: SanPham
        public ActionResult Index()
        {
            int pageSize = 12; // số sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1); // nếu page null thì lấy là trang 1

            var SanPhams = db.SanPhams.ToList();
            // Chuyển List thành IPagedList
            return View(SanPhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            var SanPham = db.SanPhams.Find(id);
            if (SanPham == null)
            {
                return HttpNotFound();
            }
            return View(SanPham);
        }
    }
}