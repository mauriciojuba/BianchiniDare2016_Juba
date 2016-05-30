using UnityEngine;
using System.Collections;

public class BuildingsHandler : MonoBehaviour {

    public static BuildingsHandler Instance;
    public GameObject Floor1, Floor2, Floor3, Top;

    void Start()
    {
        Instance = this;
    }
    public void changeFloor(int _floor)
    {
        if (_floor == 0) Outside();
        if (_floor == 1) Floor1On();
        if (_floor == 2) Floor2On();
        if (_floor == 3) Floor3On();
    }
    void Outside()
    {
        Floor1.SetActive(true);
        Floor2.SetActive(true);
        Floor3.SetActive(true);
        Top.SetActive(true);
    }
    void Floor1On()
    {
        Floor1.SetActive(true);
        Floor2.SetActive(false);
        Floor3.SetActive(false);
        Top.SetActive(false);
    }
    void Floor2On()
    {
        Floor2.SetActive(true);
        Floor3.SetActive(false);
        Top.SetActive(false);
    }
    void Floor3On()
    {
        Floor3.SetActive(true);
        Top.SetActive(false);
    }


    //perguntar pro professor
    //Renderer[] Floor1r, Floor2r, Floor3r, Topr;

    //void Start()
    //{
    //    Instance = this;
    //    getMeshRenderer();
    //}

    //public void changeFloor(int _floor)
    //{
    //    if (_floor == 0) Outside();
    //    if (_floor == 1) Floor1On();
    //    if (_floor == 2) Floor2On();
    //    if (_floor == 3) Floor3On();
    //}
    //void getMeshRenderer()
    //{
    //    Floor1r = Floor1.GetComponentsInChildren<Renderer>();
    //    Floor2r = Floor2.GetComponentsInChildren<Renderer>();
    //    Floor3r = Floor3.GetComponentsInChildren<Renderer>();
    //}
    //void Floor1On()
    //{
    //    for(int i = 0; i <= Floor1r.Length; i++) if (!Floor1r[i].enabled) Floor1r[i].enabled = true;
    //    for (int j = 0; j <= Floor2r.Length; j++) if (Floor2r[j].enabled) Floor2r[j].enabled = false;
    //    for (int k = 0; k <= Floor3r.Length; k++) if (Floor3r[k].enabled) Floor3r[k].enabled = false;
    //    for (int l = 0; l <= Topr.Length; l++) if (Topr[l].enabled) Topr[l].enabled = false;
    //}
    //void Floor2On()
    //{
    //    for (int j = 0; j <= Floor2r.Length; j++) if (!Floor2r[j].enabled) Floor2r[j].enabled = true;
    //    for (int k = 0; k <= Floor3r.Length; k++) if (Floor3r[k].enabled) Floor3r[k].enabled = false;
    //    for (int l = 0; l <= Topr.Length; l++) if (Topr[l].enabled) Topr[l].enabled = false;
    //}
    //void Floor3On()
    //{
    //    for (int k = 0; k <= Floor3r.Length; k++) if (!Floor3r[k].enabled) Floor3r[k].enabled = true;
    //    for (int l = 0; l <= Topr.Length; l++) if (Topr[l].enabled) Topr[l].enabled = false;
    //}
    //void Outside()
    //{
    //    for (int l = 0; l <= Topr.Length; l++) if (!Topr[l].enabled) Topr[l].enabled = true;
    //}
}
