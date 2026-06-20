using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.Show;

namespace DotNet.ERP.UI.Win.Forms.RaporForms
{
    public partial class RaporListForm : BaseListForm
    {
        #region Variables
        private readonly KartTuru _raporTuru;
        private readonly RaporBolumTuru _raporBolumTuru;
        private readonly byte[] _dosya;
        #endregion
        public RaporListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new RaporBll();


            _raporTuru = (KartTuru)prm[0];
            _raporBolumTuru = (RaporBolumTuru)prm[1];
            _dosya = (byte[])prm[2];
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Rapor;
            FormShow = new ShowEditForms<RaporEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((RaporBll)Bll).List(x=> x.Durum == AktifKartlariGoster && x.RaporTuru == _raporTuru );
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<RaporEditForm>.ShowDialogEditForm(KartTuru.Rapor, id, _raporTuru, _raporBolumTuru,_dosya);
            ShowEditFormDefault(result);

        }
    }
}