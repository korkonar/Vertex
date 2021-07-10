using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelMenu : MonoBehaviour
{

    public static bool Paused;
    static bool changed;
    static bool dead;
    static bool win;
    string[] quotes={"Nothing is impossible, the word itself says “I’m possible”! ",
                    "Believe you can and you’re halfway there.",
                    "Life is 10 percent what happens to me and 90 percent of how I react to it.",
                    "Too many of us are not living our dreams because we are living our fears.",
                    "Strive not to be a success, but rather to be of value.",
                    "I am not a product of my circumstances. I am a product of my decisions.",
                    "The most difficult thing is the decision to act, the rest is merely tenacity.",
                    "You can’t use up creativity. The more you use, the more you have.",
                    "A person who never made a mistake never tried anything new.",
                    "The only person you are destined to become is the person you decide to be.",
                    "It does not matter how slowly you go as long as you do not stop.",
                    "Remember it’s just a bad day, not a bad life.",
                    "Be yourself; everyone else is already taken.",
                    "Be the change that you wish to see in the world.",
                    "Without music, life would be a mistake.",
                    "There are only two ways to live your life. One is as though nothing is a miracle. The other is as though everything is a miracle.",
                    "We are all in the gutter, but some of us are looking at the stars.",
                    "Fairy tales are more than true: not because they tell us that dragons exist, but because they tell us that dragons can be beaten.",
                    "Do what you can, with what you have, where you are.",
                    "Success is not final, failure is not fatal: it is the courage to continue that counts.",
                    "Pain is inevitable. Suffering is optional.",
                    "If you're reading this... Congratulations, you're alive. If that's not something to smile about, then I don't know what is.",
                    "In the end, we will remember not the words of our enemies, but the silence of our friends.",
                    "Talent hits a target no one else can hit. Genius hits a target no one else can see.",
                    "Fantasy is hardly an escape from reality. It's a way of understanding it.",
                    "The future belongs to those who believe in the beauty of their dreams.",
                    "Don't judge each day by the harvest you reap but by the seeds that you plant.",
                    "None but ourselves can free our minds.",
                    "People say nothing is impossible, but I do nothing every day.",
                    "You never fail until you stop trying.",
                    "Take responsibility of your own happiness, never put it in other people’s hands.",
                    "Do what is right, not what is easy nor what is popular.",
                    "If you are irritated by every rub, how will your mirror be polished?",
                    "‎Though nobody can go back and make a new beginning... Anyone can start over and make a new ending.",
                    "A ship is safe in harbor, but that's not what ships are for.",
                    "Even if you are on the right track, you’ll get run over if you just sit there.",
                    "You can fail at what you don’t want, so you might as well take a chance on doing what you love.",
                    "If you think you are too small to make a difference, try sleeping with a mosquito.",
                    "I don't think of all the misery, but of the beauty that still remains.",
                    "I'd rather be hated for who I am, than loved for who I am not.",
                    "Shoot for the moon. Even if you miss, you'll land among the stars.",
                    "I have never met a man so ignorant that I couldn't learn something from him.",
                    "Believe in your infinite potential. Your only limitations are those you set upon yourself.",
                    "Imagination is everything. It is the preview of life's coming attractions.",
                    "We don't make mistakes, just happy little accidents.",
                    "If you make a mistake and do not correct it, this is called a mistake.",
                    "Why are trying so hard to fit in, when you're born to stand out.",
                    "I must be willing to give up what I am in order to become what I will be.",
                    "You'll never find a rainbow if you're looking down.",
                    "Life sucks, and then you die...",
                    "Death is not the greatest loss in life. The greatest loss is what dies inside while still alive. Never surrender.",
                    "Make the most of yourself....for that is all there is of you."};
    public Canvas menuCanvas;
    float timeToPause=1.5f;
    public Animator animatorRestart;
    public Animator animatorMainMenu;
    public AudioSource sound;
    SoundManager sounds;
    // Start is called before the first frame update
    void Start()
    {
        sounds=GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Paused=false;
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")&&!dead){
            if(Paused){
                sounds.PlayUnPause();
                Paused=false;
                Time.timeScale=1;
                menuCanvas.gameObject.SetActive(false);

            }else{
                changed=true;
                Paused=true;
            }
        }

        if(Paused&&changed){
            sounds.PlayPause();
            changed=false;
            Time.timeScale=0;

            menuCanvas.gameObject.SetActive(true);
            menuCanvas.transform.GetChild(0).GetComponent<Text>().text=quotes[Random.Range(0,quotes.Length)];
            menuCanvas.transform.GetChild(1).GetComponent<Text>().enabled=true;
            menuCanvas.transform.GetChild(2).GetComponent<Text>().enabled=false;
            
        }

        if(dead){
            timeToPause-=Time.deltaTime;
            if(timeToPause<0.0f){
                timeToPause=1.5f;
                changed=false;
                Time.timeScale=0;
                menuCanvas.gameObject.SetActive(true);
                menuCanvas.transform.GetChild(0).GetComponent<Text>().text=quotes[Random.Range(0,quotes.Length)];
                menuCanvas.transform.GetChild(2).GetComponent<Text>().enabled=true;
                menuCanvas.transform.GetChild(1).GetComponent<Text>().enabled=false;
                menuCanvas.transform.GetChild(4).gameObject.SetActive(false);
            }
         }
        if(win){
            timeToPause-=Time.deltaTime;
            if(timeToPause<0.0f){
                timeToPause=1.5f;
                changed=false;
                Time.timeScale=0;
                menuCanvas.gameObject.SetActive(true);
                menuCanvas.transform.GetChild(0).GetComponent<Text>().text="You have ascended beyond our comprehension";
                menuCanvas.transform.GetChild(2).GetComponent<Text>().enabled=false;
                menuCanvas.transform.GetChild(1).GetComponent<Text>().enabled=false;
                menuCanvas.transform.GetChild(3).GetComponent<Text>().enabled=true;
                menuCanvas.transform.GetChild(4).gameObject.SetActive(false);
            }
        }
    }

    public static void meDead(){
        dead=true;
    }

    public static void Win(){
        win=true;
    }

    public void unPause(){
        animatorRestart.SetTrigger("Click");
        sound.Play();
        sounds.PlayUnPause();
        Paused=false;
        Time.timeScale=1;
        menuCanvas.gameObject.SetActive(false);
    }
    private IEnumerator WaitAndLoad(int index)
    {
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene(index);
    }

    public void Restart(){
        animatorRestart.SetTrigger("Click");
        sound.Play();
        dead=false;
        Paused=false;
        Time.timeScale=1;
        healthBehaviour.reachKills=3;
        healthBehaviour.numKills=0;
        IEnumerator coroutine = WaitAndLoad(1);
        StartCoroutine(coroutine);
        
    }

    
    public void MainMenu(){
        animatorMainMenu.SetTrigger("Click");
        sound.Play();
        IEnumerator coroutine = WaitAndLoad(0);
        StartCoroutine(coroutine);
    }
}
