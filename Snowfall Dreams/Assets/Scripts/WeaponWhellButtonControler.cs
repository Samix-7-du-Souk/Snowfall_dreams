using UnityEngine.UI;
using UnityEngine;

public class WeaponWhellButtonControler : MonoBehaviour
{
    public int Id;
    private Animator anim;
    public Image selectedWeapon;
    private bool selected = false;
    public Sprite icon;


    void Start()
    {
        if (selected)
        {
            selectedWeapon.sprite = icon;

        }

    }
    public void Selected()
    {
        selected = true;
    }
    public void Deselected()
    {
        selected = false;
    }
    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
    }
    public void HoverExit()
    {
        anim.SetBool("Hover", false);
    }
}
