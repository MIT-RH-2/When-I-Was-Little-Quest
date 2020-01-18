using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class IntegerSync : RealtimeComponent
{
    private IntegerSyncScript _integerSyncScript;
    private IntegerSyncModel _model;

    private void Awake()
    {
        _integerSyncScript = GetComponent<IntegerSyncScript>();
    }

    private IntegerSyncModel model
    {
        set
        {
            if (_model != null)
            {
                // Unregister from events
                _model.avatarIndDidChange -= AvatarIndDidChange;
            }

            // Store the model
            _model = value;

            if (_model != null)
            {
                // Update the Integer Sync Script to match the new model
                UpdateIntegerInd();

                // Register for events so we'll know if the Avater Index changes later
                _model.avatarIndDidChange += AvatarIndDidChange;
            }
        }
    }

    private void AvatarIndDidChange(IntegerSyncModel model, int value)
    {
        // Update the Avatar Index
        UpdateIntegerInd();
    }

    private void UpdateIntegerInd()
    {
        // Get the Avatar Index from the model and set it on the Integer Sync Script.
        _integerSyncScript.updateMyAvatarIndex(_model.avatarInd);
    }

    public void SetAvatarIndex(int index)
    {
        // Set the Avatar Index on the model
        // This will fire the AvatarIndDidChange event on the model, which will update the Integer Sync Script for both the local player and all remote players.
        _model.avatarInd = index;
    }
}