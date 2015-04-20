using UnityEngine;
using System.Collections;

public class ScrapText : MonoBehaviour {

	static public int num = 0;

	// Update is called once per frame
	public void Update () {
		TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
		t.text = "Scrap x "+num;
	}
}
