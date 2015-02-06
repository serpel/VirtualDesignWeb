using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using VirtualDesign.Models;

namespace VirtualDesign.Controllers
{
    public class ModelsController : ApiController
    {
        private VirtualContext db = new VirtualContext();

        /*public IQueryable<Model> GetModels()
        {
            return db.Models;
        }*/

        /*public String GetModels()
        {
            return JsonConvert.SerializeObject(db.Models, Formatting.Indented);;
        }*/

        public HttpResponseMessage GetAll()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            try
            {
                //new { Name = model.Name, ImageUrl = model.PictureFile, ModelUrl = model.ModelFile }
                var arrayList = from model in db.Models
                                select new
                                {
                                    Name = model.Name,
                                    Category = model.Category.Name,
                                    Tags = model.Tags,
                                    ImageUrl = model.PictureFile,
                                    ModelUrl = model.ModelFile
                                };

                String json = JsonConvert.SerializeObject(arrayList, Formatting.Indented);

                JArray jarray = new JArray();
                jarray.Add(JToken.Parse(json).ToList());

                JObject obj = new JObject();
                obj["models"] = jarray;

                response.Content = new StringContent(obj.ToString(), Encoding.UTF8, "text/plain");
            }
            catch (Exception e)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            return response;
        }

        // GET /api/Models
        public HttpResponseMessage GetModelsTemp()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            try
            {
                String json = JsonConvert.SerializeObject(db.Models, Formatting.Indented);
                response.Content = new StringContent(json, Encoding.UTF8, "text/plain");
            }catch(Exception e)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            return response;
        }

        // GET /api/Models/5
        public HttpResponseMessage GetModels(int id)
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            try
            {
                Model model = db.Models.Find(id);

                if (model == null)
                    return this.Request.CreateResponse(HttpStatusCode.NotFound);

                String json = JsonConvert.SerializeObject(model, Formatting.Indented);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                
            }
            catch (Exception e)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            return response;
        }

        /*
        // GET api/ModelApi/5
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> GetModel(int id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
         * */
        

        // DELETE api/ModelApi/5
        //[ResponseType(typeof(Model))]
        public HttpResponseMessage DeleteModel(int id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Models.Remove(model);
            db.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Models.Count(e => e.ModelId == id) > 0;
        }
    }
}