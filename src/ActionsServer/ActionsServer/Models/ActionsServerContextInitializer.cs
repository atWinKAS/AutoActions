using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ActionsServer.Models
{
    public class ActionsServerContextInitializer : DropCreateDatabaseAlways<ActionsServerContext>
    {
        protected override void Seed(ActionsServerContext context)
        {
            var letters = new List<Letter> 
            { 
                new Letter { Address = "aa@a.a", Subject="Letter 1", Body="Test letter 1" },
                new Letter { Address = "bb@b.b", Subject="Letter 2", Body="Test letter 2" }
            };

            letters.ForEach(l => context.Letters.Add(l));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}