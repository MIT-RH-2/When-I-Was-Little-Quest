using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialToClientID : MonoBehaviour
{
    //RealtimeView has a public clientID variable to uniquely identify our player
    private Normal.Realtime.RealtimeTransform _rt;
    private Normal.Realtime.RealtimeView _rv;
   
    private Material[] objMats;

    //here's where we place a bunch of preset materials with different colors
    public Material[] avatarMats;

    //if there's more than one material on this object, we need to identify which to target
    public int matSlot;

    void Start()
    {
        _rt = GetComponentInParent<Normal.Realtime.RealtimeTransform>();
        _rv = GetComponentInParent<Normal.Realtime.RealtimeView>();
        //_rv.RequestOwnership();

        //Debug.Log("realtime.clientID is " + _rt.ownerID);
        objMats = this.gameObject.GetComponent<Renderer>().materials;

        if (_rt != null)
        {
            //set the player number to the matching material number
            if (_rt.ownerID < avatarMats.Length && _rt.ownerID >= -1)
            {
                //Debug.Log(_rt.ownerID + 1);
                objMats[matSlot] = avatarMats[_rt.ownerID + 1];
            }
            //but if we have more players than materials, than cycle back around
            else
            {
                objMats[matSlot] = avatarMats[_rt.ownerID % avatarMats.Length];
            }
            //don't forget to tell this object to now use our new materials
            this.gameObject.GetComponent<Renderer>().materials = objMats;

            //Debug.Log("clientID is " + _rv.realtime.clientID);     
        }
        if (_rt == null && _rv != null)
        {
            //set the player number to the matching material number
            if (_rv.ownerID < avatarMats.Length && _rv.ownerID >= -1)
            {
                //Debug.Log(_rt.ownerID + 1);
                objMats[matSlot] = avatarMats[_rv.ownerID + 1];
            }
            //but if we have more players than materials, than cycle back around
            else
            {
                objMats[matSlot] = avatarMats[_rv.ownerID % avatarMats.Length];
            }
            //don't forget to tell this object to now use our new materials
            this.gameObject.GetComponent<Renderer>().materials = objMats;

            //Debug.Log("clientID is " + _rv.realtime.clientID);     
        }
        /*
        if (_rt == null && _rv == null)
        {

        } */
    }
}
