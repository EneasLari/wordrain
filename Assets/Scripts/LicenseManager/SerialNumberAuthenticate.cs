using UnityEngine;
using System.Collections;
using Assets.Scripts.LicenseManager;
using UnityEngine.Networking;
using Assets.Scripts.Web;
using Assets.Scripts.PersistentData;

public class SerialNumberAuthenticate : MonoBehaviour {

    private SerialNumber SerialNumber=null;
    public string apiURL = "http:///www.yoururl.com";
    private bool _serialNumberInitialized = false;
    public string Serial = "NONE";

    public void InitializeSerialNumber(string serialnumber) {
        SerialNumber = new SerialNumber();
        this.SerialNumber.SerialNumberRegistered = serialnumber;
        apiURL = apiURL +this.SerialNumber.SerialNumberRegistered;
        _serialNumberInitialized = true;
    }

    public void SendSerialNumberGetRequest(string serial) {
        InitializeSerialNumber(serial);
        if (_serialNumberInitialized) {
            StartCoroutine(GetRequest(apiURL));
        } else {
            StartCoroutine(GetRequest(apiURL + "/noserialnumber"));
        }
    }

    // Use this for initialization
    void Start() {
        SendSerialNumberGetRequest(Serial);
    }


    IEnumerator GetRequest(string uri) {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError) {
            Debug.Log("Error While Sending: " + uwr.error);
        } else {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
