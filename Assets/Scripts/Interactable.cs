using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //add or remove an interactionEvent vomponrnt to this gameobject.
    public bool useEvents;
    [SerializeField]
    public string promptMassage;

    public virtual string OnLook() 
    {
        return promptMassage;
    }

    public void BaseInteract()
    { 
        if (useEvents) 
            GetComponent<InteractionEvent>().OnInteract.Invoke();
       Interact();
    }
    protected virtual void Interact()
    { 
     // we wont have any code weitten in this function
     // this is a teampel function to be overridden by our subclasses
    
    }
}
