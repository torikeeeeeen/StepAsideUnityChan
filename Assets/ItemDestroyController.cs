using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyController : MonoBehaviour
{

    // Unityちゃんのオブジェクト
    private GameObject unitychan;
    //UnityちゃんとItemDestroyLineの距離
    private float difference;


    // Start is called before the first frame update
    void Start()
    {
        // Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        // UnityちゃんとItemDestroyLine位置の差（z座標）を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてItemDestroyLineを移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    // Unityちゃんの後ろに設置したItemDestroyLineに衝突したオブジェクトを破壊
    void OnTriggerEnter(Collider other)
    {
        // オブジェクトに衝突した場合
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            // 接触したオブジェクトを破壊
            Destroy(other.gameObject);
        }
    }

}
