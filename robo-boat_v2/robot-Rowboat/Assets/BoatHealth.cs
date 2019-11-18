using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoatHealth : MonoBehaviour {

    public int Health;
    [SerializeField] private Image image;
    [SerializeField] private List<Sprite> sprites;

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
            image.sprite = sprites[5 - Health];
            Destroy(col.gameObject);
            Debug.Log("DAMAGE");
            Debug.Log(col.gameObject.name);
            if (Health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (col.gameObject.tag == "Island")
        {
            Debug.Log("You win");
        }
    }
}
