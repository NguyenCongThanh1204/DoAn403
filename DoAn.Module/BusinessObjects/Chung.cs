using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Module.BusinessObjects
{
	public static class Chung
	{
		public static DateTime Tungay = DateTime.Now;
		public static DateTime Denngay = DateTime.Now;
		public static IBindingList GetDoanhThu(IObjectSpace objectSpace)
		{
			BindingList<DoanhthuRpt> objects = new();
			Session session = ((XPObjectSpace)objectSpace).Session;
			XPCollection<Dongxuat> dongxuats = new(session);
			DateTime.TryParse(Tungay.ToShortDateString() + "00:00:01", out DateTime fTungay);
			DateTime.TryParse(Denngay.ToShortDateString() + "23:59:59", out DateTime fDenngay);
			dongxuats.Criteria = CriteriaOperator.Parse("Phieu.NgayCT>=? and Phieu.NgayCT<=?",fTungay, fDenngay);
			foreach (Dongxuat dong in dongxuats)
			{
				DoanhthuRpt obj = new()
				{
					Oid = dong.Oid,
					Nhom = dong.Hang.Nhom.TenNhom,
					MaSP = dong.Hang.Masp,
					TenSP = dong.Hang.TenSP,
					Dvt = dong.Hang.Dvt,
					Soluong = dong.Soluong,
					Doanhthu = dong.Thanhtien,
					Giavon = dong.DongiaVon * (decimal)dong.Soluong,
					Laigop = dong.Thanhtien - dong.DongiaVon * (decimal)(dong.Soluong),
				};
				objects.Add(obj);
			}
			return objects;
		}

	}
}
