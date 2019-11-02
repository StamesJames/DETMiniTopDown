using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class CountContainer
{
    public Dictionary<string, int> container = new Dictionary<string, int>();

    public int getInt(string name)
    {
        int returnValue = 0;
        if (container.TryGetValue(name, out returnValue))
        {
            return returnValue;
        }else
	    {
            return 0;
        }    
    }

    public CountContainer()
    {

    }

    public CountContainer(string path)
    {
        if (File.Exists(path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CountContainerItem>));
            FileStream stream = new FileStream(path, FileMode.Open);
            List<CountContainerItem> tempList = serializer.Deserialize(stream) as List<CountContainerItem>;
            foreach (CountContainerItem item in tempList)
            {
                container[item.key] = item.value;
            }
            stream.Close();
        }
        else
        {

        }
    }

    public CountContainer(List<CountContainerItem> items)
    {
        foreach (CountContainerItem item in items)
        {
            container[item.key] = item.value;
        }
    }

    public List<CountContainerItem> ToList()
    {
        List<CountContainerItem> templist = new List<CountContainerItem>();
        foreach ( KeyValuePair<string,int> entry in container)
        {
            templist.Add(new CountContainerItem() { key = entry.Key, value = entry.Value });
        }
        return templist;
    }

    public void increaseValue(string name, int value)
    {
        if (container.ContainsKey(name))
        {
            container[name] += value;
        }
        else
        {
            container[name] = value;
        }
    }

    public void increaseValue(string name)
    {
        if (container.ContainsKey(name))
        {
            container[name] += 1;
        }
        else
        {
            container[name] = 1;
        }
    }

    public void Serialize(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<CountContainerItem>));
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        FileStream stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this.ToList());
        stream.Close();
    }

}

[System.Serializable]
public class CountContainerItem
{
    public string key;
    public int value;
}