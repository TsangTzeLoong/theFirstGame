using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterAttributes", menuName = "Character/Attributes")]
public class CharacterAttributes : Skill{
    //[SerializeField]
    public string characterName;
    [SerializeField]
    private int level = 1;
    private int health;
    public int Health{
        get{return health;}
        set{health = value;}
    }
    public float wallet = 5; // 金钱 // 起到蓝量的作用
    ///  /* 
    /// 清醒程度每回合开始前回复一次，回复量基于醒酒速度，不同角色的回复量不同；被攻击后与生命值一起消耗；
    /// */
    public float sobriety = 100; // 清醒程度 //起到速度的作用 
    public float wakeUpSpeed = 10; // 醒酒速度 // 影响恢复清醒的速度
    //[SerializeField]
    public int attack;
    public int beerFlowerCounts = TouchMonitor.pointCount;
    //public Skill _skill;
    private void Awake(){
        Health = level * 100;
        attack = 10 + beerFlowerCounts*10;
    }
}
public class Skill: ScriptableObject{
    public int att;
    public int abcc{get; set;}
}