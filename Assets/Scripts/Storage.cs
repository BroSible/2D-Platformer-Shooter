using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

[Serializable]
public class Storage 
{
    public static string filePath;
    private BinaryFormatter formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        filePath = directory + "/GameSave.save";
        InitBinaryFormatter();
    }

    private void InitBinaryFormatter()
    {
        formatter = new BinaryFormatter();
        var selector = new SurrogateSelector();

        var v3Surrogate = new Vector3SerialisationSurrogate();
        var qSurrogate = new QuartenionSerialisationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(state:StreamingContextStates.All),v3Surrogate);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(state:StreamingContextStates.All),qSurrogate);

        formatter.SurrogateSelector = selector;
    }

    public object Load(object saveDataByDefault)
    {
        if(!File.Exists(filePath))
        {
            if(saveDataByDefault !=null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }
        var file = File.Open(filePath, FileMode.Open);
        var savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(filePath);
        formatter.Serialize(file,saveData);
        file.Close();
    }

}
