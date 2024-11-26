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
    [System.ComponentModel.DisplayName("Khách hàng")]
    [DefaultProperty("TenKH")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KhachHang : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public KhachHang(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private NhomKhach _Nhom;
        [XafDisplayName("Nhóm")]
        [Association]
        public NhomKhach Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomKhach>(nameof(Nhom), ref _Nhom, value); }
        }


        private string _TenKH;
        [XafDisplayName("Tên khách hàng"),Size(255)]
        public string TenKH
        {
            get { return _TenKH; }
            set { SetPropertyValue<string>(nameof(TenKH), ref _TenKH, value); }
        }


        private string _DiaChi;
        [XafDisplayName("Địa chỉ"),Size(255)]
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