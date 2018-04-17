using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BarbarianCharacterCustomization : MonoBehaviour
    {

        public GameObject PLAYER_CHARACTER;
        public Material[] PLAYER_SKIN;
        public GameObject CLOTH_01LOD0;
        public GameObject CLOTH_01LOD0_SKIN;
        public GameObject CLOTH_02LOD0;
        public GameObject CLOTH_02LOD0_SKIN;
        public GameObject CLOTH_03LOD0;
        public GameObject CLOTH_03LOD0_SKIN;
        public GameObject CLOTH_03LOD0_FAT;
        public GameObject BELT_LOD0;
        public GameObject SKN_LOD0;
        public GameObject HAIR_LOD0;
        public GameObject BOW_LOD0;

        // Head Equipment
        public GameObject GLADIATOR_01LOD0;
        public GameObject HELMET_01LOD0;
        public GameObject HELMET_02LOD0;
        public GameObject HELMET_03LOD0;
        public GameObject HELMET_04LOD0;

        // Shoulder Pad - Right Arm / Left Arm
        public GameObject SHOULDER_PAD_R_01LOD0;
        public GameObject SHOULDER_PAD_R_02LOD0;
        public GameObject SHOULDER_PAD_R_03LOD0;
        public GameObject SHOULDER_PAD_R_04LOD0;

        public GameObject SHOULDER_PAD_L_01LOD0;
        public GameObject SHOULDER_PAD_L_02LOD0;
        public GameObject SHOULDER_PAD_L_03LOD0;
        public GameObject SHOULDER_PAD_L_04LOD0;

        // Fore Arm - Right / Left Plates
        public GameObject ARM_PLATE_R_1LOD0;
        public GameObject ARM_PLATE_R_2LOD0;

        public GameObject ARM_PLATE_L_1LOD0;
        public GameObject ARM_PLATE_L_2LOD0;

        // Player Character Weapons
        public GameObject AXE_01LOD0;
        public GameObject AXE_02LOD0;
        public GameObject CLUB_01LOD0;
        public GameObject CLUB_02LOD0;
        public GameObject FALCHION_LOD0;
        public GameObject GLADIUS_LOD0;
        public GameObject MACE_LOD0;
        public GameObject MAUL_LOD0;
        public GameObject SCIMITAR_LOD0;
        public GameObject SPEAR_LOD0;
        public GameObject SWORD_BASTARD_LOD0;
        public GameObject SWORD_BOARD_01LOD0;
        public GameObject SWORD_SHORT_LOD0;

        // Player Character Defense Weapons
        public GameObject SHIELD_01LOD0;
        public GameObject SHIELD_02LOD0;
        public GameObject QUIVER_LOD0;
        public GameObject BOW_01_LOD0;

        // Player Character Calf - Right / Left
        public GameObject KNEE_PAD_R_LOD0;
        public GameObject LEG_PLATE_R_LOD0;

        public GameObject KNEE_PAD_L_LOD0;
        public GameObject LEG_PLATE_L_LOD0;

        public GameObject BOOT_01LOD0;
        public GameObject BOOT_02LOD0;

        public bool RotateModel = false;

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                RotateModel = !RotateModel;
            }

            if (RotateModel)
            {
                PLAYER_CHARACTER.transform.Rotate(new Vector3(0, 1, 0), 33.0f * Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                Debug.Log(PlayerPrefs.GetString("NAME"));
            }
        }

        public void SetShoulderPad(Toggle id)
        {
            switch (id.name)
            {
                case "SP01":
                {
                    SHOULDER_PAD_R_01LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_R_02LOD0.SetActive(false);
                    SHOULDER_PAD_R_03LOD0.SetActive(false);
                    SHOULDER_PAD_R_04LOD0.SetActive(false);
                    SHOULDER_PAD_L_01LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_L_02LOD0.SetActive(false);
                    SHOULDER_PAD_L_03LOD0.SetActive(false);
                    SHOULDER_PAD_L_04LOD0.SetActive(false);
                    Debug.Log(string.Format("Activating {0}", id.name));
                    PlayerPrefs.SetInt("SP-01", 1);
                    PlayerPrefs.SetInt("SP-02", 0);
                    PlayerPrefs.SetInt("SP-03", 0);
                    PlayerPrefs.SetInt("SP-04", 0);
                    break;
                }

                case "SP02":
                {
                    SHOULDER_PAD_R_01LOD0.SetActive(false);
                    SHOULDER_PAD_R_02LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_R_03LOD0.SetActive(false);
                    SHOULDER_PAD_R_04LOD0.SetActive(false);
                    SHOULDER_PAD_L_01LOD0.SetActive(false);
                    SHOULDER_PAD_L_02LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_L_03LOD0.SetActive(false);
                    SHOULDER_PAD_L_04LOD0.SetActive(false);
                    PlayerPrefs.SetInt("SP-01", 0);
                    PlayerPrefs.SetInt("SP-02", 1);
                    PlayerPrefs.SetInt("SP-03", 0);
                    PlayerPrefs.SetInt("SP-04", 0);
                    break;
                }

                case "SP03":
                {
                    SHOULDER_PAD_R_01LOD0.SetActive(false);
                    SHOULDER_PAD_R_02LOD0.SetActive(false);
                    SHOULDER_PAD_R_03LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_R_04LOD0.SetActive(false);
                    SHOULDER_PAD_L_01LOD0.SetActive(false);
                    SHOULDER_PAD_L_02LOD0.SetActive(false);
                    SHOULDER_PAD_L_03LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_L_04LOD0.SetActive(false);
                    PlayerPrefs.SetInt("SP-01", 0);
                    PlayerPrefs.SetInt("SP-02", 0);
                    PlayerPrefs.SetInt("SP-03", 1);
                    PlayerPrefs.SetInt("SP-04", 0);
                    break;
                }

                case "SP04":
                {
                    SHOULDER_PAD_R_01LOD0.SetActive(false);
                    SHOULDER_PAD_R_02LOD0.SetActive(false);
                    SHOULDER_PAD_R_03LOD0.SetActive(false);
                    SHOULDER_PAD_R_04LOD0.SetActive(id.isOn);
                    SHOULDER_PAD_L_01LOD0.SetActive(false);
                    SHOULDER_PAD_L_02LOD0.SetActive(false);
                    SHOULDER_PAD_L_03LOD0.SetActive(false);
                    SHOULDER_PAD_L_04LOD0.SetActive(id.isOn);
                    PlayerPrefs.SetInt("SP-01", 0);
                    PlayerPrefs.SetInt("SP-02", 0);
                    PlayerPrefs.SetInt("SP-03", 0);
                    PlayerPrefs.SetInt("SP-04", 1);
                    break;
                }
            }
        }

        public void SetKneePad(Toggle id)
        {
            KNEE_PAD_R_LOD0.SetActive(id.isOn);
            KNEE_PAD_L_LOD0.SetActive(id.isOn);
        }

        public void SetLegPlate(Toggle id)
        {
            LEG_PLATE_R_LOD0.SetActive(id.isOn);
            LEG_PLATE_L_LOD0.SetActive(id.isOn);
        }

        public void SetWeaponType(Slider id)
        {
            switch (System.Convert.ToInt32(id.value))
            {
                case 0:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 1:
                {
                    AXE_01LOD0.SetActive(true);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 2:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(true);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 3:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(true);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 4:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(true);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 5:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(true);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 6:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(true);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 7:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(true);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 8:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(true);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 9:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(true);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 10:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(true);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 11:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(true);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 12:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(true);
                    SWORD_SHORT_LOD0.SetActive(false);
                    break;
                }

                case 13:
                {
                    AXE_01LOD0.SetActive(false);
                    AXE_02LOD0.SetActive(false);
                    CLUB_01LOD0.SetActive(false);
                    CLUB_02LOD0.SetActive(false);
                    FALCHION_LOD0.SetActive(false);
                    GLADIUS_LOD0.SetActive(false);
                    MACE_LOD0.SetActive(false);
                    MAUL_LOD0.SetActive(false);
                    SCIMITAR_LOD0.SetActive(false);
                    SPEAR_LOD0.SetActive(false);
                    SWORD_BASTARD_LOD0.SetActive(false);
                    SWORD_BOARD_01LOD0.SetActive(false);
                    SWORD_SHORT_LOD0.SetActive(true);
                    break;
                }
            }
        }

        public void SetHelmetType(Toggle id)
        {
            switch (id.name)
            {
                case "HL01":
                {
                    HELMET_01LOD0.SetActive(id.isOn);
                    HELMET_02LOD0.SetActive(false);
                    HELMET_03LOD0.SetActive(false);
                    HELMET_04LOD0.SetActive(false);
                    break;
                }

                case "HL02":
                {
                    HELMET_01LOD0.SetActive(false);
                    HELMET_02LOD0.SetActive(id.isOn);
                    HELMET_03LOD0.SetActive(false);
                    HELMET_04LOD0.SetActive(false);
                    break;
                }

                case "HL03":
                {
                    HELMET_01LOD0.SetActive(false);
                    HELMET_02LOD0.SetActive(false);
                    HELMET_03LOD0.SetActive(id.isOn);
                    HELMET_04LOD0.SetActive(false);
                    break;
                }

                case "HL04":
                {
                    HELMET_01LOD0.SetActive(false);
                    HELMET_02LOD0.SetActive(false);
                    HELMET_03LOD0.SetActive(false);
                    HELMET_04LOD0.SetActive(id.isOn);
                    break;
                }
            }
        }
    }
}
