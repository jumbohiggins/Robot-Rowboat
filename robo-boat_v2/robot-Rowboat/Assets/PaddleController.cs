using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public Rigidbody boat;
    public float torque;
    public float m_speed = 5.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (leftPaddle.gameObject.transform.position.y < 1 && rightPaddle.gameObject.transform.position.y > 1)
        {
            Debug.Log("Turning left");
            //boat.velocity = -transform.forward * m_speed;
            //transform.Rotate(new Vector3(0, -5, 0) * Time.deltaTime * m_speed, Space.World);
            float turn = Input.GetAxis("Horizontal");
            boat.AddTorque(transform.up * torque * -1.0f);
        }

        if (rightPaddle.gameObject.transform.position.y < 1 && leftPaddle.gameObject.transform.position.y > 1)
        {
            Debug.Log("Turning right");
            //boat.velocity = -transform.forward * m_speed;
            //transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime * m_speed, Space.World);
            float turn = Input.GetAxis("Horizontal");
            boat.AddTorque(transform.up * torque * 1.0f);
        }
        if (leftPaddle.gameObject.transform.position.y < 1 && rightPaddle.gameObject.transform.position.y < 1)
        {
            Debug.Log("Going Straiht");
            boat.velocity = -transform.forward * m_speed;
            //transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime * m_speed, Space.World);
        }
    }
}
