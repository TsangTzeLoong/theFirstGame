using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightLogic : MonoBehaviour{
    private Button attackBtn;
    [SerializeField]
    private Button healBtn;
    [SerializeField]
    private Button endBtn;
    [SerializeField]
    private Button quitBtn;
    [SerializeField]
    private CharacterAttributes characterAttributes;
    [SerializeField]
    private CharacterAttributes enmyAttributes;
}
