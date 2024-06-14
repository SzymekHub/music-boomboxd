using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public enum userType
    {
        Admin,
        Regular,
        Critic,
        Musician
    }

    public enum genreType
    {
        Rock,
        Reggae,
        Metal,
        Rap,
        Blues,
        HipHop,
        Pop,
        ClassicalMusic,
        Disco,
        Folk,
        Country,
        Techno,
    }
}
