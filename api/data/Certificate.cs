using api.Migrations;
using System.ComponentModel;

namespace api.data
{
    public enum EStatus
    {
        [Description("Inativo")]
        Inativo = 0,
        [Description("Ativo")]
        Ativo
    }
    public enum ECertificateStatus
    {
        /// <summary>
        /// Enfileirado aguardando processamento
        /// </summary>    
        Pending = 1,
        ///<summary>
        /// Problemas dureante o processamento
        /// </summary>    
        Error = 2,
        /// <summary>
        /// Processando
        /// </summary>
        Processed = 3,
        ///<summary>
        /// Interrupção manual do processamento
        /// </summary>    
        Abort = 4,
        /// <summary>
        /// Processando
        /// </summary>
        Processing = 5,
        /// Processado e revisado
        Reviewd = 6,
    }

    public class FunctionPoints
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public Certificate Certificate { get; set; }
        public Guid CertificateId { get; set; }

    }
    public class CertificateGlossaryEntry
    {
        
        public Guid Id { get; set; }
        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int GlossaryEntryId { get; set; }
        public GlossaryEntry GlossaryEntry { get; set; }

    }
    public class GlossaryEntry
    {
        public int Id { get; set; }
        public required string Word { get; set; }
        public int? SynonymOfId { get; set; }
        public GlossaryEntry? SynonymOf { get; set; }
        public IEnumerable<GlossaryEntry>? Synonyms { get; set; }
        public EStatus Status { get; set; }
        public IEnumerable<CertificateGlossaryEntry> CertificateGlossaryEntrys { get; set; }
        public GlossaryEntry()
        {
            CertificateGlossaryEntrys = new List<CertificateGlossaryEntry>();
        }
    }
    public class ServiceHours
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Qtd { get; set; }
        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        public ServiceHours()
        {
            Id = Guid.NewGuid();    
        }

    }
    public class Certificate
    {


        public Guid Id { get; set; }
        public required string Hash { get; set; }
        public required string FilePath { get; set; }
        public string? ContractorDocument { get; set; }
        public string? ContractorName { get; set; }
        public string? ContractNumber { get; set; }
        public DateTime? BenningTerm { get; set; }
        public DateTime? EndTerm { get; set; }
        public string? ContractedDocument { get; set; }
        public string? ContractedName { get; set; }
        public string? SignerName { get; set; }
        public string? SignerRole { get; set; }
        public string? SignerPhone { get; set; }
        public string? SignerEmail { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? Breif { get; set; }
        public string? ContractorAddress { get; set; }
        public required string FileExtension { get; set; }
        public ECertificateStatus CertificateStatus { get; set; }
        public List<FunctionPoints> FunctionPoints { get; set; }
        public List<ServiceHours> ServicesHours { get; set; }
        public List<CertificateGlossaryEntry> CertificateGlossaryEntry { get; set; }

        public Guid? ChildrenId { get; set; }
        public Certificate? Children { get; set; }
        public List<Certificate>? Childrens { get; set; }
        public Certificate()
        {
            Id = Guid.NewGuid();    
            ServicesHours = new List<ServiceHours>();
            FunctionPoints = new List<FunctionPoints>();
            Childrens = new List<Certificate>();
            CertificateGlossaryEntry = new List<CertificateGlossaryEntry>();
        }
    }
}
