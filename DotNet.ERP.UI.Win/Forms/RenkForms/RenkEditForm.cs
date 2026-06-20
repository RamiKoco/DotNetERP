using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using System.Drawing;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.RenkForms
{
    public partial class RenkEditForm : BaseEditForm
    {
        public RenkEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.RenkBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Renk;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.RenkS() : ((Bll.General.RenkBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.Renk>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.RenkBll)Bll).YeniKodVer();
            txtRenkAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Dto.RenkS)OldEntity;

            txtKod.Text = entity.Kod;
            txtRenkAdi.Text = entity.RenkAdi;
            txtRGB.Text = entity.RGB;
            txtForeColor.Color = Color.FromArgb(entity.ForeColor);
            //txtRenkAdi.ForeColor = Color.FromArgb(entity.ForeColor); // <- BURASI!
            txtAciklama.Text = entity.Aciklama;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.Renk
            {
                Id = Id,
                Kod = txtKod.Text,
                RenkAdi = txtRenkAdi.Text,
                RGB = txtForeColor.Text,
                ForeColor = txtForeColor.Color.ToArgb(),
                Aciklama = txtAciklama.Text,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())

                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Renk);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Renk);

        }
    }
}