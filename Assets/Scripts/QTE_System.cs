using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QTE_System : MonoBehaviour
{
    public bool masuk;
    public Transform target;
    public Transform targetstart;
    public Transform targetend;
    public Slider progress;
    public GameObject win;

    private int FishType;
    private PointerMove pointerMove;

    private void Start()
    {
        pointerMove = FindObjectOfType<PointerMove>();
        FishType = pointerMove.GetFishType();

        switch (FishType)
        {
            case 0:
                target.localScale = new Vector3(250, 25, 1);
                break;
            case 1:
                target.localScale = new Vector3(200, 25, 1);
                break;
            case 2:
                target.localScale = new Vector3(150, 25, 1);
                break;
            case 3:
                target.localScale = new Vector3(100, 25, 1);
                break;
            default:
                target.localScale = new Vector3(50, 25, 1);
                break;
        }
        
    }

    void Update()
    {
        if(progress.value < 1)
        {
            progress.value -= Time.deltaTime * 0.03f;
        }
        else
        {
            win.SetActive(true);
            //SceneManager.LoadScene(3);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (masuk)
            {
                if(progress.value < 1)
                {
                    progress.value += 0.2f;
                }
                target.position = new Vector2(Random.Range(targetstart.position.x, targetend.position.x), target.position.y);
                Debug.Log("Berhasil");
            }
            else
            {
                if (progress.value > 0)
                {
                    progress.value -= 0.2f;
                }

                Debug.Log("Gagal");
            }
            
        }

        if(win.activeInHierarchy) {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(1);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        masuk = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        masuk = false;
    }

    private void OnDrawGizmos()
    {
        if (target != null && targetstart != null && targetend != null)
        {
            Gizmos.DrawLine(target.transform.position, targetstart.position);
            Gizmos.DrawLine(target.transform.position, targetend.position);
        }
    }
}
