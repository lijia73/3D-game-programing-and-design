using myGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

    public GameObject canvasPrefabs, scoreTextPrefabs, windTextPrefabs;
    private int score = 0, windDir = 0, windStrength = 0;

    private const float TIPS_SHOW_TIME = 0.5f;

    private GameObject canvas, scoreText, windText;
    private SceneController scene;
    private string[] windDirectionArray;

    // Use this for initialization
    void Start () {
        scene = SceneController.getInstance();
        scene.setGameStatueController(this);
        canvas = Instantiate(canvasPrefabs);
        scoreText = Instantiate(scoreTextPrefabs, canvas.transform);
        windText = Instantiate(windTextPrefabs, canvas.transform);

        //scoreText.transform.Translate(canvas.transform.position);
        //tipsText.transform.Translate(canvas.transform.position);
        //windText.transform.Translate(canvas.transform.position);

        scoreText.GetComponent<Text>().text = "得分: " + score;
        windDirectionArray = new string[8] { "北", "东北", "东", "东南", "南", "西南", "西", "西北" };
        changeWind();
    }

    public void changeWind()
    {
        windDir = UnityEngine.Random.Range(0,8);
        windStrength = UnityEngine.Random.Range(0, 8);
        windText.GetComponent<Text>().text = windDirectionArray[windDir] + "风 " + windStrength + " 级";
    }

    internal void addScore(int point)
    {
        score += point;
        scoreText.GetComponent<Text>().text = "得分: " + score;
        changeWind();
    }

    // Update is called once per frame
    void Update () {
		
	}

    internal int getWindDirec()
    {
        return windDir;
    }

    internal int getWindStrength()
    {
        return windStrength;
    }

}
