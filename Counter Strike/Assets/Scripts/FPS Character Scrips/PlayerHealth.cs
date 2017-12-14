using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {

    [SyncVar]
    public float health = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damage)
    {
        if(!isServer)
        {
            return;
        }

        health -= damage;

        print("DAMAGE RECIEVED");

        if(health <= 0f)
        {

        }
    }
}
