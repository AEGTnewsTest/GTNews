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
    
    public partial class Event
    {
        public int event_id { get; set; }
        public int menu2_id { get; set; }
        public string event_pictureUrl { get; set; }
        public string event_CNtitle { get; set; }
        public string event_TWtitle { get; set; }
        public System.DateTime event_date { get; set; }
        public string event_CNtext { get; set; }
        public string event_TWtext { get; set; }
        public string event_downloadUrl { get; set; }
        public bool event_status { get; set; }
        public byte event_sort { get; set; }
        public System.DateTime event_createdate { get; set; }
        public System.DateTime event_editdate { get; set; }
    
        public virtual Menu2 Menu2 { get; set; }
    }
}
