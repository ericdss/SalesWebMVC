using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")] //permite personalizar o nome de exibição
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Salário Base"), DisplayFormat(DataFormatString ="{0:f2}")]
        [Range(100, 9999999, ErrorMessage = "O salário deve ser entre {1} e {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double BaseSalary { get; set; }

        
        public Department Department { get; set; }

        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSale(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSale(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(x => x.Date >= initial & x.Date <= final).Sum(x=> x.Amount);
        }

    }
}
