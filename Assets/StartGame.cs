using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    private Button btn;
    void Start()
    {
        GameObject go = GameObject.FindWithTag("Button");
        btn = go.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

    }

    void OnClick()
    {
        Application.LoadLevel(1);
    }
}
