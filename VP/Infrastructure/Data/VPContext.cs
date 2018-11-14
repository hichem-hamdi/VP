using Infrastructure.Models;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public static class VPContext
    {
        public static List<Login> Context = new List<Login>
        {
            new Login{ Email="email1@test.fr", Password="email1"},
            new Login{ Email="email2@test.fr", Password="email2"},
            new Login{ Email="email3@test.fr", Password="email3"},
            new Login{ Email="email4@test.fr", Password="email4"}
        };
    }
}
