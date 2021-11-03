using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    // CarPrefabを入れる
    public GameObject carPrefab;
    // CoinPrefabを入れる
    public GameObject coinPrefab;
    // TrafficConePrefabを入れる
    public GameObject conePrefab;

    // スタート地点
    private int startPos = 80;
    // ゴール地点
    private int goalPos = 360;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // 発展：Unityちゃんのオブジェクト
    private GameObject unitychan;
    // 発展：Unityちゃんとアイテム出現地点との距離
    private int distance= 50;
    // 発展：Unityちゃんが到達したらアイテムを出現させるz座標値の調整値
    private int item_interval = 0;


    // Start is called before the first frame update
    void Start()
    {
        // 発展：Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }


    // Update is called once per frame
    void Update()
    {

        // 以下、発展課題 //

        // Unityちゃんのz座標が15m進むごとに50m先にアイテムを出現させる
        // ただしstartPosより前、GoalPosより後にはアイテムを出現させない
        if ((unitychan.transform.position.z >= startPos - distance + item_interval) && (unitychan.transform.position.z <= goalPos - distance))
        {
            // 15m間隔でアイテムを出現させる
            this.item_interval += 15;

            // どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                // コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + distance);
                }
            }
            else
            {
                // レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    // アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    // アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    // 60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        // コイン生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + distance + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // 車生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + distance + offsetZ);
                    }
                }
            }
        }
    }

}
