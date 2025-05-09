using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager_Shabu : MonoBehaviour
{
    public static GameManager_Shabu instance;
    [SerializeField] private UiMenu userinterface;
    //public GameObject Intro;
    //public TMP_Text Coinhave;
    private bool IsGameStart = false;
    public GameObject SoupPrefab;
    public GameObject SpawnLocate;
    public GameObject BeefPrefab;
    public GameObject thisbeef;

    public int score = 0;
    public bool isDrag = false;
    private Vector3 screenPoint;

    [Space(10)]
    [Header("Soup Setting")]
    public float maxhightsoup = 0f;
    public float minhightsoup = -0.1f;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;
    private float speedrate;
    public bool forRefile;

    [Space(10)]
    [Header("Timer")]
    [SerializeField] private float baseTimer;//480;
    [SerializeField] private float currentTimer = 0;
    [SerializeField] private float currentTimerforsoup = 0;
    [SerializeField] private bool isCountTimer = false;

    private float rotanum = 0;

    Camera cam;
    public LayerMask layersToHit;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        cam = Camera.main;

        startPoint = 0;

        ResetTimer();
        IsGameStart = true;
        StartTimer();
        //Vector3.Distance(points[0].transform.position, points[1].transform.position);
        Debug.Log(Vector3.Distance(points[0].transform.position, points[1].transform.position));
        float destination = Vector3.Distance(points[0].transform.position, points[1].transform.position);
        speedrate = destination / baseTimer;
        Debug.Log(speedrate);
        Debug.Log(System.Math.Round(speedrate, 2));
        Debug.Log(StaticData.valueToKeep);
    }
    void Start()
    {
        /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        cam = Camera.main;
        
        startPoint = 0;

        ResetTimer();
        IsGameStart = true;
        StartTimer();
        //Vector3.Distance(points[0].transform.position, points[1].transform.position);
        Debug.Log(Vector3.Distance(points[0].transform.position, points[1].transform.position));
        float destination = Vector3.Distance(points[0].transform.position, points[1].transform.position);
        speedrate = destination / baseTimer;
        Debug.Log(speedrate);
        Debug.Log(System.Math.Round(speedrate, 2));
        Debug.Log(StaticData.valueToKeep);*/
    }

    // Update is called once per frame
    void Update()
    {
        /*currentTimerforRefile += Time.deltaTime;
        blend = Mathf.Pow(1f, currentTimerforRefile * 1f);*/
        if (userinterface.isPause() == false && IsGameReady() == true)
        {
            if(StaticData.valueToKeep == 0)
            {
                Update_Timer();
                Update_SoapDry();
            }
            if (IsTimesup())
            {
                currentTimer = 0;
                StopTimer();
            }
            if(forRefile)
            {
                //Low number go much Speed 
                float blend = Mathf.Pow(0.5f, 10 * 0.5f);
                SoupPrefab.transform.position = Vector3.Lerp(SoupPrefab.transform.position, points[startPoint].position, blend);
            }
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit,100, layersToHit))
                {
                    float getnum = GetRandomRotationMeat();
                    rotanum = getnum;
                    //Debug.Log(hit.transform.name);
                    //GameObject test = SpwaneBeef(hit.transform.position);
                    thisbeef = SpwaneBeef(hit.point);
                    thisbeef.transform.position = ray.GetPoint(0.95f);
                    thisbeef.transform.rotation = Quaternion.Euler(0.0f, rotanum, 0.0f);
                    thisbeef.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                    /*hit.collider.gameObject.transform.position = ray.GetPoint(4.0f);
                    hit.collider.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);*/
                    isDrag = true;
                }
            }
            if(isDrag)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                thisbeef.transform.position = ray.GetPoint(0.95f);
                thisbeef.transform.rotation = Quaternion.Euler(0.0f, rotanum, 0.0f);;
                thisbeef.transform.position = new Vector3(thisbeef.transform.position.x, 1.6f, thisbeef.transform.position.z);
                thisbeef.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
            if (Input.GetMouseButtonUp(0))
            {
                //Destroy(thisbeef);
                thisbeef = null;
                isDrag = false;
            }
        }
    }

    public bool IsGameReady()
    {
        return IsGameStart;
    }
    public GameObject SpwaneBeef(Vector3 loc)
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            Position.y = 1.5f;

            thisbeef = Instantiate(BeefPrefab, Position, Quaternion.identity);            
            //thisbeef = Instantiate(BeefPrefab, new Vector3(-9.35f, 1.65f, 6.49f), Quaternion.identity);
        }*/
        thisbeef = Instantiate(BeefPrefab, loc, Quaternion.identity);
        return thisbeef;
    }

    public void Update_SoapDry()
    {
        //0.001f * Time.fixedDeltaTime //60 Sec
        SoupPrefab.transform.position = Vector3.MoveTowards(SoupPrefab.transform.position, points[startPoint].position, speedrate * Time.deltaTime);
    }

    public void Update_SoapRefill()
    {
        startPoint = 1;
        //0.001f * Time.fixedDeltaTime //60 Sec
        float destination = Vector3.Distance(points[0].transform.position, points[1].transform.position);
        //SoupPrefab.transform.position = Vector3.MoveTowards(SoupPrefab.transform.position, points[startPoint].position, speed * Time.deltaTime /** Time.deltaTimeTime.fixedDeltaTime*/);
        //float blend = Mathf.Pow(0.5f, Time.deltaTime * speedrate);
        //float blend = Mathf.Pow(0.5f, currentTimerforRefile * speedrate);
        //SoupPrefab.transform.position = Vector3.Lerp(SoupPrefab.transform.position, points[startPoint].position, 2f);
        forRefile = true;
    }

    #region Timer
    public void ResetTimer()
    {
        //count up
        forRefile = false;
        currentTimerforsoup = 0;

        //count down
        currentTimer = baseTimer;
        float destination = Vector3.Distance(points[0].transform.position, points[1].transform.position);
        speedrate = destination / baseTimer;

        startPoint = 0;

        StartTimer();
    }

    public void StartTimer()
    {
        isCountTimer = true;
    }

    public void StopTimer()
    {
        isCountTimer = false;
    }

    public bool IsTimesup()
    {
        return currentTimer <= 0;
    }

    public bool IsTimerCounting()
    {
        return isCountTimer;
    }

    /*public float ResetTime()
    {
        return currentTimer = 0;
    }*/

    public void Update_Timer()
    {
        if (IsTimerCounting() == false)
            return;

        //Count up
        currentTimerforsoup += Time.deltaTime;

        //Count Down
        currentTimer -= Time.deltaTime;
    }

    public float GetCurrentTimer()
    {
        return currentTimer;
    }

    #endregion    

    public void Update_Score(int Newscore)
    {
        score += Newscore;
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public float GetRandomRotationMeat()
    {
        float[] numlst = { 0f, 30f, 45f, 60f};
        int num = Random.Range(0, numlst.Length - 1);
        return numlst[num];
    }
}
