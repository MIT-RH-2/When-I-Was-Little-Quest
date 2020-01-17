using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SyncScene : MonoBehaviour
{
    public float time;
    public float offset;

    private AudioSource m_AudioSource;
    private AudioClip m_AudioClip;

    private void Awake()
    {
        m_AudioSource = this.gameObject.GetComponent<AudioSource>();
        //m_AudioClip = this.gameObject.GetComponent<AudioClip>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        //this.gameObject.GetComponent<VideoPlayer>().time = time;
        //this.gameObject.GetComponent<AudioSource>().time += offset;
        if (offset > 0)
        {
            m_AudioSource.PlayDelayed(offset);
        }
        else
        {
            this.gameObject.GetComponent<AudioSource>().time = time;

            m_AudioSource.Play();
        }
        

    }

    private void LateUpdate()
    {
        time = m_AudioSource.time;
    }

    // Update is called once per frame
    void OnDisable()
    {
        //time = m_AudioClip;
    }
}
