using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero
{
    public class SearchResult
    {
        public SearchResult()
        {
            Item = null;
            ResultCount = 0;
        }      
        List<ProductItem> item;
        int resultCount;

        public List<ProductItem> Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public int ResultCount
        {
            get
            {
                return resultCount;
            }

            set
            {
                resultCount = value;
            }
        }
    }
    public class ProductItem
    {
        public ProductItem(DataRow row)
        {
            OriginID = 0;
            ParentId = 0;
            CatID = 0;
            Id = 0;
            Warranty = 0;
            Price =0;
            Vprice =0;
            CatName = null;
            PrName = null;
            Images = null;
            OriginName = null;
            UpdateTime = null;
            ParentCatName = null;
            Detail = null;
            IsSale = false;
        }
        
        string prName, detail, images, originName, updateTime, catName, parentCatName;
        decimal price, vprice;
        int id, parentId, catID, originID, warranty;
        Boolean isSale;
        public int OriginID
        {
            get
            {
                return originID;
            }

            set
            {
                originID = value;
            }
        }
        public string CatName
        {
            get
            {
                return catName;
            }

            set
            {
                catName = value;
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
        public decimal Vprice
        {
            get
            {
                return vprice;
            }

            set
            {
                vprice = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string UpdateTime
        {
            get
            {
                return updateTime;
            }

            set
            {
                updateTime = value;
            }
        }

        public string OriginName
        {
            get
            {
                return originName;
            }

            set
            {
                originName = value;
            }
        }

        public string Images
        {
            get
            {
                return images;
            }

            set
            {
                images = value;
            }
        }

        public string Detail
        {
            get
            {
                return detail;
            }

            set
            {
                detail = value;
            }
        }

        public string PrName
        {
            get
            {
                return prName;
            }

            set
            {
                prName = value;
            }
        }

        public int CatID
        {
            get
            {
                return catID;
            }

            set
            {
                catID = value;
            }
        }

        public string ParentCatName
        {
            get
            {
                return parentCatName;
            }

            set
            {
                parentCatName = value;
            }
        }

        public int Warranty
        {
            get
            {
                return warranty;
            }

            set
            {
                warranty = value;
            }
        }

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
        public bool IsSale
        {
            get
            {
                return isSale;
            }

            set
            {
                isSale = value;
            }
        }
    }
}
