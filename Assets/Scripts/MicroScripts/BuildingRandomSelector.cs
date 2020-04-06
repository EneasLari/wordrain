using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRandomSelector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int buildingpos = Random.Range(0, gameObject.transform.childCount-1);
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            if (i == buildingpos) {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            } else {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
