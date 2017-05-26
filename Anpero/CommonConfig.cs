using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero
{
    public class CommonConfig
    {
        public CommonConfig()
        {
            MenuList = new List<Menu>();
            FaceBookLink = "";
            PageScript = "";
            Skype = "";
            HotLine = "";
            Footer = "";
            Logo = "";
        }
        string footer, pageScript, hotLine, skype, faceBookLink, logo; 
        List<Menu> menuList;
        public List<Menu> MenuList
        {
            get
            {
                return menuList;
            }

            set
            {
                menuList = value;
            }
        }
        public string FaceBookLink
        {
            get
            {
                return faceBookLink;
            }

            set
            {
                faceBookLink = value;
            }
        }
        public string Skype
        {
            get
            {
                return skype;
            }

            set
            {
                skype = value;
            }
        }
        public string HotLine
        {
            get
            {
                return hotLine;
            }

            set
            {
                hotLine = value;
            }
        }
        public string PageScript
        {
            get
            {
                return pageScript;
            }

            set
            {
                pageScript = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }

            set
            {
                footer = value;
            }
        }
        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }
    }
    public class Menu
    {
       
        public Menu()
        {
            List<Menu> chidMenu = new List<Menu>();
            Id = 0;
            Link = "";
            ParentId = 0;
            Prioty = 0;
            Prioty = 0;
            Tittle = "";
        }  
        List<Menu> ChidMenu;
        int id, parentId, prioty;
        string tittle, link;

        public List<Menu> ChidMenu = new List<Menu>();
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }
        public int ParentId
        {
            get
            {
                return parentId;
            }

            set
            {
                parentId = value;
            }
        }
        public int Prioty
        {
            get
            {
                return prioty;
            }

            set
            {
                prioty = value;
            }
        }
        public string Tittle
        {
            get
            {
                return tittle;
            }

            set
            {
                tittle = value;
            }
        }
    }
}
