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
    
    public partial class Question
    {
        public int qa_id { get; set; }
        public int menu2_id { get; set; }
        public string qa_CNtitle { get; set; }
        public string qa_TWtitle { get; set; }
        public byte qa_sort { get; set; }
        public bool qa_status { get; set; }
        public string qa_CNtext { get; set; }
        public string qa_TWtext { get; set; }
        public System.DateTime qa_createdate { get; set; }
        public System.DateTime qa_editdate { get; set; }
    
        public virtual Menu2 Menu2 { get; set; }
    }
}
