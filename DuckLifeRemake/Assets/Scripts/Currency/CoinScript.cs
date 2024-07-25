using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static float MoveSpeed;
    public bool IsHorizontal = true;
    [SerializeField] private AudioClip coinSoundClip;

    // Update is called once per frame
    void Update()
    {
        if(IsHorizontal)
        {
            gameObject.transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position -= Vector3.up * MoveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            SoundManager.instance.PlaySoundClip(coinSoundClip, 1f);

            GameObject.Destroy(this.gameObject);

            // adds 1 to the number of coins earned in the current minigame
            CoinManager.incomingBalance++;
        }
    }
}
