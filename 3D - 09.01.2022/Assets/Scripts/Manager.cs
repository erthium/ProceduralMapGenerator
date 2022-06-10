using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Animator side_menu_animator;
    public GameObject side_menu_slide_button;
    bool is_side_menu_open = false;

    public void SwitchSideMenu()
    {
        bool current_condition = side_menu_animator.GetBool("open");
        is_side_menu_open = !is_side_menu_open;
        side_menu_animator.SetBool("open", is_side_menu_open);
        //side_menu_slide_button.transform.rotation.y 
    }
}
