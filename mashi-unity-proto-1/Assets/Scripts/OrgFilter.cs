using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrgFilter : MonoBehaviour
{
    public TopicLibrary library;
    public Transform earthTransform;
    public TextMeshProUGUI blurb;
    public TMP_Dropdown dropdown;
    public bool isDropdownUpdated = false;
    
    public Dictionary<int, string> orgLibrary = new() { { 0, "Choose from a list of organizations to see what they're up to!" } };
    public Transform orgButtonGroupTransform;
    public GameObject orgButtonPrefab;

    public GameObject orgRelevant;
    public OrgHeading orgHeadingButton;
    public OrgContributions orgContributions;
    public MainText mainText;

    void Start() { }

    private void Update() { }

    public void SetupOrgUI(string org)
    {
        orgHeadingButton.gameObject.SetActive(true);
        orgHeadingButton.ButtonSetup(library.topicLibrary[(int)library.currentTopic][0], org);
        orgContributions.gameObject.SetActive(true);
        mainText.SetHeadingAndBody("", OrgNameToData.nameToDescription[org]);
        orgRelevant.SetActive(false);
    }

    public void UpdateDropdown()
    {
        StartCoroutine(PopulateDropdown());
    }

    IEnumerator PopulateDropdown()
    {
        while (dropdown == null) yield return null;
        dropdown.AddOptions(DatabaseRetrievalTest.officeList);
    }

    public void UpdateScrollView()
    {
        StartCoroutine(PopulateScrollView());
    }

    IEnumerator PopulateScrollView()
    {
        foreach (string office in DatabaseRetrievalTest.officeList)
        {
            CreateOrgButton(office.ToUpper());
            yield return null;
        }
    }

    public GameObject CreateOrgButton(string orgName)
    {
        GameObject newButton = Instantiate(orgButtonPrefab, orgButtonGroupTransform);
        newButton.GetComponent<OrgButtonParams>().SetNameAndImage(orgName);
        // if (newButton.transform.parent.childCount == 1) newButton.GetComponent<OrgButtonParams>().topSeparator.SetActive(false);
        return newButton;
    }

    // temporary, just for the topic Children
    public void AddLibraryEntry(string orgName)
    {
        orgLibrary.Add(orgLibrary.Count, $"This is a brief summary of {orgName}'s contribution in {library.currentTopic}!");
        OrgNameToData.nameToDescription.Add(orgName.ToUpper(), $"This is a brief summary of {orgName}'s contribution in {library.currentTopic}!");
        OrgNameToData.indexToName.Add(orgLibrary.Count - 1, orgName.ToUpper());
        // foreach (int i in OrgNameToData.indexToName.Keys) print(i);
    }

    public void FilterOrg()
    {
        StartCoroutine(ReplaceMarkers());
    }

    public void FilterOrgButton(OrgButtonParams buttonParams)
    {
        StartCoroutine(ReplaceMarkersButton(buttonParams));
    }

    // button press triggers error because inactive in beginning
    public void DisableAllEvents(bool disableGameObject = false)
    {
        StartCoroutine(DisableEvents(disableGameObject));
    }

    IEnumerator ReplaceMarkersButton(OrgButtonParams buttonParams)
    {
        earthTransform.gameObject.GetComponent<EarthNavigator>().ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
        Transform currentTopicTransform = earthTransform.GetChild((int)library.currentTopic);
        blurb.text = OrgNameToData.nameToDescription[buttonParams.GetName()];

        foreach (Transform landmark in currentTopicTransform)
        {
            int id = landmark.gameObject.GetComponent<LandmarkObject>().GetMarkerOrgID();
            string orgName = OrgNameToData.indexToName[id];

            if (orgName != buttonParams.GetName())
            {
                landmark.gameObject.GetComponent<LandmarkObject>().DisableMarker();
                landmark.gameObject.GetComponent<LandmarkObject>().HideEvents();
            }
            else
            {
                landmark.gameObject.GetComponent<LandmarkObject>().EnableMarker();
                landmark.gameObject.GetComponent<LandmarkObject>().ShowEvents();
            }
            yield return null;
        }
    }


    IEnumerator ReplaceMarkers()
    {
        earthTransform.gameObject.GetComponent<EarthNavigator>().ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
        Transform currentTopicTransform = earthTransform.GetChild((int)library.currentTopic);
        
        // should depend on which org
        blurb.text = orgLibrary[dropdown.value];

        foreach (Transform landmark in currentTopicTransform)
        {
            int id = landmark.gameObject.GetComponent<LandmarkObject>().GetMarkerOrgID();

            if (dropdown.value == 0)
            {
                landmark.gameObject.GetComponent<LandmarkObject>().EnableMarker();
                landmark.gameObject.GetComponent<LandmarkObject>().HideEvents();
                yield return null;
            } else if (id != dropdown.value)
            {
                landmark.gameObject.GetComponent<LandmarkObject>().DisableMarker();
                landmark.gameObject.GetComponent<LandmarkObject>().HideEvents();
            } else
            {
                landmark.gameObject.GetComponent<LandmarkObject>().EnableMarker();
                landmark.gameObject.GetComponent<LandmarkObject>().ShowEvents();

            }
            yield return null;
        }
    }

    IEnumerator DisableEvents(bool disableDropdown = false)
    {
        Transform currentTopicTransform = earthTransform.GetChild((int)library.currentTopic);
        foreach (Transform landmark in currentTopicTransform)
        {
            // landmark.gameObject.GetComponent<LandmarkObject>().DisableMarker();
            landmark.gameObject.GetComponent<LandmarkObject>().HideEvents();
            yield return null;
        }
        if (disableDropdown) dropdown.gameObject.SetActive(false);
    }
}
