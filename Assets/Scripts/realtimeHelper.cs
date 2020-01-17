using Normal.Realtime;
using UnityEngine;

public class realtimeHelper : MonoBehaviour
{
    public Realtime _realtimeInstance;

    // Start is called before the first frame update
    void Start()
    {
        _realtimeInstance = GetComponent<Realtime>();

        _realtimeInstance.didConnectToRoom += connectedToRoom;
        _realtimeInstance.didDisconnectFromRoom += disconnectedFromRoom;
    }

    void connectedToRoom(Realtime room)
    {
        Realtime.Instantiate("userPrefab");
    }

    void disconnectedFromRoom(Realtime room)
    {
        
    }
}
