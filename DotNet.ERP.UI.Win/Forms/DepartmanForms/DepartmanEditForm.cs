using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.DepartmanForms
{
    public partial class DepartmanEditForm : BaseEditForm
    {
        public DepartmanEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new Bll.General.DepartmanBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Departman;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Model.Entities.Departman() : ((Bll.General.DepartmanBll)Bll).Single(Functions.FilterFunctions.Filter<Model.Entities.Departman>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((Bll.General.DepartmanBll)Bll).YeniKodVer();
            txtDepartmanAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Model.Entities.Departman)OldEntity;

            txtKod.Text = entity.Kod;
            txtDepartmanAdi.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Model.Entities.Departman
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtDepartmanAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}