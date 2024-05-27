using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private PlayableDirector director;
    public GameObject canvas;
    public bool akhir;
    public AudioSource audioSource;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        audioSource.loop= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                audioSource.Stop();
            }

        }
    }

    public void StartDialogue(PlayableDirector pd)
    {
        index = 0;
        StartCoroutine(TypeLine());
        director = pd;
        director.Pause();
    }

    IEnumerator TypeLine()
    {
        audioSource.Play();
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        audioSource.Stop();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            EndDialogue();
        }
    }
    void EndDialogue()
    {
        if (akhir)
        { 
            canvas.SetActive(false);
            director.Stop();
        }
        director.Resume();
    }
}