using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public AudioClip[] exitSounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ByeByeBrushStrokes()
    {
        BrushStroke[] bs = GameObject.FindObjectsOfType<BrushStroke>();


        if (bs.Length > 0)
        {
            foreach (BrushStroke b in bs)
            {
                b.gameObject.AddComponent<AudioSource>();
                b.gameObject.GetComponent<AudioSource>().spatialBlend = 1f;
                int rand = Random.Range(0, 4);
                int rand2 = Random.Range(0, exitSounds.Length);
                b.GetComponent<AudioSource>().PlayOneShot(exitSounds[rand2]);
                switch (rand)
                {
                    case 0:
                        iTween.MoveBy(b.gameObject, iTween.Hash("x", -150f, "time", 2.5f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", "delay", .1f, gameObject));
                        print("Up");
                        break;
                    case 1:
                        print("Down");
                        iTween.MoveBy(b.gameObject, iTween.Hash("x", -100f, "time", 2f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                    case 2:
                        print("Left");
                        iTween.MoveBy(b.gameObject, iTween.Hash("z", -100f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", "delay", .15f, gameObject));
                        break;
                    case 3:
                        print("Right");
                        iTween.MoveBy(b.gameObject, iTween.Hash("z", -150f, "time", 2.5f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                    case 4:
                        print("what");
                        iTween.MoveBy(b.gameObject, iTween.Hash("y", -50f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                    default:
                        print("default!");
                        iTween.MoveBy(b.gameObject, iTween.Hash("y", -50f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                }
                //iTween.MoveBy(SceneParent.gameObject, iTween.Hash("y", -50f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
            }
        }
    }
    public void FlyAway(Transform SceneParent)
    {
        /*

        }
       */

        if (SceneParent.childCount > 0) iTween.MoveBy(SceneParent.gameObject, iTween.Hash("y", -50f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject)); 
        /*
        {
            foreach (Transform child in SceneParent)
            {
                child.gameObject.AddComponent<AudioSource>();
                child.gameObject.GetComponent<AudioSource>().spatialBlend = 1f;
                int rand = Random.Range(0, 4);
                int rand2 = Random.Range(0, exitSounds.Length);
                child.GetComponent<AudioSource>().PlayOneShot(exitSounds[rand2]);
                switch (rand)
                {
                    case 0:
                        iTween.MoveBy(child.gameObject, iTween.Hash("x", -150f, "time", 2.5f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", "delay", .1f, gameObject));
                        print("Up");
                        break;
                    case 1:
                        print("Down");
                        iTween.MoveBy(child.gameObject, iTween.Hash("x", -100f, "time", 2f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                    case 2:
                        print("Left");
                        iTween.MoveBy(child.gameObject, iTween.Hash("z", -100f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", "delay", .15f, gameObject));
                        break;
                    case 3:
                        print("Right");
                        iTween.MoveBy(child.gameObject, iTween.Hash("z", -150f, "time", 2.5f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                    case 4:
                        print("what");
                        iTween.MoveBy(child.gameObject, iTween.Hash("y", -50f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                    default:
                        print("default!");
                        iTween.MoveBy(child.gameObject, iTween.Hash("y", -50f, "time", 3f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                        break;
                }
            }
        } */
    }

    public void RelocateTurnOffNextScene()
    {
       // this.gameObject.transform.GetChild(state).gameObject.SetActive(false);
        //this.gameObject.transform.GetChild(state).gameObject.transform.position = startPos;
        //NextChoice();
    }
}
