using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DoAn.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Module.Controllers
{
    public class ChonhangController: ObjectViewController<DetailView,PhieuNhap>
    {
        private bool ignoreExecute=false;
        public ChonhangController()
        {
            PopupWindowShowAction chonhang = new(this, "chonnhap", "View")
            {
                Caption = "chọn hàng",
                ImageName= "BO_Contact",
                TargetViewId= "PhieuNhap_DetailView"
            };
            chonhang.CustomizePopupWindowParams += Chonhang_CustomizePopupWindowParams;
            chonhang.Execute += Chonhang_Execute;
        }

        private void Chonhang_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            if (ignoreExecute)
            {
                ignoreExecute = false;
                e.CanCloseWindow = false;
                return;
            }
        }

        private void Chonhang_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace=Application.CreateObjectSpace(typeof(SanPham));
            CollectionSourceBase collectionSourceBase=new CollectionSource(objectSpace,(typeof(SanPham)));
            ListView listView = Application.CreateListView("SanPham_LookupListView", collectionSourceBase, true);
            e.View = listView;
            e.Context = TemplateContext.PopupWindow;
            e.DialogController.AcceptAction.ActionMeaning=ActionMeaning.Unknown;
            e.DialogController.AcceptAction.Active.SetItemValue("hủy",false);
            e.DialogController.FrameAssigned += DialogController_FrameAssigned;

        }

        private void DialogController_FrameAssigned(object sender, EventArgs e)
        {
            ListViewProcessCurrentObjectController listViewProcessCurrentObjectController=
                ((Controller)sender).Frame.GetController<ListViewProcessCurrentObjectController>();
            listViewProcessCurrentObjectController.CustomProcessSelectedItem += ListViewProcessCurrentObjectController_CustomProcessSelectedItem;
        }

        private void ListViewProcessCurrentObjectController_CustomProcessSelectedItem(object sender, CustomProcessListViewSelectedItemEventArgs e)
        {
            if(ObjectSpace.GetObject(e.InnerArgs.CurrentObject)is SanPham sp && View.CurrentObject is PhieuNhap phieunhap){
                DongNhap dong = ObjectSpace.CreateObject<DongNhap>();
                dong.Phieu = phieunhap;
                dong.Hang = sp;
                dong.Soluong = 1;
                dong.Save();
                phieunhap.DongNhaps.Add(dong);
                ignoreExecute=true;
                e.Handled = true;

            }
        }
    }
}
