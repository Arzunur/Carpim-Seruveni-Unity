using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{
    //Bu scripte bulunan nesnelere Tag ismi verdik ki ayný isimdeki taglara ulaþabilelim.
    //MERMÝLER CIRCLE'a VURDUÐUNDA DÖNDÜRME ÝÞLEMÝ 
    string hangiSonuc;

    GameManager gameManager;

    private void Awake()
    {
        gameManager =Object.FindObjectOfType<GameManager>(); // GameManager scriptine ulaþmýþ olduk 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //Nesnelerin Trigger özellikleri açýk ise mermi dairelerin içinden geçebilecektir.
    {
        if (collision.tag == "mermi")
        {
            //  Debug.Log(this.gameObject.name);    mermi hangi nesneye çarptýysa onun ismini ekranda yazar 
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            /* 
             
            `gameObject.transform.DORotate` satýrý, Unity'nin DOTween kütüphanesini kullanarak bir GameObject'in rotasyonunu animasyonlu bir þekilde deðiþtirmek için kullanýlýr. 
            `transform.eulerAngles`**: Bu, nesnenin mevcut dünya koordinatlarýndaki rotasyon açýsýný temsil eder. Yani nesnenin þu anki rotasyonunu alýr.
            `Quaternion.AngleAxis(45, Vector3.forward).eulerAngles`**: Bu, **`Vector3.forward`** ekseni etrafýnda 45 derece döndürülmüþ bir Quaternion'u alýr ve onun eulerAngles deðerini döndürür. 
            Böylece nesnenin þu anki rotasyon açýsýna 45 derece ekleyerek, hedef rotasyon açýsýný elde ederiz.*/
            /* 
             Vector3.forward = new Vector3(0,0,1); //z eks. sol tarafa 1 br ilerle 
             Vector3.back = new Vector3(0, 0, -1);
             Vector3.right = new Vector3(1, 0, 0);  
            */

            if (this.gameObject != null)
            {
                //Mermi daire'ye çarptýðýnda mermi yok olsun
                Destroy(collision.gameObject);//çarptýðý nesneyi yok etmek 
            }

            if (gameObject.name == "solDaire")//mermi tag solDaire'ye carptýysa.solText'in deðerini versin
            {
                hangiSonuc = GameObject.Find("solText").GetComponent<TextMeshProUGUI>().text;//O anda aktif olan tüm gameObjecti tarar
            }
            else if(gameObject.name=="ortaDaire")
            {
                hangiSonuc = GameObject.Find("ortaText").GetComponent<TextMeshProUGUI>().text;
            }

            else if (gameObject.name == "saðDaire")
            {
                hangiSonuc = GameObject.Find("saðText").GetComponent<TextMeshProUGUI>().text;
            }
            // Debug.Log(hangiSonuc); doðru olup olmadýðýný kontrol etmiþ olduk.

            gameManager.SonucuKontrolEt(int.Parse(hangiSonuc));
        }
    }
}
