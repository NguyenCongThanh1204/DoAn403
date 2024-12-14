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
    [System.ComponentModel.DisplayName("Nhân viên")]
    [DefaultProperty("HoTen")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NhanVien : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NhanVien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [DevExpress.Xpo.Aggregated, Association("kt-chi")]
        [XafDisplayName("Phiếu chi")]
        public XPCollection<PhieuChi> PhieuChis
        {
            get { return GetCollection<PhieuChi>(nameof(PhieuChis)); }
        }

        [DevExpress.Xpo.Aggregated, Association("kt-thu")]
        [XafDisplayName("Phiếu thu")]
        public XPCollection<PhieuThu> PhieuThus
        {
            get { return GetCollection<PhieuThu>(nameof(PhieuThus)); }
        }

        [DevExpress.Xpo.Aggregated, Association("kt-nhap")]
        [XafDisplayName("Phiếu nhập")]
        public XPCollection<PhieuNhap> PhieuNhaps
        {
            get { return GetCollection<PhieuNhap>(nameof(PhieuNhaps)); }
        }

        [DevExpress.Xpo.Aggregated, Association("kt-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public XPCollection<phieuxuat> Phieuxuats
        {
            get { return GetCollection<phieuxuat>(nameof(Phieuxuats)); }
        }

        private string _TaiKhoan;
        [XafDisplayName("Tài khoản"),Size(12)]
        public string TaiKhoan
        {
            get { return _TaiKhoan; }
            set { SetPropertyValue<string>(nameof(TaiKhoan), ref _TaiKhoan, value); }
        }



        private string _HoTen;
        [XafDisplayName("Họ tên"), Size(255)]
        public string HoTen
        {
            get { return _HoTen; }
            set { SetPropertyValue<string>(nameof(HoTen), ref _HoTen, value); }
        }

        private string _DiaChi;
        [XafDisplayName("Địa chỉ"), Size(255)]
        public string DiaChi
        {
            get { return _DiaChi; }
            set { SetPropertyValue<string>(nameof(DiaChi), ref _DiaChi, value); }
        }

        private string _DienThoai;
        [XafDisplayName("Điện thoại"), Size(50)]
        public string DienThoai
        {
            get { return _DienThoai; }
            set { SetPropertyValue<string>(nameof(DienThoai), ref _DienThoai, value); }
        }


        private string _Email;
        [XafDisplayName("Email"), Size(255)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }


        private string _GhiChu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }
    }
}