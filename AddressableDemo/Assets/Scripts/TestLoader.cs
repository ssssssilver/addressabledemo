using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class TestLoader : MonoBehaviour
{
    [SerializeField]
    private AssetReference assetReference;
    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<Texture>("cat").Completed += (handle) =>
        {
            Texture texture = handle.Result;
            Debug.Log(texture.name);
        };
        Addressables.InstantiateAsync("cube").Completed += (handle) =>
        {
            GameObject cube = handle.Result;
            cube.name = "cube";
        };
        assetReference.LoadAssetAsync<GameObject>().Completed += (handle) =>
        {
            Instantiate(handle.Result);
        };
    }


    // Update is called once per frame
    void Update()
    {

    }
}
