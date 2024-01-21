using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private TextMeshProUGUI soruText;

    [SerializeField]
    private TextMeshProUGUI birinciSonucText, ikinciSonucText, ucuncuSonucText;

    [SerializeField]
    private TextMeshProUGUI dogruAdetText, yanlisAdetText, puanText;

    [SerializeField]
    private GameObject dogruImage,yanlisImage;

    string hangiOyun;
    int birinciCarpan;
    int ikinciCarpan;
    int dogruSonuc;
    int birinciYanlisSonuc, ikinciYanlisSonuc;
   public int dogruAdet, yanlisAdet, toplamPuan;

    playerManager playerManager; //rotaDegissinMi degiskenini kullanmak için

    private void Awake()
    {
        playerManager = Object.FindObjectOfType<playerManager>();
    }
    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero; //Oyun baþladýðýnda bunlar ekranda gözükmesini engelledik.
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("hangiOyun")) //hangiOyun isminde bir anahtar olup olmadýðýný kontrol eder == HasKey
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");//Bilgiyi almak için GET 
        }
        StartCoroutine(baslaYaziRoutine());
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);//bekleme süresi
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();
    }

    void OyunaBasla()
    {
        playerManager.rotaDegissinMi = true;
        //BirinciCarpaniAyarla();
        SoruyuYazdir();
    }
    void BirinciCarpaniAyarla()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;
            case "uc":
                birinciCarpan = 3;
                break;
            case "dort":
                birinciCarpan = 4;
                break;
            case "bes":
                birinciCarpan = 5;
                break;
            case "alti":
                birinciCarpan = 6;
                break;
            case "yedi":
                birinciCarpan = 7;
                break;
            case "sekiz":
                birinciCarpan = 8;
                break;
            case "dokuz":
                birinciCarpan = 9;
                break;
            case "on":
                birinciCarpan = 10;
                break;
            case "karisik":
                birinciCarpan = Random.Range(2, 11);
                break;

        }
        //Debug.Log(birinciCarpan);
    }

    void SoruyuYazdir()
    {
        BirinciCarpaniAyarla();
        ikinciCarpan = Random.Range(2, 11);
        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger <= 50)
        {
            soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }
        else
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
        }
        dogruSonuc = birinciCarpan * ikinciCarpan;

        SonuclariYazdir();
    }

    void SonuclariYazdir() //Sonucu Daireye yazdýrmak 
    {
        birinciYanlisSonuc = dogruSonuc + Random.Range(2, 10);
        if (dogruSonuc > 10)
        {
            ikinciYanlisSonuc = dogruSonuc - Random.Range(2, 8);
        }
        else
        {
            ikinciYanlisSonuc = Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }


        int rastgeleDeger = Random.Range(1, 100);
        if (rastgeleDeger <= 33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();
        }
        else if (rastgeleDeger <= 66)

        {
            ikinciSonucText.text = dogruSonuc.ToString();
            birinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();
        }
        else
        {
            ucuncuSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            birinciSonucText.text = ikinciYanlisSonuc.ToString();
        }
    }

    public void SonucuKontrolEt(int textSonuc)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero; //Oyun baþladýðýnda bunlar ekranda gözükmesini engelledik.
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonuc == dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1,.1f);
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1,.1f);
        }

        dogruAdetText.text = dogruAdet.ToString()+ " DOGRU";
        yanlisAdetText.text = yanlisAdet.ToString() + " YANLIS";
        puanText.text = toplamPuan.ToString() + " PUAN";

        SoruyuYazdir();
    }



}
