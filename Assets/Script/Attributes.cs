using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Attributes : MonoBehaviour{
    [SerializeField]
    private string characterName;
    [SerializeField]
    private int level = 1;
    private int health;
    private int attackPower;
    private int beerFlowerCounts = TouchMonitor.pointCount;
    public int Health{
        get{return health;}
        set{health = value;}
    }
    public int AttackPower{
        get{return attackPower;}
        set{attackPower = value;}
    }
    private void UpdateAttributes(){
        Health = level * 100;
        AttackPower = 10 + beerFlowerCounts * 10;
    }
    private void Awake(){
        LoadData();
        UpdateAttributes();
    }
    public void LevelUp(){
        level++;
        UpdateAttributes();
        SaveData();
    }
    /// <summary>
    /// gpt给的savedata方法，把属性序列化为json
    /// </summary>
    void SaveData(){
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(Application.persistentDataPath + "characterData.json", json);
        Debug.Log(Application.persistentDataPath);
    }
    void LoadData(){
        string path = Application.persistentDataPath + "character.json";
        Debug.Log(path);
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else{
            Debug.Log($"path {path} doesnt exists! check the file plz");
        }
    }
    void OnApplicationQuit(){
        SaveData();
    }
    
}
