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

        //menuPanel animasyonlu giri�
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f); //Inspector k�sm�ndan CanvasGroup ekledik ve Alfa de�erini 1'e getirdik.Ba�lang��ta 0'di.
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack); //Inspector'deki Scale de�eri=0 'dan 1'e getirme i�lemi
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

        Application.Quit();//exe veya apk ��kt�s�nda �al���r
    }
}
