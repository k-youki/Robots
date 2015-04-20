using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static public int score = 0;
	
	// Update is called once per frame
	public void Update () {
		this.guiText.text = "Score :" + score;
	}
}
