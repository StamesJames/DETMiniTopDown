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

    public List<KeyValuePair<string, int>> ToList()
    {
        List<KeyValuePair<string, int>> templist = new List<KeyValuePair<string, int>>();
        foreach ( KeyValuePair<string,int> entry in container)
        {
            templist.Add(entry);
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

public class CountContainerItem
{
    string key;
    int value;
}