using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnperoFrontend.Models
{
    public class SearchModel
    {
        public int StoreId { get; set; }
        public string KeyWord { get; set; }
        public string SortBy { get; set; }
        public string GroupId { get; set; }
        public string Category { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int CurentPage { get; set; }
        public int PageSize { get; set; }
        public int MinPrioty { get; set; }
        public int Page { get; set; }
        
        public string PriceRank
        {
            get
            {
                return priceRank;
            }

            set
            {
                var t = string.IsNullOrEmpty(value);
                if (!string.IsNullOrEmpty(value))
                {
                    
                    try
                    {
                        string[] price = new string[2];
                        if (value.Contains("-"))
                        {
                            price = value.Split('-');
                        }
                        if (price.Length > 1)
                        {
                            PriceFrom = Convert.ToInt32(price[0].Trim()); 
                            PriceTo = Convert.ToInt32(price[1].Trim());
                        }
                    }
                    catch (Exception)
                    {
                    }
                    
                }
                priceRank = value;
            }
        }

        string priceRank;

        public SearchModel()
        {
            SortBy="timeDesc";
            Page = 1;
            StoreId = 0;
            KeyWord = string.Empty;
            Category = "%";
            PriceFrom = 0;
            PriceTo = 99999999;
            CurentPage = 1;
            PageSize = 15;
        }

    }
}