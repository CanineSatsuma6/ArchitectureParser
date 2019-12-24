using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArchitectureParser.DiagramUtils
{
    public static class DiagramParser
    {
        private static string Style(this XElement element, string desiredStyle)
        {
            var foundStyle = null as string;

            if (element.Attribute("style")?.Value == null)
            {
                return foundStyle;
            }

            var styles = element.Attribute("style").Value.Split(';');

            foreach (var style in styles)
            {
                var styleParts = style.Split('=');
                var styleName  = styleParts[0];
                var styleValue = styleParts[1];

                if (string.Equals(desiredStyle, styleName))
                {
                    foundStyle = styleValue;
                    break;
                }
            }

            return foundStyle;
        }

        private static void ParseTypes(XElement typesPage)
        {
            var tableElements = from element in typesPage.Descendants("mxCell")
                                where element.Descendants("mxGeometry").Count() > 0
                                select XElement.Parse(element.Attribute("value").Value);

            foreach (var tableElement in tableElements)
            {
                
            }
        }
    }
}
