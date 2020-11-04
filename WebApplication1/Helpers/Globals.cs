using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public static class Globals
        
    {
        public static readonly FirebaseClient Client = new FirebaseClient("https://freshfish-4e41d.firebaseio.com");
    }
}
