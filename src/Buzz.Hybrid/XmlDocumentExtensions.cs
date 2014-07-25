namespace Buzz.Hybrid
{
    using System;
    using System.Xml;

    public static class XmlExtensions
    {
        #region XmlElement Goodies

        /// <summary>
        /// Returns an XML Nodes value as a string or a default value if something went wrong, up to you 
        /// to work out what. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="node">XmlElement to get the value from</param>
        /// <param name="defaultString">Default value you want to be bounced back if anything goes wrong, default is an empty string</param>
        /// <returns></returns>
        public static string GetSafeValueAsString( this XmlElement node, string defaultString = "" )
        {
            return node != null && !String.IsNullOrEmpty( node.Value ) ? node.Value : defaultString;
        }

        /// <summary>
        /// Returns an XML Nodes value as an int or a default value if something went wrong, up to you 
        /// to work out what. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="element">XmlElement to get the value from</param>
        /// <param name="defaultNumber">Default value you want to be bounced back if anything goes wrong, default is zero</param>
        /// <returns></returns>
        public static int GetSafeValueAsInt( this XmlElement element, int defaultNumber = 0 )
        {
            int converted;
            return int.TryParse( element.GetSafeValueAsString( defaultNumber.ToString() ), out converted ) ? converted : defaultNumber;
        }

        /// <summary>
        /// Returns the value of an XML Nodes found using the provided xpath. Will return a default value if something went wrong, up to you 
        /// to work out what blew up though. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="node">The XmlNode you want to be the root of the query</param>
        /// <param name="xpath">The xpath to your target node</param>
        /// <param name="defaultString">The default value if anything goes wrong, currently empty string</param>
        /// <returns>The found value or the defaultValue</returns>
        public static string GetSafeValueAsStringByXPath(this XmlElement node, string xpath, string defaultString = "" )
        {
            // Guard
            if ( node == null ) return defaultString;

            var retValue = defaultString;

            var targetNode = node.SelectSingleNode( xpath );
            if ( targetNode != null )
            {
                retValue = ( (XmlElement) targetNode ).GetSafeValueAsString( defaultString );
            }

            return retValue;
        }

        /// <summary>
        /// Returns the int value of an XML Nodes found using the provided xpath. Will return a default value if something went wrong, up to you 
        /// to work out what blew up though. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="element">The XmlNode to query</param>
        /// <param name="xpath">The xpath to your target node</param>
        /// <param name="defaultNumber">The default value if anything goes wrong, currently zero</param>
        /// <returns>The int in the targetted node or the default you provided</returns>
        public static int GetSafeValueAsIntByXPath( this XmlElement element, string xpath, int defaultNumber = 0 )
        {
            int converted;
            return int.TryParse( element.GetSafeValueAsStringByXPath( xpath ), out converted ) ? converted : defaultNumber;
        }

        #endregion

        #region XmlNode Goodies

        /// <summary>
        /// Returns an XML Nodes value as a string or a default value if something went wrong, up to you 
        /// to work out what. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="node">XmlNode to get the value from</param>
        /// <param name="defaultString">Default value you want to be bounced back if anything goes wrong, default is an empty string</param>
        /// <returns></returns>
        public static string GetSafeValueAsString( this XmlNode node, string defaultString = "" )
        {
            return node != null ? ( (XmlElement) node ).GetSafeValueAsString( defaultString ) : defaultString;
        }
        
        /// <summary>
        /// Returns an XML Nodes value as an int or a default value if something went wrong, up to you 
        /// to work out what. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="node">XmlNode to get the value from</param>
        /// <param name="defaultNumber">Default value you want to be bounced back if anything goes wrong, default is zero</param>
        /// <returns></returns>
        public static int GetSafeValueAsInt( this XmlNode node, int defaultNumber = 0 )
        {
            return node != null ? ( (XmlElement) node ).GetSafeValueAsInt( defaultNumber ) : defaultNumber;
        }
        
        /// <summary>
        /// Returns the value of an XML Nodes found using the provided xpath. Will return a default value if something went wrong, up to you 
        /// to work out what blew up though. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="node">The XmlNode you want to be the root of the query</param>
        /// <param name="xpath">The xpath to your target node</param>
        /// <param name="defaultString">The default value if anything goes wrong, currently empty string</param>
        /// <returns>The found value or the defaultValue</returns>
        public static string GetSafeValueAsStringByXPath( this XmlNode node, string xpath, string defaultString = "" )
        {
            return node != null ? ((XmlElement) node).GetSafeValueAsStringByXPath(xpath, defaultString) : defaultString;
        }

        /// <summary>
        /// Returns the int value of an XML Nodes found using the provided xpath. Will return a default value if something went wrong, up to you 
        /// to work out what blew up though. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="node">The XmlNode to query</param>
        /// <param name="xpath">The xpath to your target node</param>
        /// <param name="defaultNumber">The default value if anything goes wrong, currently zero</param>
        /// <returns>The int in the targetted node or the default number you provided</returns>
        public static int GetValueAsIntByXPath( this XmlNode node, string xpath, int defaultNumber = 0 )
        {
            return node != null ? ( (XmlElement) node ).GetValueAsIntByXPath( xpath, defaultNumber ) : defaultNumber;
        }

        #endregion

        #region XmlDocument Goodies

        /// <summary>
        /// Returns the string value of an XML Nodes found using the provided xpath. Will return a default value if something went wrong, up to you 
        /// to work out what blew up though. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="doc">The XmlDocument to query</param>
        /// <param name="xpath">The xpath to your target node</param>
        /// <param name="defaultString">The default value if anything goes wrong, currently empty string</param>
        /// <returns></returns>
        public static string GetSafeValueAsStringByXPath( this XmlDocument doc, string xpath, string defaultString = "" )
        {
            return doc != null ? doc.DocumentElement.GetSafeValueAsStringByXPath( xpath, defaultString ) : defaultString;
        }

        /// <summary>
        /// Returns the int value of an XML Nodes found using the provided xpath. Will return a default value if something went wrong, up to you 
        /// to work out what blew up though. Good for grabbing data from a response that *should* be there quickly
        /// </summary>
        /// <param name="doc">The XmlDocument to query</param>
        /// <param name="xpath">The xpath to your target node</param>
        /// <param name="defaultNumber">The default value if anything goes wrong, currently zero</param>
        /// <returns>The int in the targetted node or the default number you provided</returns>
        public static int GetValueAsIntByXPath( this XmlDocument doc, string xpath, int defaultNumber = 0 )
        {
            return doc != null && doc.DocumentElement != null ? doc.DocumentElement.GetSafeValueAsIntByXPath( xpath, defaultNumber ) :  defaultNumber;
        }

        #endregion
    }
}
