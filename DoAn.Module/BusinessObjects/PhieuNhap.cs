using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DoAn.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [System.ComponentModel.DisplayName("Phiếu nhập")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PhieuNhap : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PhieuNhap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
                SoCT = GetSoCT().ToString();
            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        protected override void OnSaving()
        {
            
            base.OnSaving();
            Tinhtong();
        }
        private KhachHang _Khach;
        [XafDisplayName("Nhà cung cấp")]
        [Association("khach-nhap")]
        public KhachHang Khach
        {
            get { return _Khach; }
            set { SetPropertyValue<KhachHang>(nameof(Khach), ref _Khach, value); }
        }

        private NhanVien _Ketoan;
        [XafDisplayName("Kế toán")]
        [Association("kt-nhap")]
        public NhanVien Ketoan
        {
            get { return _Ketoan; }
            set { SetPropertyValue<NhanVien>(nameof(Ketoan), ref _Ketoan, value); }
        }

        private string _SoCT;
        [XafDisplayName("Số CT"), Size(20), RuleUniqueValue]
        public string SoCT
        {
            get { return _SoCT; }
            set { SetPropertyValue<string>(nameof(SoCT), ref _SoCT, value); }
        }

        private DateTime _NgayCT;
        [XafDisplayName("Ngày CT")]
        [ModelDefault("EditMák", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
        }

        private String _SoHD;
        [XafDisplayName("Số CT"), Size(20)]
        public String SoHD
        {
            get { return _SoHD; }
            set { SetPropertyValue<String>(nameof(SoHD), ref _SoHD, value); }
        }

        private DateTime _NgayHD;
        [XafDisplayName("Ngày HD")]
        [ModelDefault("EditMák", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayHD
        {
            get { return _NgayHD; }
            set { SetPropertyValue<DateTime>(nameof(NgayHD), ref _NgayHD, value); }
        }

        private Decimal _SoTien;
        [XafDisplayName("Số tiền")]
        public Decimal SoTien
        {
            get { return _SoTien; }
            set { SetPropertyValue<Decimal>(nameof(SoTien), ref _SoTien, value); }
        }

        private string _ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string ghichu
        {
            get { return _ghichu; }
            set { SetPropertyValue<string>(nameof(ghichu), ref _ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Nhập")]
        public XPCollection<DongNhap> DongNhaps
        {
            get { return GetCollection<DongNhap>(nameof(DongNhaps)); }
        }

        private decimal _Tongtien;
        [XafDisplayName("Tổng tiền"), ModelDefault("AllowEdit","false")]
        [ModelDefault("DisplayFormat","{0:### ### ### ###}")]
        public decimal Tongtien
        {
            get { return _Tongtien; }
            set { SetPropertyValue<decimal>(nameof(Tongtien), ref _Tongtien, value); }
        }
        public void Tinhtong()
        {
            decimal tong = 0;
            foreach(DongNhap dong in DongNhaps)
            {
                tong += dong.Thanhtien;
            }    
            Tongtien = tong;
        }
        private int GetSoCT()
        {
            string sql = @"SELECT MAX(CAST(SoCT AS INT)) AS MaxSoCT
            FROM Phieunhap
            WHERE isnumeric(sOct) = 1 AND GCRecord is null;";
            int so = 1;
            var ret=Session.ExecuteScalar(sql);
            if(ret!=null)
                so = Convert.ToInt32(ret)+1;
            return so;
        }

    }
}