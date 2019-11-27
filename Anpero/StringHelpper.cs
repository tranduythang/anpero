using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Anpero
{
    public class StringHelpper
    {
        public StringHelpper()
        {

        }
        public static int GetDiscountPersen(int oldPrice, int newPrive)
        {
            return (oldPrice - newPrive) / oldPrice * 100;
        }
        public static int GetDiscountPersen(decimal oldPrice, decimal newPrive)
        {
            try
            {
                return Convert.ToInt32((oldPrice - newPrive) / oldPrice * 100);
            }
            catch (Exception)
            {
                return 0;
            }
           
        }
        public static Boolean isUrl(String url)
        {
            string pattern = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

            if (Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase))
            {
                return true;

            }
            else
            {


                return false;
            }

        }
        public static string URLBBCodeToATag(String s)
        {
            s = Regex.Replace(s, @"\[URL\](http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?)\[\/URL\]", @"<a href=""$1"" target='_blank' rel='nofollow'/>$1</a>", RegexOptions.IgnoreCase);
            return s;
        }
        public static Boolean isEmail(String Email)
        {

            // string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            try
            {
                if (Email != null)
                {
                    return Regex.IsMatch(Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }


        }
        public static Boolean isYouToBeLink(String link)
        {


            try
            {
                string pattern = @"^http://youtu.be/([A-Z0-9]*_?\-?[A-Z0-9]*)*$";
                if (Regex.IsMatch(link, pattern, RegexOptions.IgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static String GetYouTubeAgument(String link)
        {
            try
            {

                int lengths = link.Length;
                int i = link.LastIndexOf("/");
                return link.Substring(i, lengths - i);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string imgBBCodeToImgTag(String s)
        {
            s = Regex.Replace(s, @"\[IMG\](https?://(?:[a-z0-9\-\.]+\.)+[a-z0-9]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png|jpeg))\[\/IMG\]", @"<img src=""$1""/>", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"\[IMG alt=""([^/><*&?]+)""\](https?://(?:[a-z0-9\-\.]+\.)+[a-z0-9]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png|jpeg))\[\/IMG\]", @"<img src=""$2"" alt=""$1""/>", RegexOptions.IgnoreCase);
            return s;
        }
        public static string ImgTagtoimgBBCode(String s)
        {
            s = Regex.Replace(s, @"<img src=""(https?://(?:[a-z0-9\-\.]+\.)+[a-z0-9]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png|jpeg))"">", @"[IMG]$1[/IMG]", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"<img src=""(https?://(?:[a-z0-9\-\.]+\.)+[a-z0-9]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png|jpeg))"" \/>", @"[IMG]$1[/IMG]", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"<img src=""(https?://(?:[a-z0-9\-\.]+\.)+[a-z0-9]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png|jpeg))"" alt=""([^/><*&?]+)""\/>", @"[IMG alt=""$2""]$1[/IMG]", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"<img src=""(https?://(?:[a-z0-9\-\.]+\.)+[a-z0-9]{2,6}(?:/[^/#?]+)+\.(?:jpg|gif|png|jpeg))"" alt=""([^/><*&?]+)"">", @"[IMG alt=""$2""]$1[/IMG]", RegexOptions.IgnoreCase);
            return s;
        }
        public static String RemoveScript(String s)
        {
            ///check
            ///
            if (string.IsNullOrEmpty(s))
            {

                return s;
            }
            else
            {
                s = s.Replace("--", "_");
                s = s.Replace("'", "");

            }

            return Regex.Replace(s, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        }
        public static String removeHtmlTangs(String s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return Regex.Replace(s, @"<.*?>", string.Empty);

            }
            else { return s; }

        }
        #region const
        public const string uniChars =
          "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";

        public const string KoDauChars = "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";
        #endregion
        public static bool isVnPhone(String input)
        {
            bool valid = true;

            if (input != null && input.Length > 9)
            {
                input = input.Replace(" ", String.Empty).Trim();
                input = input.Replace("+", "0").Replace("-", "").Replace(".", "");


                if (input.Length < 10 || input.Length > 16)
                {
                    valid = false;
                }
            }
            else
            {
                valid = false;
            }

            try
            {
                Convert.ToDouble(input);
                valid = true;
            }
            catch (Exception)
            {

                valid = false;
            }


            return valid;
        }
        public static string UnicodeToKoDau(string s)
        {
            string retVal = String.Empty;
            int pos;
            if (!string.IsNullOrEmpty(s))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    pos = uniChars.IndexOf(s[i].ToString());
                    if (pos >= 0)
                        retVal += KoDauChars[pos];
                    else
                        retVal += s[i];
                }
            }

            return retVal;
        }
        public static string toURLgach(String inputtring)
        {
            inputtring = UnicodeToKoDau(inputtring).ToLower();
            Regex regex = new Regex("[^a-zA-Z0-9 -]");
            inputtring = regex.Replace(inputtring, String.Empty);


            if (inputtring.Length > 35)
            {
                inputtring = inputtring.Substring(0, 35);

            }
            inputtring = inputtring.Trim().ToLower();
            inputtring = inputtring.Replace(" ", "-").Replace(@"--", "-");
            return inputtring.Replace(@"--", "-").Replace(@"–", "");
        }
        public static string toURLgachTag(String title)
        {
            title = UnicodeToKoDau(title);
            Regex regex = new Regex("[^a-zA-Z0-9 -,]");
            title = regex.Replace(title, String.Empty);
            if (title.Length > 150)
            {
                title = title.Substring(0, 150);

            }
            title = title.Trim().ToLower();
            title = title.Replace(" ", "-").Replace(@"--", "-");
            return title.Replace(@"--", "-").Replace(@"–", "");
        }
        public static String SubString(int maxLeng, String inPut)
        {
            if (!String.IsNullOrEmpty(inPut))
            {
                if (inPut.Length >= maxLeng)
                {
                    inPut = inPut.Substring(0, maxLeng - 2) + " ..";
                }
            }

            return inPut;
        }
        public static string ConvertToVndMoney(decimal input)
        {
            decimal outPut = 0;
            string donvi = "";
            if (input > 1000000000)
            {
                outPut = input / 1000000000;
                donvi = "tỷ";
            }
            else if (input > 1000000)
            {
                outPut = input / 1000000;
                donvi = "triệu";
            }
            else if (input > 1000)
            {
                outPut = input / 1000000;
                donvi = "nghìn";
            }
            if (outPut > 0)
            {
                return String.Format("{0:0}", outPut) + " " + donvi;
            }
            else
            {
                return "liên hệ";
            }
        }
        public static String ToPhoneNumberFormat(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                try
                {
                    string area = phone.Substring(0, 3);
                    string major = phone.Substring(3, 3);
                    string minor = phone.Substring(6);
                    return string.Format("{0}.{1}.{2}", area, major, minor);
                }
                catch (Exception)
                {

                    return "";
                }                
            }
            else { return ""; }
        }
        public static String ConVertToMoneyFormatInt(String s)
        {
            int dotIndex = s.LastIndexOf(".");
            if (s != null && !DBNull.Value.Equals(s))
            {
                if (s == "0" || s == "0.00")
                {
                    return "0";
                }
                if (s.Length > (dotIndex + 3) && dotIndex != -1)
                {
                    s = s.Substring(0, dotIndex + 2);

                }
                return string.Format("{0:##,###}", Convert.ToDecimal(s));

            }
            else
            {
                return "Liên hệ";
            }
        }

        public static String ConVertToMoneyFormatInt(int input)
        {
            return ConVertToMoneyFormatInt(input.ToString());
        }
        public static String ConVertToMoneyFormatInt(decimal input)
        {
            return ConVertToMoneyFormatInt(input.ToString());
        }
        public static string FormatPhoneNumber(string phoneNumber)
        {

            if (String.IsNullOrEmpty(phoneNumber))
                return phoneNumber;

            Regex phoneParser = null;
            string format = "";

            switch (phoneNumber.Length)
            {

                case 5:
                    phoneParser = new Regex(@"(\d{3})(\d{2})");
                    format = "$1 $2";
                    break;

                case 6:
                    phoneParser = new Regex(@"(\d{2})(\d{2})(\d{2})");
                    format = "$1 $2 $3";
                    break;

                case 7:
                    phoneParser = new Regex(@"(\d{3})(\d{2})(\d{2})");
                    format = "$1 $2 $3";
                    break;

                case 8:
                    phoneParser = new Regex(@"(\d{4})(\d{2})(\d{2})");
                    format = "$1 $2 $3";
                    break;

                case 9:
                    phoneParser = new Regex(@"(\d{4})(\d{3})(\d{2})(\d{2})");
                    format = "$1 $2 $3 $4";
                    break;

                case 10:
                    phoneParser = new Regex(@"(\d{4})(\d{3})(\d{3})");
                    format = "$1 $2 $3";
                    break;

                case 11:
                    phoneParser = new Regex(@"(\d{4})(\d{4})(\d{3})");
                    format = "$1 $2 $3";
                    break;

                default:
                    return phoneNumber;

            }//switch

            return phoneParser.Replace(phoneNumber, format);

        }
        public static String ConVertToMoneyFormat(String s)
        {
            int dotIndex = s.LastIndexOf(".");
            if (s != null && !DBNull.Value.Equals(s))
            {
                if (s == "0" || s == "0.00")
                {
                    return "0";
                }
                if (s.Length > (dotIndex + 3) && dotIndex != -1)
                {
                    s = s.Substring(0, dotIndex + 2);

                }
                return string.Format("{0:##,###.00}", Convert.ToDecimal(s));

            }
            else
            {
                return null;
            }
        }

        public static string toSplitURLgach(String title)
        {
            title = removeHtmlTangs(title);

            title = UnicodeToKoDau(title);
            Regex regex = new Regex("[^a-zA-Z0-9 -]");
            title = regex.Replace(title, String.Empty);
            if (title.Length > 50)
            {
                title = title.Substring(0, 50);

            }
            title = title.Trim();
            title = title.Replace("'", String.Empty).Replace("|", String.Empty).Replace(" ", "-").Replace("!", "").Replace(" ", "-").Replace(@"\", String.Empty).Replace(@"/", String.Empty).Replace(@"?", "").Replace(@"<", "").Replace(@">", "").Replace(@"(", "").Replace(@")", "").Replace(@"--", "-").Replace(@":", String.Empty);
            return System.Web.HttpUtility.UrlEncode(title).Replace(@"%0", "").Replace(@"%1", "").Replace(@"%2c", ",").Replace(@"%3a", String.Empty).ToLower();
        }
        /// <summary>
        /// Chuyển dạng số dang dạng chứ đọc tiếng viet
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToStringVN(Decimal number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return UpperFirstCharacter(str) + "đồng chẵn.";
        }
        public static string ToStringVN(int number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            return UpperFirstCharacter(str);
        }
        public static string UpperFirstCharacter(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public static string GetProductLink(string productName, int productId)
        {
            if (!string.IsNullOrEmpty(productName) && productId > 0)
            {
                return "/" + toURLgach(productName) + "-p" + productId;
            }
            else
            {
                return "/";
            }
        }
        public static string GetProductGroupLink(string productName, int productId)
        {
            if (!string.IsNullOrEmpty(productName) && productId > 0)
            {
                return "/" + toURLgach(productName) + "-g" + productId;
            }
            else
            {
                return "/";
            }
        }
        public static string GetProductLink(string parentCatName, string productName, int productId)
        {
            if (!string.IsNullOrEmpty(parentCatName) && !string.IsNullOrEmpty(productName) && productId > 0)
            {
                return "/" + toURLgach(parentCatName.ToLower()) + "/" + toURLgach(productName.ToLower()) + "-p" + productId;
            }
            else
            {
                return "/";
            }

        }
        public static string GetCategoryLink(string categoryName, int CategoryId)
        {
            if (!string.IsNullOrEmpty(categoryName) && !string.IsNullOrEmpty(categoryName) && CategoryId > 0)
            {
                return "/" + toURLgach(categoryName.ToLower()) + "-cat" + CategoryId;
            }
            else
            {
                return "/";
            }

        }
        public static string GetBlogCategoryLink(string categoryName, int CategoryId)
        {
            if (!string.IsNullOrEmpty(categoryName) && !string.IsNullOrEmpty(categoryName) && CategoryId > 0)
            {
                return "/" + toURLgach(categoryName.ToLower()) + "-b" + CategoryId;
            }
            else
            {
                return "/";
            }

        }
        public static string GetArticleLink(string ArticleTitle, int ArticleId)
        {
            if (!string.IsNullOrEmpty(ArticleTitle) && !string.IsNullOrEmpty(ArticleTitle) && ArticleId > 0)
            {
                return "/" + toURLgach(ArticleTitle.ToLower()) + "-a" + ArticleId;
            }
            else
            {
                return "/";
            }

        }
        public static string GetParentCategoryLink(string parentCategoryName, int parentCategoryId)
        {
            if (!string.IsNullOrEmpty(parentCategoryName) && !string.IsNullOrEmpty(parentCategoryName) && parentCategoryId > 0)
            {
                return "/" + toURLgach(parentCategoryName.ToLower()) + "-c" + parentCategoryId;
            }
            else
            {
                return "/";
            }

        }
        public static string ConvertTimeVN(string YYYYMMddhhmmss)
        {
            try
            {
                if (YYYYMMddhhmmss.Length >= 8)
                {
                    String year = YYYYMMddhhmmss.Substring(0, 4);
                    String month = YYYYMMddhhmmss.Substring(4, 2);
                    String day = YYYYMMddhhmmss.Substring(6, 2);
                    return day + " tháng " + month + " năm " + year;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {

                return "";
            }


        }
        public static DateTime ConvertDateTime(string YYYYMMddhhmmss)
        {
            try
            {
                if (YYYYMMddhhmmss.Length >= 8)
                {

                    string year = YYYYMMddhhmmss.Substring(0, 4);
                    string month = YYYYMMddhhmmss.Substring(4, 2);
                    string day = YYYYMMddhhmmss.Substring(6, 2);
                    return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch (Exception)
            {

                return DateTime.Now;
            }


        }

        /// <summary>
    }
}
