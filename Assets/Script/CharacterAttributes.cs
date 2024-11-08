using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewCharacterAttributes", menuName = "Character/Attributes")]
[System.Serializable]
public class CharacterAttributes{
    [SerializeField]
    private string characterName;
    public int level = 1;
    private Inventory inventory;
    public CharacterAttributes(){
        inventory = new Inventory();
    }
    //[SerializeField]
    private int health;
    public int Health{
        get{return health;}
        set{health = value;}
    }
    /// <summary>
    /// 暂定两种基础货币 金币和酒花
    /// </summary>
    //[SerializeField]
    private int coin;
    public int Coin{
        get{return coin;}
        set{coin = value;}
    }
    [SerializeField]
    private int beerFlower;
    public int BeerFlower{
        get{return beerFlower;}
        set{beerFlower = value;}
    }
    private int beer;
    public int Beer{
        get{return beer;}
        set{beer = value;}
    }
    ///  /* 
    /// 清醒程度每回合开始前回复一次，回复量基于醒酒速度，不同角色的回复量不同；被攻击后与生命值一起消耗；
    /// */
    [SerializeField] 
    private int sobriety = 100; // 清醒程度 //起到速度的作用 
    public int Sobriety{
        get{return sobriety;}
        set{sobriety = value;}
    }
    public float wakeUpSpeed = 10; // 醒酒速度 // 影响恢复清醒的速度
    [SerializeField]
    private int attackPower;
    public int AttackPower{
        get{return attackPower;}
        set{attackPower = value;}
    }
    public void UpdateAttributes(){
        beerFlower = TouchMonitor.pointCount;
        Health = level * 100 + beerFlower;
    }
    public void LevelUp(){
        level++;
        Debug.Log($"Current Level: {level}!");
    }
}