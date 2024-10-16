using Microsoft.AspNetCore.Identity;
using Regies.Domain.Constants;
using Regies.Domain.Model;
using Regies.Infrastructure.Persistence;
using System.Reflection.Metadata.Ecma335;

namespace Regies.Infrastructure.Seeders;

internal class RegiesSeeder(RegiesDBContext dbContext) : IRegiesSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Regies.Any())
            {
                var regies = GetRegies();
                dbContext.Regies.AddRange(regies);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    /// <summary>
    /// Generates a list of predefined <see cref="Regie"/> objects.
    /// </summary>
    /// <returns>A list of <see cref="Regie"/> objects with predefined data.</returns>
    public static List<Regie> GetRegies()
    {
        List<Regie> regies = [

            new(){
                Nom = "AgenceImmo",
                Description = "Une Agence Immo",
                estActive = true,
                contactEmail = "contactMoi@email.com",
                contactTelephone = "06.05.05.05.05",
                Adresse = new(){
                    Rue = "Rue de Charleston",
                    numeroRue = "17bis",
                    codePostal = "75-000",
                    Ville = "Paris"
                },
                lesBiensDeLaRegie = [
                    new() {
                        NomAnnonce="MonAnnonce",
                        Decription = "Lalalalere",
                        Adresse = new(){
                                Rue = "Rue de Charleston",
                                numeroRue = "18",
                                codePostal = "75-000",
                                Ville = "Paris"
                            },
                        pourParticulier = true,
                        isLocation = true,
                        prixLocatif = 1500,
                        prixVente = 0
                    }
                    ]

            },
            new(){
                Nom = "RegieDuCoin",
                Description = "Une régie locale",
                estActive = true,
                contactEmail = "contact@regieducoin.com",
                contactTelephone = "07.07.07.07.07",
                Adresse = new(){
                    Rue = "Rue de la République",
                    numeroRue = "10",
                    codePostal = "69-000",
                    Ville = "Lyon"
                },
                lesBiensDeLaRegie = [
                    new() {
                        NomAnnonce="AnnonceLocale",
                        Decription = "Description de l'annonce locale",
                        Adresse = new(){
                                Rue = "Rue de la République",
                                numeroRue = "11",
                                codePostal = "69-000",
                                Ville = "Lyon"
                            },
                        pourParticulier = false,
                        isLocation = false,
                        prixLocatif = 0,
                        prixVente = 300000
                    }
                ]
            },
            new(){
                Nom = "ImmoParis",
                Description = "Agence immobilière à Paris",
                estActive = false,
                contactEmail = "contact@immoparis.com",
                contactTelephone = "08.08.08.08.08",
                Adresse = new(){
                    Rue = "Avenue des Champs-Élysées",
                    numeroRue = "50",
                    codePostal = "75-008",
                    Ville = "Paris"
                },
                lesBiensDeLaRegie = [
                    new() {
                        NomAnnonce="AnnonceParis",
                        Decription = "Description de l'annonce parisienne",
                        Adresse = new(){
                                Rue = "Avenue des Champs-Élysées",
                                numeroRue = "51",
                                codePostal = "75-008",
                                Ville = "Paris"
                            },
                        pourParticulier = true,
                        isLocation = true,
                        prixLocatif = 2000,
                        prixVente = 0
                    }
                ]
            }
            ];

        return regies;
    }

    public static List<IdentityRole> GetRoles()
    {
        return [
            new IdentityRole { Name = UserRoles.s_Admin.Name,   NormalizedName = UserRoles.s_Admin.NormalizedName },
            new IdentityRole { Name = UserRoles.s_Manager.Name, NormalizedName = UserRoles.s_Manager.NormalizedName },
            new IdentityRole { Name = UserRoles.s_User.Name,    NormalizedName = UserRoles.s_User.NormalizedName }
        ];
    }
}
