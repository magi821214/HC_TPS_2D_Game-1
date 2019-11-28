using UnityEngine;
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
    [Header("遊戲結束")]
    public static bool gameover;

    public Text textScore;
    
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

    }

    /// <summary>
    /// 生成水管。
    /// </summary>
    private void SpawnPipe()
    {
        print("生成水管");
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
    }

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0, 1.6f);
        //SpawnPipe();
    }
    
}
