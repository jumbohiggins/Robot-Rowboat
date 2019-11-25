using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;

public class EvilBird : Enemy
{

    [SerializeField] private float speed;
    [SerializeField] private float jitterSpeed;
    private Vector3 target;
    private Vector3 currOffset;
    private Vector3 oldPos;
    
    protected override void Die()
    {
        base.Die();
    }


    protected override void EnemyStart()
    {
        StartCoroutine(MoveAndAttack());
        target = transform.position;
        oldPos = target;
    }

    public void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target + currOffset, step);
        LookAtPlayer();
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            target = oldPos;
        }
    }

    private IEnumerator MoveAndAttack()
    {
        int count = 0;
        while (true)
        {
            Movement();
            count++;
            yield return new WaitForSeconds(0.8f + Random.Range(-0.1f, 0.4f));
        }
    }



    private void Movement()
    {
       // Transform playerTransform = MapGenerator.Instance.player;
        Vector3 randomPos = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), Random.Range(-1f,1f));
        float scaleFactor =
            jitterSpeed;// * Vector3.Dot((playerTransform.position - transform.position).normalized,randomPos.normalized);
        Vector3 toAdd = scaleFactor * randomPos;
        currOffset = toAdd;
    }

    private void AttackPlayer() 
    {
        Debug.Log("attacking");
        Transform playerTransform = MapGenerator.Instance.player;
        Vector3 diff = playerTransform.position - transform.position;
        oldPos = target;
        target += 0.66f * diff;
    }

    private void LookAtPlayer()
    {
        Transform playerTransform = MapGenerator.Instance.player;
        transform.LookAt(playerTransform);
    }
    
}
