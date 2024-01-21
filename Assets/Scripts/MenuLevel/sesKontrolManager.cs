using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesKontrolManager : MonoBehaviour
{
    private void Start()
    {
        SesiAc();
    }
    public void SesiAc()
    {
        //Ses durumunu PlayerPrefabs kullan ��nk� sesi her sahneden ula�mam laz�m 
        PlayerPrefs.SetInt("sesDurumu", 1);
    }

    public void SesiKapat()
    {
        PlayerPrefs.SetInt("sesDurumu", 0);
    }
}
