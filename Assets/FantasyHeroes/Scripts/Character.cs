using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Character presentation in editor
/// </summary>
[ExecuteInEditMode]
public class Character : MonoBehaviour
{
    [Header("Body")]
    public Texture2D Head;
    public Texture2D Ears;
    public Texture2D Hair;
    public Texture2D Eyebrows;
    public Texture2D Eyes;
    public Texture2D Mouth;
    public Texture2D Beard;
    public Texture2D Body;

    [Header("Equipment")]
    public Texture2D Helmet;
    public Texture2D Weapon;
    public Texture2D Armor;
    public Texture2D Shield;
    public Texture2D Bow;

    [Header("Renderers")]
    public SpriteRenderer HeadRenderer;
    public SpriteRenderer EarsRenderer;
    public SpriteRenderer HairRenderer;
    public SpriteRenderer EyebrowsRenderer;
    public SpriteRenderer EyesRenderer;
    public SpriteRenderer MouthRenderer;
    public SpriteRenderer BeardRenderer;
    public SpriteRenderer[] BodyRenderers;
    public SpriteRenderer HelmetRenderer;
    public SpriteRenderer WeaponRenderer;
    public SpriteRenderer[] ArmorRenderers;
    public SpriteRenderer[] BowRenderers;
    public SpriteRenderer ShieldRenderer;

    [Header("Animation")]
    public Animator Animator;
    public WeaponType WeaponType;
    SpriteCollection sp;
    CharacterEditor ce;
    Text charName;

    DatabaseController dc;
    CharacterModel cm;
    CharacterColorModel ccm;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("CharacterEditor"))
        {
            sp = GameObject.Find("SpriteCollection").GetComponent<SpriteCollection>();
            ce = GameObject.Find("CharacterEditor").GetComponent<CharacterEditor>();
            //sp.Refresh();

        }
        else
        {
            sp = GameObject.Find("GameMananger").GetComponent<SpriteCollection>();
        }

        cm = new CharacterModel();
        ccm = new CharacterColorModel();

        dc = GameObject.Find("DataBase").GetComponent<DatabaseController>();

        getCharacter();
    }
    public void saveCharacter()
    {
        if (Head != null)
            cm.Head = Head.name;
        else
            cm.Head = "0";
        if (Ears != null)
            cm.Ears = Ears.name;
        else
            cm.Ears = "0";
        if (Hair != null)
            cm.Hair = Hair.name;
        else
            cm.Hair = "0";
        if (Eyebrows != null)
            cm.Eyebrows = Eyebrows.name;
        else
            cm.Eyebrows = "0";
        if (Eyes != null)
            cm.Eyes = Eyes.name;
        else
            cm.Eyes = "0";
        if (Mouth != null)
            cm.Mouth = Mouth.name;
        else
            cm.Mouth = "0";
        if (Beard != null)
            cm.Beard = Beard.name;
        else
            cm.Beard = "0";
        if (Body != null)
            cm.Body = Body.name;
        else
            cm.Body = "0";

        dc.saveCharacter(cm);
        SceneManager.LoadScene("Scene1");
    }
    public void saveName()
    {
        charName = GameObject.FindObjectOfType<Canvas>()
            .transform.Find("Character")
            .Find("NameContainer").Find("Name").Find("Text").GetComponent<Text>();
        if (charName.text != "")
            PlayerPrefs.SetString("CharName", charName.text.ToString());
        else
            PlayerPrefs.SetString("CharName", "Davohkiin");

    }
    public void getCharacter()
    {
        if (SceneManager.GetActiveScene().name.Equals("CharacterEditor"))
        {

            defaultChar();
            ce.Refresh();
        }
        else
        {
            cm = dc.getCharacter();
            ccm = dc.getCharacterColors();
            equipHair(cm.Hair);
            equipHead(cm.Head);
            equipEyes(cm.Eyes);
            equipEyebrows(cm.Eyebrows);
            equipMouth(cm.Mouth);
            equipBeard(cm.Beard);
            equipBody(cm.Body);
            equipEars(cm.Ears);
        }
        Initialize();
    }

    public void equipHair(string name)
    {
        if (name == "0")
        {
            Hair = null;
            return;
        }
        foreach (Texture2D t in sp.Hair)
        {
            if (t.name == name)
            {
                Hair = t;
            }
        }
        print(ccm.HairColor);

        HairRenderer.color = toColor(ccm.HairColor);

    }
    public void equipHead(string name)
    {
        if (name == "0")
        {
            Head = null;
            return;
        }
        foreach (Texture2D t in sp.Head)
        {
            if (t.name == name)
            {
                Head = t;
            }
        }
        foreach (var b in BodyRenderers)
        {
            b.color = toColor(ccm.HeadColor);
        }
        HeadRenderer.color = toColor(ccm.HeadColor);
    }
    public void equipEyes(string name)
    {
        if (name == "0")
        {
            Eyes = null;
            return;
        }
        foreach (Texture2D t in sp.Eyes)
        {
            if (t.name == name)
            {
                Eyes = t;
            }
        }
    }
    public void equipEyebrows(string name)
    {
        if (name == "0")
        {
            Eyebrows = null;
            return;
        }
        foreach (Texture2D t in sp.Eyebrows)
        {
            if (t.name == name)
            {
                Eyebrows = t;
            }
        }
        EyebrowsRenderer.color = toColor(ccm.EyebrowsColor);
    }
    public void equipMouth(string name)
    {
        if (name == "0")
        {
            Mouth = null;
            return;
        }
        foreach (Texture2D t in sp.Mouth)
        {
            if (t.name == name)
            {
                Mouth = t;
            }
        }
    }
    public void equipBeard(string name)
    {
        if (name == "0")
        {
            Beard = null;
            return;
        }
        foreach (Texture2D t in sp.Beard)
        {
            if (t.name == name)
            {
                Beard = t;
            }
        }
        BeardRenderer.color = toColor(ccm.BeardColor);
    }
    public void equipBody(string name)
    {
        if (name == "0")
        {
            Body = null;
            return;
        }
        foreach (Texture2D t in sp.Body)
        {
            if (t.name == name)
            {
                Body = t;
            }
        }
    }
    public void equipEars(string name)
    {
        if (name == "0")
        {
            Ears = null;
            return;
        }
        foreach (Texture2D t in sp.Ears)
        {
            if (t.name == name)
            {
                Ears = t;
            }
        }
        EarsRenderer.color = toColor(ccm.EarsColor);

    }
    public Color toColor(string color)
    {
        Color cResp = new Color();
        char[] chars = color.ToCharArray();
        float r = float.Parse((chars[5].ToString() + chars[6].ToString() + chars[7].ToString() + chars[8].ToString() + chars[9].ToString()), CultureInfo.InvariantCulture.NumberFormat);
        float g = float.Parse((chars[12].ToString() + chars[13].ToString() + chars[14].ToString() + chars[15].ToString() + chars[16].ToString()), CultureInfo.InvariantCulture.NumberFormat);
        float b = float.Parse((chars[19].ToString() + chars[20].ToString() + chars[21].ToString() + chars[22].ToString() + chars[23].ToString()), CultureInfo.InvariantCulture.NumberFormat);

        cResp.r = r;
        cResp.g = g;
        cResp.b = b;
        cResp.a = 1;

        return cResp;

    }

    public void defaultChar()
    {
        setDefaultColor();
        Head = sp.Head[0];
        Ears = sp.Ears[1];
        Hair = sp.Hair[0];
        Eyes = sp.Eyes[12];
        Eyebrows = sp.Eyebrows[1];
        Mouth = null;
        Beard = sp.Beard[0];

        HeadRenderer.color = toColor(ccm.HeadColor);
        foreach(var b in BodyRenderers)
        {
            b.color = toColor(ccm.HeadColor);
        }
        EarsRenderer.color = toColor(ccm.EarsColor);
        HairRenderer.color = toColor(ccm.HairColor);
        EyebrowsRenderer.color = toColor(ccm.EyebrowsColor);
        BeardRenderer.color = toColor(ccm.BeardColor);
    }
    public void setDefaultColor()
    {
        ccm.BeardColor = "RGBA(1.000, 1.000, 0.000, 1.000)";
        ccm.EarsColor = "RGBA(0.941, 0.745, 0.471, 1.000)";
        ccm.HairColor = "RGBA(1.000, 1.000, 0.000, 1.000)";
        ccm.HeadColor = "RGBA(0.941, 0.745, 0.471, 1.000)";
        ccm.EyebrowsColor = "RGBA(1.000, 1.000, 0.000, 1.000)";
    }
    
    /// <summary>
    /// Called automatically when something was changed
    /// </summary>
    public void OnValidate()
    {
        if (Head == null) return;

        Initialize();
    }

    /// <summary>
    /// Initialize character renderers with selected sprites
    /// </summary>
    public void Initialize()
    {
        ReplaceSprite(HeadRenderer, Head);
        ReplaceSprite(EarsRenderer, Ears);
        ReplaceSprite(HairRenderer, Hair);
        ReplaceSprite(EyebrowsRenderer, Eyebrows);
        ReplaceSprite(EyesRenderer, Eyes);
        ReplaceSprite(MouthRenderer, Mouth);
        ReplaceSprite(BeardRenderer, Beard);
        ReplaceSprite(HelmetRenderer, Helmet);
        ReplaceSprite(WeaponRenderer, Weapon);
        ReplaceTexture(BodyRenderers, Body);
        ReplaceTexture(ArmorRenderers, Armor);
        ReplaceTexture(BowRenderers, Bow);
        ReplaceSprite(ShieldRenderer, Shield);

        WeaponRenderer.enabled = true;
        ShieldRenderer.enabled = true;
        //WeaponRenderer.enabled = WeaponType == WeaponType.Melee1H || WeaponType == WeaponType.Melee2H;
        //ShieldRenderer.enabled = WeaponType == WeaponType.Melee1H;

        //foreach (var part in BowRenderers)
        //{
        //    part.enabled = WeaponType == WeaponType.Bow;
        //}
    }

    private static void ReplaceSprite(SpriteRenderer part, Texture2D texture)
    {
        if (texture == null)
        {
            part.sprite = null;
            return;
        }
        var layout = part.GetComponent<SpriteLayout>();
        var pivot = new Vector2(layout.Pivot.x / layout.Rect.width, layout.Pivot.y / layout.Rect.height);

        part.sprite = Sprite.Create(texture, layout.Rect, pivot, 100, 2, SpriteMeshType.Tight);
        part.sprite.name = "Dynamic";
    }

    private static void ReplaceTexture(IEnumerable<SpriteRenderer> parts, Texture2D texture)
    {
        foreach (var part in parts)
        {
            ReplaceSprite(part, texture);
        }
    }


}
