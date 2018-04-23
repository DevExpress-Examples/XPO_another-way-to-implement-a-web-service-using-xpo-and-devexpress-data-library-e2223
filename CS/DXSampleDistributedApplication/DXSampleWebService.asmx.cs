using System.Web.Services;
using System.ComponentModel;
using DevExpress.Xpo;
using DXSample.Service.Model;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;

namespace DXSample.Service {
    [WebService(Namespace = "http://www.devexpress.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DXSampleWebService :WebService {
        [WebMethod]
        public string GetDataView (string className, ViewProperty[] properties, string filter) {
            using (Session session = new Session()) {
                XPClassInfo classInfo = session.GetClassInfo(typeof(Category).Assembly.FullName, 
                    string.Concat(typeof(Category).Namespace, ".", className));
                XPView result = new XPView(session, classInfo, new CriteriaOperatorCollection(), 
                    CriteriaOperator.Parse(filter));
                result.Properties.AddRange(properties);
                return new PersistentObjectToXmlConverter().ConvertViewToXml(result);
            }
        }
    }
}