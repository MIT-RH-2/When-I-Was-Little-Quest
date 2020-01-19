using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent {
    [SerializeField]
    private MeshRenderer   _meshRenderer;
    private ColorSyncModel _model;

    private void Start() {
        
    }

    private ColorSyncModel model {
        set {
            if (_model != null) {
                // Unregister from events
                _model.colorDidChange -= ColorDidChange;
                _model.isVisibleDidChange -= IsVisibleDidChange;
            }

            // Store the model
            _model = value;

            if (_model != null) {
                // Update the mesh render to match the new model
                UpdateMeshRendererColor();
                UpdateMeshRendererVisibility();

                // Register for events so we'll know if the color changes later
                _model.colorDidChange += ColorDidChange;
                _model.isVisibleDidChange += IsVisibleDidChange;
            }
        }
    }

    private void ColorDidChange(ColorSyncModel model, Color value) {
        // Update the mesh renderer
        UpdateMeshRendererColor();
    }

    private void IsVisibleDidChange(ColorSyncModel model, bool value) {
        // Update the mesh renderer
        #if !UNITY_LUMIN
            if(_model.isVisible){
                GetComponent<RealtimeTransform>().RequestOwnership();
                Debug.Log("ownership transferred");
            }
        #endif
        UpdateMeshRendererVisibility();
    }


    private void UpdateMeshRendererColor() {
        // Get the color from the model and set it on the mesh renderer.
        _meshRenderer.material.color = _model.color;
    }

    private void UpdateMeshRendererVisibility() {
        bool shouldObjectBeVisible = _model.isVisible;
        #if UNITY_LUMIN
            shouldObjectBeVisible = true;
            Debug.Log("Lumin");
        #endif
        Debug.Log("Is model visible: " + shouldObjectBeVisible);
        _meshRenderer.enabled = shouldObjectBeVisible;
    }

    public void SetColor(Color color) {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        _model.color = color;
    }

    public void SetIsVisible(bool isVisible) {
        // Set the isVisible property on the model
        // This will fire the isVisibleDidChange event on the model, which will update the renderer for both the local player and all remote players.
        _model.isVisible = isVisible;
    }

    public void TransferObject(){
        _model.isVisible = true;
        Debug.Log("transfer complete");
    }

    public void DragAndDrop(){

    }



}