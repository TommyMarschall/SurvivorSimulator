using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadImage("https://th.bing.com/th/id/OIP.ttQUeacrwq73pbqyYEb_cAHaJ1?rs=1&pid=ImgDetMain.png"));
    }

    IEnumerator loadImage(string url)
    {
        WWW www = new WWW(url);
        while (!www.isDone) {
        yield return null;}
        Texture2D texture = new Texture2D(1, 1);
        www.LoadImageIntoTexture(texture);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
