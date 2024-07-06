using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Stage1Scene_PointScript : MonoBehaviour
{
    public bool isDead = false;

    [SerializeField]
    private GameObject pointGameObject;

    [SerializeField]
    private List<GameObject> items;

    private List<GameObject> genItems = new List<GameObject>();

    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject movie;

    [SerializeField]
    private TMP_Text countText;

    private bool isNext = true;

    private GameObject newItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            gameOverCanvas.SetActive(true);
            movie.GetComponent<VideoPlayer>().Pause();

            return;
        }

        //マウスの座標を取得する
        Vector3 mousePos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換する
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        pos.y = transform.position.y;
        //ワールド座標をゲームオブジェクトの座標に設定する
        transform.position = pos;

        if (newItem == null)
        {
            CreateNewItem();
        }
 
        bool isLeftLoop = Input.GetMouseButton(0);

        if (newItem != null && isLeftLoop)
        {
            newItem.transform.position = transform.position;
        }

        bool isLeftUp = Input.GetMouseButtonUp(0);

        // 左クリック / スマホのタップされていたら実行
        if (!Stage1Scene_SceneParameter.isTryAgain && newItem != null && isNext && isLeftUp)
        {
            isNext = false;
            newItem.GetComponent<Rigidbody2D>().isKinematic = false;
            newItem.GetComponent<PolygonCollider2D>().enabled = true;

            CreateNewItem();

            StartCoroutine(ChangeIsNextCoroutine());
        }

        if (isLeftUp)
        {
            Stage1Scene_SceneParameter.isTryAgain = false;
        }
    }

    private void CreateNewItem()
    {
        GameObject randomObject = items[Random.Range (0, items.Count)];
        newItem = (GameObject)Instantiate(
            randomObject,
            pointGameObject.transform.position,
            pointGameObject.transform.rotation
        );
        newItem.GetComponent<Rigidbody2D>().isKinematic = true;
        newItem.GetComponent<PolygonCollider2D>().enabled = false;
        genItems.Add(newItem);

        countText.text = genItems.Count.ToString();
    }

    private IEnumerator ChangeIsNextCoroutine()
    {
        yield return new WaitForSeconds(1);

        isNext = true;
    }
}
