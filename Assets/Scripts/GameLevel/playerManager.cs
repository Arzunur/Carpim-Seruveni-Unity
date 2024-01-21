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
    float ikiMermiAras�S�re = 200f;
    float sonrakiAtisS�rei;

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

    void RotateDegistir() //Roketin mouse'un bulundu�u konuma g�re hareket ettirme i�lemi
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;//Ana kameran�n ana sahne �zerindeki (ScreenToWorldPoint) mouse ile t�klad���m yerdeki poziyon(Input.mousePosition)

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; ;
        //��kan sonuc Radyan.A��ya d�n��t�rmek i�in --> Mathf.Rad2Deg
        //Atan2== iki tane de�er ister 
        //Atan==verilen de�eri a��ya �evirir
        //direction.y==bulunan y y�n�. y'yi x'e b�l


        if (angle <56 && angle > -60) //gun nesnesinin belirtilen a��larda d�nmesini sa�layarak a�a��ya mermi atmas�n� engellemi� olduk
        {

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);//Rotasyona aktarma i�lemi.
                                                                               //Quaternion = d�nd�rmek i�in kullan�l�r. AngleAxis d�nd�rme a��s� ve d�nd�rme ekseni belirler.Vector3.forward asl�nda d�z bir 3D vekt�rd�r ve Z ekseninde d�nd�rme yapar.

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
            //Slerp yumu�ak ge�i� i�in 

        }

       /* Debug.Log(angle); A�� de�eri gun'�n a�� s�n�rlamas� yapmak istersen bu kodu kullanabilirsin.*/ 

        if (Input.GetMouseButtonDown(0)) //Mouse ile t�klan�ld��� zaman d�nmesini aktif edelim.  
                                         //Input.GetMouseButtonDown(0))==Mouse'un sol tu�una bas�ld��� anda
        {



            if (Time.time > sonrakiAtisS�rei)//MERM�N�N S�REKL� ATI�INI ENGELLED�K BELL� B�R S�RE SONRA MERM� ATILACAK
                                             //Time.time=ge�en s�re
            {
                sonrakiAtisS�rei = Time.time + ikiMermiAras�S�re / 1000;
                MermiAt();
            }
        }

    }

    void MermiAt() //mermi olu�turrma 
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(topClick);
        }
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0, mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation) as GameObject;
        //mermiPrefab, mermiYeri'nin pozisyonundan ve rotasyonu ile olu�acak  ve as GameObject = GameObject olarak tan�mas�n� sa�l�yoruz.
    }


}
