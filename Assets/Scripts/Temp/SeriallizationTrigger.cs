using Persistence;
using UnityEngine;

public class SeriallizationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.SerializeAll();
    }
}
