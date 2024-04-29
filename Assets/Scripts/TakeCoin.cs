using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeCoin : MonoBehaviour
{
    public int coins;
    public int score;
    public AudioClip take;
    public AudioClip lose;
    public AudioClip win;
    public AudioSource takeSource;
    public GameObject hero;
    public Movement movement;
    public GameObject eff;
    public GameObject eff2;


    void OnTriggerEnter2D(Collider2D other) //Для 2D - в нашем случае, это событие выполняться не будет.
    {
        if (other.gameObject.tag == "Coin") //Проверяем тэг объекта. Убедись, что у Игрока есть тег Player
        {
            takeSource.PlayOneShot(take);
            coins = PlayerPrefs.GetInt("Coins", coins);
            coins += 1;
            PlayerPrefs.SetInt("Coins", coins);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Ship") //Проверяем тэг объекта. Убедись, что у Игрока есть тег Player
        {
            eff.SetActive(true);
            hero.SetActive(false);
            takeSource.PlayOneShot(lose);
            movement.enabled = false;
            StartCoroutine(end(2f));
        }

        if (other.gameObject.tag == "Portal") //Проверяем тэг объекта. Убедись, что у Игрока есть тег Player
        {
            score = PlayerPrefs.GetInt("Score", score);
            score += 1;
            PlayerPrefs.SetInt("Score", score);
            eff2.SetActive(true);
            hero.SetActive(false);
            takeSource.PlayOneShot(win);
            movement.enabled = false;
            StartCoroutine(end(2f));
        }
    }
    IEnumerator end(float Secs)
    {
        yield return new WaitForSeconds(Secs);
        SceneManager.LoadScene("Game");
    }

}
