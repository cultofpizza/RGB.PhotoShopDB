//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoShopDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Order_List = new HashSet<Order_List>();
        }
    
        public int Id_order { get; set; }
        public int Id_client { get; set; }
        public int Id_employee { get; set; }
        public System.DateTime Date { get; set; }
        public int Id_status { get; set; }
        public string Note { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_List> Order_List { get; set; }
        public virtual Order_Status Order_Status { get; set; }
    }
}
