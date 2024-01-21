using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiManager : MonoBehaviour
{
    //Mermiye Hýz Vermek 

    float mermiHiz=15f;
 
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHiz);
            //translate=taþý
    }
}
