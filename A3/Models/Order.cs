using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3.Models;

public class Order
{
    /** 
     * ^[A-Z] start capital letter
     * [A-Za-z ] any letter b/w a-z and white spaces
     * Test String 
     * https://regex101.com/r/G7DJ3s/1
     */
    private const string _custNameRegex = @"^[A-Z][A-Za-z ]*$";

    // Database generates a value when a row is inserted
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderID {get; set;}

    // Date Time 
    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }

    [Required]
    [StringLength(50)]
    [RegularExpression(_custNameRegex, ErrorMessage = "Must start with an upper-case and only contain letters and spaces")]
    public string CustomerName { get; set; }

    [Required]
    [StringLength(200)]
    public string DeliveryAddress { get; set; }

    // Nullable
    [DataType(DataType.DateTime)]
    [Display(Name = "Delivery Date")]
    public DateTime? DeliveryDate { get; set; }

}

