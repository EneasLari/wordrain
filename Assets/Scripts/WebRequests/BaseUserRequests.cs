using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class BaseUserRequests : MonoBehaviour
{
    string email = "email";
    string emailvalue = "";

    string password = "password";
    string passwordvalue = "";

    public InputField emailinput;
    public InputField passwordinput;

    public Text ResponseMessage;

    void Start() {

        //StartCoroutine(Upload());
    }

    public void submit() {
        emailvalue = emailinput.text;
        passwordvalue = passwordinput.text;
        StartCoroutine(Login());
    }

    IEnumerator Login() {
        WWWForm form = new WWWForm();
        form.AddField(email, emailvalue);
        form.AddField(password, passwordvalue);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:5000/user/login", form)) {
            yield return www.SendWebRequest();

            if (www.responseCode == 404) {
                Debug.Log("User not found");
                ResponseMessage.text = "User not found";
            } else if (www.responseCode == 401) {
                Debug.Log("Wrong Password");
                ResponseMessage.text = "Wrong Password";
            } else if (www.isNetworkError || www.isHttpError) {
                ResponseMessage.text = www.error;
                Debug.Log(www.error);
            } else {
                ResponseMessage.text = "Success";
                Debug.Log("OK");
                StringBuilder sb = new StringBuilder();
                foreach (System.Collections.Generic.KeyValuePair<string, string> dict in www.GetResponseHeaders()) {
                    sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
                }

                // Print Headers
                Debug.Log(sb.ToString());
                loginresponse res = JsonUtility.FromJson<loginresponse>(www.downloadHandler.text);
            }
        }
    }
}