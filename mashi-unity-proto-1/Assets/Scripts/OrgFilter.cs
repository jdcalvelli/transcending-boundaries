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
    // private int lastDropdownValue;

    public Dictionary<int, string> orgLibrary = new() { { 0, "Choose from a list of organizations to see what they're up to!" } };
    private bool isDropdownUpdated = false;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        // orgLibrary.Add(0, "Choose from a list of organizations to see what they're up to!");
    }

    void Start()
    {
        
        // lastDropdownValue = 0;

        
/*        orgLibrary.Add(1, $"This is a brief summary of Org #1's contribution in Topic."); // summary per org per topic
        orgLibrary.Add(2, $"This is a brief summary of Org #2's contribution in Topic."); // e.g. if 6 orgs and 5 topics,
        orgLibrary.Add(3, $"This is a brief summary of Org #3's contribution in Topic."); // then 30 unique descriptions?
        orgLibrary.Add(4, $"This is a brief summary of Org #4's contribution in Topic.");
        orgLibrary.Add(5, $"This is a brief summary of Org #5's contribution in Topic.");*/
    }

    private void Update()
    {
        if (!isDropdownUpdated)
        {
            if (dropdown != null)
            {
                dropdown.AddOptions(DatabaseRetrievalTest.officeList);
                isDropdownUpdated = true;
            }
        }
    }

    // temporary, just for children
    public void AddLibraryEntry(string orgName)
    {
        orgLibrary.Add(orgLibrary.Count, $"This is a brief summary of {orgName}'s contribution in {library.currentTopic}!");
    }

    public void FilterOrg()
    {
        StartCoroutine(ReplaceMarkers());
    }

    // button press triggers error because inactive in beginning
    public void DisableAllEvents()
    {
        StartCoroutine(DisableEvents());
    }

    IEnumerator ReplaceMarkers()
    {
        earthTransform.gameObject.GetComponent<EarthNavigator>().ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
        Transform currentTopicTransform = earthTransform.GetChild((int)library.currentTopic);
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
        // lastDropdownValue = dropdown.value;
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

    //temp
    private void OnEnable()
    {
        dropdown.AddOptions(DatabaseRetrievalTest.officeList);
    }
}
