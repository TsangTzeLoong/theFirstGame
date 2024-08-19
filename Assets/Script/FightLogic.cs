using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightLogic : MonoBehaviour{
    [SerializeField]
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
    //SceneController sc = new SceneController();
    void Start(){
        attackBtn.onClick.AddListener(GameLogicMonitor);
        healBtn.onClick.AddListener(GameLogicMonitor);

        attackBtn.onClick.AddListener(AttackBtnOnClick);
        healBtn.onClick.AddListener(HealBtnOnClick);

        endBtn.onClick.AddListener(RoundEndBtnOnClick);

        quitBtn.onClick.AddListener(QuitBtnOnClick);

        //TimeMonitor();
    }
    private void AttackBtnOnClick(){
        if(characterAttributes.wallet > 0){
            characterAttributes.wallet -= 1;
            enmyAttributes.Health -= 10;
            enmyAttributes.sobriety -= 10;
        }
        else {
            characterAttributes.Health -= 10; // 没钱时 攻击自己
            Debug.Log("NO MONEY!!!");
        }
    }
    private void HealBtnOnClick(){
        characterAttributes.sobriety -= 10; // 消耗清醒值来充钱
        if(characterAttributes.wallet <= 0){
            characterAttributes.wallet += 5;
        }
        else {
            Debug.Log($"U still have {characterAttributes.wallet} in ur wallet!");
        };
    }
    private void RoundEndBtnOnClick(){
        RoundEnd();
    }
    void TimeMonitor(){
        RoundEnd();
        float t = 1000f;
        while(t>0){
            t -= Time.deltaTime;
            //Debug.Log("time up");
        }
        if(t<=0){
            Debug.Log("time up");
        }
        //t<= 0: break;
    }
    void RoundEnd(){
        EnmyAction();
        RoundEndAutoHeal();
        Debug.Log("Round End");
    }
    void EnmyAction(){
        characterAttributes.Health -= 10;
        Debug.Log("Attack From Enmy!!!");
    }
    void RoundEndAutoHeal(){
        characterAttributes.sobriety += 10; // 结束回合 醒酒一次
    }
    private void GameLogicMonitor(){
        HealthMonitor();
        SobrietyMonitor();
    }
    void HealthMonitor(){
        if(enmyAttributes.Health <= 0 || characterAttributes.Health <= 0){
            Debug.Log("game over!");
            QuitBtnOnClick();
        }
    }
    void SobrietyMonitor(){
        if(enmyAttributes.sobriety <= 0){
            Debug.Log("game over!");
        }
    }
    void QuitBtnOnClick(){
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.UnloadSceneAsync(currentScene);
        Debug.Log($"Unloading Current Scene: {currentScene}");
        //SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadSceneAsync(0);
    }
    private void OnDestroy() {
        attackBtn.onClick.RemoveAllListeners();
        healBtn.onClick.RemoveAllListeners();
        endBtn.onClick.RemoveListener(RoundEndBtnOnClick);
    }
}
