using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Module.BusinessObjects
{
	[DomainComponent]
	[NavigationItem("chungtu")]
	[System.ComponentModel.DisplayName("Doanh thu")]
	public class DoanhthuRpt
	{
		[DevExpress.ExpressApp.Data.Key]
		public Guid Oid { get; set; }
		[XafDisplayName("Nhóm")]
		public string Nhom { set; get; }
		[XafDisplayName("Mã")]
		public string MaSP { set; get; }
		[XafDisplayName("Tên sản phẩm")]
		public string TenSP { set; get; }
		[XafDisplayName("ĐVT")]
		public string Dvt { set; get; }
		[XafDisplayName("Số lượng")]
		[ModelDefault("DisplayFormat","### ### ###")]

		public Nullable<double> Soluong { get; set; }
		[XafDisplayName("Doanh thu")]
		[ModelDefault("DisplayFormat","### ### ###")]

		public Nullable<decimal> Doanhthu { get; set; }
		[XafDisplayName("Giá vốn")]
		[ModelDefault("DisplayFormat","### ### ###")]
		public Nullable<decimal> Giavon { get; set; }
		[XafDisplayName("Lãi gộp")]
		[ModelDefault("DisplayFormat","### ### ###")]

		public Nullable<decimal> Laigop { get; set; }
	}
}
