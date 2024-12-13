using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl;
using DevExpress.RichEdit.Export;
using DevExpress.XtraReports.Native.Data;
using DevExpress.XtraRichEdit.Internal;
using DoAn.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Module.Controllers
{
	public abstract class InPhieunhap: ViewController
	{
		public InPhieunhap()
		{
			TargetObjectType = typeof(PhieuNhap);
			SimpleAction inphieunhap = new(this, "in phieu nhap", "View")
			{
				Caption = "In phiếu",
				ImageName = "printer",
				ToolTip = "In phiếu nhập",
				TargetObjectType = typeof(PhieuNhap),
				ConfirmationMessage = "Có chắc chắn in hay không?"
			};
			inphieunhap.Execute += Inphieunhap_Execute;
		}

		private void Inphieunhap_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			if (View.CurrentObject is PhieuNhap p)
			{


				string ChungtuOid = p.Oid.ToString();
				if (!string.IsNullOrEmpty(ChungtuOid))
				{
					IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
					IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
						new BinaryOperator("DisplayName", "pnhap"));
					if (reportData != null)
					{

						PrintReport(reportData, Guid.Parse(ChungtuOid));
					}
				}
			}
		}
		protected abstract void PrintReport(IReportDataV2 reportData, Guid phieuOid);
	}
}
