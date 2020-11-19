using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ball")
		{
			GameObject.FindGameObjectWithTag("win").gameObject.transform.GetChild(0).gameObject.SetActive(true);
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
		GameObject.FindGameObjectWithTag("win").gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}
}
