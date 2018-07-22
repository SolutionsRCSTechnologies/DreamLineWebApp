using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Serializable<T>
    {
        public string Serialize()
        {
            string retStr = string.Empty;
            var obj = this;
            if (obj != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringWriter writter = new StringWriter())
                {
                    serializer.Serialize(writter, obj);
                    retStr = writter.ToString();
                }
            }
            return retStr;
        }

        public T Parse(string str)
        {
            T obj = default(T);
            if (!string.IsNullOrEmpty(str))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(str))
                {
                    obj = (T)serializer.Deserialize(reader);
                }
            }
            return obj;
        }
    }
}
