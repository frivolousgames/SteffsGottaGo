using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeanutIntroController : MonoBehaviour
{
    List<string> urls;

    string[] intros;
    string selectedIntro;

    private void Awake()
    {
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };

        urls = new List<string>();

        urls.Add("https://img.memecdn.com/weird-faced-people_o_1970819.webp");
        urls.Add("https://cdn.statically.io/img/cdn.ebaumsworld.com/mediaFiles/picture/2117880/83088462.jpg");
        urls.Add("https://i.pinimg.com/236x/59/c8/65/59c8655c56300be22fd2c4fac8e48955--so-funny-funny-shit.jpg?q=60");
        urls.Add("https://i.pinimg.com/originals/b3/65/ac/b365ac55a57f4be045e7f1e46c084b13.jpg");
        urls.Add("https://cdn.statically.io/img/weirdgag.weebly.com/uploads/2/4/2/0/24207667/7002231_orig.jpg");
        urls.Add("https://i.ytimg.com/vi/ffjqkEHGL8g/hqdefault.jpg");
        urls.Add("https://cdn131.picsart.com/318134655036211.png");
        urls.Add("https://static.wikia.nocookie.net/robensikk/images/4/47/Download-0.jpg/revision/latest/scale-to-width-down/600?cb=20190403232235");
        urls.Add("https://i.kym-cdn.com/photos/images/facebook/001/590/564/aff.jpg");
    }
    public void Play()
    {
        selectedIntro = intros[Random.Range(0, intros.Length)];
        SceneManager.LoadScene(selectedIntro);
    }

    public void Dumb()
    {
        int i = Random.Range(0, urls.Count);
        Application.OpenURL(urls[i]);
    }
}
