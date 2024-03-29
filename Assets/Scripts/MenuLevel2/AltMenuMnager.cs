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

        PlayerPrefs.SetString("hangiOyun", hangiOyun); //Anahtarı ilk kez oluşturacağımız için SET(isim,kullanacağın değişken ismi)
        /*  PlayerPrefs == Verilerin kaybolmasını istemediğimiz durumlardaki metotlardır.
            Oyuncuya ait veya oyunu yapan kişiye ait verilerin saklanmasında ve bu verileri sahneler  arasında erişilmesine imkan sağlar.*/

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
