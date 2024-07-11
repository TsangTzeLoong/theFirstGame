using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InitialLoad : MonoBehaviour
{
    public AssetReference persistenScene;
    private void Awake() {
        Addressables.LoadSceneAsync(persistenScene);
    }
}
