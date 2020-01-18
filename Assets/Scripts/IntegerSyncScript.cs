using Normal.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class IntegerSyncScript : MonoBehaviour
{
    public int _Index;
    public RealtimeView _RealtimeView;
    public IntegerSync _integerSync;

    public List<GameObject> _AvatarOptions;

    public bool isOwnedLocally = false;

    private void Start()
    {
        _RealtimeView = GetComponent<RealtimeView>();

        transform.name = _RealtimeView.ownerID.ToString();

        _integerSync = GetComponent<IntegerSync>();

        if (_RealtimeView.isOwnedLocally)
            isOwnedLocally = true;
    }

    private void Update()
    {
        //Update My Avatar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOwnedLocally)
                _RealtimeView.RequestOwnership();
            else
                return;

            if (!_RealtimeView.isOwnedLocally)
                return;

            _Index = getNewIndex();

            foreach (GameObject _Player in GameObject.FindGameObjectsWithTag("Player"))
            {
                IntegerSyncScript tmpIntSyncScript = _Player.GetComponent<IntegerSyncScript>();

                if (tmpIntSyncScript != this)
                {
                    if (_Index == tmpIntSyncScript._Index)
                        _Index = getNewIndex();
                }
            }

            _integerSync.SetAvatarIndex(_Index);
        }

        //Sync All Avatars
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isOwnedLocally)
                return;

            int syncedIndex = getNewIndex();

            foreach (GameObject _Player in GameObject.FindGameObjectsWithTag("Player"))
            {
                IntegerSyncScript tmpIntSyncScript = _Player.GetComponent<IntegerSyncScript>();

                _Player.GetComponent<RealtimeView>().RequestOwnership();

                tmpIntSyncScript._integerSync.SetAvatarIndex(syncedIndex);
            }
        }
    }

    public int getNewIndex()
    {
        if (_Index < _AvatarOptions.Count - 1)
            return _Index + 1;

        else
            return 0;
    }

    public void updateMyAvatarIndex(int Index)
    {
        _Index = Index;

        disableAllAvatarOptions();
        _AvatarOptions[_Index].SetActive(true);
    }

    public void disableAllAvatarOptions()
    {
        foreach (GameObject myAvatar in _AvatarOptions)
        {
            myAvatar.SetActive(false);
        }
    }
}
