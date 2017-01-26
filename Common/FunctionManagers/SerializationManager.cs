using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TowerDefend.Engine;

namespace TowerDefend.FunctionManagers
{
	public class SerializationManager
	{
		public static Map Deserialize(string xml)
		{
			XmlSerializer s = new XmlSerializer(typeof(Map));
			StringReader sr = new StringReader(xml);
			XmlReader reader = XmlReader.Create(sr);
			return (Map)(s.Deserialize(reader));
		}

		public static string Serialize(Map metadata)
		{
			string result = string.Empty;
			XmlSerializer s = new XmlSerializer(typeof(Map));
			using (StringWriter sw = new StringWriter())
			using (XmlWriter writer = XmlWriter.Create(sw))
			{
				s.Serialize(writer, metadata);
				result = sw.ToString();
			}
			return result;
		}
	}
}
