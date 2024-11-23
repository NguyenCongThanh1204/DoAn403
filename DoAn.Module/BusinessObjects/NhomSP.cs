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
    [System.ComponentModel.DisplayName("Nhóm hàng")]
    [ImageName("BO_Contact")]
    [DefaultProperty("TenNhom")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NhomSP : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NhomSP(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _TenNhom;
        [XafDisplayName("Tên nhóm"),Size(100)]
        public string TenNhom
        {
            get { return _TenNhom; }
            set { SetPropertyValue<string>(nameof(TenNhom), ref _TenNhom, value); }
        }
        [XafDisplayName("Số hàng")]
        public int Sohang
        {
            get 
            { 
                return SanPhams.Count; 
            }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Sản phẩm")]
        public XPCollection<SanPham> SanPhams
        {
            get { return GetCollection<SanPham>(nameof(SanPhams)); }
        }

    }
}