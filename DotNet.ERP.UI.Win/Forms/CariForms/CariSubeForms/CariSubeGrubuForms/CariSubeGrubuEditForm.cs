using DotNet.ERP.Bll.General.CarilerBll.CariSubeBll;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto.CariDto.CariSubeDto;
using DotNet.ERP.Model.Entities.CariEntity.CariSube;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms
{
    public partial class CariSubeGrubuEditForm : BaseEditForm
    {       
        public CariSubeGrubuEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new CariSubeGrubuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.CariSubeGrubu;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CariSubeGrubuS() : ((CariSubeGrubuBll)Bll).Single(Functions.FilterFunctions.Filter<CariSubeGrubu>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CariSubeGrubuBll)Bll).YeniKodVer();
            txtCariSubeGrubuAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CariSubeGrubuS)OldEntity;

            txtKod.Text = entity.Kod;
            txtCariSubeGrubuAdi.Text = entity.Ad;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new CariSubeGrubu
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtCariSubeGrubuAdi.Text,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.CariSubeGrubu);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.CariSubeGrubu);
        }
    }
}