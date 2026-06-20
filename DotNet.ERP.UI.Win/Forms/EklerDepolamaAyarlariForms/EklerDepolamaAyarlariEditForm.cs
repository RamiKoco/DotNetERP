using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.EklerDepolamaAyarlariForms
{
    public partial class EklerDepolamaAyarlariEditForm : BaseEditForm
    {
        public EklerDepolamaAyarlariEditForm()
        {
            InitializeComponent();
            
            DataLayoutControl = myDataLayoutControl;
            Bll = new EklerDepolamaAyarlariBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.EklerDepolamaAyarlari;
            EventsLoad();
            HideItems = new BarItem[] { btnYeni, btnSil, btnKaydet, btnGerial };
            this.FormClosing += EklerDepolamaAyarlariEditForm_FormClosing;
        }
        public override void Yukle()
        {
            OldEntity = ((EklerDepolamaAyarlariBll)Bll)
                .Single(x => x.Kod == "EKLER_DEPOLAMA");

            if (OldEntity == null)
            {
                BaseIslemTuru = IslemTuru.EntityInsert;
                OldEntity = new EklerDepolamaAyarlari();
                Id = BaseIslemTuru.IdOlustur(OldEntity);
            }
            else
            {
                BaseIslemTuru = IslemTuru.EntityUpdate;
                Id = OldEntity.Id;
            }

            NesneyiKontrollereBagla();
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new EklerDepolamaAyarlari
            {
                Id = Id,
                Kod = "EKLER_DEPOLAMA",
                KokDizin = txtDizin.Text?.Trim()
            };
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (EklerDepolamaAyarlari)OldEntity;
            txtDizin.EditValue = entity.KokDizin;
        }     
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;

            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtDizin)
                    sec.Sec(txtDizin, KartTuru.EklerDepolamaAyarlari);

        }
        protected override bool EntityInsert()
        {
            return ((EklerDepolamaAyarlariBll)Bll)
                .Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod);
        }
        protected override bool EntityUpdate()
        {
            return ((EklerDepolamaAyarlariBll)Bll)
                .Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod);
        }
        private void EklerDepolamaAyarlariEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDizin.Text))
                return;

            GuncelNesneOlustur();

            if (BaseIslemTuru == IslemTuru.EntityInsert)
                EntityInsert();
            else
                EntityUpdate();
        }
    }
}