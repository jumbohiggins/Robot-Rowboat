using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public Rigidbody boat;
    public float torque;
    public float m_speed = 5.0f;
    public Vector3 initPos;
    public Quaternion initRot;
    public GameObject[] balls;
    private List<Vector3> ballPos;
    private List<Quaternion> ballRots;
    // Use this for initialization
    void Start() {
        initPos = boat.transform.position;
        initRot = boat.transform.rotation;
        foreach (GameObject ball in balls){
            ballPos.Add(ball.transform.position);
            ballRots.Add(ball.transform.rotation);
        }
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetBoat();

        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (leftPaddle.gameObject.transform.position.y < 1 && rightPaddle.gameObject.transform.position.y > 1)
        {
            //Debug.Log("Turning left");
            //boat.velocity = -transform.forward * m_speed;
            //transform.Rotate(new Vector3(0, -5, 0) * Time.deltaTime * m_speed, Space.World);
            float turn = Input.GetAxis("Horizontal");
            boat.AddTorque(transform.up * torque * -2.0f);
        }

        if (rightPaddle.gameObject.transform.position.y < 1 && leftPaddle.gameObject.transform.position.y > 1)
        {
           // Debug.Log("Turning right");
            //boat.velocity = -transform.forward * m_speed;
            //transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime * m_speed, Space.World);
            float turn = Input.GetAxis("Horizontal");
            boat.AddTorque(transform.up * torque * 2.0f);
        }
        if (leftPaddle.gameObject.transform.position.y < 1 && rightPaddle.gameObject.transform.position.y < 1)
        {
            //Debug.Log("Going Straiht");
            boat.velocity = -transform.forward * m_speed;
            //transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime * m_speed, Space.World);
        }
    }

    void ResetBoat()
    {
        Debug.Log("reset");
        boat.transform.rotation = initRot;
        boat.transform.position = new Vector3(boat.transform.position.x, initPos.y, boat.transform.position.z);
        int i = 0;
        foreach(GameObject ball in balls)
        {
            ball.transform.position = ballPos[i];
            ball.transform.rotation = ballRots[i];
            ++i;
        }
    }
}
