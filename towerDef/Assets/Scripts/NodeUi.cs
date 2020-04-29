using UnityEngine;

public class NodeUi : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    
    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();// depalce le node UI
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
