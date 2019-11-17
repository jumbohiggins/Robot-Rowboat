using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBob : MonoBehaviour {


    public float freq;
    public float amp;
    public Renderer rend;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start () {
        //renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        rend = GetComponent<Renderer>();
        rend.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        freq = Random.Range(freq - 0.5f, freq + .5f);
        amp = Random.Range(amp - .5f, amp + .5f);
        posOffset = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        tempPos = posOffset;

        transform.position = new Vector3(gameObject.transform.position.x, tempPos.y + Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * amp, gameObject.transform.position.z);

    }
}
