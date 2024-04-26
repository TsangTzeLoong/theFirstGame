using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePrefab : MonoBehaviour
{
    public GameObject _prefabToGenerate;
    public Transform _parentObj;
    [SerializeField]
    private Button _copyBtn;
    public void GenerateAndCopyPrefab(){
        GameObject newPrefab = Instantiate(_prefabToGenerate, _parentObj);

        if(_parentObj != null){
            newPrefab.transform.SetParent(_parentObj);
        }
    }
    void Start()
    {
        _copyBtn.onClick.AddListener(GenerateAndCopyPrefab);
    }

    void Update(){

    }
}
