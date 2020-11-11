using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicActionManager : MonoBehaviour,IActionManager
{
    //private List<GameObject> disks = new List<GameObject>();
    public FirstController scene_controller;             //当前场景的场景控制器

    protected void Start()
    {
        scene_controller = (FirstController)Director.GetInstance().currentSceneController;
        scene_controller.actionManager = this;
    }

    // protected void FixUpdate(){
    //     for(int i=0;i<disks.Count;i++){
    //         if(disks[i].activeSelf==false)disks.Remove(disks[i]);
    //         if (disks[i].transform.position.y < -10 || disks[i].transform.position.y > 10)
    //         {
    //             disks[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
    //             disks.Remove(disks[i]);
    //         }
    //     }
    //     Debug.Log(disks.Count);
    // }

    //飞碟飞行
    public void diskFly(GameObject disk, float angle, float power)
    {
        //disks.Add(disk);
        Vector3 v = Quaternion.Euler(new Vector3(0, 0, angle)) * Vector3.right * power * 5;
        disk.GetComponent<Rigidbody>().velocity=v;
        disk.GetComponent<Rigidbody>().useGravity = false;
    }
}