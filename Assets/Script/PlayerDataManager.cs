using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager _inter;
    public static PlayerDataManager inter
    {
        get
        {
            if (_inter == null)
            {
                GameObject obj = new GameObject();
                obj.name = "PlayerDataManger";
                _inter = obj.AddComponent<PlayerDataManager>();
                DontDestroyOnLoad(obj);
                _inter.Load();
            }
            return _inter;
        }
    }

    private int _meat;
    private int _unlock;

    //public int _ScoreRingTossInbottle;
    public int _ScoreMeat;
    public int _FinalScore;

    // Start is called before the first frame update
    void Start()
    {
        _FinalScore = PlayerPrefs.GetInt("FinalScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int meat
    {
        get { return _meat; }
        set
        {
            SetValidate(ref _meat, value);
        }
    }

    public int ScoreMeat
    {
        get { return _ScoreMeat; }
        set
        {
            SetRingTossScoreValidate(ref _ScoreMeat, value);
        }
    }

    protected void SetValidate(ref int currentValue, int newValue)
    {
        int curValue = newValue;
        curValue = curValue < 0 ? 0 : curValue;

        //int oldValue = currentValue;
        currentValue = curValue;
        Save();
    }

    protected void SetRingTossScoreValidate(ref int currentValue, int newValue)
    {
        int curValue = newValue;
        curValue = curValue < 0 ? 0 : curValue;

        //int oldValue = currentValue;
        currentValue = curValue;
        SaveRingTossScore();
    }

    public void Load()
	{
        //_gold = PlayerPrefs.GetInt("PlayerGold");
        //lastlocate = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
    }

    public void Save()
	{
        PlayerPrefs.SetInt("EatMeat", _meat);
    }

    public void SaveRingTossScore()
    {
        PlayerPrefs.SetInt("ScoreMeat", _ScoreMeat);
#if UNITY_EDITOR
        Debug.Log($"||ScoreMeat: {_ScoreMeat} || EatMeat: {_meat}");
#endif
    }

    public void SaveFinalScore()
    {

    }

    public void Reset()
    {
        PlayerPrefs.SetInt("ScoreMeat", 0);
        PlayerPrefs.SetInt("ScoreHaveMeat", 0);
        PlayerPrefs.SetInt("GameAlredayStart", 0);
        Debug.Log("Reset Complete");
    }
}
