using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerPowerR : MonoBehaviour {
    public Transform lastpos;
    private Vector3 vthrust;
    public Rigidbody boat;
    public float m_speed = 5.0f;
    public bool wdir;

	// Use this for initialization
	void Start () {
        lastpos = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < 0)
        {
            Debug.Log("In water");
            Vector3 direction = boat.transform.position + transform.position;
            vthrust = 1.1f * (lastpos.position - this.gameObject.transform.position);
            vthrust *= 1.1f * -this.gameObject.transform.position.y;
            var outthrust = 1 / Mathf.Tan(90);
            boat.velocity = -transform.forward * m_speed;
            Debug.Log(wdir);
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_speed, Space.World);
        }

	}
}
