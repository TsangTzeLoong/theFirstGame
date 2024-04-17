using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingSystem : MenuController{
private float _blood = 0;
public Slider slider; // 引用血条的 Slider 组件
[SerializeField]
private Button _testBtn;
[SerializeField]
private Button _damageBtn;
    void Start(){
        slider = GetComponent<Slider>();
        _testBtn.onClick.AddListener(Test);
        _damageBtn.onClick.AddListener(Damage);
    }

    private void Damage(){
        _blood -= 5;
        Debug.Log($"_blood: {_blood}");
        if(_blood < 5){
            ExitGame();
        }
    }
    /// <summary>
    /// function for test 
    /// </summary>
    private void Test(){
        slider.value = 100;
        _blood = 100;
        Debug.Log($"value: {slider.value}");
    }
    void Update(){
       _blood += Time.deltaTime;
       _blood = Mathf.Clamp(_blood, 0, 100);
       slider.value = _blood / 100;
    }
}
