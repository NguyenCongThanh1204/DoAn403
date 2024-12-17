using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
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
        public static IBindingList GetDoanhthu1(IObjectSpace objectSpace)
        {
            BindingList<DoanhthuRpt> objects = new();
            Session session = ((XPObjectSpace)objectSpace).Session;
            XPCollection<Dongxuat> dongxuats = new(session);

            DateTime.TryParse(Tungay.ToShortDateString() + "00:00:01", out DateTime fTungay);
            DateTime.TryParse(Denngay.ToShortDateString() + "23:59:59", out DateTime fDenngay);
            dongxuats.Criteria = CriteriaOperator.Parse("Phieu.NgayCT>=? and Phieu.NgayCT<=?", fTungay, fDenngay);
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
        public static IBindingList GetDoanhThu(IObjectSpace objectSpace)
		{
			BindingList<DoanhthuRpt> objects = new();
			Session session = ((XPObjectSpace)objectSpace).Session;
			
			DateTime.TryParse(Tungay.ToShortDateString() + "00:00:01", out DateTime fTungay);
			DateTime.TryParse(Denngay.ToShortDateString() + "23:59:59", out DateTime fDenngay);
            string sTungay = fTungay.ToString("yyyy-MM-dd HH:mm:ss");
            string sDenngay = fDenngay.ToString("yyyy-MM-dd HH:mm:ss");
            SelectedData results = session.ExecuteSprocParametrized("DoanhthuProc", new SprocParameter("@Tungay", sTungay),
            new SprocParameter("@Denngay", sDenngay));

            foreach (SelectStatementResultRow row in results.ResultSet[0].Rows)
            {
                DoanhthuRpt obj = new()
                {
                    Oid = (Guid)row.Values[0],
                    Nhom = row.Values[1] as string,
                    MaSP = row.Values[2] as string,
                    TenSP = row.Values[3] as string,
                    Dvt = row.Values[4] as string,
                    Soluong = Convert.ToDouble(row.Values[5]),
                    Doanhthu = Convert.ToDecimal(row.Values[6]),
                    Giavon = Convert.ToDecimal(row.Values[7]),
                    Laigop = Convert.ToDecimal(row.Values[8])

                };
                objects.Add(obj);
            }
        
			return objects;
		}

	}
}
