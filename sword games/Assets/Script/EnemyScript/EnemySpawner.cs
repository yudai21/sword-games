using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // スポーンさせる敵のプレハブ
    public float spawnInterval = 2f; // 敵をスポーンさせる間隔（秒）
    
    // 手動で指定する出現ポイント
    public Vector2 leftSpawnPoint = new Vector2(-9.5f, -8f); // 左側の座標
    public Vector2 rightSpawnPoint = new Vector2(9.5f, -8f);  // 右側の座標

    void Start()
    {
        // 一定時間ごとに敵をスポーンさせる
        InvokeRepeating("TrySpawnEnemy", spawnInterval, spawnInterval);
    }

    void TrySpawnEnemy()
    {   
        {
            // ランダムに左側か右側にスポーンさせる
            Vector2 spawnPosition = Random.value > 0.5f ? leftSpawnPoint : rightSpawnPoint;

            // 選ばれた位置に敵を生成
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // 敵が破壊されたときに呼ばれるメソッド
    public void OnEnemyDestroyed()
    {
        
    }
}
