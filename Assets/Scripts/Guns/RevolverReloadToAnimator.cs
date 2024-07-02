using UnityEngine;

public class RevolverReloadToAnimator : MonoBehaviour
{
    public Revolver revolver;

    private bool isReloading = false;

    public void startReload()
    {
        revolver.isRealoading = true;
        isReloading = true;
    }
    
    public void stopReload()
    {
        revolver.isRealoading = false;
        isReloading = false;
    }

}
