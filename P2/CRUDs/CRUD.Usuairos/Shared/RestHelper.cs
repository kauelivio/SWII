using CRUD.Usuairos.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Usuairos.Shared
{
    public static class RestHelper
    {
        private static readonly string baseUrl = "https://localhost:44346/";
        private static readonly string nameUrl = "usuarios";

        public static async Task<string> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl + nameUrl))
                {
                    using (HttpContent content = res.Content)
                    {
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

        public static async Task<string> Get(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl + nameUrl + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
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

        public static async Task<string> Post(string nome, string senha, bool status)
        {
            Usuario user = new Usuario();
            user.Nome = nome;
            user.Senha = senha;
            user.Status = status;
            
            using (HttpClient client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(user);
                var userRes = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PostAsync(baseUrl + nameUrl, userRes))
                {
                    using (HttpContent content = res.Content)
                    {
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

        public static async Task<string> PUT(string id, string nome, string senha, bool status)
        {
            Usuario user = new Usuario();
            user.Id = Convert.ToInt32(id);
            user.Nome = nome;
            user.Senha = senha;
            user.Status = status;

            using (HttpClient client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(user);
                var userRes = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PutAsync(baseUrl + nameUrl + "/" + id, userRes))
                {
                    using (HttpContent content = res.Content)
                    {
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


        public static string BeautifyJson(string jsonStr)
        {
            JToken parseJson = JToken.Parse(jsonStr);
            return parseJson.ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
