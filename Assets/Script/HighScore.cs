using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int highScore = 0;
	
	// Update is called once per frame
	public void Update () {
		this.guiText.text = "HighScore :" + highScore;
	}
}

	
