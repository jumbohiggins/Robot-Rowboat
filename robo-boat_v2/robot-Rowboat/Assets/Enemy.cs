using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	[SerializeField] private int health;
	private int _currHealth;
	private bool canBeAttacked = true;
	
	// Use this for initialization
	void Start () {
		_currHealth = health;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Weapon"))
		{
			if (--_currHealth <= 0)
			{
				Die();
			}
			else
			{
				OnAttack();
			}
		}
	}

	protected virtual void Die()
	{
		Destroy(this);
	}

	protected virtual void OnAttack()
	{
		
	}

}
