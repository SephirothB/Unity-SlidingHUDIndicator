using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderObject : MonoBehaviour {

    private Image icon;
    private Text content;

    private Animator animator;
    public Animator SliderAnimator {
        get {
            return animator;
        }
    }

    private void Awake() {
        animator = GetComponent<Animator>();

        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        content = gameObject.transform.GetChild(1).GetComponent<Text>();


    }
    public void SetIcon(Sprite sprite){
        icon.sprite = sprite;
    }

    public void SetText(string text){
        content.text = text;
    }

}
