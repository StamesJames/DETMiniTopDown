using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

[System.Serializable]
public class CountContainerItem
{
    public string key;
    public int value;
}