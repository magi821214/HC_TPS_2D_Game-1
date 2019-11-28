public class Pipe : Ground
{
    private void Start()
    {
        //gameObject 此類別的遊戲物件(本身)
        //刪除(物件,延遲時間)
        //Destroy(gameObject,2);
    }

    //掛此類別的物件需要有元件： Mesh Renderer
    //在攝影機畫面外的時候會執行一次
    private void OnBecameInvisible()
    {
        Destroy(gameObject, 1f);
    }

    //在攝影機畫面內的時候會執行一次
    private void OnBecameVisible()
    {
        
    }
}
