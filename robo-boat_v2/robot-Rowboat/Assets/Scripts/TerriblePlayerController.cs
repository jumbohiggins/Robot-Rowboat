using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerriblePlayerController : MonoBehaviour
{

   [SerializeField] private float speed = 1;
   public void Update()
   {
      transform.position +=
         new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 
            0, 
            Input.GetAxisRaw("Vertical") * speed *Time.deltaTime);
   }
}
