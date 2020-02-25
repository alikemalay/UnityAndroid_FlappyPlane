using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ucak : MonoBehaviour {

    public Ses ses;
    public static float mesafe=0;
    private float ucakSabitHiz, yukselisHizi, maxPuan = 0, mesafeSkala = 10000, Puan, yildizMiktar = 0, netHiz;
    public Transform baslangicNoktasi;
    
    /* metinler : devamPuan[0],yildizMiktari[1],sonPuan[2],maxPuan[3] */
    public Text[] metinler;
    
    /* paneller: baslangic[0],devam[1],son[2] */ 
    public GameObject[] paneller;
    
    void Start () {

        netHiz = 0;
        mesafe = 0;

        /* PANEL */
        paneller[0].SetActive(true);
        paneller[1].SetActive(false);
        paneller[2].SetActive(false);
        
        ucakSabitHiz = 0;
        yukselisHizi = 0;

        GetComponent<Rigidbody2D>().gravityScale = 0;
        
        // Ekranı sadece yatay pozisyona sabitler.
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void yenidenBaslat() {
        Time.timeScale = 1;
        SceneManager.LoadScene("ucakOyun");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Update ()
    {
        mesafe = Vector2.Distance(baslangicNoktasi.position, transform.position);
        
        netHiz = ucakSabitHiz * Time.deltaTime + (mesafe / mesafeSkala);

        transform.Translate(netHiz, 0, 0);

        Puan = (int)(yildizMiktar * yildizMiktar + mesafe);

        metinler[0].text = "Puan : " + Puan + "P";        
        
        metinler[1].text = "Toplanılan Yıldız : " + (int)yildizMiktar;

        
        //if  (Input.GetKeyDown(KeyCode.Space))  // FOR PC 
        //    {
        //        GetComponent<Rigidbody2D>().AddForce(Vector2.up * yukselisHizi);
            
        //        ses.sesler[3].Play();
        //        ses.sesler[3].volume= 0.1f;
        //        ses.sesler[3].reverbZoneMix = 1.1f;
        //}


        if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began) //FOR ANDROID TOUCH 
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * yukselisHizi);

            ses.sesler[3].Play();
            ses.sesler[3].volume = 0.1f;
            ses.sesler[3].reverbZoneMix = 1.1f;
        }

    }

    void OnTriggerEnter2D(Collider2D carpilanNesne)
    {
        if (carpilanNesne.gameObject.tag == "Yildiz")
        {
            ses.sesler[1].Play();
            ses.sesler[1].volume = 0.15f;
            ses.sesler[1].reverbZoneMix = 1.1f;
            
            carpilanNesne.gameObject.transform.root.gameObject.GetComponent<Cevre>().yildizAktifmi= true;
            yildizMiktar++;
        }
        if (carpilanNesne.gameObject.tag == "cevre")
        {
            carpilanNesne.gameObject.transform.root.gameObject.GetComponent<Cevre>().cevreAktifmi = true;
        }
    }

    void OnCollisionEnter2D(Collision2D carpilanNesne)
    {
        if (carpilanNesne.gameObject.tag == "Engel")
        {
            Time.timeScale = 0;
        }
        OyunSonu();
    }

    public void OyunBaslat()
    {
        ses.sesler[0].Play();
        ses.sesler[0].volume = 0.2f;
        ses.sesler[0].loop= true;

        /* PANEL */
        paneller[0].SetActive(false);
        paneller[1].SetActive(true);
        paneller[2].SetActive(false);


        ucakSabitHiz = 5;
        yukselisHizi = 200;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        gameObject.SetActive(true); // UCAK NESNESINI TEMSIL EDER.
        
        
    }
    void OyunSonu()
    {
        ses.sesler[0].Stop();
        

        ses.sesler[2].Play();
        ses.sesler[2].volume = 0.15f;

        

        metinler[2].text = "Toplanılan Yıldız : " + yildizMiktar + "\n" + "      Puan : " + (int)Puan + "P";

        /* PANEL */
        paneller[0].SetActive(false);
        paneller[1].SetActive(false);
        paneller[2].SetActive(true);
        gameObject.SetActive(false);



        maxPuan = PlayerPrefs.GetFloat("maxPuan");

        if(maxPuan > Puan)
        {
            metinler[3].text = "Max Puan : " + (int)maxPuan + "P";
        }
        else
        {
            maxPuan = Puan;
            PlayerPrefs.SetFloat("maxPuan", maxPuan);
            metinler[3].text = "Max Puan : " + (int)maxPuan + "P";
        }
            
    }
}
