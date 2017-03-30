using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

//[XmlRoot("LanguagesCollection")]
public class Languages
{ 

    [XmlElement("TouchPad")]
    public string touchPad;

    [XmlElement("TriggerButton")]
    public string triggerButton;

    [XmlElement("GripButton")]
    public string gripButton;

    [XmlElement("CurrentLanguage")]
    public string currentLanguage;

}
