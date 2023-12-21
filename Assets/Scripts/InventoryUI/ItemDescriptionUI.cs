using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text descriptionText;

    [Header("Weapon")]
    [SerializeField]
    private GameObject weaponDescrpitionGO;
    [SerializeField]
    private TMP_Text weaponName;
    [SerializeField]
    private TMP_Text weaponDamage;
    [SerializeField]
    private TMP_Text weaponDamage_Slash;
    [SerializeField]
    private TMP_Text weaponDamage_Pierce;
    [SerializeField]
    private TMP_Text weaponDamage_Strike;
    [SerializeField]
    private TMP_Text weaponDescription;

    [Header("Gem")]
    [SerializeField]
    private GameObject gemDescrpitionGO;
    [SerializeField]
    private TMP_Text gemName;
    [SerializeField]
    private TMP_Text gemDescription;

    // Start is called before the first frame update
    void Start()
    {   
        gemDescrpitionGO.SetActive(false);
        weaponDescrpitionGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGemDescriptipon(ItemData_Gem data)
    {
        gemDescrpitionGO.SetActive(true);
        weaponDescrpitionGO.SetActive(false);
        
        gemName.text = data.Name;
        gemDescription.text = data.Description;
    }

    public void SetWeaponDescription(ItemData_Weapon data)
    {
        gemDescrpitionGO.SetActive(false);
        weaponDescrpitionGO.SetActive(true);

        weaponName.text = data.Name;
        weaponDamage.text = data.Damage.ToString();
        weaponDamage_Pierce.text = data.PierceValue.ToString();
        weaponDamage_Slash.text = data.SlashValue.ToString();
        weaponDamage_Strike.text = data.StrikeValue.ToString();
        weaponDescription.text = data.Description;
    }
}
