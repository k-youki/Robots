using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int x;
	public int y;

	public bool scrapFlag = false;
	public float move = 2.5f;

	GameObject playerObj;
	Player player;

	void Start () {
		transform.Translate(move*x, move*y, 0, Space.World);
		transform.rotation = Quaternion.Euler(0, 0, 45);
		playerObj = GameObject.Find("Player");
		player = playerObj.GetComponent<Player>();
	}

	public void Move () {
		if(x > player.x){
			x--;
		}else if(x < player.x){
			x++;
		}

		if(y > player.y){
			y--;
		}else if(y < player.y){
			y++;
		}

		iTween.MoveTo(gameObject, iTween.Hash("x", x*move, "y", y*move,
		 "time", 0.1f, "oncomplete", "CompleteMove", "oncompletetarget",
		 this.gameObject, "easetype", iTween.EaseType.easeInOutQuart));
	}
}
