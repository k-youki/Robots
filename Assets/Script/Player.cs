using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public int x = 0;
	public int y = 0;

	public float move = 2.5f;

	public int right = 0;
	public int left = 0;
	public int up = 0;
	public int down = 0;
	public int space = 0;
	public int stop = 0;

	public bool moveFlag = false;
	public bool movingFlag = false;

	Manage manage;

	// Use this for initialization
	void Start () {
		manage = GetComponent<Manage>();
	}

	// Update is called once per frame
	void Update () {

		if (!manage.gameover) {
			Move();
		}

		if(moveFlag == true) {
			manage.EnemyMove ();
			manage.EnemyCollisionJudge ();
			manage.GameOverJudge ();
			manage.StageCrearJudge ();
			moveFlag = false;
		}
	}

	void Move () {

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.Keypad6)) {
			if (++right == 1 && x < 20) {
				x++;
				iTweenMove();
			}
		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.Keypad4)) {
			if (++left == 1 && x > -19) {
				x--;
				iTweenMove();
			}
		} else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey (KeyCode.Keypad8)) {
			if (++up == 1 && y < 20){
				y++;
				iTweenMove();
			}
		} else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey (KeyCode.Keypad2)) {
			if (++down == 1 && y > -19) {
				y--;
				iTweenMove();
			}
		} else if (Input.GetKey (KeyCode.Keypad7)) {
			if (++left == 1 && x > -19 && ++up == 1 && y < 20) {
				x--; y++;
				iTweenMove();
			}
		}else if (Input.GetKey (KeyCode.Keypad9)) {
			if (++right == 1 && x < 20 && ++up == 1 && y < 20) {
				x++; y++;
				iTweenMove();
			}
		}else if (Input.GetKey (KeyCode.Keypad1)) {
			if (++left == 1 && x > -19 && ++down == 1 && y > -19) {
				x--; y--;
				iTweenMove();
			}
		}else if (Input.GetKey (KeyCode.Keypad3)) {
			if (++right == 1 && x < 20 && ++down == 1 && y > -19) {
				x++; y--;
				iTweenMove();
			}
		}else if(Input.GetKey(KeyCode.Space) || Input.GetKey (KeyCode.Keypad0)) {
			if(++space == 1){
				JumpPlayer();
			}
		}else if(Input.GetKey(KeyCode.Keypad5)){
				moveFlag = true;
		} else {
			up = down = left = right = space = stop = 0;
		}
	}

	void iTweenMove()
	{
		iTween.MoveTo(gameObject, iTween.Hash("x", x*move, "y", y*move,
		"time", 0.1f, "oncomplete", "CompleteMove", "oncompletetarget",
		this.gameObject, "easetype", iTween.EaseType.easeInOutQuart));
		moveFlag = true;
	}

	void CompleteMove()
	{

	}

	public void JumpPlayer()
	{
		x = Random.Range(-19, 20);
		y = Random.Range(-19, 20);
		iTweenMove();
	}
}
