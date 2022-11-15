using UnityEngine;

public class Shop_Listener : MonoBehaviour
{
    [SerializeField]
    GameObject shopwindow;

    GameObject shoppointer;

    bool shopExists;
    // Start is called before the first frame update
    void Start()
    {
        shopExists = false;
        if(shopwindow == null)
        {
            shopwindow = Resources.Load<GameObject>("Prefabs/TowerShop/TowerShop - Layer 25");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SummonShop();
        }
    }

    public void SummonShop()
    {
        if(shopExists == false)
        {

            shopExists = true;
            shoppointer = Instantiate(shopwindow, transform.parent.parent);
        }
        else
        {
            CloseShop();
        }
    }

    public void CloseShop()
    {
        if(shopExists == true)
        {
            shopExists = false;
            GameObject.Destroy(shoppointer.gameObject);
        }
    }
}
