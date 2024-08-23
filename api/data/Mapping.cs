using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.data
{
    public class CertificateGlossaryEntryMapping : IEntityTypeConfiguration<CertificateGlossaryEntry>
    {
        public void Configure(EntityTypeBuilder<CertificateGlossaryEntry> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Certificate)
                .WithMany(c => c.CertificateGlossaryEntry)
                .HasForeignKey(c => c.CertificateId);

            builder.HasOne(c => c.GlossaryEntry)
               .WithMany(c => c.CertificateGlossaryEntrys)
               .HasForeignKey(c => c.GlossaryEntryId);

            builder.ToTable("CertificadoGlossario");
        }
    }
    public class FunctionPointsMapping : IEntityTypeConfiguration<FunctionPoints>
    {
        public void Configure(EntityTypeBuilder<FunctionPoints> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
               .HasColumnName("Nome")
               .IsRequired(true)
               .HasMaxLength(200)
               ;
            builder.Property(c => c.Hours)
             .HasColumnName("Horas")
             .IsRequired(true)
             ;

            builder.HasOne(x => x.Certificate)
                .WithMany(x => x.FunctionPoints)
                .HasForeignKey(x => x.CertificateId);

            builder.ToTable("PontosFuncao");
        }
    }
    public class GlossaryEntryMapping : IEntityTypeConfiguration<GlossaryEntry>
    {
        public void Configure(EntityTypeBuilder<GlossaryEntry> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Word)
                .HasMaxLength(1000)
                .HasColumnName("Palavra")
                .IsRequired();
            builder.Property(x => x.Status)
               .HasColumnName("Estatus")
               .IsRequired();

            builder.HasOne(c => c.SynonymOf)
            .WithMany(c => c.Synonyms)
            .HasForeignKey(c => c.SynonymOfId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Glossario");

        }
    }
    public class CertificateMapping : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            /*stefanini*/
            //Contracted Contratada
            //Contractor Contratante
            //Cliente 
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CertificateStatus)
                .HasColumnName("Estatus")
                .IsRequired(true);
            builder.Property(c => c.ContractorAddress)
                .HasColumnName("EnderecoContratante")
                .HasMaxLength(200)
                .IsRequired(false);
            builder.Property(c => c.FileExtension)
                .HasColumnName("ExtensaoArquivo")
                .HasMaxLength(10)
                .IsRequired(false);
            builder.Property(c => c.Hash)
                .HasColumnName("CodigoArquivo")
                .HasMaxLength(255)
                .IsRequired(true);
            builder.Property(c => c.ContractedDocument)
                .HasColumnName("DocumentoContratada")
                .HasMaxLength(14)
                .IsRequired(false);
            builder.Property(c => c.FilePath)
                .HasColumnName("CaminhoArquivo")
                .HasMaxLength(200)
                .IsRequired(false);
            builder.Property(c => c.ContractorDocument)
                .HasColumnName("DocumentoContratante")
                .HasMaxLength(14)
                .IsRequired(false);
            builder.Property(c => c.ContractorName)
               .HasColumnName("NomeContratante")
               .HasMaxLength(200)
               .IsRequired(false);
            builder.Property(c => c.IssueDate)
               .HasColumnName("DataEmissao")
               .IsRequired(false);
            builder.Property(c => c.Breif)
               .HasColumnName("Apresentacao")
               .IsRequired(false);
            builder.Property(c => c.BenningTerm)
               .HasColumnName("DataInicial")
               .IsRequired(false);
            builder.Property(c => c.EndTerm)
              .HasColumnName("DataFinal")
              .IsRequired(false);
            builder.Property(c => c.ContractNumber)
              .HasColumnName("NumeroContrato")
              .HasMaxLength(14)
              .IsRequired(false);
            builder.Property(c => c.ContractedName)
               .HasColumnName("NomeContratada")
               .HasMaxLength(200)
               .IsRequired(false);
            builder.Property(c => c.SignerName)
               .HasColumnName("AssinanteContratada")
               .HasMaxLength(200)
               .IsRequired(false);
            builder.Property(c => c.SignerRole)
              .HasColumnName("CargoAssinanteContratada")
              .HasMaxLength(200)
              .IsRequired(false);
            builder.Property(c => c.SignerEmail)
              .HasColumnName("EmailAssinanteContratada")
              .HasMaxLength(200)
              .IsRequired(false);
            builder.Property(c => c.SignerPhone)
              .HasColumnName("TelefoneAssinanteContratada")
              .HasMaxLength(20)
              .IsRequired(false);

            builder.HasOne(x => x.Children)
                .WithMany(x => x.Childrens)
                .HasForeignKey(x => x.ChildrenId)
                .OnDelete(DeleteBehavior.Cascade);
                ;

            
            builder.ToTable("Certificados");
        }
    }
    public class ServiceHoursMapping : IEntityTypeConfiguration<ServiceHours>
    {
        public void Configure(EntityTypeBuilder<ServiceHours> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
               .HasColumnName("Nome")
               .IsRequired(true)
               .HasMaxLength(200)
               ;
            builder.Property(c => c.Qtd)
             .HasColumnName("Qtd")
             .IsRequired(true)
             ;

            builder.HasOne(x => x.Certificate)
                .WithMany(x => x.ServicesHours)
                .HasForeignKey(x => x.CertificateId);

            builder.ToTable("HorasServico");
        }
    }
}
