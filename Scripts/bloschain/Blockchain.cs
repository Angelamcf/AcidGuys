using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SubirFormulario : MonoBehaviour
{

    
    void Start() { }

    void OnMouseDown()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("receiver", "myData");

        UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}