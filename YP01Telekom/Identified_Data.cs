//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YP01Telekom
{
    using System;
    using System.Collections.Generic;
    
    public partial class Identified_Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Identified_Data()
        {
            this.Equipment = new HashSet<Equipment>();
        }
    
        public int Id_Identifiend_Data { get; set; }
        public Nullable<int> Serial_number { get; set; }
        public Nullable<int> Inventory_number { get; set; }
        public Nullable<int> IP { get; set; }
        public Nullable<int> MAC { get; set; }
        public Nullable<int> Other { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
