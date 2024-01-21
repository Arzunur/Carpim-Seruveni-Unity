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

        PlayerPrefs.SetString("hangiOyun", hangiOyun); //Anahtarý ilk kez oluþturacaðýmýz için SET(isim,kullanacaðýn deðiþken ismi)
        /*  PlayerPrefs == Verilerin kaybolmasýný istemediðimiz durumlardaki metotlardýr.
            Oyuncuya ait veya oyunu yapan kiþiye ait verilerin saklanmasýnda ve bu verileri sahneler  arasýnda eriþilmesine imkan saðlar.*/

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
