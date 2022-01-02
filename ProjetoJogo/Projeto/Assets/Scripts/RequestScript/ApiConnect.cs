using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[SerializeField]
public static class ApiConnect
{
    static string apiURL = "http://127.0.0.1:8080"; //"http://mai.paxsoft.com.br:8080"; //"http://127.0.0.1:8080";

    public static IEnumerator SendDataNoAuth(string endpoin, modelRequest data, System.Action<string, bool> callback)
    {
        string jsonToSend = JsonUtility.ToJson(data);
        UnityWebRequest uwr = UnityWebRequest.Post($"{apiURL}{endpoin}", "");
        uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonToSend));
        uwr.SetRequestHeader("Content-Type", "application/json");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            callback(uwr.downloadHandler.text, false);
        }
        else
        {
            if (callback != null)
            {
                data.Success(uwr.downloadHandler.text, callback);
            }
            else
            {
                data.Success(uwr.downloadHandler.text);
            }
        }
    }

    public static IEnumerator SendDataWithAuth(string endpoin, modelRequest data, System.Action<string, bool> callback)
    {
        string token = PlayerPrefs.GetString("token");
        string jsonToSend = JsonUtility.ToJson(data);
        UnityWebRequest uwr = UnityWebRequest.Post($"{apiURL}{endpoin}", "");
        uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonToSend));
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("x-access-token", token);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            callback(uwr.downloadHandler.text, false);
        }
        else
        {
            if (callback != null)
            {
                data.Success(uwr.downloadHandler.text, callback);
            }
            else
            {
                data.Success(uwr.downloadHandler.text);
            }

        }
    }
}
