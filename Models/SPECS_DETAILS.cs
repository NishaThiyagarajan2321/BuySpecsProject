//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuySpecsProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class SPECS_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPECS_DETAILS()
        {
            this.ORDER_DETAILS = new HashSet<ORDER_DETAILS>();
        }
        [DisplayName("SPECS ID")]
       
        public int SPECS_ID { get; set; }
        [DisplayName("SPECS NAME")]
        [Required(ErrorMessage = "Specs NAME IS REQUIRED")]
        public string SPECS_NAME { get; set; }
        [DisplayName("SPECS IMAGE")]
        public string SPECS_IMAGE { get; set; }
        [DisplayName("FRAME TYPE")]
        [Required(ErrorMessage = "SPECS IMAGE IS REQUIRED")]
        public string FRAME_TYPE { get; set; }
        [DisplayName("FRAME WIDTH")]
        [Required(ErrorMessage = "FRAME WIDTH IS REQUIRED")]
        public string FRAME_WIDTH { get; set; }
        [DisplayName("FRAME SIZE")]
        [Required(ErrorMessage = "FRAME SIZE IS REQUIRED")]
        public string FRAME_SIZE { get; set; }
        [DisplayName("SPECS PRICE")]
        [Required(ErrorMessage = "SPECS PRICE IS REQUIRED")]
        public Nullable<double> SPECS_PRICE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAILS> ORDER_DETAILS { get; set; }
        public virtual ADD_TO_CART ADD_TO_CART { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
