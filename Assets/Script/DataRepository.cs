using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRepository : MonoBehaviour{
    private static DataRepository instance;
    public static DataRepository Instance{
        get{
            if(instance == null){
                GameObject go = new GameObject("DataRepository");
                instance = go.AddComponent<DataRepository>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    [SerializeField]
    private CharacterAttributes characterAttributes;
    public CharacterAttributes CharacterAttributes{
        get{return characterAttributes;}
        set{characterAttributes= value;}
    }
    void Awake(){
        if (characterAttributes == null){
            characterAttributes = new CharacterAttributes();
            Debug.Log($"{characterAttributes} been new");
        }
    }
}