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
    
    public partial class Custom_Services
    {
        public int id_custom { get; set; }
        public Nullable<int> id_service { get; set; }
        public Nullable<int> id_ticket { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
