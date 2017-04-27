using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject[] hazards;//enemy数据数组
    public Vector3 spawnValues;
    public int hazardCount;//enemy数量
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());//启动携程
    }
	IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);//初始等待时间
        while (true)
        {
            for (int i = 0; i < hazardCount;i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];//随机获取一个预设
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.y), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPos, spawnRotation);//实例预设
                yield return new WaitForSeconds(spawnWait);//等待spawnWait下一次
            }
            yield return new WaitForSeconds(waveWait);//结束一轮后等待waveWait重新开始
            if (gameOver)
            {
                restartText.text = "Press 'R' for restart";
                restart = true;
                break;
            }
        }
    }
	// Update is called once per frame
	void Update () {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("AirplaneBattle");
            }
        }
	}
    public void addScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
