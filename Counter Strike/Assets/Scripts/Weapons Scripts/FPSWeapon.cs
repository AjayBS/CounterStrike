using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWeapon : MonoBehaviour {

    private GameObject muzzleFlash;

	// Use this for initialization
	void Awake () {
        muzzleFlash = transform.Find("Muzzle Flash").gameObject;
        muzzleFlash.SetActive(false);
	}

    public void Shoot()
    {
        StartCoroutine(TurnOnMuzzleFlash());
    }

    IEnumerator TurnOnMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
    }
}
