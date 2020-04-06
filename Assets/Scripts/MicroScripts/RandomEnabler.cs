using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnabler : MonoBehaviour
{
    // Start is called before the first frame update\
    public bool EnableScaling = true;
    void Awake()
    {
        int ran = Random.Range(0, 100);
        if (ran > 50) {
            gameObject.SetActive(true);
        } 
        else { 
            gameObject.SetActive(false); 
        }
        //Scale if is needed
        if (EnableScaling) {
            float randscalerX = Random.Range(0.6f, 1.2f);
            float randscalerY = Random.Range(0.6f, 1.2f);
            float randscalerZ = Random.Range(0.6f, 1f);
            gameObject.transform.localScale = new Vector3(randscalerX, randscalerY, randscalerZ);
        }

    }


}
