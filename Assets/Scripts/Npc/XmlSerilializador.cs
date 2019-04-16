using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public static class XmlSerilializador {

    public static void Serializar<T>(string path, T objeto)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, objeto);
        writer.Close(); 
    }

    public static T Deserializar<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        T objeto =(T)serializer.Deserialize(reader.BaseStream);
        reader.Close();

        return objeto;
    }
}
