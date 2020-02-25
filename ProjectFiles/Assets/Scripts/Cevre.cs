using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cevre : MonoBehaviour {

    public GameObject[] nesneler;
    public GameObject[] arkaPlan;
    public bool cevreAktifmi,yildizAktifmi;
    private float GecikmeliTasi = 4; // Tasimanin Gecikme Suresi
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Ucak.mesafe > 100 && Ucak.mesafe < 600 )
        {
            GecikmeliTasi = 2.0f;
        }
        else if (Ucak.mesafe > 601 && Ucak.mesafe < 800)
        {
            GecikmeliTasi = 1.7f;
        }
        else if (Ucak.mesafe > 801 && Ucak.mesafe < 2600)
        {

            GecikmeliTasi = 1.0f;
        }
        else if (Ucak.mesafe > 2601 && Ucak.mesafe < 6000)
        {

            GecikmeliTasi = 0.5f;
        }
        else if (Ucak.mesafe > 6001 && Ucak.mesafe < 10000)
        {

            GecikmeliTasi = 0.1f;
        }
        
        if (cevreAktifmi)
        {
            Invoke("YoluTasi", GecikmeliTasi);
            cevreAktifmi = false;
        }
        if (yildizAktifmi)
        {
            nesneler[2].SetActive(false);
            yildizAktifmi = false;
        }
	}

    public void YoluTasi() {

        float altSayi = Random.Range(0, 2),ustSayi = Random.Range(0, 2);

        if (altSayi==0 && ustSayi == 0) // iki engelin çıkmadığı durumdaki yıldızın pozisyonu ve engel scale değerleri
        {
            nesneler[0].SetActive(false);

            nesneler[1].SetActive(false);

            nesneler[2].transform.localPosition = new Vector2(0, Random.Range(-3.1f, 3.1f));
            nesneler[2].SetActive(true);
        }
        else if(altSayi==0 && ustSayi == 1) // alt engelin çıkmadığı durumdaki yıldızın pozisyonu ve engel scale değerleri
        {
            nesneler[0].SetActive(false);

            nesneler[1].SetActive(true);
            nesneler[1].transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 5),1);
            
            nesneler[2].transform.localPosition = new Vector2(0, Random.Range(-3.1f,0));
            nesneler[2].SetActive(true);
        }
        else if (altSayi==1&&ustSayi==0) // ust engelin çıkmadığı durumdaki yıldızın pozisyonu ve engel scale değerleri
        {
            nesneler[0].SetActive(true);
            nesneler[0].transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 5), 1);
            
            nesneler[1].SetActive(false);
            
            nesneler[2].transform.localPosition = new Vector2(0, Random.Range(0, 3.1f));
            nesneler[2].SetActive(true);
        }
        else // iki engelin çıktığı durumdaki yıldızın pozisyonu ve engel scale değerleri
        {
            if (Ucak.mesafe < 1000)
            {
                nesneler[0].SetActive(true);
                nesneler[0].transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 3), 1);

                nesneler[1].SetActive(true);
                nesneler[1].transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 3), 1);

                nesneler[2].transform.localPosition = new Vector2(0, Random.Range(-0.5f, 0.5f));
                nesneler[2].SetActive(true);
            }
        }
        if (Ucak.mesafe < 750)
        {
            nesneler[3].transform.localPosition = new Vector2(Random.Range(-2.0f, 1.0f), 0f);
        }
        else if(Ucak.mesafe>751 && Ucak.mesafe < 2000)
        {
            nesneler[3].transform.localPosition = new Vector2(Random.Range(-0.2f, 0.2f), 0f);
        }
        transform.position = transform.position + new Vector3(40.0f, 0, 0);
        
    }


}
