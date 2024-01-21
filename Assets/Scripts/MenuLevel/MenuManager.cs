using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private GameObject sesPaneli;

    private bool sesPaneliAcikmi = false; 

    void Start()
    {
        //bool sesPaneliAcikmi = false;
        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(6, -81.486f, 0);

        //menuPanel animasyonlu giriþ
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f); //Inspector kýsmýndan CanvasGroup ekledik ve Alfa deðerini 1'e getirdik.Baþlangýçta 0'di.
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack); //Inspector'deki Scale deðeri=0 'dan 1'e getirme iþlemi
    }

 public void ikinciLevelGec()
    {
        if(PlayerPrefs.GetInt("sesDurumu")==1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MenuLevel2");
    }

    public void AyarlarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        if(!sesPaneliAcikmi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveX(166,0.5f);
            sesPaneliAcikmi = true;      
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveX(6, 0.5f);
            sesPaneliAcikmi = false;
        }

    }
    public void OyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        Application.Quit();//exe veya apk çýktýsýnda çalýþýr
    }
}
