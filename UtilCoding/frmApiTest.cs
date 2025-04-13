using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UtilCoding.ApiTestHelper;

namespace UtilCoding
{
    public partial class frmApiTest : Form
    {
        public frmApiTest()
        {
            InitializeComponent();
        }

        private async Task<Reply> GetAsync() 
        {
            Reply oReply = new Reply();
            oReply = await ApiTestHelper.Execute<Reply>(txtUrl.Text, methodHttp.GET, oReply);
            return oReply;
        }

        private async void Get() 
        {
            Reply oReply = new Reply();
            oReply = await GetAsync();
            txtVisor.Text = ApiTestHelper.BeautifyJson(oReply.Data.ToString());
            lblStatus.Text = oReply.StatusCode;
        }


        private void btnGet_Click(object sender, EventArgs e)
        {
            Get();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {

        }
    }
}
