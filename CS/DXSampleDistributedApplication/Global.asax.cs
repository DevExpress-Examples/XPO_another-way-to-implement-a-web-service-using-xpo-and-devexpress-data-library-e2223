using System;
using System.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DXSample.Service.Model;

namespace DXSample.Service {
    public class Global :HttpApplication {

        protected void Application_Start (object sender, EventArgs e) {
            string conn = AccessConnectionProvider.GetConnectionString(Server.MapPath(@"~\App_Data\nwind.mdb"));
            XPDictionary dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(typeof(Category));
            XpoDefault.Session = null;
            IDataStore prov = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = new ThreadSafeDataLayer(dict, prov);
        }

        protected void Session_Start (object sender, EventArgs e) {

        }

        protected void Application_BeginRequest (object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest (object sender, EventArgs e) {

        }

        protected void Application_Error (object sender, EventArgs e) {

        }

        protected void Session_End (object sender, EventArgs e) {

        }

        protected void Application_End (object sender, EventArgs e) {

        }
    }
}