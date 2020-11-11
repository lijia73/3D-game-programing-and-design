using myGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    public GameObject TargetPrefabs, ArrowPrefabs;
    private GameObject holdingArrow, target;
    private ArrowFlyActionManager actionManager;
    private const int SPEED = 35;
    private SceneController scene;
    private Vector3[] winds = new Vector3[8]
    {
        new Vector3(0, 1, 0), new Vector3(1,1,0), new Vector3(1,0,0), new Vector3(1,-1,0), new Vector3(0,-1,0), new Vector3(-1,-1,0), new Vector3(-1,0,0), new Vector3(-1,1,0)
    };

    private void Awake()
    {
        ArrowFactory.getInstance().init(ArrowPrefabs);
    }

    // Use this for initialization
    void Start () {
        scene = SceneController.getInstance();
        scene.setArrowController(this);
        target = Instantiate(TargetPrefabs);
        actionManager = gameObject.AddComponent<ArrowFlyActionManager>() as ArrowFlyActionManager;
	}
	
	// Update is called once per frame
	void Update () {
        ArrowFactory.getInstance().detectArrowsReuse();
	}

    public bool ifReadyToShoot()
    {
        return (holdingArrow != null);
    }

    internal void getArrow()
    {
        if (holdingArrow == null) holdingArrow = ArrowFactory.getInstance().getArrow();
    }

    internal void moveArrow(Vector3 mousePos)
    {
        //箭头跟随鼠标移动
        holdingArrow.transform.LookAt(mousePos * 30);
    }

    internal void shootArrow(Vector3 mousePos)
    {
        int windDir = scene.getWindDirection();
        int windStrength = scene.getWindStrength();
        Vector3 wind = winds[windDir]*windStrength;
        actionManager.ArrowFly(holdingArrow, wind, mousePos * 30);
        holdingArrow = null;
    }

    private void addWind()
    {
        int windDir = scene.getWindDirection();
        int windStrength = scene.getWindStrength();
        Vector3 windForce = winds[windDir];
        holdingArrow.GetComponent<Rigidbody>().AddForce(windForce, ForceMode.Force);
    }
}
