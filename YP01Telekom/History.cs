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
    
    public partial class History
    {
        public int Id_History { get; set; }
        public string Id_Client { get; set; }
        public string Handling { get; set; }
    
        public virtual Clients Clients { get; set; }
    }
}
