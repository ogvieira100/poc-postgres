using api.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CertificateController : ControllerBase
    {
        readonly ApplicationDbContext _applicationDbContext;
        public CertificateController(ApplicationDbContext applicationDbContext)
        {
                _applicationDbContext = applicationDbContext;
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {

            var glossary = new GlossaryEntry { Word = "Olha3" };
            await _applicationDbContext.Set<GlossaryEntry>().AddAsync(glossary);

            var certificate = await _applicationDbContext.Set<Certificate>()
                                     .Include(x=>x.ServicesHours)
                                     .Include(x => x.FunctionPoints)
                                     .Include(x => x.CertificateGlossaryEntry)
                                    .FirstOrDefaultAsync();



           certificate!.CertificateGlossaryEntry.Clear();
           certificate!.FunctionPoints.Clear();
           

            var certificateGlossaryEntry2 = new CertificateGlossaryEntry { Certificate = certificate!, GlossaryEntry = glossary };
            await _applicationDbContext.Set<CertificateGlossaryEntry>().AddAsync(certificateGlossaryEntry2);
            certificate!.CertificateGlossaryEntry.Add(certificateGlossaryEntry2);

            var funcPoint1Add = new FunctionPoints
            {
                Certificate = certificate,
                Hours = 10.50,
                Name = "Function3"
            };
            await _applicationDbContext.Set<FunctionPoints>().AddAsync(funcPoint1Add);
            certificate.FunctionPoints.Add(funcPoint1Add);


            await _applicationDbContext.SaveChangesAsync();



            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var glossary = new GlossaryEntry { Word = "Olha" };
            await _applicationDbContext.Set<GlossaryEntry>().AddAsync(glossary);

            var glossary2 = new GlossaryEntry { Word = "Olha2" };
            await _applicationDbContext.Set<GlossaryEntry>().AddAsync(glossary2);

            var certificate = new Certificate { FileExtension = ".PDF", FilePath = "C:\\projetos", Hash = "1015150" };
            await _applicationDbContext.Set<Certificate>().AddAsync(certificate);

            var certificateChildren = new Certificate { FileExtension = ".PDF", FilePath = "C:\\projetos", Hash = "1015150" };
            await _applicationDbContext.Set<Certificate>().AddAsync(certificateChildren);

            await AddItensCertificate(glossary,
                                glossary2,
                                certificateChildren);

            await AddItensCertificate(glossary,
                glossary2, 
                certificate);

            certificate.Childrens!.Add(certificateChildren);

            await _applicationDbContext.SaveChangesAsync();

            return Ok();

        }

        private async Task AddItensCertificate(GlossaryEntry glossary, GlossaryEntry glossary2, Certificate certificate)
        {
            var funcPoint1Add = new FunctionPoints
            {
                Certificate = certificate,
                Hours = 10.50,
                Name = "Function1"
            };
            await _applicationDbContext.Set<FunctionPoints>().AddAsync(funcPoint1Add);
            certificate.FunctionPoints.Add(funcPoint1Add);

            var funcPoint2Add = new FunctionPoints
            {
                Certificate = certificate,
                Hours = 10.50,
                Name = "Function2"
            };
            await _applicationDbContext.Set<FunctionPoints>().AddAsync(funcPoint2Add);
            certificate.FunctionPoints.Add(funcPoint2Add);

            var certificateGlossaryEntry1 = new CertificateGlossaryEntry { Certificate = certificate, GlossaryEntry = glossary };
            await _applicationDbContext.Set<CertificateGlossaryEntry>().AddAsync(certificateGlossaryEntry1);
            certificate.CertificateGlossaryEntry.Add(certificateGlossaryEntry1);

            var certificateGlossaryEntry2 = new CertificateGlossaryEntry { Certificate = certificate, GlossaryEntry = glossary2 };
            await _applicationDbContext.Set<CertificateGlossaryEntry>().AddAsync(certificateGlossaryEntry2);
            certificate.CertificateGlossaryEntry.Add(certificateGlossaryEntry2);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
