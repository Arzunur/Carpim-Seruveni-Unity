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
        //Ses durumunu PlayerPrefabs kullan çünkü sesi her sahneden ulaþmam lazým 
        PlayerPrefs.SetInt("sesDurumu", 1);
    }

    public void SesiKapat()
    {
        PlayerPrefs.SetInt("sesDurumu", 0);
    }
}
