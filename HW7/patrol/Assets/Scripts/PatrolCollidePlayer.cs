using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCollidePlayer : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            // 当玩家与巡逻兵相撞
            this.GetComponent<Animator>().SetTrigger("attack");
            Singleton<GameEventManager>.Instance.OnPlayerCatched();
            Debug.Log("collide with player");
        } else {
            // 当巡逻兵碰到其他障碍物
            this.GetComponent<PatrolData>().isCollided = true;
            Debug.Log("collide with wall");
        }
    }
}