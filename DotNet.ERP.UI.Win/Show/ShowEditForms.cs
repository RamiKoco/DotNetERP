using System;
using System.Windows.Forms;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities.Base.Interfaces;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show.Interfaces;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Show
{
    public class ShowEditForms<TForm> : IBaseFormShow where TForm : BaseEditForm
    {

        public long ShowDialogEditForm(KartTuru kartTuru, long id)
        {
            if (!Forms.Functions.GeneralFunctions.EditFormYetkiKontrolu(id, kartTuru)) return 0;

            using (var frm = (TForm) Activator.CreateInstance(typeof(TForm)))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefleshYapilacak ? frm.Id : 0;
            }
        }
        public static long ShowDialogEditForm(KartTuru kartTuru, long id, params object[] prm)
        {
            if (!Forms.Functions.GeneralFunctions.EditFormYetkiKontrolu(id, kartTuru)) return 0;

            using (var frm = (TForm) Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefleshYapilacak ? frm.Id : 0;

            }
        }
        public static long ShowDialogEditForm( long id, params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefleshYapilacak ? frm.Id : 0;

            }
        }
       
        public static void ShowDialogEditForm(long? id, params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.Yukle();
                frm.ShowDialog();
            }
        }
        
        public static bool ShowDialogEditForm(params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
             
                frm.Yukle();
                return frm.DialogResult == DialogResult.OK;
            }
        }
       
        public static bool ShowDialogEditForm(KartTuru kartTuru,params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return false;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {

                frm.Yukle();
                frm.ShowDialog();
                return frm.DialogResult == DialogResult.OK;

            }
        }

        public static void ShowDialogEditForm(KartTuru kartTuru)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.BaseIslemTuru = IslemTuru.EntityUpdate;
                frm.Yukle();
                frm.ShowDialog();

            }
        }
        public static void ShowDialogEditForm()
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.Yukle();
                frm.ShowDialog();

            }
        }
       
        public static bool ShowDialogEditForm(IslemTuru islemTuru,params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm),prm))
            {
                frm.BaseIslemTuru = islemTuru;
                frm.Yukle();
                frm.ShowDialog();

                return frm.RefleshYapilacak;
            }
        }
        public static T ShowDialogEditForm<T>(params object[] prm) where T : IBaseEntity
        {
            using (var frm = (TForm) Activator.CreateInstance(typeof(TForm), prm))
            {

                frm.Yukle();
                frm.ShowDialog();
                return (T) frm.ReturnEntity();
            }

        }
    }
}