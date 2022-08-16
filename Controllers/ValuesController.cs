using Application_Programming_Interface.DB_Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application_Programming_Interface.Controllers
{
    public class ValuesController : ApiController
    {
       [Route("Post/CreateAPI")]
        [HttpPost]
        public HttpResponseMessage CreateAPI(SaftyEngineer tblobj)
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            if (tblobj.SEID == 0)
            {
                dbobj.SaftyEngineer.Add(tblobj);
                dbobj.SaveChanges();
            }
            else
            {
                dbobj.Entry(tblobj).State = System.Data.Entity.EntityState.Modified;
                dbobj.SaveChanges();
            }
            
            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);

            return hrm;
        }

        [Route("Get/ReadAPI")]
        [HttpGet]
        public List<SaftyEngineer> ReadAPI()
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            var tblData = dbobj.SaftyEngineer.ToList();

            return tblData;
        }

        [Route("Get/Update")]
        [HttpGet]
        public SaftyEngineer UpdateAPI(int SEID)
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            var Data = dbobj.SaftyEngineer.Where(m => m.SEID == SEID).FirstOrDefault();

            return Data;
        }

        [Route("Get/DeleteAPI")]
        [HttpGet]
        public HttpResponseMessage DeleteAPI(int SEID)
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            var DeleteData = dbobj.SaftyEngineer.Where(m => m.SEID == SEID).FirstOrDefault();

            dbobj.SaftyEngineer.Remove(DeleteData);
            dbobj.SaveChanges();

            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);
            return hrm;
        }
    }
}
