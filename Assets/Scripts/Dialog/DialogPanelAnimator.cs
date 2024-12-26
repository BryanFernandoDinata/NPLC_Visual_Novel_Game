using UnityEngine;

public class DialogPanelAnimator : MonoBehaviour
{
    public void NextDialog()
    {
        DialogController.instance.ContinueDialog();
    }
}
