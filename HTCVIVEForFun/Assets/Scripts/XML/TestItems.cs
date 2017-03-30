using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

//[XmlRoot("AllDialogues")]
public class TestItems
{
    [XmlArray("Texten"), XmlArrayItem("Text")]
    public List<string> texten = new List<string>();

    [XmlAttribute("ID")]
    public int id;

    [XmlElement("NpcName")]
    public string npcName;

    [XmlElement("Npc")]
    public string npc;

    [XmlElement("FindKey")]
    public string findKey;

    [XmlElement("FoundKey")]
    public string foundKey;


}





