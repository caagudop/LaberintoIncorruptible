using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRespawn : MonoBehaviour
{ 

    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ball")
        {
			GameObject.FindGameObjectWithTag("die").gameObject.transform.GetChild(0).gameObject.SetActive(true);
			StartCoroutine(WaitforSeconds());

		}
	}

    IEnumerator WaitforSeconds()
    {
        yield return new WaitForSeconds(2);
		GameObject.FindGameObjectWithTag("box").transform.rotation = Quaternion.identity;
		GameObject.FindGameObjectWithTag("box").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		GameObject.FindGameObjectWithTag("ball").gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
		GameObject.FindGameObjectWithTag("ball").gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		GameObject.FindGameObjectWithTag("die").gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}
}
