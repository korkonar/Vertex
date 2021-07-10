using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;
    // Start is called before the first frame update
    public void startGame(){
        animator.SetTrigger("Click");
        sound.Play();
        IEnumerator coroutine = WaitAndLoad(1);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndLoad(int index)
    {
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene(index);
    }
}
