using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AltMenuMnager : MonoBehaviour
{
    [SerializeField]
    private GameObject altMenuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;
    void Start()
    {

        if (altMenuPanel != null)
        {
            altMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
            altMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        }

    }
    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        //Debug.Log(hangiOyun);

        PlayerPrefs.SetString("hangiOyun", hangiOyun); //Anahtar� ilk kez olu�turaca��m�z i�in SET(isim,kullanaca��n de�i�ken ismi)
        /*  PlayerPrefs == Verilerin kaybolmas�n� istemedi�imiz durumlardaki metotlard�r.
            Oyuncuya ait veya oyunu yapan ki�iye ait verilerin saklanmas�nda ve bu verileri sahneler  aras�nda eri�ilmesine imkan sa�lar.*/

        SceneManager.LoadScene("GameLevel"); //using UnityEngine.SceneManagement;

    }
    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MenuLevel");
    }


}
