using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, UserAction
{

    public int round;
    public int trial;
    public float interval;
    public int score;
    public UserGUI userGUI;

    private Queue<GameObject> disksQueue = new Queue<GameObject>();
    public Ruler ruler;
    public CCActionManager actionManager;
    public ScoreRecorder scoreRecorder;

    //public DiskFactory diskFactory;

    void Awake()
    {
        Director director = Director.GetInstance();
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
    }

    public void LoadResources()
    {
        actionManager = gameObject.AddComponent<CCActionManager>() as CCActionManager;
        this.gameObject.AddComponent<DiskFactory>();
        ruler = new Ruler();
        scoreRecorder = new ScoreRecorder();
    }

    // Use this for initialization
    void Start()
    {
        round = 1;
        interval = 0;
        trial = 0;
        getDisksForNextRound();
        userGUI.targetThisRound = ruler.getTargetThisRound(round);
    }

    // Update is called once per frame
    void Update()
    {
        if (round != -1&&ruler.enterNextRound(round, scoreRecorder.score))
        {
            round++;
            trial = 0;
            getDisksForNextRound();
            userGUI.score = this.score = 0;
            scoreRecorder.reset();
            userGUI.targetThisRound = ruler.getTargetThisRound(round);
        }
        else if (round != -1&&!ruler.enterNextRound(round, scoreRecorder.score) && trial == 11)
        {
            round = -1;
        }

        if (this.round >= 1)
        {
            if (interval > ruler.setInterval(round))
            {
                if (trial < 10)
                {
                    throwDisk();
                    interval = 0;
                    trial++;
                }
                else if (trial == 10)
                {
                    trial++;
                }
            }
            else
            {
                interval += Time.deltaTime;
            }
        }

        userGUI.round = this.round;
    }

    public void throwDisk()
    {
        if (disksQueue.Count != 0)
        {
            GameObject disk = disksQueue.Dequeue();
            ruler.setDiskProperty(disk, round);
            disk.SetActive(true);
            actionManager.diskFly(disk, disk.GetComponent<DiskData>().angle, disk.GetComponent<DiskData>().power);
        }
    }

    public void getDisksForNextRound()
    {
        DiskFactory diskFactory = Singleton<DiskFactory>.Instance;
        int numDisk = 10;
        for (int i = 0; i < numDisk; i++)
        {
            GameObject disk = diskFactory.GetDisk(round);
            disksQueue.Enqueue(disk);
        }
    }

    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.gameObject.GetComponent<DiskData>() != null)
            {
                //Debug.Log("hit");
                hit.collider.gameObject.SetActive(false);

                scoreRecorder.record(hit.collider.gameObject);
                userGUI.score = scoreRecorder.score;
            }
        }
    }

    public void restart()
    {
        Debug.Log("restart");
        round = 1;
        userGUI.round = 1;
        score = 0;
        userGUI.score = 0;
        scoreRecorder.reset();
        interval = 0;
        trial = 0;
        getDisksForNextRound();
        userGUI.targetThisRound = ruler.getTargetThisRound(round);
    }

}