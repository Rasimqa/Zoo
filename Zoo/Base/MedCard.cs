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
    
    public partial class MedCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedCard()
        {
            this.Med_History = new HashSet<Med_History>();
        }
    
        public int id_medcard { get; set; }
        public Nullable<int> id_animal { get; set; }
        public Nullable<System.DateTime> date_start_account { get; set; }
    
        public virtual Animal Animal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Med_History> Med_History { get; set; }
    }
}
