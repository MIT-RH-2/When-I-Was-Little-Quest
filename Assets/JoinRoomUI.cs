using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class JoinRoomUI : MonoBehaviour {
    private Realtime _realtime;

    private void Awake()
    {
        _realtime = GetComponent<Realtime>();
    }

    // Quest idea
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            _realtime.Connect("Room A");
            enabled = false;
        }
    }
}
