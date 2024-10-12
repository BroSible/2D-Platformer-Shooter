using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class Vector3SerialisationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var v3 = (Vector3) obj;
        info.AddValue(name:"x", v3.x);
        info.AddValue(name:"y", v3.y);
        info.AddValue(name:"z", v3.z);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector select)
    {
        var v3 = (Vector3) obj;
        v3.x = (float)info.GetValue(name:"x", typeof(float));
        v3.y = (float)info.GetValue(name:"y", typeof(float));
        v3.z = (float)info.GetValue(name:"z", typeof(float));
        obj = v3;
        return obj;
    }
   
}
