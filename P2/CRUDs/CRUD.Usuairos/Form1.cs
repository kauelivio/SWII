using CRUD.Usuairos.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Usuairos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetAll_ClickAsync(object sender, EventArgs e)
        {
            var response = await RestHelper.GetAll();
            tbAll.Text = RestHelper.BeautifyJson(response);
        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            var response = await RestHelper.Post(tbNome.Text,tbSenha.Text,cbStatus.Checked);
            tbAll.Text = RestHelper.BeautifyJson(response);
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            var response = await RestHelper.Get(tbId.Text);
            tbAll.Text = RestHelper.BeautifyJson(response);
        }

        private async void btnPut_Click(object sender, EventArgs e)
        {
            var response = await RestHelper.PUT(tbId.Text, tbNome.Text, tbSenha.Text, cbStatus.Checked);
            tbAll.Text = response;
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            var response = await Delete(tbId.Text);
        }

        private async Task<string> Delete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://localhost:44346/usuarios/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show(res.StatusCode.ToString());
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
