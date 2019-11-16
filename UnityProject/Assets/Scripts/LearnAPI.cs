using UnityEngine;

public class LearnAPI : MonoBehaviour
{
    public Transform TransformA;
    public Transform TransformB;
    public Camera cam;
    public AudioSource AudioS;

    private void Start()
    {
        //print(Random.value);
        print("PI : " + Mathf.PI);
        Camera.main.depth = Camera.main.depth + 5;
        print(Random.Range(1, 500));

        print("物件A的座標 : " + TransformA.position);
        //TransformA.position = new Vector3(-1,1,0);
        //TransformA.Rotate(0,0,1);
        if (AudioS.isPlaying)
        {
            AudioS.playOnAwake = false;
            print("遊戲音效 : " + TransformA.position);
        }
        else
        {
            AudioS.playOnAwake = true;
        }

        print("攝影機深度 : " + cam.depth);
    }
    private void Update()
    {
        TransformA.position = new Vector3(-1, 1, 0);
        TransformA.Rotate(0, 1, 1);
    }
}
