using UnityEngine;
using System.Collections;

public class Manage : MonoBehaviour 
{
	public const int MAP_SIZE = 20;
	public const float MOVE = 2.5f;
	
	// マップデータ
	//int[,] mapData = new int[MAP_SIZE, MAP_SIZE];
	// エネミーの数
	public int enemyNum;
	// ステージ
	public int stage;
	// スコア
	public int socre;
	// ゲームオーバーフラグ
	public bool gameover = false;


	public Player player;
	public Enemy[] enemy = new Enemy[100];
	public GameObject enemyPrefab;
	public GameObject scrapPrefab;
	public GameObject gameoverPrefab;

	public GameObject obj;
	public GameObject[] enemyObj = new GameObject[100];

	void Start () {
		enemyNum = Stage.stage*5;
		if (enemyNum > 40) enemyNum = 40;
		EnemyText.num = enemyNum;
		ScrapText.num = 0;
		for (int i = 0; i<enemyNum; i++){
			obj = Instantiate (enemyPrefab, transform.position, transform.rotation) as GameObject;
			enemy[i] = obj.GetComponent<Enemy> ();
			enemy[i].x = Random.Range(-MAP_SIZE+1, MAP_SIZE);
			enemy[i].y = Random.Range(-MAP_SIZE+1, MAP_SIZE);
		}
		player = GetComponent<Player> ();
		enemyObj = GameObject.FindGameObjectsWithTag("EnemyGroup");
	}

	public void EnemyMove () {
		for (int i=0; i<enemyNum; i++) {
			//Debug.Log(i);
			if(enemy[i].scrapFlag == false){
				enemyObj[i].SendMessage("Move");
			}
		}
	}

	public void EnemyCollisionJudge () {
		for (int i=0; i<enemyNum; i++) {
			for (int j=i+1; j<enemyNum; j++) {
				if (enemy[i].x == enemy[j].x && enemy[i].y == enemy[j].y) {
					if(enemy[i].scrapFlag == false || enemy[j].scrapFlag == false){
						obj = Instantiate (scrapPrefab, transform.position, transform.rotation) as GameObject;
						obj.transform.localPosition = new Vector3(enemy[i].x*MOVE, enemy[i].y*MOVE, -1);
						ScrapText.num++;
					}
					if (enemy[i].scrapFlag != true){
						GameObject.Destroy(enemyObj[i]);
						EnemyText.num--; 
						Score.score++;
						enemy[i].scrapFlag = true;
					}
					if (enemy[j].scrapFlag != true) {
						GameObject.Destroy(enemyObj[j]); 
						EnemyText.num--; 
						Score.score++;
						enemy[j].scrapFlag = true;
					}
				}
			}
		}
	}

	public void StageCrearJudge () {
		int i;
		for (i=0; i<enemyNum; i++) {
			if (enemy[i].scrapFlag == false) break;
		}
		if (i == enemyNum) {
			// StageCrear
			Score.score += Stage.stage;
			Stage.stage++;
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Scrap")) {
				GameObject.Destroy(obj);
			}
			Application.LoadLevel ("MainBord");
		}
	}

	public void GameOverJudge () 
	{
		for (int i=0; i<enemyNum; i++) {
			if (player.x == enemy[i].x && player.y == enemy[i].y){
				obj = Instantiate (gameoverPrefab, new Vector3(0.5f, 0.5f, -1), transform.rotation) as GameObject;
				StartCoroutine("Gameover");
			}
		}
	}

	IEnumerator Gameover () 
	{
		gameover = true;
		while (!Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.KeypadEnter)) { yield return 0; }
		Stage.stage = 1;
		if(HighScore.highScore < Score.score) {
			HighScore.highScore = Score.score;
		}
		Score.score = 0;
		Application.LoadLevel("MainBord");
	}

}
