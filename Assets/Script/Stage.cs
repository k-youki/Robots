using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	static public int stage = 1;
	
	// Update is called once per frame
	public void Update () {
		this.guiText.text = "Stage :" + stage;
	}
}
