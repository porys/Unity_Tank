using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

    GameObject goShell = null;
    bool action = false;
	// Use this for initialization
	void Start () {
        goShell = transform.FindChild("Tank_Shell").gameObject;
        goShell.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                if (collition2d.gameObject == gameObject)
                {
                    action = true;
                }
            }
            if (action)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(+30.0f, 0.0f));
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0) && action)
            {
                if (goShell)
                {
                    goShell.SetActive(true);
                    goShell.GetComponent<Rigidbody2D>().AddForce(new Vector2(+300.0f, 500.0f));
                    Destroy(goShell.gameObject, 3.0f);
                }
                action = false;
            }
        }
	}

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 10, 300, 60),
            "[Unity2D Tank Sample]\n" +
            "탱크를 클릭하면 가속\n놓으면 발사!!"
            );
        if(GUI.Button(new Rect(10,80,100,20),
            "다시 시작"))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
