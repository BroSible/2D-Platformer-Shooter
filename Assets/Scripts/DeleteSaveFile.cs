using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class DeleteSaveFile : MonoBehaviour
{
    public static bool filedeleted = false;
    public void DeleteFile()
    {
        if (File.Exists(Storage.filePath))
        {
            File.Delete(Storage.filePath);
            Debug.Log("Файл сохранения удален.");
            filedeleted = true;
        }
        else
        {
            Debug.Log("Файл сохранения не существует.");
        }
    }
}
