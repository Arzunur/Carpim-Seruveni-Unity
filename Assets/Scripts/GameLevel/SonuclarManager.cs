using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SonuclarManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private TextMeshProUGUI dogruText, yanlisText, puanText;

    [SerializeField]
    private GameObject tekrarOynaBtn, anaMenuBtn;

    float sureTimer;
    bool resimAcilsinmi;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        sureTimer = 0;
        resimAcilsinmi = true;

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";
        tekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenuBtn.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(ResimAcRoutine());
    }

    IEnumerator ResimAcRoutine()
    {
        while (resimAcilsinmi)
        {
            sureTimer += 0.15f;
            sonucImage.fillAmount = sureTimer;//fillAmount 0.0 ile 1.0 deðer alýr. Dolu kýsmýn ne kadarýnýn doldurulacaðýný belirler. Dolu çubuðun tamamý için 1.0, dolu olmayan kýsým için 0.0 deðeri kullanýlýr.

            yield return new WaitForSeconds(0.1f);

            if (sureTimer >= 1)
            {
                sureTimer = 1;
                resimAcilsinmi = false;



                dogruText.text = gameManager.dogruAdet.ToString()+" DOÐRU";
                yanlisText.text = gameManager.yanlisAdet.ToString() + " YANLIÞ";
                puanText.text = gameManager.toplamPuan.ToString() + " PUAN";

                tekrarOynaBtn.GetComponent<RectTransform>().DOScale(1,0.3f);
                anaMenuBtn.GetComponent<RectTransform>().DOScale(1, 0.3f);
            }

        }
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }

}
