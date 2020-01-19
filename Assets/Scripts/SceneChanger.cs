using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    public int state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlyAway(Transform SceneParent)
    {
        /*foreach (Transform child in SceneParent)
        {
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    iTween.MoveBy(transform.GetChild(state).gameObject, iTween.Hash("x", -2f, "time", .8f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                    print("Up");
                    break;
                case 1:
                    print("Down");
                    iTween.MoveBy(transform.GetChild(state).gameObject, iTween.Hash("x", 2f, "time", .8f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                    break;
                case 2:
                    print("Left");
                    iTween.MoveBy(transform.GetChild(state).gameObject, iTween.Hash("z", -2f, "time", .8f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                    break;
                case 3:
                    print("Right");
                    iTween.MoveBy(transform.GetChild(state).gameObject, iTween.Hash("x", 2f, "time", .8f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
                    break;
                default:
                    print("default!");
                    break; 
            } */
        iTween.MoveBy(SceneParent.gameObject, iTween.Hash("y", -100f, "time", .8f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
    }

    public void FlyLeft()
    {
        iTween.MoveBy(transform.GetChild(state).gameObject, iTween.Hash("x", -2f, "time", .8f, "easeType", iTween.EaseType.spring, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
    }

    public void FlyRight()
    {
        //iTween.MoveBy(transform.GetChild(state).gameObject, new Vector3(10f, 0f, 0f), .8f);
        iTween.MoveBy(transform.GetChild(state).gameObject, iTween.Hash("x", 2f, "time", .8f, "easeType", iTween.EaseType.linear, "space", "world", "oncomplete", "RelocateTurnOffNextScene", "oncompletetarget", gameObject));
    }

    public void RelocateTurnOffNextScene()
    {
       // this.gameObject.transform.GetChild(state).gameObject.SetActive(false);
        //this.gameObject.transform.GetChild(state).gameObject.transform.position = startPos;
        //NextChoice();
    }
}
