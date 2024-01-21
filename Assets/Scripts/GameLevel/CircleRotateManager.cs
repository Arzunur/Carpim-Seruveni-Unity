using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{
    //Bu scripte bulunan nesnelere Tag ismi verdik ki ayn� isimdeki taglara ula�abilelim.
    //MERM�LER CIRCLE'a VURDU�UNDA D�ND�RME ��LEM� 
    string hangiSonuc;

    GameManager gameManager;

    private void Awake()
    {
        gameManager =Object.FindObjectOfType<GameManager>(); // GameManager scriptine ula�m�� olduk 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //Nesnelerin Trigger �zellikleri a��k ise mermi dairelerin i�inden ge�ebilecektir.
    {
        if (collision.tag == "mermi")
        {
            //  Debug.Log(this.gameObject.name);    mermi hangi nesneye �arpt�ysa onun ismini ekranda yazar 
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            /* 
             
            `gameObject.transform.DORotate` sat�r�, Unity'nin DOTween k�t�phanesini kullanarak bir GameObject'in rotasyonunu animasyonlu bir �ekilde de�i�tirmek i�in kullan�l�r. 
            `transform.eulerAngles`**: Bu, nesnenin mevcut d�nya koordinatlar�ndaki rotasyon a��s�n� temsil eder. Yani nesnenin �u anki rotasyonunu al�r.
            `Quaternion.AngleAxis(45, Vector3.forward).eulerAngles`**: Bu, **`Vector3.forward`** ekseni etraf�nda 45 derece d�nd�r�lm�� bir Quaternion'u al�r ve onun eulerAngles de�erini d�nd�r�r. 
            B�ylece nesnenin �u anki rotasyon a��s�na 45 derece ekleyerek, hedef rotasyon a��s�n� elde ederiz.*/
            /* 
             Vector3.forward = new Vector3(0,0,1); //z eks. sol tarafa 1 br ilerle 
             Vector3.back = new Vector3(0, 0, -1);
             Vector3.right = new Vector3(1, 0, 0);  
            */

            if (this.gameObject != null)
            {
                //Mermi daire'ye �arpt���nda mermi yok olsun
                Destroy(collision.gameObject);//�arpt��� nesneyi yok etmek 
            }

            if (gameObject.name == "solDaire")//mermi tag solDaire'ye carpt�ysa.solText'in de�erini versin
            {
                hangiSonuc = GameObject.Find("solText").GetComponent<TextMeshProUGUI>().text;//O anda aktif olan t�m gameObjecti tarar
            }
            else if(gameObject.name=="ortaDaire")
            {
                hangiSonuc = GameObject.Find("ortaText").GetComponent<TextMeshProUGUI>().text;
            }

            else if (gameObject.name == "sa�Daire")
            {
                hangiSonuc = GameObject.Find("sa�Text").GetComponent<TextMeshProUGUI>().text;
            }
            // Debug.Log(hangiSonuc); do�ru olup olmad���n� kontrol etmi� olduk.

            gameManager.SonucuKontrolEt(int.Parse(hangiSonuc));
        }
    }
}
