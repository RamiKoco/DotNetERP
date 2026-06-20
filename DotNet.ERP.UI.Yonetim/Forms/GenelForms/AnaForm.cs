using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Data.Contexts;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.Model.Entities.Base;
using DotNet.ERP.UI.Win.Forms.DonemForms;
using DotNet.ERP.UI.Win.Forms.EklerDepolamaAyarlariForms;
using DotNet.ERP.UI.Win.Forms.KullaniciForms;
using DotNet.ERP.UI.Win.Forms.SubeForms;
using DotNet.ERP.UI.Win.Forms.VergiDairesiForms;
using DotNet.ERP.UI.Win.GenelForms;
using DotNet.ERP.UI.Win.Show;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Security;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Yonetim.Forms.GenelForms
{
    public partial class AnaForm : RibbonForm
    {
        #region Variables

        private readonly string _server;
        private readonly SecureString _kullaniciAdi;
        private readonly SecureString _sifre;
        private readonly YetkilendirmeTuru _yetkilendirmeTuru;
        private readonly KurumBll _bll; 
        
        #endregion
        public AnaForm(params object[] prm)
        {
            InitializeComponent();

            longNavigator.Navigator.NavigatableControl = tablo.GridControl;
            EventsLoad();
            ButonEnabledDurumu();
            
            _server = prm[0].ToString();
            _kullaniciAdi = (SecureString)prm[1];
            _sifre = (SecureString)prm[2];
            _yetkilendirmeTuru = (YetkilendirmeTuru)prm[3];
            _bll = new KurumBll();

        }

        private void EventsLoad()
        {
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //Table Events
            tablo.DoubleClick += Tablo_DoubleClick;
            tablo.KeyDown += Tablo_KeyDown;
            tablo.MouseUp += Tablo_MouseUp;
            tablo.RowCountChanged += Tablo_RowCountChanged;

            //Form Events
            FormClosing += AnaForm_FormClosing;
            Load += AnaForm_Load;
        }


        protected internal void Listele()
        {
            tablo.GridControl.DataSource = _bll.List(null);

        }
        protected virtual void ShowEditForm(long id)
        {

            Win.Forms.Functions.GeneralFunctions.CreateConnectionString("DotNet_ERP_Yonetim",_server,_kullaniciAdi,_sifre,_yetkilendirmeTuru);
            
            //if (id < -1) return; //Kart seçme hatası sonrası hata verdiği için eklendi udemy soru cevaptan
            var result = ShowEditForms<KurumEditForm>.ShowDialogEditForm(id, _server, _kullaniciAdi, _sifre,_yetkilendirmeTuru);
            if (result <= 0) return;
            Listele();
            tablo.RowFocus("Id",result);
        }
        private void ButonEnabledDurumu()
        {
            foreach (BarItem button in ribbonControl.Items)
            {
                if (!(button is BarButtonItem item)) continue;
                if (item != btnYeni)
                    item.Enabled = tablo.DataRowCount > 0;

            }
        }

        private void EntityDelete(BaseEntity entity)
        {
            Win.Forms.Functions.GeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            if (!Functions.GeneralFunctions.DeleteDatabase<ERPYonetimContext>()) return;

            Win.Forms.Functions.GeneralFunctions.CreateConnectionString("DotNet_ERP_Yonetim", _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            _bll.Delete(entity);
            tablo.DeleteSelectedRows();
            tablo.RowFocus(tablo.FocusedRowHandle);

        }
        private MyButtonEdit _btnEdit;
        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnYeni || e.Item == btnDuzelt)
            {
                if(e.Item == btnYeni)
                    ShowEditForm(-1);
                else if (e.Item == btnDuzelt)
                    ShowEditForm(tablo.GetRowId());
            }
            else
            {
                var entity = tablo.GetRow<Kurum>();
                if (entity == null) return;
                Win.Forms.Functions.GeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);

                if(e.Item == btnSil)
                    EntityDelete(entity);
                else if (e.Item == btnEmailParametreleri)
                    ShowEditForms<EmailParametreEditForm>.ShowDialogEditForm();
                else if (e.Item == btnSubeKartlari)
                    ShowListForms<SubeListForm>.ShowDialogListForm();
                else if (e.Item == btnDonemKartlari)
                    ShowListForms<DonemListForm>.ShowDialogListForm();
                else if (e.Item == btnVergiDaireleriKartlari)
                {
                    ShowListForms<VergiDairesiListForm>.ShowDialogListForm(
                         KartTuru.VergiDairesi,
                            null,
                            frm =>
                            {
                                frm.ShowYeniButton = true;
                                frm.ShowDuzeltButton = true;
                                frm.ShowSilButton = true;
                            }
                    );
                }
                else if (e.Item == btnEklerDepolamaAyarlari)
                    ShowEditForms<EklerDepolamaAyarlariEditForm>.ShowDialogEditForm();
                else if (e.Item == btnKurumBilgileri)
                    ShowEditForms<KurumBilgileriEditForm>.ShowDialogEditForm(null,entity.Kod,entity.Ad);
                else if (e.Item == btnRolKartlari)
                    ShowListForms<RolListForm>.ShowDialogListForm();
                else if (e.Item == btnKullaniciKartlari)
                    ShowListForms<KullaniciListForm>.ShowDialogListForm();
                else if (e.Item == btnKullaniciBirimYetkileri)
                    ShowEditForms<KullaniciBirimYetkileriEditForm>.ShowDialogEditForm();


            }

            Cursor.Current = DefaultCursor;

        }
        private void Tablo_DoubleClick(object sender, System.EventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;
            ShowEditForm(tablo.GetRowId());

        }
        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowEditForm(tablo.GetRowId());
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(sagMenu);
            
        }
        private void Tablo_RowCountChanged(object sender, System.EventArgs e)
        {
            ButonEnabledDurumu();
        }
        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Messages.HayirSeciliEvetHayir("Programdan Çıkmak İstiyor Musunuz?", "Çıkış Onay") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;

        }
        private void AnaForm_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            tablo.Focus();
            Cursor.Current = Cursors.Default;
        }

    }
}

