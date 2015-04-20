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
		//x = 5;
		//y = 8;
		transform.Translate(move*x, move*y, 0, Space.World);
		transform.rotation = Quaternion.Euler(0, 0, 45);
		playerObj = GameObject.Find("Player");
		player = playerObj.GetComponent<Player> ();
	}

	public void Move () {
		if(x > player.x){
			transform.Translate(-move, 0, 0, Space.World);
			x--;
		}else if(x < player.x){
			transform.Translate(move, 0, 0, Space.World);
			x++;
		}
		
		if(y > player.y){
			transform.Translate(0, -move, 0, Space.World);
			y--;
		}else if(y < player.y){
			transform.Translate(0, move, 0, Space.World);
			y++;
		}
	}
}
