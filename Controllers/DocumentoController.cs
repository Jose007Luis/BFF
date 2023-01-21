using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using grendraJL.Models;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace grendraJL.Controllers
{
    public class DocumentoController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "http://localhost:8080/";

        public IActionResult index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> allDocumento()
        {
            List<DocumentoBean> listDoc = new List<DocumentoBean>();
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
             
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
                HttpResponseMessage Res = await client.GetAsync("api/allOrdenesDocumentos");
              
                if (Res.IsSuccessStatusCode)
                {
                    
                    var Docs = Res.Content.ReadAsStringAsync().Result;
                    
                    listDoc = JsonConvert.DeserializeObject<List<DocumentoBean>>(Docs);
                }
                //returning the employee list to view
                return View(listDoc);
            }
        }

        [HttpGet]
        public async Task<ActionResult> obtieneDocumentoPorId(int IdDocumento)
        {
            List<DocumentoBean> listDoc = new List<DocumentoBean>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/obtieneDocumentoPorId/" + IdDocumento);

                if (Res.IsSuccessStatusCode)
                {

                    var Docs = Res.Content.ReadAsStringAsync().Result;

                    listDoc = JsonConvert.DeserializeObject<List<DocumentoBean>>(Docs);
                }
                //returning the employee list to view
                return View(listDoc);
            }     
        }

        public IActionResult saveDocumento()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> saveDocumentos(DocumentoBean doc)
        {

            DocumentoBean listDoc = new DocumentoBean();
            try
            {
                Uri url = new Uri("http://localhost:8080/");

                HttpClient httpClient = new HttpClient();

                httpClient = new HttpClient
                {
                    BaseAddress = url
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var serializedRequest = Newtonsoft.Json.JsonConvert.SerializeObject(doc);

                //Se cambio Encoding.Unicode  a -------> Encoding.UTF8 para que jalara
                var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

                string content = string.Empty;

                HttpResponseMessage responseMessage;
                try
                {
                    responseMessage = httpClient.PostAsync("api/guardarDocumento", requestContent).Result;
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        var returnMessage = responseMessage.Content.ToString();
                    }
                    else
                    {
                        content = responseMessage.Content.ReadAsStringAsync().Result;

                    }
                }
                catch (HttpRequestException ex)
                {

                }
                catch (System.Exception ex)
                {

                }
                finally
                {
                    httpClient.Dispose();
                }
                
                listDoc = JsonConvert.DeserializeObject<DocumentoBean>(content);

                return RedirectToAction("allDocumento");
            }
            catch (System.Exception ex)
            {

            }
           
            return View(listDoc);
 
        }

        public async Task<ActionResult> Edita(int IdOrdenDocumento)
        {
            List<DocumentoBean> listDoc = new List<DocumentoBean>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/allOrdenesDocumentos");

                if (Res.IsSuccessStatusCode)
                {

                    var Docs = Res.Content.ReadAsStringAsync().Result;

                    listDoc = JsonConvert.DeserializeObject<List<DocumentoBean>>(Docs);
                }

                DocumentoBean datosVista = new DocumentoBean();
                foreach (var item in listDoc)
                {
                    if (item.idOrdenDocumento == IdOrdenDocumento)
                    {
                        datosVista = new DocumentoBean();
                        datosVista = item;
                        break;
                    }

                }

                //returning the employee list to view
                return View(datosVista);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Editar(DocumentoBean doc)
        {

            DocumentoBean listDoc = new DocumentoBean();
            try
            {
                Uri url = new Uri("http://localhost:8080/");

                HttpClient httpClient = new HttpClient();

                httpClient = new HttpClient
                {
                    BaseAddress = url
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var serializedRequest = Newtonsoft.Json.JsonConvert.SerializeObject(doc);

                //Se cambio Encoding.Unicode  a -------> Encoding.UTF8 para que jalara
                var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

                string content = string.Empty;

                HttpResponseMessage responseMessage;
                try
                {
                    responseMessage = httpClient.PostAsync("api/guardarDocumento", requestContent).Result;
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        var returnMessage = responseMessage.Content.ToString();
                    }
                    else
                    {
                        content = responseMessage.Content.ReadAsStringAsync().Result;

                    }
                }
                catch (HttpRequestException ex)
                {

                }
                catch (System.Exception ex)
                {

                }
                finally
                {
                    httpClient.Dispose();
                }

                listDoc = JsonConvert.DeserializeObject<DocumentoBean>(content);

                return RedirectToAction("allDocumento");
            }
            catch (System.Exception ex)
            {

            }

            return View(listDoc);

        }

        public async Task<ActionResult> Elimina(int IdOrdenDocumento)
        {
            List<DocumentoBean> listDoc = new List<DocumentoBean>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/allOrdenesDocumentos");

                if (Res.IsSuccessStatusCode)
                {

                    var Docs = Res.Content.ReadAsStringAsync().Result;

                    listDoc = JsonConvert.DeserializeObject<List<DocumentoBean>>(Docs);
                }

                DocumentoBean datosVista = new DocumentoBean();
                foreach (var item in listDoc)
                {
                    if (item.idOrdenDocumento == IdOrdenDocumento)
                    {
                        datosVista = new DocumentoBean();
                        datosVista = item;
                        break;
                    }

                }

                //returning the employee list to view
                return View(datosVista);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Eliminar(int IdOrdenDocumento)
        {
            String listDoc = "";
            try
            {
                Uri url = new Uri("http://localhost:8080/");

                HttpClient httpClient = new HttpClient();

                httpClient = new HttpClient
                {
                    BaseAddress = url
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var serializedRequest = JsonConvert.SerializeObject(IdOrdenDocumento);

                //Se cambio Encoding.Unicode  a -------> Encoding.UTF8 para que jalara
                var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

                string content = string.Empty;

                HttpResponseMessage responseMessage;
                try
                {
                    responseMessage = httpClient.PostAsync("api/eliminarDocumentoPorId/" + IdOrdenDocumento, requestContent).Result;
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        var returnMessage = responseMessage.Content.ToString();
                    }
                    else
                    {
                        content = responseMessage.Content.ReadAsStringAsync().Result;

                    }
                }
                catch (HttpRequestException ex)
                {

                }
                catch (System.Exception ex)
                {

                }
                finally
                {
                    httpClient.Dispose();
                }

                //listDoc = JsonConvert.DeserializeObject<String>(content);

                return RedirectToAction("allDocumento");
            }
            catch (System.Exception ex)
            {

            }
            return View(listDoc);
        }
    }
}
