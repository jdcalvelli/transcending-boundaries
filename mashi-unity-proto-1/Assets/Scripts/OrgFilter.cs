using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrgFilter : MonoBehaviour
{
    public TopicLibrary library;
    public Transform earthTransform;
    public bool isDropdownUpdated = false;
    
    public Dictionary<int, string> orgLibrary = new() { { 0, "Choose from a list of organizations to see what they're up to!" } };
    public Transform orgButtonGroupTransform;
    public GameObject orgButtonPrefab;

    public GameObject orgRelevantList;
    public OrgHeading orgHeadingButton;
    public OrgContributions orgContributions;
    public MainText mainText;

    public LandmarkObject currentOrg;

    void Start() { }

    private void Update() { }

    public void SetupOrgUI(string org)
    {
        orgHeadingButton.gameObject.SetActive(true);
        orgHeadingButton.ButtonSetup(library.topicLibrary[(int)library.currentTopic][0], org);
        orgContributions.gameObject.SetActive(true);
        mainText.SetHeadingAndBody("", OrgNameToData.nameToDescription[org]);
        orgRelevantList.SetActive(false);
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

    public void FilterOrgButton(OrgButtonParams buttonParams)
    {
        StartCoroutine(ReplaceMarkersButton(buttonParams));
    }

    // button press triggers error because inactive in beginning
    public void DisableAllEvents()
    {
        StartCoroutine(DisableEvents());
    }

    IEnumerator ReplaceMarkersButton(OrgButtonParams buttonParams)
    {
        earthTransform.gameObject.GetComponent<EarthNavigator>().ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
        Transform currentTopicTransform = earthTransform.GetChild((int)library.currentTopic);

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
                currentOrg = landmark.gameObject.GetComponent<LandmarkObject>();
                landmark.gameObject.GetComponent<LandmarkObject>().EnableMarker();
                landmark.gameObject.GetComponent<LandmarkObject>().ShowEvents();
            }
            yield return null;
        }
    }

    IEnumerator DisableEvents()
    {
        Transform currentTopicTransform = earthTransform.GetChild((int)library.currentTopic);
        foreach (Transform landmark in currentTopicTransform)
        {
            // landmark.gameObject.GetComponent<LandmarkObject>().DisableMarker();
            landmark.gameObject.GetComponent<LandmarkObject>().HideEvents();
            yield return null;
        }
    }
}
