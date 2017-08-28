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

        private void Start()
        {

            if (SceneManager.GetActiveScene().name.Equals("CharacterEditor"))
            {
                sp = GameObject.Find("SpriteCollection").GetComponent<SpriteCollection>();
                ce = GameObject.Find("CharacterEditor").GetComponent<CharacterEditor>();
                //sp.Refresh();
                deleteChar();
            }
            else
            {
                sp = GameObject.Find("GameMananger").GetComponent<SpriteCollection>();
            }
            getCharacter();
        }
        public void saveCharacter()
        {
            deleteChar();
            saveHead();
            saveEars();
            saveHair();
            saveEyebrows();
            saveEyes();
            saveMouth();
            saveBeard();
            saveName();
            SceneManager.LoadScene("Scene1");

        }
        public void saveName()
        {
            charName = GameObject.FindObjectOfType<Canvas>()
                .transform.Find("Character")
                .Find("NameContainer").Find("Name").Find("Text").GetComponent<Text>();
            if(charName.text != "")
                PlayerPrefs.SetString("CharName", charName.text.ToString());
            else
                PlayerPrefs.SetString("CharName", "Davohkiin");

        }
        public void getCharacter()
        {
            if (SceneManager.GetActiveScene().name.Equals("CharacterEditor"))
            {
                setDefaultColor();
                defaultChar();
                           
               
                ce.Refresh();

            }
            else
            {
               // sp.Refresh();
                getHead();
                getEars();
                getHair();
                getEyebrows();
                getEyes();
                getMouth();
                getBeard();
            }

           
            Initialize();

        }

        public void deleteChar()
        {
            PlayerPrefs.DeleteKey("Head");
            PlayerPrefs.DeleteKey("Ears");
            PlayerPrefs.DeleteKey("Hair");
            PlayerPrefs.DeleteKey("Eyes");
            PlayerPrefs.DeleteKey("Eyebrows");
            PlayerPrefs.DeleteKey("Mouth");
            PlayerPrefs.DeleteKey("Beard");            
            
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
            if(!PlayerPrefs.HasKey("Head") && !PlayerPrefs.HasKey("Ears") && !PlayerPrefs.HasKey("Hair")
                && !PlayerPrefs.HasKey("Eyes") && !PlayerPrefs.HasKey("Eyebrows") && !PlayerPrefs.HasKey("Mouth"))
            {                
                Head = sp.Head[0];
                Ears = sp.Ears[1];
                Hair = sp.Hair[0];
                Eyes = sp.Eyes[12];
                Eyebrows = sp.Eyebrows[1];
                Mouth = null;
                Beard = sp.Beard[0];

                HeadRenderer.color = (toColor(PlayerPrefs.GetString("HeadColor")));
                EarsRenderer.color = (toColor(PlayerPrefs.GetString("EarsColor")));
                HairRenderer.color = (toColor(PlayerPrefs.GetString("HairColor")));
                EyebrowsRenderer.color = (toColor(PlayerPrefs.GetString("EyebrowsColor")));
                BeardRenderer.color = (toColor(PlayerPrefs.GetString("BeardColor")));                
                
            }
        }
        public void setDefaultColor()
        {
            PlayerPrefs.SetString("HeadColor", "RGBA(0.941, 0.745, 0.471, 1.000)");
            PlayerPrefs.SetString("EarsColor", "RGBA(0.941, 0.745, 0.471, 1.000)");
            PlayerPrefs.SetString("EyebrowsColor", "RGBA(1.000, 1.000, 0.000, 1.000)");
            PlayerPrefs.SetString("HairColor", "RGBA(1.000, 1.000, 0.000, 1.000)");
            PlayerPrefs.SetString("BeardColor", "RGBA(1.000, 1.000, 0.000, 1.000)");
        }

        private void getHead()
        {
            foreach(Texture2D t in sp.Head)
            {
                if(t.GetHashCode() == PlayerPrefs.GetInt("Head"))
                Head = t;
            }
            foreach(var b in BodyRenderers)
            {
                b.color = toColor(PlayerPrefs.GetString("HeadColor"));
            }
            HeadRenderer.color = toColor(PlayerPrefs.GetString("HeadColor"));
        }
        private void saveHead()
        {
            if(Head !=null)
                PlayerPrefs.SetInt("Head", Head.GetHashCode());
        }
        private void getEars()
        {
            foreach(Texture2D t in sp.Ears)
            {
                if(t.GetHashCode() == PlayerPrefs.GetInt("Ears"))
                {
                    Ears = t;
                }
            }
            EarsRenderer.color = toColor(PlayerPrefs.GetString("EarsColor"));
        }
        private void saveEars()
        {
            if(Ears != null)
             PlayerPrefs.SetInt("Ears", Ears.GetHashCode());
            
        }
        private void getHair()
        {
            if(PlayerPrefs.GetInt("Hair") == 0)
            {
                Hair = null;
            }
            else
            {
                foreach(Texture2D t in sp.Hair)
                {
                    if(t.GetHashCode() == PlayerPrefs.GetInt("Hair"))
                    {
                        Hair = t;
                    }
                }
                HairRenderer.color = toColor(PlayerPrefs.GetString("HairColor"));
            }

        }
        private void saveHair()
        {
            if (Hair != null)
                PlayerPrefs.SetInt("Hair", Hair.GetHashCode());
            else
                PlayerPrefs.SetInt("Hair", 0);
        }

        private void saveEyebrows()
        {
            if (Eyebrows != null)
                PlayerPrefs.SetInt("Eyebrows", Eyebrows.GetHashCode());
            else
                PlayerPrefs.SetInt("Eyebrows", 0);
        }

        private void getEyebrows()
        {
            if (PlayerPrefs.GetInt("Eyebrows") == 0)
            {
                Eyebrows = null;
            }
            else
            {
                foreach (Texture2D t in sp.Eyebrows)
                {
                    if (t.GetHashCode() == PlayerPrefs.GetInt("Eyebrows"))
                    {
                        Eyebrows = t;
                    }
                }
                EyebrowsRenderer.color = toColor(PlayerPrefs.GetString("EyebrowsColor"));
            }

        }

        private void getEyes()
        {
            foreach (Texture2D t in sp.Eyes)
            {
                if (t.GetHashCode() == PlayerPrefs.GetInt("Eyes"))
                {
                    Eyes = t;
                }
            }
            
        }
        private void saveEyes()
        {
            if (Eyes != null)
                PlayerPrefs.SetInt("Eyes", Eyes.GetHashCode());

        }

        private void getMouth()
        {
            if(PlayerPrefs.GetInt("Mouth") == 0)
            {
                Mouth = null;
            }
            else
            {
                foreach(Texture2D t in sp.Mouth)
                {
                    if(t.GetHashCode() == PlayerPrefs.GetInt("Mouth"))
                    {
                        Mouth = t;
                    }
                }
            }
        }
        private void saveMouth()
        {
            if(Beard == null)
            {
                PlayerPrefs.SetInt("Mouth", Mouth.GetHashCode());
            }
            else
            {
                PlayerPrefs.SetInt("Mouth", 0);
            }
        }

        private void getBeard()
        {
            if(PlayerPrefs.GetInt("Beard") == 0)
            {
                Beard = null;
            }
            else
            {
                foreach(Texture2D t in sp.Beard)
                {
                    if(t.GetHashCode() == PlayerPrefs.GetInt("Beard"))
                    {
                        Beard = t;
                    }
                }

                BeardRenderer.color = toColor(PlayerPrefs.GetString("BeardColor"));
            }
        }
        private void saveBeard()
        {
            if(Mouth == null)
            {
                PlayerPrefs.SetInt("Beard", Beard.GetHashCode());
            }
            else
            {
                PlayerPrefs.SetInt("Beard", 0);
            }
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

            WeaponRenderer.enabled = WeaponType == WeaponType.Melee1H || WeaponType == WeaponType.Melee2H;
            ShieldRenderer.enabled = WeaponType == WeaponType.Melee1H;

            foreach (var part in BowRenderers)
            {
                part.enabled = WeaponType == WeaponType.Bow;
            }
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
