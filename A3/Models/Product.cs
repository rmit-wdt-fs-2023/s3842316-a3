using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3.Models;

public class Product
{
    /** 
     * ^[A-Z] start capital letter
     * [A-Za-z0-9 ] any letter b/w a-z, int 0-9 and white spaces
     * Test String 
     * https://regex101.com/r/xvLDIc/1
     */
    private const string _nameRegex = @"^[A-Z][A-Za-z0-9 ]*$";

    // Database generates a value when a row is inserted
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }

    [Required]
    [StringLength(50)]
    [RegularExpression(_nameRegex, ErrorMessage = "Must start with an upper-case letter and only contain letters, numbers, and spaces")]
    public string Name { get; set; }

    // Required, and price has to be between greather than 0
    [Required]
    [DataType(DataType.Currency)]
    [Range(1, (double)decimal.MaxValue, ErrorMessage = "Price has to be greater than 0")]
    public decimal Price { get; set; }

    public List<OrderedProduct> OrderedProduct { get; set; }

}

