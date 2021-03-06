using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public Texture2D tex;
    public Color color;
    public float fadeTime = 1f;
    public bool playOnStart = true;

    private bool opaque = false, fireEvent = false;
    private GameObject target;
    private string action;

    private static Fade _fade;

    public static void Out() { Out(null, ""); }
    public static void Out(GameObject target, string action) { ChangeState(false, target, action); }
    public static void In() { In(null, ""); }
    public static void In(GameObject target, string action) { ChangeState(true, target, action); }

    public static void ChangeState(bool opaque, GameObject target, string action)
    {
        if (_fade == null)
        {
            if ((_fade = GameObject.FindObjectOfType(typeof(Fade)) as Fade) == null)
            {
                Debug.LogError("Fade not found : add Fade.prefab in your hierarchy");
                return;
            }
        }
        _fade.action = action;
        _fade.target = target;
        _fade.opaque = opaque;
        _fade.fireEvent = (target != null && action != "");
    }

	void Start () {
        if (this.playOnStart)
            this.color.a = 1f;
        else
            this.color.a = 0f;
	}
	
	void Update () {
        if ((this.color.a <= 0f && !opaque) || (this.color.a >= 1f && opaque))
        {
            if (fireEvent && this.target != null)
            {
                this.fireEvent = false;
                this.target.SendMessage(this.action, SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            if (opaque)
                this.color.a += Time.deltaTime / fadeTime;
            else
                this.color.a -= Time.deltaTime / fadeTime;
        }
	}

    void OnGUI()
    {
        if (this.color.a <= 0) return;
        GUI.color = this.color;
        GUI.depth = -9999;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.tex, ScaleMode.StretchToFill);
    }

}
