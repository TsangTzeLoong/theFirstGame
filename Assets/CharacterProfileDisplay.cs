using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterProfileDisplay : MonoBehaviour{
    [SerializeField]
    private TMP_Text txt;
    [SerializeField]
    private TMP_Text playerNameDisplay;
    [SerializeField]
    private string inputMCName;
    private int beerFlowerCounts = TouchMonitor.pointCount;
    void Start(){
        ProfileInfoUpdate();
    }
    private void ProfileInfoUpdate() {
        txt.text = beerFlowerCounts.ToString();
        playerNameDisplay.text = inputMCName;
    }
    void Update(){
        
    }
}
