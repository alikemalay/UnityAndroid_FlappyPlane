using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class arkaPlan : MonoBehaviour {

    public Transform ucak;

    public GameObject[] image;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        image[0].transform.position = new Vector3(ucak.position.x + 5, 0, 6);
    }

   

}
