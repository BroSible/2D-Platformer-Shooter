using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class QuartenionSerialisationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var q = (Quaternion) obj;
        info.AddValue(name:"x", q.x);
        info.AddValue(name:"y", q.y);
        info.AddValue(name:"z", q.z);
        info.AddValue(name:"w", q.w);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector select)
    {
        var q = (Quaternion) obj;
        q.x = (float)info.GetValue(name:"x", typeof(float));
        q.y = (float)info.GetValue(name:"y", typeof(float));
        q.z = (float)info.GetValue(name:"z", typeof(float));
        q.w = (float)info.GetValue(name:"w", typeof(float));
        obj = q;
        return obj;
    }
   
}
