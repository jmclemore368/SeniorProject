using UnityEngine;

public class AssaultRifle : Gun
{
    // Update is called once per frame
    override protected void Update()
    {
        base.Update();

        // Instead of GetMouseButtonDown, use GetMouseButton to see if the 
        // player is holding down the left mouse button for auto-fire.
        // Automatic Fire
        if (Input.GetMouseButton(0) && Time.time - lastFireTime > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}