using System;


public class EventBroker 
{

    public static event Action ProjectileOutOfbounds;

    public static void CallProjectileOutOfBounds()
    {
        if (ProjectileOutOfbounds != null)
        {
            ProjectileOutOfbounds();

        }
    }
   

}
