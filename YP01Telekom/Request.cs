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
    
    public partial class Request
    {
        public int Id_Request { get; set; }
        public string Number_Request { get; set; }
        public Nullable<System.DateTime> Date_request { get; set; }
        public Nullable<int> Product { get; set; }
        public string Status { get; set; }
        public Nullable<int> Type_Problem { get; set; }
        public string Reason_request { get; set; }
        public Nullable<System.DateTime> Date_close { get; set; }
        public string Id_client { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Product Product1 { get; set; }
    }
}
