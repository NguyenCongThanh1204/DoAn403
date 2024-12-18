using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DoAn.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [System.ComponentModel.DisplayName("Hàng xuất")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Dongxuat : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Dongxuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private phieuxuat _Phieu;
        [XafDisplayName(" Phiếu Xuất")]
        [Association]
        public phieuxuat Phieu
        {
            get { return _Phieu; }
            set { SetPropertyValue<phieuxuat>(nameof(Phieu), ref _Phieu, value); }
        }

        private SanPham _Hang;
        [XafDisplayName("Hàng hóa")]
        [Association("hang-xuat")]
        public SanPham Hang
        {
            get { return _Hang; }
            set
            {
                bool isModified = SetPropertyValue<SanPham>(nameof(Hang), ref _Hang, value);
                if (isModified)
                {
                    // Automatically set the sale price when the product is selected
                    if (Hang != null)
                    {
                        Dongia = Hang.Giaban;
                    }
                    // Trigger calculation after setting the unit price
                    if (!IsLoading && !IsDeleted && !IsSaving)
                    {
                        Tinhdong();
                    }
                }
            }
        }

        private double _Soluong;
        [XafDisplayName(" Số lượng")]
        public double Soluong
        {
            get { return _Soluong; }
            set
            {
                bool isModified = SetPropertyValue<double>(nameof(Soluong), ref _Soluong, value);
                if (!IsLoading && !IsDeleted && !IsSaving) { Tinhdong(); }

            }
        }



        private decimal _Dongia;
        [XafDisplayName(" Đơn giá")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal Dongia
        {
            get { return _Dongia; }
            set
            {
                bool isModified = SetPropertyValue<decimal>(nameof(Dongia), ref _Dongia, value);
                if (!IsLoading && !IsDeleted && !IsSaving) { Tinhdong(); }
            }
        }


        private double _Chietkhau;
        [XafDisplayName(" Chiết khấu(%)")]
        public double Chietkhau
        {
            get { return _Chietkhau; }
            set
            {
                bool isModified = SetPropertyValue<double>(nameof(Chietkhau), ref _Chietkhau, value);
                if (!IsLoading && !IsDeleted && !IsSaving) { Tinhdong(); }
            }
        }

        private decimal _Thanhtien;
        public decimal Thanhtien
        {
            get { return _Thanhtien; }
            set { SetPropertyValue<decimal>(nameof(Thanhtien), ref _Thanhtien, value); }
        }
        private decimal _DongiaVon;
        [XafDisplayName("Đơn giá vốn"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ### ###}")]
        public decimal DongiaVon
        {
            get { return _DongiaVon; }
            set { SetPropertyValue<decimal>(nameof(DongiaVon), ref _DongiaVon, value); }
        }
        private void Tinhdong()
        {
            decimal tien = 0;
            tien = (decimal)Soluong *Dongia;
            decimal tienck = (decimal)(Chietkhau / 100) * tien;
            tien -= tienck;
            Thanhtien = tien;
            if (Phieu != null)
                if(Hang != null)
                {
                    string sqlngay = Phieu.NgayCT.ToString("yyyy-MM-dd HH:mm:ss");
                    double dg = (double)Session.ExecuteScalar("SELECT dbo.Tinhgiavon('"+Hang.Oid+"','"+sqlngay+"')AS von");
                    DongiaVon = (decimal)dg;
                }
                Phieu.Tinhtong();

        }

    }

}