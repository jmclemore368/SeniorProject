using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    
    /*
     * SerializeField attribute conveys to C# runtime that the following
     * variables in this class can accessed from are the Unity Inspector but 
     * not other scripts.
     */
    [SerializeField]
    Sprite pistolCrossHair;
    [SerializeField]
    Sprite shotgunCrossHair;
    [SerializeField]
    Sprite assaultRifleCrossHair;
    [SerializeField]
    Image crossHair;

    // Sprite : Imported texture made to be used in 2D or UI (jpg, png)
    // Image:   What projects the sprite to the screen
    public void UpdateCrosshair()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                crossHair.sprite = pistolCrossHair;
                break;
            case Constants.Shotgun:
                crossHair.sprite = shotgunCrossHair;
                break;
            case Constants.AssaultRifle:
                crossHair.sprite = assaultRifleCrossHair;
                break;
            default:
                return;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
