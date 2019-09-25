using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudio : MonoBehaviour
{
    public AudioSource[] audioSources;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            timer = 0;
            foreach (var item in audioSources)
            {
                item.Stop();
            }
            int randomIndex = Random.Range(0, audioSources.Length);
            audioSources[randomIndex].Play();
        }
            
        
    }
}
