using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime);
	}
}
