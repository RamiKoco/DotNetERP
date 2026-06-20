using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.OzelKodForms
{
    public partial class OzelKodEditForm : BaseEditForm
    {
        #region Variables
        private readonly OzelKodTuru _ozelKodTuru;
        private readonly KartTuru _ozelKodKartTuru;

        #endregion
        public OzelKodEditForm(params object[] prm)
        {
            InitializeComponent();

            _ozelKodTuru = (OzelKodTuru)prm[0];
            _ozelKodKartTuru = (KartTuru)prm[1];

            DataLayoutControl = myDataLayoutControl;
            Bll = new OzelKodBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.OzelKod;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new OzelKod() : ((OzelKodBll)Bll).Single(Functions.FilterFunctions.Filter<OzelKod>(Id));
            NesneyiKontrollereBagla();
            

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((OzelKodBll)Bll).YeniKodVer(x => x.KodTuru == _ozelKodTuru && x.KartTuru == _ozelKodKartTuru);
            txtOzelKodAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (OzelKod)OldEntity;

            txtKod.Text = entity.Kod;
            txtOzelKodAdi.Text = entity.OzelKodAdi;
            txtAciklama.Text = entity.Aciklama;
            
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new OzelKod
            {
                Id = Id,
                Kod = txtKod.Text,
                OzelKodAdi = txtOzelKodAdi.Text,
                KodTuru = _ozelKodTuru,
                KartTuru = _ozelKodKartTuru,
                Aciklama = txtAciklama.Text
               
            };

            ButonEnabledDurumu();

        }

        protected override bool EntityInsert()
        {
            return ((OzelKodBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KodTuru == _ozelKodTuru && x.KartTuru == _ozelKodKartTuru);
        }

        protected override bool EntityUpdate()
        {
            return ((OzelKodBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.KodTuru == _ozelKodTuru && x.KartTuru == _ozelKodKartTuru);
        }

    }
}