using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class TabGroup : MonoBehaviour
{
    List<TabBTN> tabs;
    public TabBTN tabBTN;
    public List<GameObject> tabsObject;
    public bool isReseted;
    public TweenManager tweenManager;

    public void Subs(TabBTN btn)
    {
        if(tabs == null)
        {
            tabs = new List<TabBTN>();
        }
        tabs.Add(btn);
    }

    public void OnTabEnter(TabBTN btn)
    {
        ResetTabs();
        if (tabBTN == null || btn != tabBTN)
            btn.bacground.color = btn.hoverColor;
    }
    public void OnTabExit(TabBTN btn)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabBTN btn)
    {
       
        if (tabBTN != null)
            tabBTN.Unselect();

        tabBTN = btn;
        ResetTabs();
        tabBTN.Select();
        
        int index = btn.transform.GetSiblingIndex();
        for(int i = 0; i < tabsObject.Count; i++)
        {
            if(i == index)
            {
                tabsObject[i].SetActive(true);
                if(tweenManager != null)
                    tweenManager.Scaling(tabsObject[i], 1, 1, 1, .5f);
            }
            else
            {
                tabsObject[i].SetActive(false);
                if (tweenManager != null)
                    tweenManager.Scaling(tabsObject[i], 0, 0, 0, .5f);
            }
        }
    }

    void ResetTabs()
    {
        foreach(TabBTN tab in tabs)
        {
            if (isReseted)
                if (tabBTN != null && tab == tabBTN) 
                    continue;
            tab.ResetBTN();
        }
    }
}
