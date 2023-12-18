using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContributions : MonoBehaviour
{
    public Dictionary<(string, string), string> topicAndOrgToContribution;
    // public TopicLibrary topicLibrary;

    void Start()
    {
        topicAndOrgToContribution = new();
        PopulateDictionary(topicAndOrgToContribution);
    }

    void PopulateDictionary(Dictionary<(string, string), string> dict) 
    {
        // children
        dict.Add(("Children", "UNESCO"),
            "-<indent=10%>" + "World Heritage in Young Hands Educational Resource Kit" + "</indent=10%><br>" +
            "-<indent=10%>" + "Campus Africa: Reinforcing Higher Education in Africa" + "</indent=10%><br>" +
            "-<indent=10%>" + "Her Atlas: Interactive tool to monitor the status of national legal frameworks related to girlsÅf and womenÅfs right to education" + "</indent=10%><br>"
            );
        dict.Add(("Children", "WHO"),
            "-<indent=10%>" + "Global platform to monitor school health" + "</indent=10%><br>" +
            "-<indent=10%>" + "Caregiver Skills Training (CST) programme for caregivers of children with developmental delays and disabilities" + "</indent=10%><br>" +
            "-<indent=10%>" + "PAHO-UNIDO Project on e-waste and childrenÅfs health" + "</indent=10%><br>"
        );
        dict.Add(("Children", "UNICEF"),
            "-<indent=10%>" + "WASH (Water, Sanitation and Hygiene) strategy and infrastructure in over 100 countries" + "</indent=10%><br>" +
            "-<indent=10%>" + "Essential emergency responses with supplies, kits, vaccines for children" + "</indent=10%><br>" +
            "-<indent=10%>" + "Elimination of harmful practices like child labor, child marriage and FGM" + "</indent=10%><br>"
        );
        dict.Add(("Children", "WFP"),
            "-<indent=10%>" + "School Meal Programs and School Meals Coalition" + "</indent=10%><br>" +
            "-<indent=10%>" + "Home Grown School Feeding initiative that links local farmers to the schools" + "</indent=10%><br>" +
            "-<indent=10%>" + "Nutrition-based programs targeting pregnant women and young children." + "</indent=10%><br>"
        );
        dict.Add(("Children", "ILO"),
            "-<indent=10%>" + "The Asia Regional Child Labour (ARC) Project " + "</indent=10%><br>" +
            "-<indent=10%>" + "MAP 16 Project: Measurement, awareness-raising and policy engagement to accelerate action against child labour and forced labour" + "</indent=10%><br>" +
            "-<indent=10%>" + "CLEAR Cotton Project" + "</indent=10%><br>"
        );
        dict.Add(("Children", "FAO"),
            "-<indent=10%>" + "Global Action Plan for ending child wasting" + "</indent=10%><br>" +
            "-<indent=10%>" + "Education for Rural People (ERP) Tool Kit" + "</indent=10%><br>" +
            "-<indent=10%>" + "Junior Farmer Field and Life School (JFFLS) programme" + "</indent=10%><br>"
        );

        // refugees
        dict.Add(("Refugees", "UNHCR"),
            "-<indent=10%>" + "Mobilize supplies for refugees and provide staff to protect people forced to flee" + "</indent=10%><br>" +
            "-<indent=10%>" + "alent Beyond Boundaries Programme to matched 1,200 refugees to work opportunities overseas" + "</indent=10%><br>" 
        );
        dict.Add(("Refugees", "IOM"),
            "-<indent=10%>" + "Refugees and Resettlement Program" + "</indent=10%><br>" +
            "-<indent=10%>" + "Migration health assessments" + "</indent=10%><br>" +
            "-<indent=10%>" + "Travel Loans Program" + "</indent=10%><br>" +
            "-<indent=10%>" + "Migration Crisis Response" + "</indent=10%><br>"
        );
        dict.Add(("Refugees", "UNOCHA"),
            "-<indent=10%>" + "Multi-Purpose Cash Assistance" + "</indent=10%><br>" +
            "-<indent=10%>" + "Black Sea Initiative" + "</indent=10%><br>"
        );
        dict.Add(("Refugees", "WFP"),
            "-<indent=10%>" + "Cash-Based Transfers Programme" + "</indent=10%><br>" +
            "-<indent=10%>" + "INITIATE2 project to improve emergency health responses" + "</indent=10%><br>"
        );

        // gender equality
        dict.Add(("Gender Equality", "UN WOMEN"),
            "-<indent=10%>" + "Oasis programme to provide crucial cash-for-work, skill development, and early childhood services to more than 30,000 people, including many women with disabilities" + "</indent=10%><br>" +
            "-<indent=10%>" + "Contributing to the Empowerment of Women in Africa through Climate-Smart Agriculture Programme" + "</indent=10%><br>"
        );
        dict.Add(("Gender Equality", "UNICEF"),
            "-<indent=10%>" + "Maternal care and support for female front-line health workforce" + "</indent=10%><br>" +
            "-<indent=10%>" + "Education system and economic empowerment for adolescent girls" + "</indent=10%><br>" +
            "-<indent=10%>" + "Prevent and repond to gender-based violence" + "</indent=10%><br>" +
            "-<indent=10%>" + "Social protection and care" + "</indent=10%><br>"
        );
        dict.Add(("Gender Equality", "OHCHR"),
            "-<indent=10%>" + "Reform discriminatory laws and policies" + "</indent=10%><br>" +
            "-<indent=10%>" + "Transform discriminatory social norms and harmful gender stereotypes" + "</indent=10%><br>" +
            "-<indent=10%>" + "Eliminate gender-based violence" + "</indent=10%><br>" +
            "-<indent=10%>" + "#IStandWithHer Campaign" + "</indent=10%><br>"
        );
        dict.Add(("Gender Equality", "WHO"),
            "-<indent=10%>" + "Gender-responsive health service" + "</indent=10%><br>" +
            "-<indent=10%>" + "Health sector response to gender-based violence" + "</indent=10%><br>" +
            "-<indent=10%>" + "Address gender equality in health workforce development" + "</indent=10%><br>"
        );
        dict.Add(("Gender Equality", "UNFPA"),
            "-<indent=10%>" + "Ending preventable maternal death" + "</indent=10%><br>" +
            "-<indent=10%>" + "Tackling gender-based vioelnce and harmful practices" + "</indent=10%><br>" +
            "-<indent=10%>" + "Increase access to safe, voluntary family planning" + "</indent=10%><br>" +
            "-<indent=10%>" + "Promoting good sexual and reproductive health" + "</indent=10%><br>"
        );

    }

    public string GetMainContribution(string topicName, string orgName) 
    {
        return topicAndOrgToContribution[(topicName, orgName)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
