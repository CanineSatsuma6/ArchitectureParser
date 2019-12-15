using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ArchitectureParser.DiagramUtils
{
    public static class DiagramDecoder
    {
        public static byte[] Base64Decode(string toDecode)
        {
            return Convert.FromBase64String(toDecode);
        }

        public static string Inflate(byte[] bytesToDecompress)
        {
            using (MemoryStream inputStream = new MemoryStream(bytesToDecompress))
            {
                using (DeflateStream decompressStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(decompressStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public static string URLDecode(string toDecode)
        {
            return Uri.UnescapeDataString(toDecode);
        }

        public static XElement ToXElement(this string toElement)
        {
            return XElement.Parse(toElement);
        }

        public static XDocument DecodeArchitecture(XDocument encodedArchitecture)
        {
            var pages = new Dictionary<string, IEnumerable<XElement>>();

            foreach (var xElement in encodedArchitecture.Descendants("diagram"))
            {
                pages.Add(xElement.Attribute("name").Value, URLDecode(Inflate(Base64Decode(xElement.Value))).ToXElement().Elements());
            }

            var newDocument = new XDocument(new XElement("architecture", pages.Values));
            var roots       = newDocument.Descendants("root").ToList();

            for (int i = 0; i < roots.Count; i++)
            {
                roots[i].Name = pages.ElementAt(i).Key;
            }

            return newDocument;
        }
    }
}
