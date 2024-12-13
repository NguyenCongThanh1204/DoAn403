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
    [NavigationItem(false)]
    [System.ComponentModel.DisplayName("Hàng nhập")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DongNhap : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DongNhap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private PhieuNhap _Phieu;
        [XafDisplayName(" Phiếu nhập")]
        [Association]
        public PhieuNhap Phieu
        {
            get { return _Phieu; }
            set { SetPropertyValue<PhieuNhap>(nameof(Phieu), ref _Phieu, value); }
        }

        private SanPham _Hang;
        [XafDisplayName(" Hàng hóa")]
        [Association]
        public SanPham Hang
        {
            get { return _Hang; }
            set { SetPropertyValue<SanPham>(nameof(Hang), ref _Hang, value); }
        }


        private double _Soluong;
        [XafDisplayName(" Số lượng")]
        public double Soluong
        {
            get { return _Soluong; }
            set { 
                bool isModified = SetPropertyValue<double>(nameof(Soluong), ref _Soluong, value);
                if(!IsLoading && !IsDeleted && !IsSaving) { Tinhdong(); }

            }
        }

        private decimal _Dongia;
        [XafDisplayName(" Đơn giá")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Dongia
        {
            get { return _Dongia; }
            set {
                bool isModified = SetPropertyValue<decimal>(nameof(Dongia), ref _Dongia, value);
                if (!IsLoading && !IsDeleted && !IsSaving) { Tinhdong(); }
            }
        }


        private double _Chietkhau;
        [XafDisplayName(" Chiết khấu(%)")]
        public double Chietkhau
        {
            get { return _Chietkhau; }
            set {
                bool isModified = SetPropertyValue<double>(nameof(Chietkhau), ref _Chietkhau, value);
                if (!IsLoading && !IsDeleted && !IsSaving) { Tinhdong(); }
            }
        }

        private decimal _Thanhtien;
        [XafDisplayName("Thành tiền"),ModelDefault("AllowEdit","false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Thanhtien
        {
            get { return _Thanhtien; }
            set { SetPropertyValue<decimal>(nameof(Thanhtien), ref _Thanhtien, value); }
        }
        private void Tinhdong()
        {
            decimal tien = 0;
            tien = (decimal)Soluong * Dongia;
            decimal tienck = (decimal)(Chietkhau/ 100) * tien;
            tien -= tienck;
            Thanhtien = tien;
            if(Phieu != null) Phieu.Tinhtong();
            
        }


    }
}