using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.Metadata.Helpers;
using System.Data;
using System.Collections;
using System.ComponentModel;

namespace DXSample.Service.Model {
    public class PersistentObjectToXmlConverter {
        private List<IXPSimpleObject> cache = new List<IXPSimpleObject>();
        private DataSet dataSet;

        public string ConvertViewToXml (XPView view) {
            dataSet = new DataSet();
            DataTable table = dataSet.Tables.Add(view.ObjectClassInfo.TableName);
            foreach (PropertyDescriptor prop in ((ITypedList)view).GetItemProperties(null))
                table.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
            for (int i = 0; i < view.Count; i++) {
                ArrayList data = new ArrayList();
                foreach (DataColumn col in table.Columns)
                    data.Add(view[i][col.ColumnName]);
                table.Rows.Add(data.ToArray());
            }
            return GetXml();
        }

        private string GetXml () {
            using (Stream stream = new MemoryStream()) {
                try {
                    dataSet.WriteXml(stream, XmlWriteMode.WriteSchema);
                    stream.Seek(0, SeekOrigin.Begin);
                    string result = new StreamReader(stream).ReadToEnd();
                    return result;
                } finally {
                    dataSet.Dispose();
                    dataSet = null;
                    cache.Clear();
                }
            }
        }
    }
}