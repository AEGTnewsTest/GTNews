//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GTnewsManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carousel
    {
        public int c_id { get; set; }
        public bool c_status { get; set; }
        public string c_pictureurl { get; set; }
        public string c_CNtext { get; set; }
        public string c_TWtext { get; set; }
        public string c_buttonCNtext { get; set; }
        public string c_buttonTWtext { get; set; }
        public string c_buttonurl { get; set; }
        public System.DateTime c_createdate { get; set; }
        public System.DateTime c_editdate { get; set; }
        public byte c_sort { get; set; }
    }
}
