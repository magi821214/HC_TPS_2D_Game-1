using UnityEngine;

public class LearnIF : MonoBehaviour
{
    public bool test;
    public string prop;
    public int _HP=100;
    //一秒執行60次
    private void Update()
    {
        #region 練習if 
        //if (test)
        //{
        //    print("打開開關~");
        //}
        //else
        //{
        //    print("~關掉囉");
        //}
        if (_HP >= 70)
        {
            print("安全");
        }
        else if (_HP >= 50 && _HP < 70)
        {
            print("警告");
        }
        else if (_HP >= 20 && _HP < 50)
        {
            print("危險");
        }
        else if (_HP > 0 && _HP < 20)
        {
            print("快死了");
        }
        else if (_HP <= 0)
        {
            print("你死了");
        }
        else
        {
            print("??????");
        }
        #endregion

    }
}
