using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI sureText;

    int kalanSure = 90;
    bool sureSaysýnmi;

    [SerializeField]
    private GameObject sonucPaneli;


    [SerializeField]
    private GameObject sonuclarObje, zamanObje, puanObje, dogruYanlisObje, playerObje;


    void Start()
    {
       kalanSure = 90;
       sureSaysýnmi = true;
        
        sonucPaneli.SetActive(false);

        sonuclarObje.SetActive(true);
        zamanObje.SetActive(true);
        puanObje.SetActive(true);
        playerObje.SetActive(true);
        dogruYanlisObje.SetActive(true);

        StartCoroutine(SureTimerRoutine());
    }
    IEnumerator SureTimerRoutine()
    {
        while(sureSaysýnmi)//sureSaysýnMi==true
        {
            yield return new WaitForSeconds(1f); //Her 1 sn'de bu fonk. çalýþsýn

            if(kalanSure<10)
            {
                sureText.text="0"+kalanSure.ToString();
            }
            else
            {
                sureText.text=kalanSure.ToString();
            }
            if(kalanSure <= 0)
            {
                sureSaysýnmi=false;
                sureText.text = "";
                EkraniTemizle();
                sonucPaneli.SetActive(true);
            }
            kalanSure--;
        }
    }

    void EkraniTemizle()
    {
        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        puanObje.SetActive(false);
        playerObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
    }
}
