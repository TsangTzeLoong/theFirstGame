using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFile: MonoBehaviour{
    [SerializeField]
    public string Profession{get; set;}
    public int Health{get; set;}
    public int Attack{get; set;}
    // public DataFile(string profession, int health, int attack){
    //     Profession = profession;
    //     Health = health;
    //     Attack = attack;
    // }

    void Start(){
        
    }
}
