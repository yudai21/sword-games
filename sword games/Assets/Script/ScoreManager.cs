using UnityEngine;
using UnityEngine.UI;  // Textを使うために必要
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // シングルトンインスタンス

    private int score = 0; // 現在のスコア
    public int scoreTowin = 10; // 必要なスコア

    public Text scoreText; // スコアを表示するTextオブジェクト
    public string gameclearSceneName = "GameClear";

    void Awake()
    {
        // シングルトンの設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンが変わっても保持
        }
        else
        {
            Destroy(gameObject); // 新しいインスタンスが作成されたら前のインスタンスを破棄
        }
        
        // シーン切り替え時にスコアをリセットする処理
        ResetScore();
    }

    void Start()
    {
        // スコアUIを更新
        UpdateScoreUI();
    }

    void OnEnable()
    {
        // シーンがロードされた際にスコアUIを再設定
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // イベントの解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // シーンがロードされた際の処理
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 新しいシーンでスコアテキストを再取得
        scoreText = FindObjectOfType<Text>();
        ResetScore(); // スコアリセット
        UpdateScoreUI(); // スコアUIを更新
    }

    // スコアを加算するメソッド
    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Current Score: {score}");

        UpdateScoreUI(); // スコアUIを更新

        // クリア条件チェック
        if (score >= scoreTowin)
        {
            Debug.Log("You Win!");
            // クリア時の処理（必要ならシーン切り替えなど）
            SceneManager.LoadScene(gameclearSceneName);
        }
    }

    // スコアUIを更新
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score}/{scoreTowin}";
        }
    }

    // スコアをリセット
    private void ResetScore()
    {
        score = 0; // スコアをゼロにリセット
    }
}
