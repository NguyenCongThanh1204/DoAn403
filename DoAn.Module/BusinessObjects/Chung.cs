using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using DoAn.Module.BusinessObjects;
using System.ComponentModel;

public static class Chung
{
    public static DateTime Tungay = DateTime.Now;
    public static DateTime Denngay = DateTime.Now;

    public static IBindingList GetDoanhThu(IObjectSpace objectSpace)
    {
        // Kiểm tra giá trị hợp lệ của Tungay và Denngay
        if (Tungay == DateTime.MinValue || Tungay < new DateTime(1753, 1, 1))
        {
            Tungay = new DateTime(1753, 1, 1);
        }

        if (Denngay == DateTime.MinValue || Denngay < new DateTime(1753, 1, 1))
        {
            Denngay = DateTime.Now;
        }

        BindingList<DoanhthuRpt> objects = new();
        Session session = ((XPObjectSpace)objectSpace).Session;
        XPCollection<Dongxuat> dongxuats = new(session);

        // Lấy giá trị thời gian bắt đầu và kết thúc
        DateTime fTungay = Tungay.Date.AddSeconds(1); // 00:00:01
        DateTime fDenngay = Denngay.Date.AddDays(1).AddSeconds(-1); // 23:59:59

        // Thiết lập điều kiện lọc
        dongxuats.Criteria = CriteriaOperator.Parse("Phieu.NgayCT >= ? AND Phieu.NgayCT <= ?", fTungay, fDenngay);

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
