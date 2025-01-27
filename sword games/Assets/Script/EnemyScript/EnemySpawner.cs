using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // スポーンさせる敵のプレハブ
    public Vector2 leftSpawnPoint = new Vector2(-9.5f, -8f);  // 左側のスポーンポイント
    public Vector2 rightSpawnPoint = new Vector2(9.5f, -8f);  // 右側のスポーンポイント
    public float spawnInterval;  // スポーン間隔

    private GameObject currentEnemy;  // 現在の敵を管理

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        // 現在の敵がいない場合のみスポーン
        if (currentEnemy == null)
        {
            // 左右ランダムにスポーン位置を選択
            bool spawnOnLeft = Random.value > 0.5f;
            Vector2 spawnPosition = spawnOnLeft ? leftSpawnPoint : rightSpawnPoint;

            // 敵を生成
            currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // 移動速度をランダムに設定
            float randomSpeed = Random.Range(6f, 8f); // 速度を6～8の範囲でランダムに決定

            // EnemyMovement に速度と方向を設定
            EnemyMovement enemyMovement = currentEnemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.speed = randomSpeed;
                enemyMovement.isLeftSpawn = spawnOnLeft;  // スポーン元を渡す
            }
        }
    }

    public void OnEnemyDestroyed()
    {
        // 敵が破壊されたら管理をリセット
        currentEnemy = null;
    }
}
