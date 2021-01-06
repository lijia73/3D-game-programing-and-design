﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AITANKGAME;

public class Controller : MonoBehaviour, IUserAction, ISceneController
{
    public GameObject player;
    public GameState gameState;
    public Factory factory;
    public SSDirector director;
    public int MAX_NPC_COUNT = 3;
    public int NPCCount;
    public UserGUI userGUI;
    public GameEventManager gameEventManager;
    public float moveSpeed = 15f;
    public float rotateSpeed = 90f;
    public float speed = 5; 
    public float angularSpeed=0.01f;
    public 

    void Start()
    {
        director = SSDirector.getInstance();
        director.CurrentSceneController = this;
        gameEventManager = gameObject.AddComponent<GameEventManager>() as GameEventManager;
        factory = gameObject.AddComponent<Factory>() as Factory;
        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
        gameState = GameState.Start;
        NPCCount = MAX_NPC_COUNT;
    }

    public void SetDifficulty(int num) {
        NPCCount=num;
    }

    public void StartGame() {
        gameState = GameState.Play;
        LoadResources();
        CameraController cc = gameObject.AddComponent<CameraController>() as CameraController;
        cc.player = player;
    }

    public void RestartGame() {
        gameState = GameState.Play;
        NPCCount = MAX_NPC_COUNT;
        //重置 player
        player.SetActive(true);
        player.GetComponent<Player>().reset();
        //将 NPC 全部回收
        factory.reset();
        LoadNPCs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() {
        //订阅事件
        GameEventManager.OnNPCDead += OnNPCDead;
        GameEventManager.OnPlayerDead += OnPlayerDead;
    }

    void OnDisable() {
        GameEventManager.OnNPCDead -= OnNPCDead;
        GameEventManager.OnPlayerDead -= OnPlayerDead;
    }

    public void LoadResources() {
        player = Instantiate(Resources.Load<GameObject>("Prefabs/player"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        LoadNPCs();
    }

    public void LoadNPCs() {        
        for (int i = 0; i < NPCCount; ++i) {
            factory.getTank();
        }
    }

    public void MovePlayer(float translationX, float translationZ){
         //朝一个方向移动 new Vector3(0, 0, v) * speed * Time.deltaTime是个向量
        player.transform.Translate(new Vector3(0, 0, translationZ) * moveSpeed * Time.deltaTime);　　//前后移动
        player.transform.Rotate(new Vector3(0, translationX, 0) * rotateSpeed * Time.deltaTime);　//左右旋转
        //player.transform.LookAt(new Vector3(player.transform.position.x + translationX, player.transform.position.y, player.transform.position.z + translationZ));
        //Rigidbody rigidbody =player.GetComponent<Rigidbody>();
        //rigidbody.velocity = transform.forward * translationZ * speed;
        //rigidbody.angularVelocity = transform.up*translationX * angularSpeed;
    }

    public void PlayerShoot() {
        GameObject bullet = factory.getBullet("Player");
        bullet.transform.position = new Vector3(player.transform.position.x, 0.76f, player.transform.position.z) + player.transform.forward*3.683f;
        bullet.transform.forward = player.transform.forward;
        bullet.GetComponent<Bullet>().playFire();
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bullet.transform.forward * 200, ForceMode.Impulse);
    }

    public Vector3 getPlayerPosition() {
        return player.transform.position;
    }

    public void OnNPCDead(GameObject npc) {
        NPCCount --;
        if(NPCCount <= 0) {
            Win();
        }
    }

    public void OnPlayerDead() {
        Lose();
    }

    public void Win() {
        gameState = GameState.Win;
    }

    public void Lose() {
        gameState = GameState.Lose;
    }

    public GameState GetGameState() {
        return gameState;
    }
}
