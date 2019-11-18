using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHealth : MonoBehaviour {

    public int Health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Health = Health - 1;
            Destroy(col.gameObject);
            Debug.Log("DAMAGE");
            Debug.Log(col.gameObject.name);
        }
        if (col.gameObject.tag == "Island")
        {
            Debug.Log("You win");
        }
    }
}
