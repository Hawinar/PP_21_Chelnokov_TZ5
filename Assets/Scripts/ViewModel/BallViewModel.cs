using System.Collections;
using UnityEngine;

public class BallViewModel : MonoBehaviour
{
    private PlayerModel player;
    private WaitForSeconds _seconds = new WaitForSeconds(0.1f);
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerModel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        Debug.Log(this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        if(GameManager.FirstGameObject == null)
        {
            GameManager.FirstGameObject = gameObject;
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
        if(GameManager.LastGameObject == null && GameManager.FirstGameObject != this.gameObject)
        {
            GameManager.LastGameObject = gameObject;
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            if (GameManager.FirstGameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == GameManager.LastGameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                player.ChangeScore(2);
                StartCoroutine(ChangeScale(GameManager.FirstGameObject));
                StartCoroutine(ChangeScale(GameManager.LastGameObject));
            }
            else
            {
                GameManager.LastGameObject.transform.localScale = GameManager.FirstGameObject.transform.localScale = new Vector2(0.33f, 0.33f);
                GameManager.LastGameObject = GameManager.FirstGameObject = null;
            }   
        }
    }

    private IEnumerator ChangeScale(GameObject targetObject)
    {
        for (float scale = targetObject.transform.localScale.x; scale >= 0; scale -= 0.05f)
        {
            targetObject.transform.localScale = new Vector2(scale, scale);
            yield return _seconds;
        }
        Destroy(targetObject);
    }
}
