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
    [System.ComponentModel.DisplayName("Phiếu chi")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PhieuChi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PhieuChi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private KhachHang _Khach;
        [XafDisplayName("chi cho")]
        [Association("khach-chi")]
        public KhachHang Khach
        {
            get { return _Khach; }
            set { SetPropertyValue<KhachHang>(nameof(Khach), ref _Khach, value); }
        }


        private NhanVien _Ketoan;
        [XafDisplayName("Kế toán")]
        [Association("kt-chi")]
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
        [ModelDefault("EditMák","dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
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
    }
}