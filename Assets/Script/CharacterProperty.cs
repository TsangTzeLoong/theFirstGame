using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty: MonoBehaviour
{
    public enum CP{
        Name,
        Level,
        Damage,
        Healty
    }
    public class CPro{
        string Name;
        int Level;
        float Damage;
        float Healty;
    }
    public Dictionary<CP, CPro> CPD;
    void Start(){
        
    }

    void Update()
    {
        
    }
}
