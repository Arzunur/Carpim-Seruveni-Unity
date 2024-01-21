using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI sureText;

    int kalanSure = 90;
    bool sureSays�nmi;

    [SerializeField]
    private GameObject sonucPaneli;


    [SerializeField]
    private GameObject sonuclarObje, zamanObje, puanObje, dogruYanlisObje, playerObje;


    void Start()
    {
       kalanSure = 90;
       sureSays�nmi = true;
        
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
        while(sureSays�nmi)//sureSays�nMi==true
        {
            yield return new WaitForSeconds(1f); //Her 1 sn'de bu fonk. �al��s�n

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
                sureSays�nmi=false;
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
