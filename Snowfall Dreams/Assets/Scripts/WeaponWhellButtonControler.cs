using UnityEngine.UI;
using UnityEngine;

public class WeaponWhellButtonControler : MonoBehaviour
{
    public int Id;
    public Image selectedWeapon;
    private bool selected = false;
    public Sprite icon;


    void Update()
    {
        if (selected)
        {
            selectedWeapon.sprite = icon;

        }

    }
    public void Selected()
    {
        selected = true;
        WeaponWhellManager.weaponID = Id;
    }
    public void Deselected()
    {
        selected = false;
        WeaponWhellManager.weaponID = 0;
    }
   
}
