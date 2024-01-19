using AutoMapper;
using FITCCRS2.Model;
using FITCCRS2.Model.Requests;
using FITCCRS2.Model.Requests.DpgadjaRequest;
using FITCCRS2.Model.Requests.KriterijRequest;
using FITCCRS2.Model.Requests.NapomenaRequest;
using FITCCRS2.Model.Requests.PredavacDogadjaj;
using FITCCRS2.Model.Requests.PredavacRequest;
using FITCCRS2.Model.Requests.ProjekatRequest;
using FITCCRS2.Model.Requests.RezultatiRequest;
using FITCCRS2.Model.Requests.RolesRequest;
using FITCCRS2.Model.Requests.SponzorRequest;
using FITCCRS2.Model.Requests.TakmicenjeRequest;
using FITCCRS2.Model.Requests.TimRequest;
using FITCCRS2.Model.Requests.UserRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.Mapping
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping()
        {
            CreateMap<Database.Takmicenje, Model.Takmicenje>();
            CreateMap<Database.Dogadjaj, Model.Dogadjaj>();
            CreateMap<Database.Agendum, Model.Agenda>();
            CreateMap<Database.Kategorija, Model.Kategorija>();
            CreateMap<Database.Kriterij, Model.Kriteriji>();
            CreateMap<Database.Rezultat, Model.Rezultati>();

            CreateMap<Database.Tim, Model.Tim>()
            .ForMember(dest => dest.TimId, opt => opt.MapFrom(src => src.TimId))
            .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
            .ForMember(dest => dest.TakmicenjeId, opt => opt.MapFrom(src => src.TakmicenjeId));

            CreateMap<Database.Sponzor, Model.Sponzor>();
            CreateMap<Database.Predavac, Model.Predavac>();
            CreateMap<Database.PredavacDogadjaj, Model.PredavacDogadjaj>();
            CreateMap<Database.AspNetUser, Model.User>();
            CreateMap<Database.AspNetRole, Model.Roles>();
            CreateMap<Database.User, Model.User>();


            CreateMap<TakmicenjeInsertRequest, Database.Takmicenje>();
            CreateMap<TakmicenjeUpdateRequest, Database.Takmicenje>();

            CreateMap<RezultatiInsertRequest, Database.Rezultat>();
            CreateMap<RezultatiUpdateRequest, Database.Rezultat>();

            CreateMap<KategorijaInsertRequest, Database.Kategorija>();
            CreateMap<KategorijaUpdateRequest, Database.Kategorija>();

            CreateMap<KriterijUpsertRequest, Database.Kriterij>();

            CreateMap<PredavacDogadjajUpsertRequest, Database.PredavacDogadjaj>();
            CreateMap<PredavacUpsertRequest, Database.Predavac>();

            CreateMap<SponzorUpsertRequest, Database.Sponzor>();
            CreateMap<DogadjajUpsertRequest, Database.Dogadjaj>();

            CreateMap<ProjekatUpsertRequest, Database.Projekat>();

            CreateMap<Database.Napomena, Model.Napomena>();
            CreateMap<NapomenaUpsertRequest, Database.Napomena>();
            
            CreateMap<TimInsertRequest, Database.Tim>();
            CreateMap<TimUpdateRequest, Database.Tim>();

            CreateMap<UserUpsertRequest, Database.AspNetUser>();
            CreateMap<RolesUpsertRequest, Database.AspNetRole>();

            CreateMap<UserUpsertRequest, Database.User>();

            CreateMap<Dogadjaj, DogadjajiPerAgenda>()
            .ForMember(dest => dest.DogadjajId, opt => opt.MapFrom(src => src.DogadjajId))
            .ForMember(dest => dest.Kraj, opt => opt.MapFrom(src => src.Kraj))
            .ForMember(dest => dest.Pocetak, opt => opt.MapFrom(src => src.Pocetak))
            .ForMember(dest => dest.Lokacija, opt => opt.MapFrom(src => src.Lokacija))
            .ForMember(dest => dest.Trajanje, opt => opt.MapFrom(src => src.Trajanje))
            .ForMember(dest => dest.Napomena, opt => opt.MapFrom(src => src.Napomena))
            .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Napomena))
            .ForMember(dest => dest.AgendaId, opt => opt.Ignore()) 
            .ForMember(dest => dest.TakmicenjeId, opt => opt.Ignore())
            .ForMember(dest => dest.Dan, opt => opt.Ignore());
            CreateMap<Database.Projekat, Model.Projekat>()
             .ForMember(dest => dest.ProjekatId, opt => opt.MapFrom(src => src.ProjekatId))
            .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
            .ForMember(dest => dest.KategorijaId, opt => opt.MapFrom(src => src.KategorijaId))
            .ForMember(dest => dest.Opis, opt => opt.MapFrom(src => src.Opis))
            .ForMember(dest => dest.TimId, opt => opt.MapFrom(src => src.TimId));


            CreateMap<Agenda, DogadjajiPerAgenda>()
                .ForMember(dest => dest.DogadjajId, opt => opt.Ignore())
                .ForMember(dest => dest.Kraj, opt => opt.Ignore())
                .ForMember(dest => dest.Pocetak, opt => opt.Ignore())
                .ForMember(dest => dest.Lokacija, opt => opt.Ignore())
                .ForMember(dest => dest.Trajanje, opt => opt.Ignore())
                .ForMember(dest => dest.Napomena, opt => opt.Ignore())
                .ForMember(dest => dest.Naziv, opt => opt.Ignore())
                .ForMember(dest => dest.AgendaId, opt => opt.MapFrom(src => src.AgendaId))
                .ForMember(dest => dest.Dan, opt => opt.MapFrom(src => src.Dan))
                .ForMember(dest => dest.TakmicenjeId, opt => opt.MapFrom(src => src.TakmicenjeId));


        }
    }
}
