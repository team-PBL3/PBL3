using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Image
    {
        public Image()
        {

        }    
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int productid { get; set; }
        public virtual Product product { get; set; }

        public static List<String> SetImage(string category)
        {
            List<String> list = new List<String>();
            string a = "";
            switch (category)
            {
                case "Perfume":
                    a = "Perfume_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Lip Balm & Treatment":
                    a = "Lipbalm_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Eyebrow":
                    a = "Eyebrow_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Eyeliner":
                    a = "Eyeliner_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i+".jpg");
                    }
                    break;
                case "Eye Palettes":
                    a = "EyePalettes_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Serum":
                    a = "Serum_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Toners":
                    a = "Toner_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;

                case "Mascara":
                    a = "Mascara_";
                    for (int i = 1; i < 3; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Body Suncream":
                    a = "BodySuncream_";
                    for (int i = 1; i < 3; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Lipstick":
                    a = "Lipstick_";
                    for (int i = 1; i < 3; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Face Suncream":
                    a = "FaceSuncream_";
                    for (int i = 1; i < 3; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Highlighter":
                    a = "Highlighter_";
                    for (int i = 1; i < 3; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                case "Foundation":
                    a = "Foundation_";
                    for (int i = 1; i < 3; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".jpg");
                    }
                    break;
                default:
                    a = "GifCategory_Background_";
                    for (int i = 1; i < 4; i++)
                    {
                        list.Add(Image_Url.urlImage + a + i + ".gif");
                    }
                    break;
            }    
            return list;
        }
            
    }
}