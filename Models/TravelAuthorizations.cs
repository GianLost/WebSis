using System;
using System.ComponentModel.DataAnnotations;

namespace WebSis.Models
{
    public class TravelAuthorizations
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Ano Corrente é obrigatório"), StringLength(4)]
        public string CurrentYear { get; set; }

        [Required(ErrorMessage = "O campo Data Atual é obrigatório"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CurrentDate { get; set; }

        [Required(ErrorMessage = "O campo Nome do Cliente é obrigatório"), StringLength(80)]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "O campo Nome da Secretaria é obrigatório"), StringLength(80)]
        public string SecretaryName { get; set; }

        [Required(ErrorMessage = "O campo Cargo é obrigatório"), StringLength(60)]
        public string Office { get; set; }

        [Required(ErrorMessage = "O campo Nível é obrigatório")]
        public int Level { get; set; }

        [Required(ErrorMessage = "O campo Código é obrigatório")]
        public int Code { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        public int Type { get; set; }

        [Required(ErrorMessage = "O campo Data de Saída é obrigatório"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "O campo Hora de saída é obrigatório"), StringLength(5)]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "O campo Data de chegada é obrigatório"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ArrivalDate { get; set; }

        [Required(ErrorMessage = "O campo Hora de chegada é obrigatório"), StringLength(5)]
        public string ArrivalTime { get; set; }

        [Required(ErrorMessage = "O campo Prestação de contas é obrigatório"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Accountability { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de passagens de ida é obrigatório")]
        public int OneWayTickets { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de passagens de volta é obrigatório")]
        public int ReturnTickets { get; set; }

        [Required(ErrorMessage = "O campo Destino é obrigatório"), StringLength(60)]
        public string Destiny { get; set; }

        [Required(ErrorMessage = "O campo UG é obrigatório")]
        public double UG { get; set; }

        [Required(ErrorMessage = "O campo UO é obrigatório")]
        public double UO { get; set; }

        [Required(ErrorMessage = "O campo PA é obrigatório")]
        public double PA { get; set; }

        [Required(ErrorMessage = "O campo Número de despesas é obrigatório"), StringLength(30)]
        public string Expanses { get; set; }

        [Required(ErrorMessage = "O campo Fonte é obrigatório")]
        public int Font { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Alimentação é obrigatório")]
        public int FoodQuantity { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Hospedagem é obrigatório")]
        public int HostingQuantity { get; set; }

        [Required(ErrorMessage = "O campo Valor unitário de Alimentação é obrigatório")] /* deve ser double */
        public string FoodUnitaryValue { get; set; }

        [Required(ErrorMessage = "O campo Valor unitário de Hospedagem é obrigatório")] /* deve ser double */
        public string HostingUnitaryValue { get; set; }

        [Required(ErrorMessage = "O campo Valor Total de Alimentação é obrigatório")] /* deve ser double */
        public string FoodTotalValue { get; set; }

        [Required(ErrorMessage = "O campo Total unitário de Hospedagem é obrigatório")] /* deve ser double */
        public string HostingTotalValue { get; set; }

        [Required(ErrorMessage = "O campo Valor Total de Despesas é obrigatório")] /* deve ser double */
        public string ExpanseTotalValue { get; set; }

        [Required(ErrorMessage = "O campo Objetivo é obrigatório"), StringLength(300)]
        public string Goal { get; set; }

        public int SecretariesId { get; set; }

        public int UsersId { get; set; }

        public Secretaries Secretaries { get; set; }

        public Users Users { get; set; }
    }
}