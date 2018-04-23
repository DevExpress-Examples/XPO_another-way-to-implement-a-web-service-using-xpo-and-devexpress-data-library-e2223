using System;
using System.Collections.Generic;
using System.Text;
using DXServiceHelper.DXService;
using System.Data;
using System.IO;

namespace DXSample.Helper {
    public class ServiceHelper {
        private DXSampleWebService source;

        public ServiceHelper () { source = new DXSampleWebService(); }

        public DataTable GetView (string className, ViewProperty[] properties, string filter) {
            DataSet result = new DataSet();
            string data = source.GetDataView(className, properties, filter);
            result.ReadXml(new StringReader(data), XmlReadMode.ReadSchema);
            return result.Tables[0];
        }
    }
}
