using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerPowerL : MonoBehaviour {
    public Transform lastpos;
    private Vector3 vthrust;
    public Rigidbody boat;
    public float m_speed = 5.0f;
    public bool wdir;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("ON");
        Debug.Log(this.gameObject.transform.position.y);

      
        if (this.gameObject.transform.position.y < 1)
        {
            Debug.Log("In water");
            boat.velocity = -transform.forward * m_speed;
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_speed, Space.World);
        }

	}
}
