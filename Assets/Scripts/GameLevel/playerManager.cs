using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private AudioSource audioSource;


    [SerializeField]
    private AudioClip topClick;

    float angle;
    float donusHizi = 5f;
    float ikiMermiArasýSüre = 200f;
    float sonrakiAtisSürei;

    public bool rotaDegissinMi;


    void Start()
    {
        rotaDegissinMi = false;
    }

    void Update()
    {
        if(rotaDegissinMi)
        {
            RotateDegistir();
        }
    }

    void RotateDegistir() //Roketin mouse'un bulunduðu konuma göre hareket ettirme iþlemi
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;//Ana kameranýn ana sahne üzerindeki (ScreenToWorldPoint) mouse ile týkladýðým yerdeki poziyon(Input.mousePosition)

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; ;
        //çýkan sonuc Radyan.Açýya dönüþtürmek için --> Mathf.Rad2Deg
        //Atan2== iki tane deðer ister 
        //Atan==verilen deðeri açýya çevirir
        //direction.y==bulunan y yönü. y'yi x'e böl


        if (angle <56 && angle > -60) //gun nesnesinin belirtilen açýlarda dönmesini saðlayarak aþaðýya mermi atmasýný engellemiþ olduk
        {

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);//Rotasyona aktarma iþlemi.
                                                                               //Quaternion = döndürmek için kullanýlýr. AngleAxis döndürme açýsý ve döndürme ekseni belirler.Vector3.forward aslýnda düz bir 3D vektördür ve Z ekseninde döndürme yapar.

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
            //Slerp yumuþak geçiþ için 

        }

       /* Debug.Log(angle); Açý deðeri gun'ýn açý sýnýrlamasý yapmak istersen bu kodu kullanabilirsin.*/ 

        if (Input.GetMouseButtonDown(0)) //Mouse ile týklanýldýðý zaman dönmesini aktif edelim.  
                                         //Input.GetMouseButtonDown(0))==Mouse'un sol tuþuna basýldýðý anda
        {



            if (Time.time > sonrakiAtisSürei)//MERMÝNÝN SÜREKLÝ ATIÞINI ENGELLEDÝK BELLÝ BÝR SÜRE SONRA MERMÝ ATILACAK
                                             //Time.time=geçen süre
            {
                sonrakiAtisSürei = Time.time + ikiMermiArasýSüre / 1000;
                MermiAt();
            }
        }

    }

    void MermiAt() //mermi oluþturrma 
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(topClick);
        }
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0, mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation) as GameObject;
        //mermiPrefab, mermiYeri'nin pozisyonundan ve rotasyonu ile oluþacak  ve as GameObject = GameObject olarak tanýmasýný saðlýyoruz.
    }


}
