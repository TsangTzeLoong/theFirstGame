using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterAttributes", menuName = "Character/Attributes")]
public class CharacterAttributes : Skill{
    public string characterName = "defaultName";
    public int level = 1;
    public int health = 100; // 剩余酒量 // 起到生命值的作用 消耗完就再也喝不动了
    public float wallet = 5; // 金钱 // 起到蓝量的作用
    ///  /* 
    /// 清醒程度每回合开始前回复一次，回复量基于醒酒速度，不同角色的回复量不同；被攻击后与生命值一起消耗；
    /// */
    public float sobriety = 100; // 清醒程度 //起到速度的作用 
    public float wakeUpSpeed = 10; // 醒酒速度 // 影响恢复清醒的速度
    public int attack;
    //public Skill _skill;
}
public class Skill: ScriptableObject{
    public int att;
    public int abcc{get; set;}
}