using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraOdak : MonoBehaviour {

    // Uçağın x pozisyonu kullanmak için oluşturduğumuz nesne.//Transform olmasının sebebi sadece yönsel işlem yapacak olmamız.

    public Transform ucak;

    // Kameranın uçaktan ileride olmasını sağlamak için oluşturduğumuz değer.
    private float ucakKameraFark; 
    
    void Start () {
        ucakKameraFark = 5;
    }
	
	// Kameranın oyun aktif olduğu sürece değişmesini istediğimiz pozisyon
	void Update () {

        transform.position = new Vector3(ucak.position.x+ ucakKameraFark, 0,-10);

    }
}
