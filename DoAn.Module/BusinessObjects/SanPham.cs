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
    [System.ComponentModel.DisplayName("Hàng hóa")]
    [ImageName("BO_Contact")]
    [DefaultProperty("TenSP")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SanPham : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public SanPham(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private NhomSP _Nhom;
        [Association]
        [XafDisplayName("Nhóm")]
        public NhomSP Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomSP>(nameof(Nhom), ref _Nhom, value); }
        }

        private string _Masp;
        [XafDisplayName("Mã"),Size(20)]
        [RuleRequiredField("Yeucau MaSP",DefaultContexts.Save,"Phải có MÃ sản phẩm")]
        [RuleUniqueValue,Indexed(Unique =true)]
        public string Masp
        {
            get { return _Masp; }
            set { SetPropertyValue<string>(nameof(Masp), ref _Masp, value); }
        }

      

        private string _TenSP;
        [XafDisplayName("Tên hàng"),Size(255)]
        public string TenSP
        {
            get { return _TenSP; }
            set { SetPropertyValue<string>(nameof(TenSP), ref _TenSP, value); }
        }


        private string _Dvt;
        [XafDisplayName("đvt"),Size(10)]
        public string Dvt
        {
            get { return _Dvt; }
            set { SetPropertyValue<string>(nameof(Dvt), ref _Dvt, value); }
        }


       
        private decimal _Giaban;
        [XafDisplayName("Giá bán")]
        public decimal Giaban
        {
            get { return _Giaban; }
            set { SetPropertyValue<decimal>(nameof(Giaban), ref _Giaban, value); }
        }


        private double _Soton;
        [XafDisplayName("Số lượng tồn"),ModelDefault("AllowEdit","false")]
        public double Soton
        {
            get { return _Soton; }
            set { SetPropertyValue<double>(nameof(Soton), ref _Soton, value); }
        }


        private decimal _Giatriton;
        [XafDisplayName("Giá trị tồn"), ModelDefault("AllowEdit", "false")]
        public decimal Giatriton
        {
            get { return _Giatriton; }
            set { SetPropertyValue<decimal>(nameof(Giatriton), ref _Giatriton, value); }
        }


        private string _Ghichu;
        [XafDisplayName("Ghi chú"),Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Nhập")]
        public XPCollection<DongNhap> DongNhaps
        {
            get { return GetCollection<DongNhap>(nameof(DongNhaps)); }
        }
    } 
}