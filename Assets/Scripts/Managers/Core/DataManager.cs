using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();

    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Datas/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}   
    private T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0) name = name.Substring(0, index);
            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null) return go as T;
        }

        return Resources.Load<T>(path);
    }

    public T LoadData<T>(string path) where T : Object
    {
        T loadedObject = Load<T>($"Datas/{path}");

        if (typeof(T) == typeof(GameObject))
        {
            GameObject original = loadedObject as GameObject;

            if (original == null)
            {
                Debug.Log($"Failed to load prefab : {path}");
            }
        }

        return loadedObject;
    }
}
