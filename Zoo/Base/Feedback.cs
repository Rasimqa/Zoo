//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoo.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feedback
    {
        public int number_feedback { get; set; }
        public Nullable<int> id_visitor { get; set; }
        public string description { get; set; }
        public Nullable<int> score { get; set; }
        public Nullable<System.DateTime> date_feed { get; set; }
    
        public virtual Visitor Visitor { get; set; }
    }
}
