﻿using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.ReportsV2;
using DoAn.Module.BusinessObjects;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.XtraSpreadsheet.Model;

namespace DoAn.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class DoAnModule : ModuleBase {
    public DoAnModule() {
		// 
		// DoAnModule
		// 
		AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
		AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileData));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileAttachmentBase));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Chart.ChartModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.CloneObject.CloneObjectModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Dashboards.DashboardsModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Office.OfficeModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        PredefinedReportsUpdater predefinedReportsUpdater = new(Application, objectSpace, versionFromDB)
        {
            UseMultipleUpdaters = true
        };
        predefinedReportsUpdater.AddPredefinedReport<PhieunhapRpt>("pnhap", typeof(PhieuNhap));
        return new ModuleUpdater[] { updater, predefinedReportsUpdater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
        application.LoggedOn += new EventHandler<LogonEventArgs>(Application_LoggedOn);
		application.SetupComplete += Application_SetupComplete;
    }

	private void Application_SetupComplete(object sender, EventArgs e)
	{
		Application.ObjectSpaceCreated += Application_ObjectSpaceCreated; ;
	}

	private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
	{
		if(e.ObjectSpace is NonPersistentObjectSpace nonPersistentObjectSpace)
        {
            IObjectSpace additionalObjectSpace = Application.CreateObjectSpace(typeof(ApplicationUser));
            nonPersistentObjectSpace.AdditionalObjectSpaces.Add(additionalObjectSpace);
			nonPersistentObjectSpace.ObjectsGetting += NonPersistentObjectSpace_ObjectsGetting;
        }    
	}

    private void NonPersistentObjectSpace_ObjectsGetting(object sender, ObjectsGettingEventArgs e)
    {
        NonPersistentObjectSpace obs = (NonPersistentObjectSpace)sender;
        XPObjectSpace objectSpace = (XPObjectSpace)obs.AdditionalObjectSpaces[0];
        if (e.ObjectType == typeof(DoanhthuRpt))
        {
            e.Objects = Chung.GetDoanhThu(objectSpace);
        }
    }
	private void Application_LoggedOn(object sender, LogonEventArgs e)
    {
        XafApplication app = (XafApplication)sender;
        IObjectSpaceProvider objectSpaceProvider = app.ObjectSpaceProviders[0];
        ((SecuredObjectSpaceProvider)objectSpaceProvider).AllowICommandChannelDoWithSecurityContext = true;
    }

    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }
}
