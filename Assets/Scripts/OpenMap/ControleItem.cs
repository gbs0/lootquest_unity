using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleItem : MonoBehaviour
{
    public GameObject SlimceCrown;
    public GameObject MonthlySardine;
    public GameObject CrystalBob;
    public GameObject LovesWhip;
    public GameObject WhispersofLoot;
    public GameObject FestiveBox;
    public GameObject CreatuurrsGauntlet;

    public Image ItemVisual;
    public Text Descricao;
    public Text Habilidade;
    public Text BotaoEquip;

    public int EquipamentoNumero;
    public GameObject DescricaoQuadro;

    public Sprite ItemSlimceCrown;
    public Sprite ItemMonthlySardine;
    public Sprite ItemCrystalBob;
    public Sprite ItemLovesWhip;
    public Sprite ItemWhispersofLoot;
    public Sprite ItemFestiveBox;
    public Sprite ItemCreatuurrsGauntlet;

    public GameObject Instrução2;


    public GameObject CristalSlimceCrown;
    public GameObject CristalMonthlySardine;
    public GameObject CristalBob;
    public GameObject CristalChicote;
    public GameObject CristalFantasma;
    public GameObject CristalManopla;



    // Start is called before the first frame update
    void Start()
    {
    }

// Update is called once per frame
void Update()
    {
        if (PlayerPrefs.GetInt("DialogoGuilda", 0) == 5)
        {
            CristalSlimceCrown.SetActive(true);
            Instrução2.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Gatos") == 1)
        {
            CristalMonthlySardine.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Dragao") == 1)
        {
            CristalBob.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Sucubus") == 1)
        {
            CristalChicote.SetActive(true);

        }
        if (PlayerPrefs.GetInt("SlimceCrown", 0) >= 1)
        {
            SlimceCrown.SetActive(true);
            CristalSlimceCrown.SetActive(false);
            Instrução2.SetActive(false);

        }
        if (PlayerPrefs.GetInt("MonthlySardine", 0) >= 1)
        {
            MonthlySardine.SetActive(true);
            CristalMonthlySardine.SetActive(false);

        }
        if (PlayerPrefs.GetInt("CrystalBob", 0) >= 1)
        {
            CrystalBob.SetActive(true);
            CristalBob.SetActive(false);


        }
        if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
        {
            LovesWhip.SetActive(true);
            CristalChicote.SetActive(false);


        }
        if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
        {
            WhispersofLoot.SetActive(true);
            CristalFantasma.SetActive(false);

        }
        if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
        {
            FestiveBox.SetActive(true);

        }
        if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
        {
            CreatuurrsGauntlet.SetActive(true);

            CristalManopla.SetActive(false);

        }
        if (EquipamentoNumero == 1)
        {
            if (PlayerPrefs.GetInt("SlimceCrown", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("SlimceCrown", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
        if (EquipamentoNumero == 2)
        {
            if (PlayerPrefs.GetInt("MonthlySardine", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("MonthlySardine", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
        if (EquipamentoNumero == 3)
        {
            if (PlayerPrefs.GetInt("CrystalBob", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("CrystalBob", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
        if (EquipamentoNumero == 4)
        {
            if (PlayerPrefs.GetInt("LovesWhip", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("LovesWhip", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
        if (EquipamentoNumero == 5)
        {
            if (PlayerPrefs.GetInt("FestiveBox", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("FestiveBox", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
        if (EquipamentoNumero == 6)
        {
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
        if (EquipamentoNumero == 7)
        {
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) == 2)

            {
                BotaoEquip.text = "Equipped";
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) == 1)

            {
                BotaoEquip.text = "Equip";
            }
        }
    }

    public void Item1()
    {
        if (PlayerPrefs.GetInt("SlimceCrown", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemSlimceCrown;
            Descricao.text = "A crown of slices, you can use it if you want, but even if it is kind of cute, is slimy.";
            Habilidade.text = "Abiliity:Gives you a bonus of +half of life to you HP";
            EquipamentoNumero = 1;
            
           
        }
    }
    public void Item2()
    {
        if (PlayerPrefs.GetInt("MonthlySardine", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemMonthlySardine;
            Descricao.text = "Is your salary, you get one every end of month.";
            Habilidade.text = "Abiliity:Gives you a bonus of +1 movement";
            EquipamentoNumero = 2;
            
        }
    }
    public void Item3()
    {
        if (PlayerPrefs.GetInt("CrystalBob", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemCrystalBob;
            Descricao.text = "I know you are thinking that this looks familiar, and you are right! It was the crystal at the top of EAragon’s head, duh.";
            Habilidade.text = "Abiliity:Gives you +2 gold";
            EquipamentoNumero = 3;
            
        }
    }
    public void Item4()
    {
        if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemLovesWhip;
            Descricao.text = "With this whip you can make some feel pain, others feel... love. ";
            Habilidade.text = "Abiliity:Gives you a bonus of +1 attack";
            EquipamentoNumero = 4;
            
        }
    }
    public void Item5()
    {
        if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemFestiveBox;
            Descricao.text = "Everything that a event loot box can be! It is kinda messy, isn’t it?";
            Habilidade.text = "Abiliity:";
            EquipamentoNumero = 5;
           
        }
    }
    public void Item6()
    {
        if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemWhispersofLoot;
            Descricao.text = "Little spirits that were once loots. They are shy, were you luck to find one?";
            Habilidade.text = "Abiliity:Gives you a bonus of +1 loot";
            EquipamentoNumero = 6;         
        }
    }
    public void Item7()
    {
        if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
        {
            DescricaoQuadro.SetActive(true);
            ItemVisual.sprite = ItemCreatuurrsGauntlet;
            Descricao.text = "A super original gauntlet that once belonged to the creators. You can hear some purrings and meows coming from it, time to time.";
            Habilidade.text = "Abiliity:Relentless! Gives you a bonus of +1 attack, +1 movement. +2 gold and also +half of your life!";
            EquipamentoNumero = 7;         
        }
    }
    public void Equipe()
    {
        if (EquipamentoNumero == 1)
        {
            PlayerPrefs.SetInt("SlimceCrown", 2);
            if (PlayerPrefs.GetInt("MonthlySardine", 0) >= 1)
            {
                PlayerPrefs.SetInt("MonthlySardine", 1);
            }
            if (PlayerPrefs.GetInt("CrystalBob", 0) >= 1)
            {
                PlayerPrefs.SetInt("CrystalBob", 1);
            }
            if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
            {
                PlayerPrefs.SetInt("LovesWhip", 1);
            }
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
            {
                PlayerPrefs.SetInt("WhispersofLoot", 1);
            }
            if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
            {
                PlayerPrefs.SetInt("FestiveBox", 1);
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
            {
                PlayerPrefs.SetInt("CreatuurrsGauntlet", 1);
            }
            PlayerPrefs.SetInt("Equip", 1);
            Item1();
        }
        if (EquipamentoNumero == 2)
        {
            PlayerPrefs.SetInt("SlimceCrown", 1);
            PlayerPrefs.SetInt("MonthlySardine", 2);
            if (PlayerPrefs.GetInt("CrystalBob", 0) >= 1)
            {
                PlayerPrefs.SetInt("CrystalBob", 1);
            }
            if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
            {
                PlayerPrefs.SetInt("LovesWhip", 1);
            }
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
            {
                PlayerPrefs.SetInt("WhispersofLoot", 1);
            }
            if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
            {
                PlayerPrefs.SetInt("FestiveBox", 1);
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
            {
                PlayerPrefs.SetInt("CreatuurrsGauntlet", 1);
            }
            PlayerPrefs.SetInt("Equip", 2);
        }
        if (EquipamentoNumero == 3)
        {
            PlayerPrefs.SetInt("SlimceCrown", 1);
            PlayerPrefs.SetInt("MonthlySardine", 1);
            PlayerPrefs.SetInt("CrystalBob", 2);
            if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
            {
                PlayerPrefs.SetInt("LovesWhip", 1);
            }
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
            {
                PlayerPrefs.SetInt("WhispersofLoot", 1);
            }
            if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
            {
                PlayerPrefs.SetInt("FestiveBox", 1);
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
            {
                PlayerPrefs.SetInt("CreatuurrsGauntlet", 1);
            }
            PlayerPrefs.SetInt("Equip", 3);
        }
        if (EquipamentoNumero == 4)
        {
            PlayerPrefs.SetInt("SlimceCrown", 1);
            PlayerPrefs.SetInt("MonthlySardine", 1);
            PlayerPrefs.SetInt("CrystalBob", 1);
            PlayerPrefs.SetInt("LovesWhip", 2);
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
            {
                PlayerPrefs.SetInt("WhispersofLoot", 1);
            }
            if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
            {
                PlayerPrefs.SetInt("FestiveBox", 1);
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
            {
                PlayerPrefs.SetInt("CreatuurrsGauntlet", 1);
            }
            PlayerPrefs.SetInt("Equip", 4);
        }
        if (EquipamentoNumero == 5)
        {
            PlayerPrefs.SetInt("SlimceCrown", 1);
            PlayerPrefs.SetInt("MonthlySardine", 1);
            PlayerPrefs.SetInt("CrystalBob", 1);
            if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
            {
                PlayerPrefs.SetInt("LovesWhip", 1);
            }
            PlayerPrefs.SetInt("WhispersofLoot", 2);
            if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
            {
                PlayerPrefs.SetInt("FestiveBox", 1);
            }
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
            {
                PlayerPrefs.SetInt("CreatuurrsGauntlet", 1);
            }
            PlayerPrefs.SetInt("Equip", 5);
        }
        if (EquipamentoNumero == 6)
        {
            PlayerPrefs.SetInt("SlimceCrown", 1);
            PlayerPrefs.SetInt("MonthlySardine", 1);
            PlayerPrefs.SetInt("CrystalBob", 1);
            PlayerPrefs.SetInt("LovesWhip", 1);
            PlayerPrefs.SetInt("WhispersofLoot", 1);
            PlayerPrefs.SetInt("FestiveBox", 2);
            if (PlayerPrefs.GetInt("CreatuurrsGauntlet", 0) >= 1)
            {
                PlayerPrefs.SetInt("CreatuurrsGauntlet", 1);
            }
            PlayerPrefs.SetInt("Equip", 6);

        }
        if (EquipamentoNumero == 7)
        {
            PlayerPrefs.SetInt("SlimceCrown", 1);
            if (PlayerPrefs.GetInt("MonthlySardine", 0) >= 1)
            {
                PlayerPrefs.SetInt("MonthlySardine", 1);
            }
            if (PlayerPrefs.GetInt("CrystalBob", 0) >= 1)
            {
                PlayerPrefs.SetInt("CrystalBob", 1);
            }
            if (PlayerPrefs.GetInt("LovesWhip", 0) >= 1)
            {
                PlayerPrefs.SetInt("LovesWhip", 1);
            }
            if (PlayerPrefs.GetInt("WhispersofLoot", 0) >= 1)
            {
                PlayerPrefs.SetInt("WhispersofLoot", 1);
            }
            if (PlayerPrefs.GetInt("FestiveBox", 0) >= 1)
            {
                PlayerPrefs.SetInt("FestiveBox", 1);
            }
            PlayerPrefs.SetInt("CreatuurrsGauntlet", 2);
            PlayerPrefs.SetInt("Equip", 7);
        }
    }
}
