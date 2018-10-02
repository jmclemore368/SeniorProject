using UnityEngine;

public class Pistol : Gun
{
    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        // Check if enough time has passed between shots to allow for another one
        // Shotgun & Pistol have semi-auto fire rate
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)
            > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }


}