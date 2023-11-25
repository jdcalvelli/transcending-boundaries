using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrgButtonParams : MonoBehaviour
{
    public TextMeshProUGUI orgName;
    public GameObject topSeparator;
    public GameObject botSeparator;
    public Image orgImage;
    private Button button;

    private OrgFilter orgFilter;
    private GameObject eventInfo;


    private void Start()
    {
        button = GetComponent<Button>();
        // orgFilter = GameObject.Find("UIManager").GetComponent<OrgFilter>();
        eventInfo = GameObject.Find("EventInfo");

        button.onClick.AddListener(StartFilterOrgButton);
    }

    public void SetOrgFilter(OrgFilter filter)
    {
        orgFilter = filter;
    }

    public void StartFilterOrgButton()
    {
        orgFilter.FilterOrgButton(this);
        orgFilter.SetupOrgUI(orgName.text);
        try { eventInfo.SetActive(false); }
        catch { } ;
    }

    public void SetNameAndImage(string name)
    {
        orgName.text = name;
        orgImage.sprite = OrgNameToData.nameToSprite[name];
    }

    public string GetName()
    {
        return orgName.text;
    }
}
