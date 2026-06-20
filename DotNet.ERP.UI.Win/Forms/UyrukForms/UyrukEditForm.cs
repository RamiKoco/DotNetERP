using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;
namespace DotNet.ERP.UI.Win.Forms.UyrukForms
{
    public partial class UyrukEditForm : BaseEditForm
    {
        public UyrukEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.UyrukBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Uyruk;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Dto.UyrukS() : ((Bll.General.UyrukBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.Uyruk>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.UyrukBll)Bll).YeniKodVer();
            txtUyrukAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Dto.UyrukS)OldEntity;
            txtKod.Text = entity.Kod;
            txtUyrukAdi.Text = entity.Ad;
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.Uyruk
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtUyrukAdi.Text,
                UlkeId = txtUlke.Id,
                Aciklama = txtAciklama.Text,
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
                if (sender == txtUlke)
                    sec.Sec(txtUlke, KartTuru.Uyruk);

        }
    }
}