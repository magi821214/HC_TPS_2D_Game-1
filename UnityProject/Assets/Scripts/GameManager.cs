using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("目前分數")]
    public int score;
    [Header("最高分數")]
    public int scoreHeight;
    [Header("水管")]
    //GameObject 可以存放場景上的遊戲物件和專案內的預製物
    public GameObject pipe;
    [Header("遊戲結算畫面")]
    public GameObject goFinal;

    //靜態的值在load不會一起更新。static 不會顯示在unity屬性介面上
    [Header("遊戲結束")]
    public static bool gameover;
    [Header("分數介面")]
    public Text textScore;
    public Text textBest;

    // 修飾詞權限：
    // private 其他類別無法使用
    // public 其他類別可以使用

    /// <summary>
    /// 加分。
    /// </summary>
    public void AddScore()
    {
        print("加分");
        score++;
        textScore.text = score.ToString();
        if ((score % 3) == 0)
        {
            textScore.fontSize = textScore.fontSize + 20;
            textScore.color = Color.red;
        }
        else
        {
            textScore.fontSize = 100;
            textScore.color = Color.white;
        }
    }
    
    /// <summary>
    /// 最高分數判定。
    /// </summary>
    private void HeightScore()
    {
        //PlayerPrefs => 單機資料存取
        if(PlayerPrefs.GetInt("最佳分數") < score)
            PlayerPrefs.SetInt("最佳分數", score);
    }

    /// <summary>
    /// 生成水管。
    /// </summary>
    private void SpawnPipe()
    {
        //print("生成水管");
        float y = Random.Range(-0.8f, 1.2f);
        Vector3 pos = new Vector3(Random.Range(0, 2), y, 0);
        //Quaternion.identity 代表零角度;
        Instantiate(pipe, pos, Quaternion.identity);
    }

    /// <summary>
    /// 遊戲失敗。
    /// </summary>
    public void GameOver()
    {
        goFinal.SetActive(true);//顯示結算畫面
        gameover = true;
        CancelInvoke("SpawnPipe"); //停止 InvokeRepeating、 Invoke的方法
        HeightScore();
        textBest.text = PlayerPrefs.GetInt("最佳分數").ToString();
    }
    /// <summary>
    /// 重置遊戲。
    /// </summary>
    public void Replay()
    {
        //舊版寫法
        //Application.LoadLevel("遊戲場景");//載入場景 可當作下一關或重新載入關卡
        SceneManager.LoadScene("遊戲場景");
    }
    /// <summary>
    /// 遊戲離開。
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    //遊戲開始與載入場景會執行一次
    private void Start()
    {
        // Switch to 720 x 1280 windowed  螢幕.設定解析度(寬,高,是否全螢幕)
        Screen.SetResolution(450, 800, false);

        //靜態成員在載入場景時不會還原
        gameover = false;
        InvokeRepeating("SpawnPipe", 0, 1.6f);
        //SpawnPipe();
       textBest.text = PlayerPrefs.GetInt("最佳分數").ToString();
    }
    
}
